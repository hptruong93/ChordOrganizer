using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordOrganizer {
  public class HotKeys {
    public const Keys CHANGE_DIR = Keys.Control | Keys.O;
    public const Keys EXIT = Keys.Alt | Keys.X;

    public const Keys TOGGLE_MODE = Keys.Control | Keys.Tab;

    public const Keys DELETE = Keys.Control | Keys.D;
    public const Keys SEARCH = Keys.Control | Keys.F;
    public const Keys PREVIEW = Keys.Control | Keys.E;
    public const Keys ADD_MODIFY = Keys.Control | Keys.Q;

    public const Keys UPLOAD_ALL = Keys.Control | Keys.S;
    public const Keys SYNC = Keys.F5;

    public const Keys SHARP = Keys.Control | Keys.D3;
    public const Keys FLAT = Keys.Control | Keys.D2;

    public const Keys CHANGE_FONT = Keys.Alt | Keys.F;

    public static void showHotKeys() {
      MessageBox.Show(
        "CHANGE_DIR = Ctrl + O\n" +
        "EXIT = Alt + X\n" +
        "TOGGLE_MODE = Ctrl + Tab\n" +
        "DELETE = Ctrl + D\n" +
        "SEARCH = Ctrl + F\n" +
        "PREVIEW = Ctrl + E\n" +
        "ADD_MODIFY = Ctrl + Q\n" +
        "UPLOAD_ALL = Ctrl + S\n" +
        "SYNC = Keys.F5\n" +
        "SHARP = Ctrl + 3\n" +
        "FLAT = Ctrl + 2\n" +
        "CHANGE_FONT = Alt + F");
    }
  }
}
