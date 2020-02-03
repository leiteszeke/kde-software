// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournMatch
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;

namespace TournamentLibrary.Interfaces
{
  public interface ITournMatch : IComparable, IBaseObject
  {
    int AddPlayer(ITournPlayer player);

    ITournPlayerArray Players { get; }

    long Winner { get; set; }

    long Loser { get; }

    TournMatchResult Status { get; set; }

    string StatusText { get; }

    bool Completed { get; }

    int Round { get; set; }

    int Table { get; set; }

    bool PlayoffMatch { get; set; }

    int Points { get; }

    int TotalPoints { get; }

    long GetOpponentId(long playerId);

    void Copy(ITournMatch match);
  }
}
