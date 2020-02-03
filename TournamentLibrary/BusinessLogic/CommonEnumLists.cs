// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.CommonEnumLists
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.BusinessLogic
{
  public static class CommonEnumLists
  {
    private static Dictionary<Engine.PrintPairingsAction, string> m_PrintPairingsActionNames = new Dictionary<Engine.PrintPairingsAction, string>();
    private static Dictionary<EventType, string> m_EventTypeNames = new Dictionary<EventType, string>();
    private static Dictionary<PenaltyEnum, string> m_PenaltyEnumNames = new Dictionary<PenaltyEnum, string>();
    private static Dictionary<TournamentPairingStructure, string> m_TournamentPairingStructureNames = new Dictionary<TournamentPairingStructure, string>();
    private static Dictionary<TournamentStyle, string> m_TournamentStyleNames = new Dictionary<TournamentStyle, string>();

    public static Dictionary<EventType, string> EventTypeNames
    {
      get
      {
        if (CommonEnumLists.m_EventTypeNames.Count == 0)
        {
          CommonEnumLists.m_EventTypeNames.Add(EventType.Local, "Local");
          CommonEnumLists.m_EventTypeNames.Add(EventType.LocalJunior, "Local - Junior");
          CommonEnumLists.m_EventTypeNames.Add(EventType.DragonDuel, "Dragon Duel");
          CommonEnumLists.m_EventTypeNames.Add(EventType.PegasusChallenge, "Pegasus Challenge");
          CommonEnumLists.m_EventTypeNames.Add(EventType.GiantCard, "ATTACK OF THE GIANT CARD!!");
          CommonEnumLists.m_EventTypeNames.Add(EventType.GoForTheGold, "Go for the Gold");
          CommonEnumLists.m_EventTypeNames.Add(EventType.WinAMat, "Win-A-Mat");
          CommonEnumLists.m_EventTypeNames.Add(EventType.TinChallenge, "Yu-Gi-Oh! Tin Challenge");
          CommonEnumLists.m_EventTypeNames.Add(EventType.CountrySpecific, "Country Specific");
          CommonEnumLists.m_EventTypeNames.Add(EventType.ChampionshipSeries, "Yu-Gi-Oh! Championship Series");
          CommonEnumLists.m_EventTypeNames.Add(EventType.WCQRegionals, "WCQ: Regionals");
          CommonEnumLists.m_EventTypeNames.Add(EventType.WCQNationalChampionship, "WCQ: National Championship");
          CommonEnumLists.m_EventTypeNames.Add(EventType.WCQContinentalChampionship, "WCQ: Continental Championship");
          CommonEnumLists.m_EventTypeNames.Add(EventType.WorldChampionship, "World Championship");
          CommonEnumLists.m_EventTypeNames.Add(EventType.SneakPeek, "Sneak Peek");
          CommonEnumLists.m_EventTypeNames.Add(EventType.DuelistLeague, "Duelist League");
        }
        return CommonEnumLists.m_EventTypeNames;
      }
    }

    public static Dictionary<PenaltyEnum, string> PenaltyEnumNames
    {
      get
      {
        if (CommonEnumLists.m_PenaltyEnumNames.Count == 0)
        {
          CommonEnumLists.m_PenaltyEnumNames.Add(PenaltyEnum.Warning, "Warning");
          CommonEnumLists.m_PenaltyEnumNames.Add(PenaltyEnum.GameLoss, "Game Loss");
          CommonEnumLists.m_PenaltyEnumNames.Add(PenaltyEnum.MatchLoss, "Match Loss");
          CommonEnumLists.m_PenaltyEnumNames.Add(PenaltyEnum.DisqualificationWithPrize, "Disqualification with Prize");
          CommonEnumLists.m_PenaltyEnumNames.Add(PenaltyEnum.DisqualificationWithoutPrize, "Disqualification without Prize");
        }
        return CommonEnumLists.m_PenaltyEnumNames;
      }
    }

    public static Dictionary<Engine.PrintPairingsAction, string> PrintPairingsActionNames
    {
      get
      {
        if (CommonEnumLists.m_PrintPairingsActionNames.Count == 0)
        {
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.None, "None");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.PrintBrackets, "Pairing Brackets");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.PrintByPlayer, "Pairings by Player");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.PrintByTable, "Pairings by Table");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.PrintUnreported, "Unreported Matches");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.RandomMatches, "Random Matches");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.StandingsAllPlayers, "Standings (All Players)");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.StandingsAllPlayersNoTies, "Standings (All Players without Tiebreakers)");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.StandingsActivePlayers, "Standings (Active Players)");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.StandingsActivePlayersNoTies, "Standings (Active Players without Tiebreakers)");
          CommonEnumLists.m_PrintPairingsActionNames.Add(Engine.PrintPairingsAction.ResultSlips, "Result Slips");
        }
        return CommonEnumLists.m_PrintPairingsActionNames;
      }
    }

    public static Dictionary<TournamentPairingStructure, string> TournamentPairingStructureNames
    {
      get
      {
        if (CommonEnumLists.m_TournamentPairingStructureNames.Count == 0)
        {
          CommonEnumLists.m_TournamentPairingStructureNames.Add(TournamentPairingStructure.Swiss, "Swiss Draw");
          CommonEnumLists.m_TournamentPairingStructureNames.Add(TournamentPairingStructure.SingleElimination, "Single-Elimination");
        }
        return CommonEnumLists.m_TournamentPairingStructureNames;
      }
    }

    public static Dictionary<TournamentStyle, string> TournamentStyleNames
    {
      get
      {
        if (CommonEnumLists.m_TournamentStyleNames.Count == 0)
        {
          CommonEnumLists.m_TournamentStyleNames.Add(TournamentStyle.ConstructedAdvanced, "Constructed - Advanced");
          CommonEnumLists.m_TournamentStyleNames.Add(TournamentStyle.ConstructedTraditional, "Constructed - Traditional");
          CommonEnumLists.m_TournamentStyleNames.Add(TournamentStyle.Sealed, "Sealed");
          CommonEnumLists.m_TournamentStyleNames.Add(TournamentStyle.OpenDueling, "Open Dueling");
        }
        return CommonEnumLists.m_TournamentStyleNames;
      }
    }
  }
}
