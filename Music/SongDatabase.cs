using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordOrganizer.Music {
  interface SongDatabase {
    string[] getSongNames();
    Song getSong(string title);
    string[] filterSongs(string keyWord);
    Object findSong(string title);
    void deleteSong(string title);
    string getSongContent(string title);
  }
}
