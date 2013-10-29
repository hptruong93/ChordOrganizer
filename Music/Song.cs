using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace ChordOrganizer.Music {
  public class Song {

    private const string CHORD_BOUND = "$";
    private static readonly string[] DELIMITERS = new string[] { " ", ".", "-", "_" };
    private static readonly string[] VALID_OPEN = new string[] { "(", "[", "<" };
    private static readonly string[] VALID_CLOSE = new string[] { ")", "]", ">" };
    private enum InterpretState {
      EXPECT_OPEN,
      EXPECT_CLOSE,
      EXPECT_WORD,
      EXPECT_SPACE
    };

    public string Title { get; private set; }
    public string[] Content { get; private set; }
    private List<Chord> chordList;

    public Song(string title, string[] content) {
      this.Title = title;
      this.Content = content;
      this.chordList = new List<Chord>();

      this.transcriptSong();
    }

    public void shift(int upOrDown) {
      foreach (Chord chord in this.chordList) {
        chord.shift(upOrDown);
      }
    }

    private void transcriptSong() {
      Boolean valid = false;
      int chordEncountered = -1;

      for (int currentLine = 0; currentLine < this.Content.Length; currentLine++) {
        int startIndex = 0, endIndex = 0;
        int wordCount = 0, chordCount = 0;
        string word = "";

        InterpretState state = InterpretState.EXPECT_WORD;
        Content[currentLine] = Content[currentLine] + " ";

        int i = 0;
        while (i < this.Content[currentLine].Length) {
          char currentChar = Content[currentLine][i];
          if (ignoreableCharacter(currentChar)) {
            i++;
            continue;
          }

          if (state == InterpretState.EXPECT_WORD) {
            if (!isDelimiter(currentChar + "")) {
              if (validOpen(currentChar + "")) {//Valid open, maybe starting a chord
                startIndex = i + 1; //+1 to ignore the valid opening we just checked
                state = InterpretState.EXPECT_CLOSE;
              } else {//Not a valid open --> starting a word
                startIndex = i;
                word += currentChar;
                state = InterpretState.EXPECT_SPACE;
              }
            }
          } else if (state == InterpretState.EXPECT_SPACE) {//Is reading a word, maybe a chord
            if (isDelimiter(currentChar + "")) {
              Chord propose = new Chord(word);
              endIndex = i;
              if (propose.isValid()) {
                chordCount++;
                if (valid) {//replace
                  int oldLength = propose.ToString().Length;
                  this.chordList.Add(propose);
                  chordEncountered++;
                  string replacement = CHORD_BOUND + chordEncountered.ToString() + CHORD_BOUND;

                  this.Content[currentLine] = this.Content[currentLine].Substring(0, startIndex) + replacement + this.Content[currentLine].Substring(endIndex);
                  i += replacement.Length - oldLength;
                }
              }
              wordCount++;
              word = "";
              state = InterpretState.EXPECT_WORD;
            } else {
              word += currentChar;
            }
          } else if (state == InterpretState.EXPECT_CLOSE) {//Is reading probably a chord
            if (validClose(currentChar + "")) {
              Chord propose = new Chord(word);
              endIndex = i;
              if (propose.isValid()) {
                int oldLength = propose.ToString().Length;
                this.chordList.Add(propose);
                chordEncountered++;
                string replacement = CHORD_BOUND + chordEncountered.ToString() + CHORD_BOUND;

                this.Content[currentLine] = this.Content[currentLine].Substring(0, startIndex) + replacement + this.Content[currentLine].Substring(endIndex);
                i += replacement.Length - oldLength;
              }
              word = "";
              state = InterpretState.EXPECT_WORD;
            } else {//Still in middle of the word/chord
              word += currentChar;
            }
          }
          i++;
        }

        Content[currentLine] = Content[currentLine].Remove(Content[currentLine].Length - 1);
        if (!valid) {
          if ((wordCount == chordCount) && (wordCount != 0)) {
            valid = true;
            currentLine--;
          }
        } else {
          valid = false;
        }
      }
    }

    public void displaySong(System.Windows.Forms.RichTextBox output, Color lyricsColor, Color chordColor) {
      output.Enabled = false;
      output.Text = "";

      output.ForeColor = lyricsColor;

      InterpretState state = InterpretState.EXPECT_OPEN;
      foreach (string item in this.Content) {
        string toAppend = item + "";
        toAppend.Trim('\r');
        string number = "";
        int startIndex = 0, i = 0;
        while (i < toAppend.Length) {
          if (state == InterpretState.EXPECT_OPEN) {
            if (CHORD_BOUND.Equals(toAppend[i] + "")) {
              state = InterpretState.EXPECT_CLOSE;
              startIndex = i;
            }
          } else if (state == InterpretState.EXPECT_CLOSE) {
            if (CHORD_BOUND.Equals(toAppend[i] + "")) {
              state = InterpretState.EXPECT_OPEN;
              string replace = chordList[Convert.ToInt16(number)].ToString();

              insertWithColor(output, toAppend.Substring(0, startIndex), lyricsColor);
              insertWithColor(output, replace, chordColor);

              toAppend = toAppend.Substring(i + 1);
              i = 0;
              number = "";
            } else {//Replace with the chord
              number += toAppend[i];
            }
          }
          i++;
        }

        if (!toAppend.EndsWith("\n")) {
          toAppend = toAppend + "\n";
        }
        insertWithColor(output, toAppend, lyricsColor);
      }
      output.Enabled = true;
    }

    private static void insertWithColor(System.Windows.Forms.RichTextBox output, string text, Color color) {
      output.SelectionStart = output.TextLength;
      output.SelectionLength = 0;
      output.SelectionColor = color;
      output.AppendText(text);
      output.SelectionColor = output.ForeColor;
    }

    public async void modifyOnline(ParseObject item) {
      item[SongTableOnline.COLUMN_LYRICS] = this.toString();
      item[SongTableOnline.COLUMN_TITLE] = this.Title;

      await item.SaveAsync();
    }

    public async void upLoad() {
      ParseObject upLoading = new ParseObject(Music.SongTableOnline.SONG_TABLE_NAME);
      upLoading[Music.SongTableOnline.COLUMN_TITLE] = this.Title;
      upLoading[Music.SongTableOnline.COLUMN_LYRICS] = this.toString();
      upLoading[Music.SongTableOnline.COLUMN_LANGUAGE] = "Vietnamese";

      await upLoading.SaveAsync();
    }

    public void saveLocal(string path) {
      try {
        System.IO.File.WriteAllText(path + this.Title + ".txt", this.toString());
      } catch (System.IO.IOException e) {
        System.Windows.Forms.MessageBox.Show("Cannot write to local directory. " + e.ToString());
      }
    }

    public string toString() {
      StringBuilder builder = new StringBuilder();
      InterpretState state = InterpretState.EXPECT_OPEN;
      foreach (string item in this.Content) {
        string toAppend = item + "";
        string number = "";
        int startIndex = 0, i = 0;
        while (i < toAppend.Length) {
          if (state == InterpretState.EXPECT_OPEN) {
            if (CHORD_BOUND.Equals(toAppend[i] + "")) {
              state = InterpretState.EXPECT_CLOSE;
              startIndex = i;
            }
          } else if (state == InterpretState.EXPECT_CLOSE) {
            if (CHORD_BOUND.Equals(toAppend[i] + "")) {
              state = InterpretState.EXPECT_OPEN;
              string replace = chordList[Convert.ToInt16(number)].ToString();
              builder.Append(toAppend.Substring(0,startIndex));
              builder.Append(replace);
              toAppend = toAppend.Substring(i + 1);
              i = 0;
              number = "";
            } else {//Replace with the chord
              number += toAppend[i];
            }
          }
          i++;
        }

        builder.Append(toAppend);
        if (!toAppend.EndsWith("\n")) {
          builder.Append("\n");   
        }
      }
      return builder.ToString();
    }

    private static Boolean validOpen(string opening) {
      foreach (string item in VALID_OPEN) {
        if (opening.Equals(item)) {
          return true;
        }
      }
      return false;
    }

    private static Boolean validClose(string close) {
      foreach (string item in VALID_CLOSE) {
        if (close.Equals(item)) {
          return true;
        }
      }
      return false;
    }

    private static Boolean ignoreableCharacter(char input) {
      Boolean invalid;
      invalid = (input < 32) || (input > 127);
      return invalid;
    }

    private static Boolean isDelimiter(string input) {
      foreach (string element in DELIMITERS) {
        if (input.Equals(element)) return true;
      }
      return false;
    }

    public static int songComparison(Song song1, Song song2) {
      return String.Compare(song1.Title, song2.Title);
    }
}
}
