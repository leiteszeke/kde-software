// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournament
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.Data;

namespace TournamentLibrary.Interfaces
{
  public interface ITournament : IBaseObject, IComparable<ITournament>
  {
    DateTime Date { get; set; }

    string ID { get; set; }

    ILocation Location { get; set; }

    int CurrentRound { get; set; }

    int TableOffset { get; set; }

    ITournStaffArray Staff { get; set; }

    ITournMatchArray Matches { get; set; }

    ITournPlayerArray ActivePlayers { get; }

    ITournPlayerArray Players { get; set; }

    string Name { get; set; }

    TournamentStyle Format { get; set; }

    TournamentPairingStructure PairingStructure { get; set; }

    EventType TournamentType { get; set; }

    bool IsPlayoffs { get; }

    int PlayoffRound { get; set; }

    bool HavePlayed(ITournPlayerArray players, int maxRound);

    bool PairNextRound();

    bool SubmitResult(int Table, TournMatchResult Result, long Winner);

    bool SubmitResult(ITournMatch Match, TournMatchResult Result, long Winner);

    ITournMatch GetMatch(int Round, int Table);

    ITournMatch GetMatch(int Table);

    ITournMatch HasRepeatMatchup(int Round);

    void CalculateTies();

    void CalculateTies(int RoundCap);

    void ClearTies();

    int TiebreakerRoundCalculated { get; }

    void CutPlayers(int CutSize, CutType CutReason);

    bool EnrollPlayer(IPlayer player);

    void CopySettings(ITournament source, bool includeID);

    DataTable GetStandings(int round, bool includeDrops);

    string Filename { get; }

    string FilenameWithRound { get; }

    int AddMissingMatches(ITournPlayer player);

    int AddMatch(ITournMatch match);

    PrinterSplitList PrinterSplits { get; set; }

    List<IPenalty> Penalties { get; set; }

    void ChangePlayerId(long oldPlayerId, long newPlayerId);

    void ExportMatchesToCSV(string filePath);

    void ExportPlayersToCSV(string filePath);

    bool Finalized { get; set; }

    void CreateSeatAllPlayers();
  }
}
