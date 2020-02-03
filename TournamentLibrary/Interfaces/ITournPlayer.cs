// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournPlayer
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;

namespace TournamentLibrary.Interfaces
{
  public interface ITournPlayer : IPlayer, IComparable, IBaseObject
  {
    CutType DropReason { get; set; }

    int DropRound { get; set; }

    bool IsActive { get; }

    int Rank { get; set; }

    int PlayoffPoints { get; set; }

    int Points { get; }

    int Tie1_Wins { get; set; }

    int Tie2_Points { get; set; }

    int OpenDuelingPoints { get; set; }

    int MatchCount { get; set; }

    void ClearTies();

    int CompareRank(ITournPlayer other);

    int AssignedSeat { get; set; }

    string Notes { get; set; }
  }
}
