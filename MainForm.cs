using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Parse;
using System.Globalization;


namespace ChordOrganizer {
  public partial class MainForm : Form {

    private const string APPLICATION_ID = "qJH1b6RfsLIDDfxz7SGC0u6YlIKLqPNxGy92UxXB";
    private const string KEY = "kkDbIaJfrXoaEVL8pubuvSskwDwvDx6deyLkt1T8";

    private string LOAD_LOCATION = "D:\\Study\\IT\\IDE\\eclipse\\Workspace\\MusicOrganizer\\src\\Songs\\";

    private const int MAX_QUERY_ITEM = 500; //Between 1 and 1000

    private enum OPERATION_MODE { ONLINE, OFFLINE };
    private OPERATION_MODE operationMode;

    private Music.SongDatabase songTable;
    private Music.Song song;

    public MainForm() {
      InitializeComponent();

      // Initialize the Parse client with your Application ID and .NET Key found on
      // your Parse dashboard
      ParseClient.Initialize(APPLICATION_ID, KEY);

      lDirectory.Text = "Local database: " + LOAD_LOCATION;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      switch (keyData) {
        case HotKeys.CHANGE_DIR:
          changeDir();
          break;
        case HotKeys.EXIT:
          Application.Exit();
          break;
        case HotKeys.TOGGLE_MODE:
          if (operationMode == OPERATION_MODE.OFFLINE) {
            toggleOnlineOffline(OPERATION_MODE.ONLINE);
          } else if (operationMode == OPERATION_MODE.ONLINE) {
            toggleOnlineOffline(OPERATION_MODE.OFFLINE);
          }
          break;
        case HotKeys.DELETE:
          bDeleteClick();
          break;
        case HotKeys.SEARCH:
          tbSearch.Focus();
          break;
        case HotKeys.PREVIEW:
          bPreviewClick();
          break;
        case HotKeys.ADD_MODIFY:
          bUploadClick();
          break;
        case HotKeys.UPLOAD_ALL:
          bUploadAllClick();
          break;
        case HotKeys.SYNC:
          bSyncRefreshClick();
          break;
        case HotKeys.SHARP:
          bSharpClick();
          break;
        case HotKeys.FLAT:
          bFlatClick();
          break;
        case HotKeys.CHANGE_FONT:
          bChangeFontClick();
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private async void sync() {
      if (operationMode == OPERATION_MODE.ONLINE) {
        ParseQuery<ParseObject> query = ParseObject.GetQuery("Song");
        List<ParseObject> result = new List<ParseObject>();
        int total = await query.CountAsync();
        int skip = 0;
        while (skip < total) {
          query = ParseObject.GetQuery("Song").Limit(MAX_QUERY_ITEM).Skip(skip);

          var output = await query.FindAsync();
          result.AddRange(output);

          skip += MAX_QUERY_ITEM;
        }
        songTable = new Music.SongTableOnline(result);

        try {
          foreach (string name in songTable.getSongNames()) {
            System.IO.File.WriteAllText(LOAD_LOCATION + name + ".txt", songTable.getSongContent(name));
          }
        } catch (System.IO.IOException e) {
          MessageBox.Show("Error writing to local database. " + e.ToString());
        }
      } else if (operationMode == OPERATION_MODE.OFFLINE) {
        songTable = new Music.SongTableOffline(LOAD_LOCATION);
      }
      clearSongList();
      addSongName(songTable.getSongNames());
    }

    private async void addSong(Music.Song song) {
      if (songTable != null) {
        if (operationMode == OPERATION_MODE.ONLINE) {
          try {
            IEnumerable<ParseObject> findSong = await ((ParseQuery<ParseObject>)songTable.findSong(song.Title)).FindAsync();
            foreach (ParseObject item in findSong) {
              if (item.Get<string>(Music.SongTableOnline.COLUMN_TITLE).ToLower().Equals(song.Title.ToLower())) {
                song.modifyOnline(item);
                return;
              }
            }
            song.upLoad();
          } catch (Exception e) {
            MessageBox.Show(e.ToString());
          }
        } else if (operationMode == OPERATION_MODE.OFFLINE) {
          song.saveLocal(LOAD_LOCATION);
        }
      }
    }

    private void clearSongList() {
      lbSongs.Items.Clear();
      tbContent.Text = "";
      updateSongNumber();
    }

    private void addSongName(string[] names) {
      foreach (string name in names) {
        lbSongs.Items.Add(name);
      }
      updateSongNumber();
    }

    private void updateSongNumber() {
      int count = lbSongs.Items.Count;
      if (count != 1) {
        lNumberSongs.Text = count.ToString() + " songs";
      } else {
        lNumberSongs.Text = count.ToString() + " song";
      }
    }

    private void uploadSongs(string directory) {
      DirectoryInfo dir = new DirectoryInfo(directory);
      FileInfo[] files = dir.GetFiles("*.txt");
      foreach (FileInfo file in files) {
        string title = file.Name.ToString();
        title = title.Remove(title.Length - 4);

        string[] contents = File.ReadAllLines(directory + file.Name.ToString());
        Music.Song toBeUploaded = new Music.Song(title, contents);
        addSong(toBeUploaded);
      }
      showSyncRequest();
    }

    private void showSyncRequest() {
      if (songTable != null) {
        MessageBox.Show("Changes are made. Please Sync!");
      } else {
        MessageBox.Show("Please Sync first!");
      }
    }

    private void deleteSong(string title) {
      if (songTable != null) {
        songTable.deleteSong(title);
      } else {
        showSyncRequest();
      }
    }

    private string[] filterSongs(string keyWord) {
      if (songTable != null) {
        return songTable.filterSongs(keyWord);
      }
      return new string[] { };
    }

    private Music.Song selectedSongChanged(string newTitle) {
      if (newTitle != null) {
        return songTable.getSong(newTitle);
      } else {
        return null;
      }
    }

    /****************************** Events Handling **********************************************************/
    private void bUploadAllClick() {
      uploadSongs(LOAD_LOCATION);
    }

    private void bSyncRefreshClick() {
      sync();
    }

    private void bDeleteClick() {
      deleteSong(lbSongs.SelectedItem.ToString());
    }

    private void bUploadClick() {
      if (tbTitle.Text.Equals("")) {
        MessageBox.Show("Please provide song title");
        return;
      }
      string[] content = tbContent.Text.Split('\n');

      song = new Music.Song(tbTitle.Text, content);
      addSong(song);
      showSyncRequest();
    }

    private void bSharpClick() {
      if (song != null) {
        song.shift(Music.Chord.UP);
        song.displaySong(tbContent, Color.Black, Color.Violet);
      }
    }

    private void bFlatClick() {
      if (song != null) {
        song.shift(Music.Chord.DOWN);
        song.displaySong(tbContent, Color.Black, Color.Violet);
      }
    }

    private void bPreviewClick() {
      song = new Music.Song(tbTitle.Text, tbContent.Text.Split('\n'));
      song.displaySong(tbContent, Color.Black, Color.Violet);
    }

    private void bChangeFontClick() {
      FontDialog fd = new FontDialog();
      if (fd.ShowDialog() == DialogResult.OK) {
        tbContent.Font = fd.Font;
        song.displaySong(tbContent, Color.Black, Color.Violet);
      }
    }

    private void toggleOnlineOffline(OPERATION_MODE newMode) {
      operationMode = newMode;

      if (operationMode == OPERATION_MODE.ONLINE) {
        miOffline.Checked = false;
        miOnline.Checked = true;
        bSyncRefresh.Text = "Sync";
        bUploadAll.Enabled = true;
      } else if (operationMode == OPERATION_MODE.OFFLINE) {
        miOnline.Checked = false;
        miOffline.Checked = true;
        bSyncRefresh.Text = "Refresh";
        bUploadAll.Enabled = false;
      }
      sync();
    }

    private void changeDir() {
      var dir = new System.Windows.Forms.FolderBrowserDialog();
      System.Windows.Forms.DialogResult result = dir.ShowDialog();
      if (result == System.Windows.Forms.DialogResult.OK) {
        LOAD_LOCATION = dir.SelectedPath + "\\";
      }
      lDirectory.Text = "Database directory: " + LOAD_LOCATION;
    }

    /****************************** Events *******************************************************************/
    private void bUploadAll_Click(object sender, EventArgs e) {
      bUploadAllClick();
    }

    private void bSyncRefresh_Click(object sender, EventArgs e) {
      bSyncRefreshClick();
    }

    private void bDelete_Click(object sender, EventArgs e) {
      bDeleteClick();
    }

    private void bUpload_Click(object sender, EventArgs e) {
      bUploadClick();
    }

    private void bSharp_Click(object sender, EventArgs e) {
      bSharpClick();
    }

    private void bFlat_Click(object sender, EventArgs e) {
      bFlatClick();
    }

    private void tbSearch_TextChanged(object sender, EventArgs e) {
      clearSongList();
      addSongName(filterSongs(tbSearch.Text));
    }

    private void lbSongs_SelectedIndexChanged(object sender, EventArgs e) {
      if (lbSongs.Items.Count != 0) {
        if (lbSongs.SelectedItem != null) {
          song = selectedSongChanged(lbSongs.SelectedItem.ToString());
          song.displaySong(tbContent, Color.Black, Color.Violet);
          tbTitle.Text = lbSongs.SelectedItem.ToString();
        }
      }
    }

    private void changeDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
      changeDir();
    }

    private void miExit_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void miOnline_Click(object sender, EventArgs e) {
      toggleOnlineOffline(OPERATION_MODE.ONLINE);
    }

    private void miOffline_Click(object sender, EventArgs e) {
      toggleOnlineOffline(OPERATION_MODE.OFFLINE);
    }

    private void bPreview_Click(object sender, EventArgs e) {
      bPreviewClick();
    }

    private void bChangeFont_Click(object sender, EventArgs e) {
      bChangeFontClick();
    }

    private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e) {
      HotKeys.showHotKeys();
    }

