using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace ChordOrganizer.Music
{
  class SongTableOnline : SongDatabase
  {
    private List<ParseObject> tableContent;

    public const string SONG_TABLE_NAME = "Song";

    //Columns
    public const string COLUMN_TITLE = "Name";
    public const string COLUMN_LYRICS = "Lyrics";
    public const string COLUMN_LANGUAGE = "Language";

    public SongTableOnline(IEnumerable<ParseObject> contents) {
      this.tableContent = new List<ParseObject>();
      this.tableContent.AddRange(contents);
      this.tableContent.Sort(songComparison);
    }

    public string[] getSongNames() {
      string[] output = new string[tableContent.Count];

      int i = 0;
      foreach (ParseObject element in tableContent) {
        output[i] = element.Get<string>(COLUMN_TITLE);
        i++;
      }
      return output;
    }

    public Song getSong(string title) {
      foreach (ParseObject element in tableContent) {
        if (element.Get<string>(COLUMN_TITLE).Equals(title)) {
          return new Song(element.Get<string>(COLUMN_TITLE), element.Get<string>(COLUMN_LYRICS).Split('\n'));
        }
      }
      return null;
    }

    public string[] filterSongs(string keyWord) {
      string[] listAll = getSongNames();
      if (keyWord.Equals("")) {
        return listAll;
      } else {
        List<string> output = new List<string>();
        keyWord = keyWord.ToLower();
        foreach (string element in listAll) {
          if (element.ToLower().Contains(keyWord)) {
            output.Add(element);
          }
        }
        return output.ToArray();
      }
    }

    public Object findSong(string title) {
      string searchTitle = title.Remove(Math.Min(8, title.Length - 1));
      return from song in ParseObject.GetQuery(SONG_TABLE_NAME)
             where song.Get<string>(COLUMN_TITLE).Contains(title)
             select song;
    }

    public async void deleteSong(string title) {
      var query = from song in ParseObject.GetQuery(SONG_TABLE_NAME)
                  where song.Get<string>(COLUMN_TITLE).Equals(title)
                  select song;
      IEnumerable<ParseObject> deleteSong = await query.FindAsync();
      if (deleteSong.Count() > 0) {
        foreach (var item in deleteSong) {
          await item.DeleteAsync();
          return;
        }
      }
    }

    public string getSongContent(string title) {
      string output = null;

      foreach (ParseObject song in tableContent) {
        if (song.Get<string>(COLUMN_TITLE).Equals(title)) {
          output = song.Get<string>(COLUMN_LYRICS);
          return output;
        }
      }

      return output;
    }

    private static int songComparison(ParseObject song1, ParseObject song2) {
      return String.Compare(song1.Get<string>(COLUMN_TITLE), song2.Get<string>(COLUMN_TITLE));
    }
  }
}