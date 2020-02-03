// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.Tournament
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class Tournament : ITournament, IBaseObject, IComparable<ITournament>
  {
    private DateTime _date = DateTime.Now;
    private EventType _tournamentType = EventType.Local;
    private ILocation _location = (ILocation) new TournamentLibrary.Data_Layer.Location();
    private int _tiebreakerRoundCalculated = -1;
    private ITournMatchArray _matches = (ITournMatchArray) new TournMatchArray();
    private ITournStaffArray _staff = (ITournStaffArray) new TournStaffArray();
    private List<IPenalty> _penalties = new List<IPenalty>();
    private PrinterSplitList _printerSplits = new PrinterSplitList();
    private string _id = Tournament.GenerateRandomTournamentId();
    private string _name = string.Empty;
    private string _xmlElementName = nameof (Tournament);
    private TournamentPairingStructure _structure = TournamentPairingStructure.Swiss;
    private TournamentStyle _format = TournamentStyle.ConstructedAdvanced;
    private ITournPlayerArray _players = (ITournPlayerArray) new TournPlayerArray();
    public const string STANDINGS_COLUMN_PLAYER = "Player";
    public const string STANDINGS_COLUMN_RANK = "Rank";
    public const string STANDINGS_COLUMN_TIE_POINTS = "Ties";
    public const string STANDINGS_COLUMN_WINS = "Points";
    public const string TOURN_ID_REGEX = "(?<EventNumber>^[a-zA-Z]\\d{2}-\\d{6}$)";
    private const string XmlKeyCurrentRound = "CurrentRound";
    private const string XmlKeyDateTime = "Date";
    private const string XmlKeyReferenceDateTime = "ReferenceDateTime";
    private const string XmlKeyEventType = "EventTypeCode";
    private const string XmlKeyFinalized = "Finalized";
    private const string XmlKeyFormat = "Format";
    private const string XmlKeyHeadJudge = "HeadJudge";
    private const string XmlKeyID = "ID";
    private const string XmlKeyJudges = "Judges";
    private const string XmlKeyName = "Name";
    private const string XmlKeyOrganizer = "Organizer";
    private const string XmlKeyPenaltyList = "PenaltyList";
    private const string XmlKeyPlayoffRound = "PlayoffRound";
    private const string XmlKeyScoreKeeper = "ScoreKeeper";
    private const string XmlKeySoftwareVersion = "SoftwareVersion";
    private const string XmlKeyStaff = "Staff";
    private const string XmlKeyStructure = "Structure";
    private const string XmlKeyStructureId = "StructureCode";
    private const string XmlKeyTableOffset = "TableOffset";
    private const string XmlKeyTournStyle = "TournamentStyleCode";
    private const string XMLOUT_DATE_FORMAT = "yyyy-MM-dd";
    private int _currentRound;
    private int _playoffRound;
    private int _tableOffset;
    private bool _finalized;

    public string Filename
    {
      get
      {
        return string.Format("{0} (ID {1}).Tournament", (object) Common.CleanFilename(this.Name.Trim()), (object) this.ID);
      }
    }

    public string FilenameWithRound
    {
      get
      {
        return string.Format("{0} (ID {1}) - Round {2}.Tournament", (object) Common.CleanFilename(this.Name.Trim()), (object) this.ID, (object) this.CurrentRound);
      }
    }

    public bool IsPlayoffs
    {
      get
      {
        return this.PlayoffRound > 0;
      }
    }

    public List<IPenalty> Penalties
    {
      get
      {
        return this._penalties;
      }
      set
      {
        this._penalties = value;
      }
    }

    public int PlayoffRound
    {
      get
      {
        return this._playoffRound;
      }
      set
      {
        this._playoffRound = value;
      }
    }

    public int TableOffset
    {
      get
      {
        return this._tableOffset;
      }
      set
      {
        this._tableOffset = value;
      }
    }

    public int TiebreakerRoundCalculated
    {
      get
      {
        return this._tiebreakerRoundCalculated;
      }
    }

    public Tournament()
    {
    }

    public Tournament(ITournament oldTournament)
    {
      if (oldTournament == null)
        return;
      this.CopySettings(oldTournament, false);
      this.Players.Clear();
      this.Players.Append(oldTournament.Players);
      this.CurrentRound = oldTournament.CurrentRound;
    }

    public bool EnrollPlayer(IPlayer player)
    {
      if (this.Players.HasPlayer(player.ID))
        return false;
      if (!Engine.PlayerList.HasPlayer(player.ID))
        Engine.PlayerList.AddPlayer(player);
      TournPlayer tournPlayer = new TournPlayer(player);
      this.Players.AddPlayer((ITournPlayer) tournPlayer);
      this.Players.SortByName();
      if (this.CurrentRound > 0)
        this.AddMissingMatches((ITournPlayer) tournPlayer);
      return true;
    }

    public static bool ValidateTournamentId(string id)
    {
      return new Regex("(?<EventNumber>^[a-zA-Z]\\d{2}-\\d{6}$)").Matches(id).Count == 1;
    }

    public int AddMissingMatches(ITournPlayer player)
    {
      int num = 0;
      for (int round = 1; round <= this.CurrentRound; ++round)
      {
        ITournMatchArray byRound = this.Matches.GetByRound(round);
        if (byRound.GetByPlayer(player.ID).Count == 0)
        {
          byRound.SortByRoundTable();
          TournMatch tournMatch = new TournMatch();
          tournMatch.AddPlayer(player);
          tournMatch.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
          tournMatch.Winner = Player.BYE_ID;
          tournMatch.Status = TournMatchResult.Winner;
          tournMatch.Round = round;
          tournMatch.Table = byRound[byRound.Count - 1].Table + 1;
          this.AddMatch((ITournMatch) tournMatch);
          ++num;
        }
      }
      return num;
    }

    public static string GenerateRandomTournamentId()
    {
      return string.Format("X99-{0:000000}", (object) new Random().Next(1, 999999));
    }

    private TournPlayerArray GetActivePlayersWithWins(int winCount)
    {
      Random random = new Random();
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
      {
        if (player.Tie1_Wins == winCount && player.IsActive)
          tournPlayerArray.AddPlayer(player);
      }
      return tournPlayerArray;
    }

    public void CutPlayers(int CutSize, CutType CutReason)
    {
      int num1 = 0;
      this.CalculateTies(this.CurrentRound);
      this.Players.SortByRank();
      Engine.LogAction((ITournament) this, UserAction.Cut_To_Playoffs, (object) CutSize, (object) CutReason);
      switch (CutReason)
      {
        case CutType.Cut:
          using (IEnumerator<ITournPlayer> enumerator = this.Players.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              ITournPlayer current = enumerator.Current;
              if (current.IsActive && current.PlayoffPoints == 0 && current.Tie1_Wins < CutSize)
              {
                current.DropRound = this.CurrentRound;
                current.DropReason = CutReason;
              }
            }
            break;
          }
        case CutType.PlayoffCut:
          for (int index = 0; index < this.Players.Count; ++index)
          {
            if (this.Players[index].IsActive)
            {
              if (num1 < CutSize)
              {
                ++num1;
              }
              else
              {
                this.Players[index].DropRound = this.CurrentRound;
                this.Players[index].DropReason = CutReason;
              }
            }
          }
          this.PlayoffRound = this.CurrentRound + 1;
          break;
        case CutType.TopX:
          int num2 = 0;
          using (IEnumerator<ITournPlayer> enumerator = this.Players.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              ITournPlayer current = enumerator.Current;
              if (current.IsActive)
              {
                if (num2 >= CutSize)
                {
                  current.DropRound = this.CurrentRound;
                  current.DropReason = CutReason;
                }
                ++num2;
              }
            }
            break;
          }
      }
    }

    public int AddMatch(ITournMatch match)
    {
      this._tiebreakerRoundCalculated = Math.Min(match.Round - 1, this._tiebreakerRoundCalculated);
      return this.Matches.AddMatch(match);
    }

    public bool Finalized
    {
      get
      {
        return this._finalized;
      }
      set
      {
        this._finalized = value;
      }
    }

    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    public DateTime Date
    {
      get
      {
        return this._date;
      }
      set
      {
        this._date = value;
      }
    }

    public ILocation Location
    {
      get
      {
        return this._location;
      }
      set
      {
        this._location = value;
      }
    }

    public ITournStaffArray Staff
    {
      get
      {
        return this._staff;
      }
      set
      {
        this._staff = value;
      }
    }

    public TournamentStyle Format
    {
      get
      {
        return this._format;
      }
      set
      {
        this._format = value;
      }
    }

    public EventType TournamentType
    {
      get
      {
        return this._tournamentType;
      }
      set
      {
        this._tournamentType = value;
      }
    }

    public TournamentPairingStructure PairingStructure
    {
      get
      {
        return this._structure;
      }
      set
      {
        this._structure = value;
      }
    }

    public int CurrentRound
    {
      get
      {
        return this._currentRound;
      }
      set
      {
        this._currentRound = value;
      }
    }

    public ITournMatchArray Matches
    {
      get
      {
        return this._matches;
      }
      set
      {
        this._matches = value;
      }
    }

    public ITournPlayerArray Players
    {
      get
      {
        return this._players;
      }
      set
      {
        this._players = value;
      }
    }

    public bool PairNextRound()
    {
      if (this.ActivePlayers.Count < 2)
        return false;
      this.Matches.DeleteRound(0);
      if (this.Matches.UnreportedMatches.Count != 0)
        return false;
      this.CalculateTies(this.CurrentRound);
      int num1 = -1;
      int round = this.CurrentRound + 1;
      Engine.LogAction((ITournament) this, UserAction.Pair_Next_Round, (object) round);
      if (this.IsPlayoffs || this.PairingStructure == TournamentPairingStructure.SingleElimination)
      {
        int num2 = 1;
        if (round == 1 || round == this.PlayoffRound)
        {
          ITournPlayerArray activePlayers = this.ActivePlayers;
          activePlayers.SortByRank();
          if (this.PairingStructure == TournamentPairingStructure.SingleElimination)
            activePlayers.Shuffle();
          int num3 = (int) Math.Pow(2.0, Math.Ceiling(Math.Log((double) activePlayers.Count, 2.0)));
          List<int> intList1 = new List<int>();
          List<int> intList2 = new List<int>();
          intList2.Add(1);
          while (intList1.Count < num3)
          {
            List<int> intList3 = new List<int>();
            foreach (int num4 in intList2)
            {
              intList3.Add(num4);
              intList3.Add(intList2.Count * 2 + 1 - num4);
            }
            if (intList3.Count >= num3)
            {
              intList1.AddRange((IEnumerable<int>) intList3);
            }
            else
            {
              intList2.Clear();
              intList2.AddRange((IEnumerable<int>) intList3);
            }
          }
          for (int index1 = 0; index1 < intList1.Count; index1 += 2)
          {
            int index2 = intList1[index1] - 1;
            int index3 = intList1[index1 + 1] - 1;
            TournMatch tournMatch = new TournMatch();
            tournMatch.Round = round;
            tournMatch.Table = num2++;
            tournMatch.PlayoffMatch = true;
            if (index2 < activePlayers.Count)
              tournMatch.AddPlayer(activePlayers[index2]);
            else
              tournMatch.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            if (index3 < activePlayers.Count)
            {
              tournMatch.AddPlayer(activePlayers[index3]);
            }
            else
            {
              tournMatch.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
              this.SubmitResult((ITournMatch) tournMatch, TournMatchResult.Winner, tournMatch.Players[0].ID);
            }
            tournMatch.Players.SortByID();
            this.AddMatch((ITournMatch) tournMatch);
          }
        }
        else
        {
          ITournMatchArray byRound = this.Matches.GetByRound(this.CurrentRound);
          if (byRound.Count % 2 == 1)
          {
            byRound.SortByRoundTable();
            TournMatch tournMatch = new TournMatch();
            tournMatch.Table = byRound[byRound.Count - 1].Table + 1;
            tournMatch.Round = byRound[byRound.Count - 1].Round;
            tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            tournMatch.Winner = Player.BYE_ID;
            tournMatch.Status = TournMatchResult.Winner;
            byRound.AddMatch((ITournMatch) tournMatch);
          }
          byRound.SortByRoundTable();
          for (int index1 = 0; index1 < byRound.Count; index1 += 2)
          {
            TournMatch tournMatch = new TournMatch();
            tournMatch.Round = round;
            tournMatch.Table = num2++;
            if (index1 < byRound.Count)
            {
              if (byRound[index1].Status == TournMatchResult.Winner)
              {
                ITournPlayer byId = byRound[index1].Players.FindById(byRound[index1].Winner);
                if (byId != null && byId.IsActive)
                  tournMatch.Players.AddPlayer(byId);
                else
                  tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
              }
              else
                tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            }
            else
              tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            int index2 = index1 + 1;
            if (index2 < byRound.Count)
            {
              if (byRound[index2].Status == TournMatchResult.Winner)
              {
                ITournPlayer byId = byRound[index2].Players.FindById(byRound[index2].Winner);
                if (byId != null && byId.IsActive)
                  tournMatch.Players.AddPlayer(byId);
                else
                  tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
              }
              else
                tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            }
            else
              tournMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            tournMatch.PlayoffMatch = true;
            this.AddMatch((ITournMatch) tournMatch);
          }
        }
      }
      else
      {
        TournPlayerArray unmatchedPlayers1 = new TournPlayerArray();
        unmatchedPlayers1.Append(this.ActivePlayers);
        unmatchedPlayers1.SortByRank();
        unmatchedPlayers1.ShuffleKeepRank();
        TournPlayerArray tournPlayerArray = new TournPlayerArray();
        tournPlayerArray.Append((ITournPlayerArray) unmatchedPlayers1);
        MatchHistoryList matchHistoryList = new MatchHistoryList();
        foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.Matches)
        {
          if (match.Round < round)
            matchHistoryList.AddMatch(match);
        }
        int index1 = this.PairingsDupeCheck(unmatchedPlayers1, matchHistoryList);
        while (index1 != -1)
        {
          int tie1Wins = unmatchedPlayers1[index1].Tie1_Wins;
          List<int> swapList = new List<int>();
          swapList.Add(index1);
          TournPlayerArray unmatchedPlayers2 = (TournPlayerArray) null;
          for (int index2 = 0; index2 < round * 2; ++index2)
          {
            int highPoints = tie1Wins + (index2 + 1) / 2;
            int lowPoints = tie1Wins - index2 / 2;
            for (int remainingSlots = 1; remainingSlots <= unmatchedPlayers1.Count; ++remainingSlots)
            {
              unmatchedPlayers2 = this.ScanForNonDupePairings((ITournPlayerArray) unmatchedPlayers1, matchHistoryList, highPoints, lowPoints, swapList, remainingSlots);
              if (unmatchedPlayers2.Count > 0)
                break;
            }
            if (unmatchedPlayers2.Count > 0)
              break;
          }
          if (unmatchedPlayers2.Count == 0)
          {
            unmatchedPlayers1 = tournPlayerArray;
            break;
          }
          index1 = this.PairingsDupeCheck(unmatchedPlayers2, matchHistoryList);
          unmatchedPlayers1 = unmatchedPlayers2;
        }
        while (unmatchedPlayers1.Count > 1)
        {
          TournMatch tournMatch = new TournMatch();
          tournMatch.Round = round;
          tournMatch.Table = num1;
          tournMatch.AddPlayer(unmatchedPlayers1[0]);
          unmatchedPlayers1.RemoveAt(0);
          tournMatch.AddPlayer(unmatchedPlayers1[0]);
          unmatchedPlayers1.RemoveAt(0);
          this.AddMatch((ITournMatch) tournMatch);
        }
        if (unmatchedPlayers1.Count > 0)
        {
          TournMatch tournMatch = new TournMatch();
          tournMatch.AddPlayer(unmatchedPlayers1[0]);
          tournMatch.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
          tournMatch.Table = num1;
          tournMatch.Round = round;
          tournMatch.Winner = unmatchedPlayers1[0].ID;
          tournMatch.Status = TournMatchResult.Winner;
          this.AddMatch((ITournMatch) tournMatch);
        }
        ITournMatchArray byRound = this.Matches.GetByRound(round);
        byRound.SortByRoundTable();
        List<int> intList = new List<int>();
        for (int index2 = 1; index2 < byRound.Count + 1; ++index2)
          intList.Add(index2);
        byRound.SortByPointsByesLast();
        foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) byRound)
        {
          foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tournMatch.Players)
          {
            if (player.AssignedSeat > 0)
            {
              tournMatch.Table = player.AssignedSeat - this.TableOffset;
              intList.Remove(tournMatch.Table);
              break;
            }
          }
        }
        int num2 = byRound.Count + 1;
        foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) byRound)
        {
          if (tournMatch.Table == -1)
          {
            if (intList.Count > 0)
            {
              tournMatch.Table = intList[0];
              intList.RemoveAt(0);
            }
            else
              tournMatch.Table = num2++;
          }
        }
      }
      ++this.CurrentRound;
      this.Matches.SortOrder = TournMatchSortOrder.Unsorted;
      this.Matches.SortByRoundTable();
      return true;
    }

    private TournPlayerArray ScanForNonDupePairings(
      ITournPlayerArray currentPlayers,
      MatchHistoryList histories,
      int highPoints,
      int lowPoints,
      List<int> swapList,
      int remainingSlots)
    {
      for (int index = 0; index < currentPlayers.Count; ++index)
      {
        if (currentPlayers[index].Tie1_Wins >= lowPoints && currentPlayers[index].Tie1_Wins <= highPoints && !swapList.Contains(index))
        {
          List<int> intList = new List<int>();
          intList.AddRange((IEnumerable<int>) swapList);
          intList.Add(index);
          if (remainingSlots == 1)
          {
            TournPlayerArray unmatchedPlayers = this.ResolveSwaps(currentPlayers, intList);
            int num = this.PairingsDupeCheck(unmatchedPlayers, histories);
            if (num == -1 || num > swapList[0])
              return unmatchedPlayers;
          }
          else
          {
            TournPlayerArray tournPlayerArray = this.ScanForNonDupePairings(currentPlayers, histories, highPoints, lowPoints, intList, remainingSlots - 1);
            if (tournPlayerArray.Count > 0)
              return tournPlayerArray;
          }
        }
      }
      return new TournPlayerArray();
    }

    public TournPlayerArray ResolveSwaps(ITournPlayerArray players, List<int> swaps)
    {
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      tournPlayerArray.AddRange((IEnumerable<ITournPlayer>) players);
      if (swaps.Count == 0 || players.Count == 0)
        return tournPlayerArray;
      ITournPlayer tournPlayer1 = players[swaps[0]];
      for (int index1 = 0; index1 < swaps.Count; ++index1)
      {
        int swap = swaps[index1];
        int index2 = index1 == swaps.Count - 1 ? swaps[0] : swaps[index1 + 1];
        ITournPlayer tournPlayer2 = tournPlayerArray[index2];
        tournPlayerArray[index2] = tournPlayer1;
        tournPlayer1 = tournPlayer2;
        tournPlayerArray[swaps[0]] = tournPlayer1;
      }
      return tournPlayerArray;
    }

    private int PairingsDupeCheck(TournPlayerArray unmatchedPlayers, MatchHistoryList playedMatches)
    {
      for (int index = 0; index < unmatchedPlayers.Count / 2; ++index)
      {
        if (playedMatches.HasPlayed(unmatchedPlayers[index * 2], unmatchedPlayers[index * 2 + 1]))
          return index * 2;
      }
      return -1;
    }

    public void ClearTies()
    {
      this._tiebreakerRoundCalculated = -1;
    }

    public void CalculateTies()
    {
      if (this.Matches.UnreportedMatches.Count == 0)
        this.CalculateTies(this.CurrentRound);
      else
        this.CalculateTies(this.CurrentRound - 1);
    }

    public void CalculateTies(int RoundCap)
    {
      if (this._tiebreakerRoundCalculated == RoundCap)
        return;
      Engine.LogAction((ITournament) this, UserAction.Calculate_Ties, (object) RoundCap);
      this._tiebreakerRoundCalculated = RoundCap;
      Dictionary<long, PlayerPoints> dictionary = new Dictionary<long, PlayerPoints>();
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
      {
        ITournMatchArray byPlayer = this.Matches.GetByPlayer(player.ID);
        PlayerPoints playerPoints = new PlayerPoints(player.ID);
        foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) byPlayer)
        {
          if (tournMatch.Round <= RoundCap)
          {
            if (!this.IsPlayoffs || tournMatch.Round < this.PlayoffRound)
            {
              if (tournMatch.GetOpponentId(player.ID) != Player.BYE_ID)
                playerPoints.Opps.Add(tournMatch.GetOpponentId(player.ID));
              ++playerPoints.Matches;
            }
            if (tournMatch.Status == TournMatchResult.Draw)
              ++playerPoints.Draws;
            else if (tournMatch.Winner == player.ID)
            {
              if (this.PlayoffRound > 0 && tournMatch.Round >= this.PlayoffRound)
                ++playerPoints.PlayoffPoints;
              else
                ++playerPoints.Wins;
            }
          }
        }
        dictionary.Add(playerPoints.PlayerId, playerPoints);
      }
      foreach (PlayerPoints playerPoints1 in dictionary.Values)
      {
        foreach (long opp in playerPoints1.Opps)
        {
          if (dictionary.ContainsKey(opp))
          {
            PlayerPoints playerPoints2 = dictionary[opp];
            playerPoints1.OppWins += playerPoints2.Wins;
            playerPoints1.OppDraws += playerPoints2.Draws;
            playerPoints1.OppMatches += playerPoints2.Matches;
          }
        }
      }
      foreach (PlayerPoints playerPoints1 in dictionary.Values)
      {
        foreach (long opp in playerPoints1.Opps)
        {
          if (dictionary.ContainsKey(opp))
          {
            PlayerPoints playerPoints2 = dictionary[opp];
            playerPoints1.OppOppWins += playerPoints2.OppWins;
            playerPoints1.OppOppDraws += playerPoints2.OppDraws;
            playerPoints1.OppOppMatches += playerPoints2.OppMatches;
          }
        }
      }
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
      {
        player.ClearTies();
        if (dictionary.ContainsKey(player.ID))
        {
          PlayerPoints playerPoints = dictionary[player.ID];
          player.PlayoffPoints = playerPoints.PlayoffPoints;
          player.Tie1_Wins = playerPoints.WinPoints;
          player.Tie2_Points = playerPoints.WinPoints * 1000000;
          if (playerPoints.OppMatches > 0)
            player.Tie2_Points += Math.Min(999, playerPoints.OppWinPoints * 1000 / (playerPoints.OppMatches * 3)) * 1000;
          if (playerPoints.OppOppMatches > 0)
            player.Tie2_Points += Math.Min(999, playerPoints.OppOppWinPoints * 1000 / (playerPoints.OppOppMatches * 3));
        }
      }
      this.Players.ForceSort(PlayerSortOrder.Rank);
    }

    public ITournMatch GetMatch(int Table)
    {
      return this.GetMatch(this.CurrentRound, Table);
    }

    public ITournMatch GetMatch(int Round, int Table)
    {
      return this.Matches.GetByRoundTable(Round, Table);
    }

    public bool SubmitResult(int Table, TournMatchResult Result, long Winner)
    {
      ITournMatch match = this.GetMatch(Table);
      return match != null && this.SubmitResult(match, Result, Winner);
    }

    public bool SubmitResult(ITournMatch Match, TournMatchResult Result, long Winner)
    {
      Engine.LogAction((ITournament) this, UserAction.Submit_Match_Result, (object) "Round ", (object) Match.Round, (object) ", Table ", (object) Match.Table, (object) ", COSSY ID ", (object) Utility.MakeDisplayCOSSY(Winner));
      this._tiebreakerRoundCalculated = Math.Min(Match.Round - 1, this._tiebreakerRoundCalculated);
      Match.Status = Result;
      Match.Winner = Winner;
      if (this.IsPlayoffs && Match.Round >= this.PlayoffRound)
      {
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) Match.Players)
        {
          if (player.ID == Winner)
          {
            player.DropReason = CutType.Active;
            player.DropRound = 0;
          }
          else
          {
            player.DropRound = this.CurrentRound;
            player.DropReason = CutType.PlayoffCut;
          }
        }
      }
      else if (this.PairingStructure == TournamentPairingStructure.SingleElimination)
      {
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) Match.Players)
        {
          if (player.ID == Winner)
          {
            player.DropReason = CutType.Active;
            player.DropRound = 0;
          }
          else
          {
            player.DropRound = this.CurrentRound;
            player.DropReason = CutType.Cut;
          }
        }
      }
      return true;
    }

    public ITournMatch HasRepeatMatchup(int Round)
    {
      foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) this.Matches.GetByRound(Round))
      {
        if (this.HavePlayed(tournMatch.Players, Round))
          return tournMatch;
      }
      return (ITournMatch) null;
    }

    public bool HavePlayed(ITournPlayerArray players, int maxRound)
    {
      return players.Count >= 2 && !players.HasPlayer(Player.BYE_ID) && this.HavePlayed(players[0], players[1], maxRound);
    }

    private bool HavePlayed(ITournPlayer p1, ITournPlayer p2, int maxRound)
    {
      if (p1.IsBye || p2.IsBye)
        return false;
      foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) this.Matches.GetByPlayer(p1.ID))
      {
        if (tournMatch.Round <= maxRound && tournMatch.Players.HasPlayer(p2.ID))
          return true;
      }
      return false;
    }

    public string ID
    {
      get
      {
        return this._id;
      }
      set
      {
        this._id = value;
      }
    }

    public ITournPlayerArray ActivePlayers
    {
      get
      {
        TournPlayerArray tournPlayerArray = new TournPlayerArray();
        foreach (TournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
        {
          if (player.IsActive)
            tournPlayerArray.Add((ITournPlayer) player);
        }
        return (ITournPlayerArray) tournPlayerArray;
      }
    }

    public void CopySettings(ITournament source, bool includeID)
    {
      if (includeID)
        this.ID = source.ID;
      this.Name = source.Name;
      this.Date = source.Date;
      this.Location = source.Location;
      this.Format = source.Format;
      this.PairingStructure = source.PairingStructure;
      this.Staff.Clear();
      this.Staff.Append(source.Staff);
      this.TournamentType = source.TournamentType;
    }

    public DataTable GetStandings(int round, bool includeDrops)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("Rank", typeof (int)));
      dataTable.Columns.Add(new DataColumn("Player", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Points", typeof (int)));
      dataTable.Columns.Add(new DataColumn("Ties", typeof (int)));
      if (round > 0)
      {
        this.CalculateTies(round);
        this.Players.AssignRanks(round, includeDrops);
        foreach (TournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
        {
          if (player.IsActive || includeDrops || player.DropRound > round)
          {
            DataRow row = dataTable.NewRow();
            row["Rank"] = (object) player.Rank;
            row["Player"] = (object) player.ToString();
            row["Points"] = (object) player.Tie1_Wins;
            row["Ties"] = (object) player.Tie2_Points;
            dataTable.Rows.Add(row);
          }
        }
      }
      return dataTable;
    }

    public PrinterSplitList PrinterSplits
    {
      get
      {
        return this._printerSplits;
      }
      set
      {
        this._printerSplits = value;
      }
    }

    public void ChangePlayerId(long oldPlayerId, long newPlayerId)
    {
      if (oldPlayerId == Player.BYE_ID)
        return;
      ITournPlayer byId = this.Players.FindById(oldPlayerId);
      if (byId != null)
        byId.ID = newPlayerId;
      foreach (ITournStaff tournStaff in (IEnumerable<ITournStaff>) this.Staff)
      {
        if (tournStaff.ID == oldPlayerId)
          tournStaff.ID = newPlayerId;
      }
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.Matches)
      {
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) match.Players)
        {
          if (player.ID == oldPlayerId)
            player.ID = newPlayerId;
        }
        if (match.Winner == oldPlayerId)
          match.Winner = newPlayerId;
      }
    }

    public void ExportMatchesToCSV(string filePath)
    {
      Engine.LogAction((ITournament) this, UserAction.Export_Matches);
      StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
      streamWriter.WriteLine("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", (object) "Event ID", (object) "Round", (object) "Player 1", (object) "Result", (object) "Player 2");
      this.Matches.SortByRoundTable();
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.Matches)
      {
        int num = 0;
        string str1 = "";
        string str2 = "";
        if (match.Status == TournMatchResult.Winner && match.Winner != Player.BYE_ID)
        {
          num = 1;
          if (match.Winner != Player.BYE_ID)
            str1 = Utility.MakeDisplayCOSSY(match.Winner);
          if (match.Loser != Player.BYE_ID)
            str2 = Utility.MakeDisplayCOSSY(match.Loser);
        }
        else if (match.Status == TournMatchResult.Draw)
        {
          num = 3;
          if (match.Players[0] != null)
            str1 = match.Players[0].IDFormatted;
          if (match.Players[1] != null)
            str2 = match.Players[1].IDFormatted;
        }
        else if (match.Status == TournMatchResult.DoubleLoss)
        {
          num = 4;
          if (match.Players[0] != null)
            str1 = match.Players[0].IDFormatted;
          if (match.Players[1] != null)
            str2 = match.Players[1].IDFormatted;
        }
        if (num != 0)
          streamWriter.WriteLine("\"{0}\",{1},{2},{3},{4}", (object) this.ID, (object) match.Round, (object) str1, (object) num, (object) str2);
      }
      streamWriter.Close();
      streamWriter.Dispose();
    }

    public void ExportPlayersToCSV(string filePath)
    {
      Engine.LogAction((ITournament) this, UserAction.Export_Player_List);
      StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
      streamWriter.WriteLine("\"ID\",\"First Name\",\"Last Name\"");
      this.Players.SortByID();
      foreach (IPlayer player in (IEnumerable<ITournPlayer>) this.Players)
        streamWriter.WriteLine("\"{0}\",\"{1}\",\"{2}\"", new object[3]
        {
          (object) player.IDFormatted,
          (object) player.FirstName.Replace("\"", "\\\""),
          (object) player.LastName.Replace("\"", "\\\"")
        });
      streamWriter.Close();
      streamWriter.Dispose();
    }

    public void CreateSeatAllPlayers()
    {
      ITournMatchArray byRound = this.Matches.GetByRound(0);
      this.Players.SortByLastname();
      ITournPlayerArray activePlayers = this.ActivePlayers;
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) activePlayers)
      {
        if (byRound.GetByPlayer(player.ID).Count == 0)
          tournPlayerArray.AddPlayer(player);
      }
      tournPlayerArray.SortByLastname();
      foreach (ITournPlayer player in (List<ITournPlayer>) tournPlayerArray)
      {
        if (byRound.Count == 0)
        {
          TournMatch tournMatch = new TournMatch();
          tournMatch.Table = 1;
          tournMatch.Round = 0;
          tournMatch.Status = TournMatchResult.Draw;
          tournMatch.AddPlayer(player);
          tournMatch.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
          byRound.AddMatch((ITournMatch) tournMatch);
          this.Matches.AddMatch((ITournMatch) tournMatch);
        }
        else
        {
          ITournMatch tournMatch1 = byRound[byRound.Count - 1];
          if (tournMatch1.Players.HasPlayer(Player.BYE_ID))
            tournMatch1.Players.RemovePlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
          if (tournMatch1.Players.Count < 2)
          {
            tournMatch1.AddPlayer(player);
          }
          else
          {
            TournMatch tournMatch2 = new TournMatch();
            tournMatch2.Table = tournMatch1.Table + 1;
            tournMatch2.Round = 0;
            tournMatch2.AddPlayer(player);
            tournMatch2.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            byRound.AddMatch((ITournMatch) tournMatch2);
            this.Matches.AddMatch((ITournMatch) tournMatch2);
          }
        }
      }
    }

    public string XmlKeyElementName
    {
      get
      {
        return this._xmlElementName;
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      if (this.Matches.UnreportedMatches.Count == 0)
      {
        this.CalculateTies(this.CurrentRound);
        this.Players.AssignRanks(this.CurrentRound, true);
      }
      writer.WriteStartElement(this.XmlKeyElementName);
      writer.WriteElementString("Name", this.Name);
      writer.WriteElementString("ID", this.ID);
      writer.WriteElementString("TournamentStyleCode", string.Format("{0:00}", (object) (int) this.Format));
      writer.WriteElementString("StructureCode", string.Format("{0:00}", (object) (int) this.PairingStructure));
      writer.WriteElementString("EventTypeCode", string.Format("{0:00}", (object) (int) this.TournamentType));
      writer.WriteElementString("ReferenceDateTime", new DateTime(2003, 1, 2).ToString("yyyy-MM-dd"));
      writer.WriteElementString("Date", this.Date.ToString("yyyy-MM-dd"));
      writer.WriteElementString("CurrentRound", this.CurrentRound.ToString());
      writer.WriteElementString("TableOffset", this.TableOffset.ToString());
      writer.WriteElementString("PlayoffRound", this.PlayoffRound.ToString());
      writer.WriteElementString("SoftwareVersion", Assembly.GetExecutingAssembly().GetName().Version.ToString());
      writer.WriteElementString("Finalized", this.Finalized.ToString());
      writer.WriteStartElement("Staff");
      this.Staff.ToFullXml(writer);
      writer.WriteEndElement();
      writer.WriteStartElement("PenaltyList");
      foreach (PenaltyClass penalty in this.Penalties)
        penalty.ToFullXml(writer);
      writer.WriteEndElement();
      this.Location.ToFullXml(writer);
      this.Players.ToFullXml(writer);
      this.Matches.ToFullXml(writer);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      this.Name = node["Name"].InnerText.Trim();
      if (node["Format"] != null)
      {
        switch ((TournamentFormat) Enum.Parse(typeof (TournamentFormat), node["Format"].InnerText))
        {
          case TournamentFormat.Constructed:
            this.Format = TournamentStyle.ConstructedAdvanced;
            break;
          case TournamentFormat.Limited:
            this.Format = TournamentStyle.Sealed;
            break;
          case TournamentFormat.Open:
            this.Format = TournamentStyle.OpenDueling;
            break;
          default:
            this.Format = TournamentStyle.ConstructedAdvanced;
            break;
        }
      }
      else
        this.Format = node["TournamentStyleCode"] == null ? TournamentStyle.ConstructedAdvanced : (TournamentStyle) int.Parse(node["TournamentStyleCode"].InnerText);
      this.TournamentType = node["EventTypeCode"] == null ? EventType.Local : (EventType) int.Parse(node["EventTypeCode"].InnerText);
      this.PairingStructure = node["Structure"] == null ? (node["StructureCode"] == null ? TournamentPairingStructure.Swiss : (TournamentPairingStructure) int.Parse(node["StructureCode"].InnerText)) : (TournamentPairingStructure) Enum.Parse(typeof (TournamentPairingStructure), node["Structure"].InnerText.Trim());
      if (node["ReferenceDateTime"] != null)
      {
        Regex regex = new Regex("(\\d+)[^\\d]*(\\d+)[^\\d]*(\\d+)");
        Match match1 = regex.Match(node["ReferenceDateTime"].InnerText);
        Match match2 = regex.Match(node["Date"].InnerText);
        int year = 0;
        int month = 0;
        int day = 0;
        for (int index = 1; index < match1.Groups.Count; ++index)
        {
          if (int.Parse(match1.Groups[index].Value) == 1)
            month = int.Parse(match2.Groups[index].Value);
          else if (int.Parse(match1.Groups[index].Value) == 2)
            day = int.Parse(match2.Groups[index].Value);
          else if (int.Parse(match1.Groups[index].Value) == 2003)
            year = int.Parse(match2.Groups[index].Value);
        }
        if (year != 0 && month != 0 && day != 0)
          this.Date = new DateTime(year, month, day);
      }
      else
      {
        try
        {
          IFormatProvider provider = (IFormatProvider) new CultureInfo("en-US");
          this.Date = DateTime.ParseExact(node["Date"].InnerText, "yyyy-MM-dd", provider);
        }
        catch (Exception ex1)
        {
          try
          {
            CultureInfo cultureInfo = new CultureInfo("es-ES");
            this.Date = Convert.ToDateTime(node["Date"].InnerText.Trim());
          }
          catch (Exception ex2)
          {
            try
            {
              CultureInfo cultureInfo = new CultureInfo("de-DE");
              this.Date = Convert.ToDateTime(node["Date"].InnerText.Trim());
            }
            catch (Exception ex3)
            {
            }
          }
        }
      }
      this.CurrentRound = Convert.ToInt32(node["CurrentRound"].InnerText.Trim());
      if (node["TableOffset"] != null && node["TableOffset"].InnerText.Trim().Length > 0)
        this.TableOffset = Convert.ToInt32(node["TableOffset"].InnerText.Trim());
      if (node["HeadJudge"] != null && node["HeadJudge"].HasChildNodes)
      {
        Player player = new Player();
        player.FromXml(node["HeadJudge"].ChildNodes[0]);
        if (player.ID != Player.BYE_ID)
          this.Staff.Add((ITournStaff) new TournStaff((IPlayer) player)
          {
            Position = StaffPosition.HeadJudge
          });
      }
      if (node["Organizer"] != null && node["Organizer"].HasChildNodes)
      {
        Player player = new Player();
        player.FromXml(node["Organizer"].ChildNodes[0]);
        if (player.ID != Player.BYE_ID)
          this.Staff.Add((ITournStaff) new TournStaff((IPlayer) player)
          {
            Position = StaffPosition.Organizer
          });
      }
      if (node["ScoreKeeper"] != null && node["ScoreKeeper"].HasChildNodes)
      {
        Player player = new Player();
        player.FromXml(node["ScoreKeeper"].ChildNodes[0]);
        if (player.ID != Player.BYE_ID)
          this.Staff.Add((ITournStaff) new TournStaff((IPlayer) player)
          {
            Position = StaffPosition.Scorekeeper
          });
      }
      if (node["Judges"] != null && node["Judges"].HasChildNodes)
      {
        PlayerArray playerArray = new PlayerArray();
        playerArray.FromXml(node["Judges"].ChildNodes[0]);
        foreach (Player player in (List<IPlayer>) playerArray)
        {
          if (player.ID != Player.BYE_ID)
            this.Staff.Add((ITournStaff) new TournStaff((IPlayer) player)
            {
              Position = StaffPosition.Judge
            });
        }
      }
      if (node["Staff"] != null && node["Staff"].HasChildNodes)
      {
        TournStaffArray tournStaffArray = new TournStaffArray();
        tournStaffArray.FromXml(node["Staff"].ChildNodes[0]);
        this.Staff.Append((ITournStaffArray) tournStaffArray);
      }
      if (node[this.Players.XmlKeyElementName].HasChildNodes)
        this.Players.FromXml((XmlNode) node[this.Players.XmlKeyElementName]);
      if (node[this.Matches.XmlKeyElementName].HasChildNodes)
        this.Matches.FromXml((XmlNode) node[this.Matches.XmlKeyElementName]);
      if (node[this.Location.XmlKeyElementName] != null)
        this.Location.FromXml((XmlNode) node[this.Location.XmlKeyElementName]);
      if (node["PenaltyList"] != null && node["PenaltyList"].HasChildNodes)
      {
        foreach (XmlNode childNode in node["PenaltyList"].ChildNodes)
        {
          PenaltyClass penaltyClass = new PenaltyClass();
          penaltyClass.FromXml(childNode);
          this.Penalties.Add((IPenalty) penaltyClass);
        }
      }
      if (node["ID"] != null)
        this.ID = !Tournament.ValidateTournamentId(node["ID"].InnerText.Trim()) ? Tournament.GenerateRandomTournamentId() : node["ID"].InnerText.Trim();
      if (node["PlayoffRound"] != null)
        int.TryParse(node["PlayoffRound"].InnerText.Trim(), out this._playoffRound);
      if (node["Finalized"] != null)
        this.Finalized = bool.Parse(node["Finalized"].InnerText);
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      this.Matches.SortByRoundTable();
      foreach (TournMatch match in (IEnumerable<ITournMatch>) this.Matches)
      {
        foreach (TournPlayer player in (IEnumerable<ITournPlayer>) match.Players)
        {
          if (!player.IsBye && this.Players.FindById(player.ID) == null && tournPlayerArray.FindById(player.ID) == null)
            tournPlayerArray.AddPlayer((ITournPlayer) player);
        }
      }
      if (tournPlayerArray.Count > 0)
      {
        foreach (TournPlayer tournPlayer in (List<ITournPlayer>) tournPlayerArray)
        {
          this.Players.AddPlayer((ITournPlayer) tournPlayer);
          ITournMatchArray byPlayer = this.Matches.GetByPlayer(tournPlayer.ID);
          byPlayer.SortByRoundTable();
          if (byPlayer[byPlayer.Count - 1].Round != this.CurrentRound)
          {
            tournPlayer.DropRound = byPlayer[byPlayer.Count - 1].Round;
            tournPlayer.DropReason = CutType.Drop;
          }
        }
      }
      int index1 = 0;
      if (this.Matches.Count > 0)
      {
        while (index1 < this.Players.Count)
        {
          ITournMatchArray byPlayer = this.Matches.GetByPlayer(this.Players[index1].ID);
          if (byPlayer == null || byPlayer.Count == 0)
            this.Players.RemoveAt(index1);
          else
            ++index1;
        }
      }
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.Matches)
      {
        for (int index2 = 0; index2 < match.Players.Count; ++index2)
        {
          if (!match.Players[index2].IsBye)
          {
            ITournPlayer byId = this.Players.FindById(match.Players[index2].ID);
            if (byId != null)
              match.Players[index2] = byId;
          }
        }
      }
      foreach (IPenalty penalty in this.Penalties)
      {
        ITournPlayer byId1 = this.Players.FindById(penalty.Player.ID);
        if (byId1 != null)
          penalty.Player = (IPlayer) byId1;
        else
          this.Players.AddPlayer((ITournPlayer) new TournPlayer(penalty.Player));
        ITournStaff byId2 = this.Staff.FindById(penalty.Judge.ID);
        if (byId2 != null)
          penalty.Judge = byId2;
        else
          this.Staff.Add(penalty.Judge);
      }
    }

    public int Compare(Tournament x, Tournament y)
    {
      return x.ID.CompareTo(y.ID);
    }

    public int CompareTo(ITournament other)
    {
      return this.ID.CompareTo(other.ID);
    }
  }
}
