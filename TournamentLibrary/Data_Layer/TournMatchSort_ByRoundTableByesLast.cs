// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournMatchSort_ByRoundTableByesLast
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  internal class TournMatchSort_ByRoundTableByesLast : IComparer<ITournMatch>
  {
    public int Compare(ITournMatch x, ITournMatch y)
    {
      bool flag1 = y.Players.HasPlayer(Player.BYE_ID);
      bool flag2 = x.Players.HasPlayer(Player.BYE_ID);
      if (flag1 && flag2)
        return x.CompareTo((object) y);
      if (flag2)
        return 1;
      return flag1 ? -1 : x.CompareTo((object) y);
    }
  }
}
