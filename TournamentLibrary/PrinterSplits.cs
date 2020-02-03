// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.PrinterSplits
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

namespace TournamentLibrary
{
  public class PrinterSplits
  {
    public string FirstChar = string.Empty;
    public string LastChar = string.Empty;
    public int Counts;
    public int GroupID;

    public PrinterSplits()
    {
    }

    public PrinterSplits(int id, string firstChar, string lastChar)
    {
      this.GroupID = id;
      this.FirstChar = firstChar;
      this.LastChar = lastChar;
    }
  }
}
