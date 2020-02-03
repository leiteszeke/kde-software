// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.PrinterSplitList
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;

namespace TournamentLibrary
{
  public class PrinterSplitList : Dictionary<int, PrinterSplits>
  {
    public int SplitCount;

    public bool IsInGroup(string lastname, int group)
    {
      if (group >= this.SplitCount || lastname == null)
        return false;
      string str = lastname.ToUpper().Substring(0, 1);
      if (group == 0)
        return str.CompareTo(this[group].LastChar) <= 0;
      if (group == this.SplitCount - 1)
        return str.CompareTo(this[group].FirstChar) >= 0;
      return str.CompareTo(this[group].LastChar) <= 0 && str.CompareTo(this[group].FirstChar) >= 0;
    }
  }
}
