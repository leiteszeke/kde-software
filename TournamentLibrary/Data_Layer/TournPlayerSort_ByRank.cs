﻿// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournPlayerSort_ByRank
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  internal class TournPlayerSort_ByRank : IComparer<ITournPlayer>
  {
    public int Compare(ITournPlayer x, ITournPlayer y)
    {
      if (y.OpenDuelingPoints.CompareTo(x.OpenDuelingPoints) != 0)
        return y.OpenDuelingPoints.CompareTo(x.OpenDuelingPoints);
      if (y.PlayoffPoints.CompareTo(x.PlayoffPoints) != 0)
        return y.PlayoffPoints.CompareTo(x.PlayoffPoints);
      return y.Tie1_Wins.CompareTo(x.Tie1_Wins) != 0 ? y.Tie1_Wins.CompareTo(x.Tie1_Wins) : y.Tie2_Points.CompareTo(x.Tie2_Points);
    }
  }
}