    private void bTest_Click(object sender, EventArgs e) {
      System.IO.StreamReader reader = new System.IO.StreamReader("D:\\ChordLib.txt");
      string path = "D:\\temp\\";
      string previousLine = "", previousTwo = "";
      System.IO.StreamWriter writer = null;

      while (!reader.EndOfStream) {
        string line = reader.ReadLine();

        if (line.Contains("# b ______")) {
          if (writer != null) {
            try {
              writer.Close();
            } catch (System.IO.IOException ee) {
              MessageBox.Show(e.ToString());
            }
          }
          //System.IO.File.Create(path + RemoveDiacritics(previousTwo) );
          writer = new System.IO.StreamWriter(path + RemoveDiacritics(previousTwo) + ".txt");
        }

        if (writer != null) {
          writer.WriteLine(previousTwo);
        }
        previousTwo = previousLine;
        previousLine = line;
      }
      if (writer != null) {
        try {
          writer.Close();
        } catch (System.IO.IOException ee) {
          MessageBox.Show(e.ToString());
        }
      }
      reader.Close();

    }

    private static string RemoveDiacritics(string stIn) {
      string stFormD = stIn.Normalize(NormalizationForm.FormD);
      StringBuilder sb = new StringBuilder();

      for (int ich = 0; ich < stFormD.Length; ich++) {
        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
        if (uc != UnicodeCategory.NonSpacingMark) {
          char toBeAppend = stFormD[ich];
          if (toBeAppend == 'Đ') {
            toBeAppend = 'D';
          } else if (toBeAppend == 'đ') {
            toBeAppend = 'd';
          }

          sb.Append(toBeAppend);
        }
      }

      return (sb.ToString().Normalize(NormalizationForm.FormC));
    }
  }
}
