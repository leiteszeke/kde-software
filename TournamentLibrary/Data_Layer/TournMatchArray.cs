// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournMatchArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournMatchArray : List<ITournMatch>, ITournMatchArray, IList<ITournMatch>, ICollection<ITournMatch>, IEnumerable<ITournMatch>, IEnumerable, IBaseObject
  {
    private string _XmlKeyElementName = "Matches";
    public const string MATCHES_COLUMN_MATCHOBJECT = "MatchObject";
    public const string MATCHES_COLUMN_PLAYER1 = "Player 1 Object";
    public const string MATCHES_COLUMN_PLAYER1_DISPLAY = "Player 1";
    public const string MATCHES_COLUMN_PLAYER2 = "Player 2 Object";
    public const string MATCHES_COLUMN_PLAYER2_DISPLAY = "Player 2";
    public const string MATCHES_COLUMN_RESULT = "Result";
    public const string MATCHES_COLUMN_TABLE = "Table";
    private TournMatchSortOrder _sortOrder;

    public void DeleteRound(int round)
    {
      Engine.LogAction((ITournament) null, UserAction.Cancel_Pairings, (object) "Round", (object) round);
      for (int index = this.Count - 1; index >= 0; --index)
      {
        if (this[index].Round == round)
          this.RemoveAt(index);
      }
    }

    public int AddMatch(ITournMatch match)
    {
      this.SortOrder = TournMatchSortOrder.Unsorted;
      match.Players.SortByID();
      this.Add(match);
      return this.Count;
    }

    public int RemoveMatch(ITournMatch match)
    {
      this.SortOrder = TournMatchSortOrder.Unsorted;
      this.Remove(match);
      return this.Count;
    }

    public int Append(ITournMatchArray NewTournMatches)
    {
      this.AddRange((IEnumerable<ITournMatch>) NewTournMatches);
      this.SortOrder = TournMatchSortOrder.Unsorted;
      return this.Count;
    }

    public TournMatchSortOrder SortOrder
    {
      get
      {
        return this._sortOrder;
      }
      set
      {
        this._sortOrder = value;
      }
    }

    public ITournMatchArray UnreportedMatches
    {
      get
      {
        TournMatchArray tournMatchArray = new TournMatchArray();
        foreach (TournMatch tournMatch in (List<ITournMatch>) this)
        {
          if (tournMatch.Round != 0 && !tournMatch.Completed)
            tournMatchArray.AddMatch((ITournMatch) tournMatch);
        }
        return (ITournMatchArray) tournMatchArray;
      }
    }

    public ITournMatchArray GetByPlayer(long PlayerId)
    {
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (TournMatch tournMatch in (List<ITournMatch>) this)
      {
        if (tournMatch.Players.HasPlayer(PlayerId))
          tournMatchArray.AddMatch((ITournMatch) tournMatch);
      }
      return (ITournMatchArray) tournMatchArray;
    }

    public void Randomize()
    {
      TournMatchArray tournMatchArray = new TournMatchArray();
      while (this.Count > 0)
      {
        int index = Common.RandomGenerator.Next(this.Count - 1);
        tournMatchArray.AddMatch(this[index]);
        this.RemoveAt(index);
      }
      this.Append((ITournMatchArray) tournMatchArray);
    }

    public ITournMatch GetByRoundTable(int round, int table)
    {
      if (round < 1 || table < 0)
        return (ITournMatch) null;
      this.SortByRoundTable();
      int index = this.BinarySearch((ITournMatch) new TournMatch()
      {
        Round = round,
        Table = table
      });
      return index < 0 ? (ITournMatch) null : this[index];
    }

    public void SortByRoundTable()
    {
      if (this.SortOrder == TournMatchSortOrder.Round)
        return;
      this.Sort();
      this.SortOrder = TournMatchSortOrder.Round;
    }

    public void SortByRoundTableByesLast()
    {
      if (this.SortOrder == TournMatchSortOrder.RoundTableByesLast)
        return;
      this.SortOrder = TournMatchSortOrder.RoundTableByesLast;
      this.Sort((IComparer<ITournMatch>) new TournMatchSort_ByRoundTableByesLast());
    }

    public void SortByPoints()
    {
      if (this.SortOrder == TournMatchSortOrder.PlayerPoints)
        return;
      this.SortOrder = TournMatchSortOrder.PlayerPoints;
      this.Sort((IComparer<ITournMatch>) new TournMatchSort_ByPoints());
    }

    public void SortByPointsByesLast()
    {
      if (this.SortOrder == TournMatchSortOrder.PlayerPointsByesLast)
        return;
      this.SortOrder = TournMatchSortOrder.PlayerPointsByesLast;
      this.Sort((IComparer<ITournMatch>) new TournMatchSort_ByPointsByesLast());
    }

    public ITournMatchArray GetByRound(int round)
    {
      return this.GetByRound(round, round, false);
    }

    public ITournMatchArray GetByRound(int round, bool hideCompleted)
    {
      return this.GetByRound(round, round, hideCompleted);
    }

    public ITournMatchArray GetByRound(int highRound, int lowRound)
    {
      return this.GetByRound(highRound, lowRound, false);
    }

    public ITournMatchArray GetByRound(
      int highRound,
      int lowRound,
      bool hideCompleted)
    {
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (TournMatch tournMatch in (List<ITournMatch>) this)
      {
        if (tournMatch.Round >= lowRound && tournMatch.Round <= highRound && (tournMatch.Status == TournMatchResult.Incomplete || !hideCompleted))
          tournMatchArray.AddMatch((ITournMatch) tournMatch);
      }
      return (ITournMatchArray) tournMatchArray;
    }

    public ITournMatchArray GetByPoints(int round, int pointCount)
    {
      return this.GetByPoints(round, pointCount, pointCount);
    }

    public ITournMatchArray GetByPoints(int round, int highPoint, int lowPoint)
    {
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (TournMatch tournMatch in (List<ITournMatch>) this)
      {
        if (tournMatch.Points <= highPoint && tournMatch.Points >= lowPoint && tournMatch.Round == round)
          tournMatchArray.AddMatch((ITournMatch) tournMatch);
      }
      return (ITournMatchArray) tournMatchArray;
    }

    public ITournMatchArray GetPairedDown(int round)
    {
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.GetByRound(round))
      {
        if (match.Players.HasPlayer(Player.BYE_ID))
          tournMatchArray.AddMatch(match);
        else if (match.Players[0].Tie1_Wins != match.Players[1].Tie1_Wins)
          tournMatchArray.AddMatch(match);
      }
      return (ITournMatchArray) tournMatchArray;
    }

    public static DataTable GetDataTable(
      ITournMatchArray matches,
      bool viewByPlayer,
      int tableOffset,
      ITournPlayerArray tournamentPlayerList)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("Table", typeof (int)));
      dataTable.Columns.Add(new DataColumn("Player 1 Object", typeof (ITournPlayer)));
      dataTable.Columns.Add(new DataColumn("Player 2 Object", typeof (ITournPlayer)));
      dataTable.Columns.Add(new DataColumn("Player 1", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Player 2", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Result", typeof (string)));
      dataTable.Columns.Add(new DataColumn("MatchObject", typeof (TournMatch)));
      foreach (TournMatch match in (IEnumerable<ITournMatch>) matches)
      {
        DataRow row1 = dataTable.NewRow();
        row1["Table"] = (object) (match.Table + tableOffset);
        if (match.Players.Count < 2)
          throw new Exception(string.Format("Match at round {0} table {1} has an invalid number of players", (object) match.Round, (object) match.Table));
        row1["Player 1 Object"] = (object) match.Players[0];
        row1["Player 2 Object"] = (object) match.Players[1];
        row1["Player 1"] = (object) match.Players[0].ToString();
        row1["Player 2"] = (object) match.Players[1].ToString();
        row1["MatchObject"] = (object) match;
        if (match.Status == TournMatchResult.DoubleLoss)
          row1["Result"] = (object) "Double Loss";
        else if (match.Status == TournMatchResult.Draw)
          row1["Result"] = (object) "Draw";
        else if (match.Status == TournMatchResult.Winner)
        {
          if (match.Winner != Player.BYE_ID)
          {
            if (tournamentPlayerList.HasPlayer(match.Winner))
              row1["Result"] = (object) tournamentPlayerList.FindById(match.Winner).ToString();
            else if (Engine.PlayerList.HasPlayer(match.Winner))
              row1["Result"] = (object) Engine.PlayerList.FindById(match.Winner).ToString();
          }
          else if (match.Winner == Player.BYE_ID)
            row1["Result"] = (object) Player.ByePlayer.FirstName;
        }
        dataTable.Rows.Add(row1);
        if (viewByPlayer && !match.Players[1].IsBye)
        {
          DataRow row2 = dataTable.NewRow();
          row2["Table"] = (object) (match.Table + tableOffset);
          row2["Player 1 Object"] = (object) match.Players[1];
          row2["Player 2 Object"] = (object) match.Players[0];
          row2["Player 1"] = (object) match.Players[1].ToString();
          row2["Player 2"] = (object) match.Players[0].ToString();
          row2["MatchObject"] = (object) match;
          if (match.Status == TournMatchResult.DoubleLoss)
            row2["Result"] = (object) "Double Loss";
          else if (match.Status == TournMatchResult.Draw)
            row2["Result"] = (object) "Draw";
          else if (match.Status == TournMatchResult.Winner)
          {
            if (match.Winner != Player.BYE_ID)
            {
              if (tournamentPlayerList.HasPlayer(match.Winner))
                row2["Result"] = (object) tournamentPlayerList.FindById(match.Winner).ToString();
              else if (Engine.PlayerList.HasPlayer(match.Winner))
                row2["Result"] = (object) Engine.PlayerList.FindById(match.Winner).ToString();
            }
            else if (match.Winner == Player.BYE_ID)
              row2["Result"] = (object) Player.ByePlayer.FirstName;
          }
          dataTable.Rows.Add(row2);
        }
      }
      return dataTable;
    }

    public string XmlKeyElementName
    {
      get
      {
        return this._XmlKeyElementName;
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      this.SortByRoundTable();
      foreach (TournMatch tournMatch in (List<ITournMatch>) this)
      {
        if (tournMatch.Round > 0)
          tournMatch.ToFullXml(writer);
      }
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      TournMatch tournMatch1 = new TournMatch();
      foreach (XmlNode selectNode in node.SelectNodes(tournMatch1.XmlKeyElementName))
      {
        TournMatch tournMatch2 = new TournMatch();
        tournMatch2.FromXml(selectNode);
        if (tournMatch2.Round > 0)
          this.AddMatch((ITournMatch) tournMatch2);
      }
    }
  }
}
