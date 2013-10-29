using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ChordOrganizer.Music {
  class SongTableOffline : SongDatabase {

    private List<Song> tableContent;
    public string Path { get; private set; }

    public SongTableOffline(IEnumerable<Song> contents) {
      this.tableContent = new List<Song>();
      this.tableContent.AddRange(contents);
      this.tableContent.Sort(Song.songComparison);
    }

    public SongTableOffline(string path) {
      this.Path = path;
      this.tableContent = new List<Song>();

      try {
        foreach (string file in Directory.EnumerateFiles(path, "*.txt")) {
          string[] contents = File.ReadAllLines(file);
          try {
            tableContent.Add(new Song(file.Remove(file.Length - 4).Substring(path.Length), contents));
            Console.Write(file.Substring(path.Length));
          } catch (Exception e) {//Ignore file
          }
        }
      } catch (System.IO.IOException e) {
        MessageBox.Show("Error reading database directory. " + e.ToString());
      }
    }

    public string[] getSongNames() {
      string[] output = new string[tableContent.Count];

      int i = 0;
      foreach (Song element in tableContent) {
        output[i] = element.Title;
        i++;
      }
      return output;
    }

    public Song getSong(string title) {
      foreach (Song element in tableContent) {
        if (element.Title.Equals(title)) {
          return element;
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

    //Return the song
    public Object findSong(string title) {
      List<Song> output = new List<Song>();
      foreach (Song element in tableContent) {
        if (element.Title.Contains(title)) {
          output.Add(element);
        }
      }
      return output;
    }

    public void deleteSong(string title) {
      try {
        System.IO.File.Delete(Path + title + ".txt");
      } catch (System.IO.IOException e) {

      }
    }

    public string getSongContent(string title) {
      string output = null;

      foreach (Song element in tableContent) {
        if (element.Title.Equals(title)) {
          output = element.toString();
          return output;
        }
      }

      return output;
    }
  }
}
