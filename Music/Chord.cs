using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordOrganizer.Music {
  public class Chord {
    private static readonly string[] CHORDS = new string[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    private static readonly string[] CHORDS_ALTERNATIVE = new string[] { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
    private static readonly char[] INVALID_CHARS = new char[] { ':', ';', '?', '!', '@', 
      'c', 'e', 'f', 'h', 'j', 'k', 'l', 'p', 'q', 'r', 't', 'w', 'v', 'x', 'y', 'z',
      'H', 'J', 'K', 'L', 'P', 'Q', 'R', 'T', 'W', 'V', 'X', 'Y', 'Z'};
    private const string INVALID_CHORD = "";

    

    public const int UP = 1;
    public const int DOWN = -1;


    protected int index { get; private set; }

    //Main Chord is one of the element in CHORDS
    //E.g. A, C, D#
    public string mainChord {
      get {
        return CHORDS[index];
      }
    }

    //Post fix represents variations of main chord (aug, dim, sus...)
    //E.g: Am, F#7, Gsus2
    public string postFix { get; private set; }
    public string bass { get; private set; }
    public int bassIndex { get; private set; }

    public Chord(string chord) {
      this.postFix = getPostFix(chord);
      this.bass = getBass(chord);

      this.index = getIndex(getMainChord(chord));
      this.bassIndex = getIndex(bass);
    }

    public Boolean isValid() {
      return (this.index >= 0) && (!containsInvalidChar());
    }

    public void sharp() {
      shift(UP);
    }

    public void flat() {
      shift(DOWN);
    }

    public void shift(int upOrDown) {
      if ((upOrDown != UP) && (upOrDown != DOWN)) {
        throw new ArgumentException("Invalid number");
      }

      this.index = (this.index + CHORDS.Length + upOrDown) % CHORDS.Length;

      if (bassIndex >= 0) {
        bassIndex = (bassIndex + CHORDS.Length + upOrDown) % CHORDS.Length;
      }
    }

    private bool containsInvalidChar() {
      string fullChord = this.ToString();
      foreach (char current in fullChord) {
        foreach (char element in INVALID_CHARS) {
          if (current == element) {
            return true;
          }
        }
      }
      return false;
    }

    public override string ToString() {
      if (!bass.Equals("")) {
        return mainChord + postFix + "/" + bass;
      }
      else {
        return mainChord + postFix;
      }
    }

    private static string getMainChord(string chord) {
      if (chord.Equals("")) {
        return INVALID_CHORD;
      }
      else {
        string output = chord[0] + "";
        if (chord.Length > 1) {
          if ((chord[1] == '#') || (chord[1] == 'b')) {
            output += chord[1];
          }
        }
        return output;
      }
    }

    private static string getPostFix(string chord) {
      int index = getMainChord(chord).Length;
      string output = "";
      while (index < chord.Length) {
        if ((chord[index] == '/') || (chord[index] == '\\')) {
          break;
        }
        output += chord[index];
        index++;
      }
      return output;
    }

    private static string getBass(string chord) {
      int index = 0;
      string output = "";
      Boolean adding = false;
      while (index < chord.Length) {
        if ((chord[index] == '/') || (chord[index] == '\\')) {
          adding = !adding;
        }
        else if (adding) {
          output += chord[index];
        }
        index++;
      }
      return output;
    }

    private static int getIndex(string mainChord) {
      if ((mainChord == null) || (mainChord.Equals(""))) {
        return -1;
      }
      for (int i = 0; i < CHORDS.Length; i++) {
        if (CHORDS[i].Equals(mainChord)) {
          return i;
        }
      }

      for (int i = 0; i < CHORDS_ALTERNATIVE.Length; i++) {
        if (CHORDS_ALTERNATIVE[i].Equals(mainChord)) {
          return i;
        }
      }

      return -2;
      //Can also throw exception invalid mainChord here;
    }
  }
}
