// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.Engine
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.BusinessLogic
{
  public static class Engine
  {
    public static bool AllowTempID = false;
    private static Dictionary<EventType, List<TournamentStyle>> _legalTournamentStyles = new Dictionary<EventType, List<TournamentStyle>>();
    private static ILocationArray _locationList = (ILocationArray) new LocationArray();
    private static IPlayer _currentPlayer = (IPlayer) null;
    private static IPlayerArray _playerList = (IPlayerArray) new PlayerArray();
    private static ITournament _currentLoggedTournament = (ITournament) null;
    private static ITournament _currentTournament = (ITournament) null;
    private static ITournMatch _currentTournMatch = (ITournMatch) null;
    public static List<string> LogMessages = new List<string>();
    public static TournamentArray AllTournaments = new TournamentArray();
    private static UserAction _currentLoggedAction = UserAction.None;

    public static IPlayer CurrentPlayer
    {
      get
      {
        return Engine._currentPlayer;
      }
      set
      {
        Engine._currentPlayer = value;
      }
    }

    public static bool CurrentPlayerSelected
    {
      get
      {
        return Engine.CurrentPlayer != null;
      }
    }

    public static ITournament CurrentTournament
    {
      get
      {
        return Engine._currentTournament;
      }
      set
      {
        Engine._currentTournament = value;
      }
    }

    public static ITournMatch CurrentTournMatch
    {
      get
      {
        return Engine._currentTournMatch;
      }
      set
      {
        Engine._currentTournMatch = value;
      }
    }

    public static bool CurrentTournMatchSelected
    {
      get
      {
        return Engine.CurrentTournMatch != null;
      }
    }

    public static ILocationArray LocationList
    {
      get
      {
        return Engine._locationList;
      }
    }

    public static string LocationListFilename
    {
      get
      {
        return Path.Combine(Settings.DataStorageFolder, "Locations.XML");
      }
    }

    public static IPlayerArray PlayerList
    {
      get
      {
        return Engine._playerList;
      }
    }

    public static string PlayerListFilename
    {
      get
      {
        return Path.Combine(Settings.DataStorageFolder, "AllPlayers.XML");
      }
    }

    public static bool GetPrinterSplits(ITournPlayerArray playerList, PrinterSplitList splits)
    {
      playerList.SortByLastname();
      int val1 = 0;
      foreach (int key in splits.Keys)
      {
        splits[key].Counts = 0;
        val1 = Math.Max(val1, key);
      }
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) playerList)
      {
        string str = "";
        if (player.LastName.Length > 0)
          str = player.LastName[0].ToString();
        foreach (int key in splits.Keys)
        {
          bool flag1 = key <= 1 || str.CompareTo(splits[key].FirstChar) >= 0;
          bool flag2 = key == val1 || str.CompareTo(splits[key].LastChar) <= 0;
          if (flag1 && flag2)
          {
            ++splits[key].Counts;
            break;
          }
        }
      }
      return true;
    }

    public static Engine.CossyIdType GetCossyIdType(long CossyId)
    {
      string str = Utility.MakeDisplayCOSSY(CossyId);
      if (Engine.GetCheckDigit(CossyId) == int.Parse(str[9].ToString()))
        return Engine.CossyIdType.CossyId;
      return CossyId >= 9999000000L && CossyId < 10000000000L ? Engine.CossyIdType.TempId : Engine.CossyIdType.None;
    }

    public static int GetCheckDigit(long CossyId)
    {
      string str = Utility.MakeDisplayCOSSY(CossyId);
      return (11 - (int.Parse(str[0].ToString()) * 9 + int.Parse(str[1].ToString()) * 8 + int.Parse(str[2].ToString()) * 7 + int.Parse(str[3].ToString()) * 6 + int.Parse(str[4].ToString()) * 5 + int.Parse(str[5].ToString()) * 4 + int.Parse(str[6].ToString()) * 3 + int.Parse(str[7].ToString()) * 2 + int.Parse(str[8].ToString()) * 9) % 11) % 10;
    }

    public static List<TournamentStyle> LegalTournamentStyles(EventType eventType)
    {
      if (Engine._legalTournamentStyles.Count == 0)
      {
        foreach (EventType key in Enum.GetValues(typeof (EventType)))
        {
          foreach (TournamentStyle tournamentStyle in Enum.GetValues(typeof (TournamentStyle)))
          {
            if (!Engine._legalTournamentStyles.ContainsKey(key))
              Engine._legalTournamentStyles.Add(key, new List<TournamentStyle>());
            Engine._legalTournamentStyles[key].Add(tournamentStyle);
          }
        }
        foreach (TournamentStyle tournamentStyle in Enum.GetValues(typeof (TournamentStyle)))
        {
          if (tournamentStyle != TournamentStyle.OpenDueling)
          {
            Engine._legalTournamentStyles[EventType.SneakPeek].Remove(tournamentStyle);
            Engine._legalTournamentStyles[EventType.DuelistLeague].Remove(tournamentStyle);
          }
          if (tournamentStyle != TournamentStyle.Sealed)
          {
            Engine._legalTournamentStyles[EventType.GoForTheGold].Remove(tournamentStyle);
            Engine._legalTournamentStyles[EventType.TinChallenge].Remove(tournamentStyle);
          }
        }
      }
      return Engine._legalTournamentStyles[eventType];
    }

    public static PlayerArray AddPlayerCsvToAllPlayers(string filename)
    {
      PlayerArray playerArray = new PlayerArray();
      int result = 0;
      char[] chArray = new char[1]{ '"' };
      string[] separator = new string[1]{ "," };
      StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);
      streamReader.ReadLine();
      while (!streamReader.EndOfStream)
      {
        string[] strArray = streamReader.ReadLine().Trim(chArray).Split(separator, StringSplitOptions.None);
        if (strArray.Length == 3 && int.TryParse(strArray[0].Trim(chArray), out result) && (result != 0 && !Engine.PlayerList.HasPlayer((long) result)))
        {
          Player player = new Player(strArray[1].Trim(chArray), strArray[2].Trim(chArray), (long) result);
          Engine.PlayerList.AddPlayer((IPlayer) player);
          playerArray.AddPlayer((IPlayer) player);
        }
      }
      streamReader.Close();
      streamReader.Dispose();
      return playerArray;
    }

    public static void LogAction(ITournament tourn, UserAction action, params object[] options)
    {
      if (action == UserAction.None)
        return;
      try
      {
        if (!Directory.Exists(Settings.DataStorageFolder))
          Directory.CreateDirectory(Settings.DataStorageFolder);
        string str = "";
        StringBuilder stringBuilder = new StringBuilder();
        if (action == UserAction.Program_Start)
          stringBuilder.AppendFormat("{0} ", (object) DateTime.Now.ToString("yyyy MMM d"));
        if (Engine._currentLoggedTournament != null && tourn != null && Engine._currentLoggedTournament.ID != tourn.ID)
        {
          str = string.Format("*** Switch to tournament {0} ({1})\r\n", (object) tourn.Name, (object) tourn.ID);
          Engine.LogMessages.Insert(0, str);
        }
        stringBuilder.AppendFormat("{0} {1}", (object) DateTime.Now.ToString("HH:mm"), (object) Enum.GetName(typeof (UserAction), (object) action).Replace('_', ' '));
        for (int index = 0; index < options.Length; ++index)
          stringBuilder.AppendFormat(" {0}", options[index]);
        StreamWriter streamWriter = new StreamWriter(Path.Combine(Settings.DataStorageFolder, "logfile.txt"), true, Encoding.UTF8);
        if (!string.IsNullOrEmpty(str))
          streamWriter.WriteLine(str);
        streamWriter.WriteLine(stringBuilder.ToString());
        streamWriter.Close();
        streamWriter.Dispose();
        Engine._currentLoggedTournament = tourn;
        Engine._currentLoggedAction = action;
        Engine.LogMessages.Insert(0, stringBuilder.ToString());
        while (Engine.LogMessages.Count > 100)
          Engine.LogMessages.RemoveAt(Engine.LogMessages.Count - 1);
      }
      catch (Exception ex)
      {
        string message = ex.Message;
      }
    }

    public static void SaveTournamentToFile(ITournament tournament)
    {
      if (tournament == null)
        return;
      string filename1 = Path.Combine(Settings.DataStorageFolder, tournament.Filename);
      Engine.SaveTournamentToFile(tournament, filename1);
      string str = Path.Combine(Settings.DataStorageFolder, "Backup");
      if (!Directory.Exists(str))
        Directory.CreateDirectory(str);
      string filename2 = Path.Combine(str, tournament.FilenameWithRound);
      Engine.SaveTournamentToFile(tournament, filename2);
    }

    public static void SaveTournamentToFile(ITournament tournament, string filename)
    {
      if (tournament == null)
        return;
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Encoding = Encoding.UTF8;
      settings.OmitXmlDeclaration = false;
      settings.Indent = true;
      settings.IndentChars = "\t";
      if (!Directory.Exists(Path.GetDirectoryName(filename)))
        Directory.CreateDirectory(Path.GetDirectoryName(filename));
      XmlWriter writer = XmlWriter.Create(filename, settings);
      tournament.ToFullXml(writer);
      writer.Flush();
      writer.Close();
    }

    public static void SaveTournamentToFinalizedFolder(ITournament tournament)
    {
      if (tournament == null)
        return;
      string filename = Path.Combine(Path.Combine(Settings.DataStorageFolder, "Finalized"), tournament.Filename);
      Engine.SaveTournamentToFile(tournament, filename);
    }

    public static void SetCurrentPlayer(object player)
    {
      if (!(player is IPlayer))
        throw new Exception("Not a player");
      Engine._currentPlayer = (IPlayer) player;
    }

    public enum CossyIdType
    {
      None,
      CossyId,
      TempId,
    }

    public enum PrintPairingsAction
    {
      None,
      PrintByTable,
      PrintByPlayer,
      PrintUnreported,
      RandomMatches,
      PrintBrackets,
      StandingsAllPlayers,
      StandingsAllPlayersNoTies,
      StandingsActivePlayers,
      StandingsActivePlayersNoTies,
      ResultSlips,
      PairedDownPlayers,
    }
  }
}
