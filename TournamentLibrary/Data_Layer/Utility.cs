// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.Utility
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Windows.Forms;

namespace TournamentLibrary.Data_Layer
{
  public class Utility
  {
    private static char[] LETTERS_LCASE = new char[26]
    {
      'a',
      'b',
      'c',
      'd',
      'e',
      'f',
      'g',
      'h',
      'i',
      'j',
      'k',
      'l',
      'm',
      'n',
      'o',
      'p',
      'q',
      'r',
      's',
      't',
      'u',
      'v',
      'w',
      'x',
      'y',
      'z'
    };
    private static char[] LETTERS_UCASE = new char[26]
    {
      'A',
      'B',
      'C',
      'D',
      'E',
      'F',
      'G',
      'H',
      'I',
      'J',
      'K',
      'L',
      'M',
      'N',
      'O',
      'P',
      'Q',
      'R',
      'S',
      'T',
      'U',
      'V',
      'W',
      'X',
      'Y',
      'Z'
    };
    private static Random rand = new Random();

    public static string RandomString(int length)
    {
      if (length < 1)
        return string.Empty;
      char[] chArray = new char[length];
      chArray[0] = Utility.RandomLetter(true);
      for (int index = 1; index < length; ++index)
        chArray[index] = Utility.RandomLetter(false);
      return new string(chArray);
    }

    public static bool IsPrintableCharacter(Keys key)
    {
      return key >= Keys.A && key <= Keys.Z || key >= Keys.D0 && key <= Keys.D9 || (key >= Keys.NumPad0 && key <= Keys.NumPad9 || (key == Keys.Decimal || key == Keys.Divide)) || (key == Keys.Multiply || key == Keys.Subtract || (key == Keys.OemBackslash || key == Keys.OemCloseBrackets) || (key == Keys.Oemcomma || key == Keys.OemMinus || (key == Keys.OemMinus || key == Keys.OemOpenBrackets))) || (key == Keys.OemPeriod || key == Keys.OemPipe || (key == Keys.Oemplus || key == Keys.OemQuestion) || (key == Keys.OemQuotes || key == Keys.OemSemicolon || (key == Keys.Oemtilde || key == Keys.Space)));
    }

    public static string MakeDisplayCOSSY(long i)
    {
      return string.Format("{0:0000000000}", (object) i);
    }

    private static char RandomLetter(bool UpperCase)
    {
      return UpperCase ? Utility.LETTERS_UCASE[Utility.rand.Next(Utility.LETTERS_UCASE.Length)] : Utility.LETTERS_LCASE[Utility.rand.Next(Utility.LETTERS_LCASE.Length)];
    }
  }
}
