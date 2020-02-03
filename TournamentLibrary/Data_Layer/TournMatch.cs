// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournMatch
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournMatch : ITournMatch, IComparable, IBaseObject
  {
    private const string _XmlKeyElementName = "TournMatch";
    private const string XmlKeyPlayer = "Player";
    private const string XmlKeyPlayoffMatch = "PlayoffMatch";
    private const string XmlKeyRound = "Round";
    private const string XmlKeyStatus = "Status";
    private const string XmlKeyTable = "Table";
    private const string XmlKeyWinner = "Winner";
    private bool _playoffMatch;
    private int _round;
    private int _table;
    private long _winner;
    private TournMatchResult _status;
    private TournPlayerArray _players;

    public string StatusText
    {
      get
      {
        string str = "";
        switch (this.Status)
        {
          case TournMatchResult.Winner:
            if (this.Players.HasPlayer(this.Winner))
            {
              str = this.Players.FindById(this.Winner).ToString();
              break;
            }
            if (Engine.PlayerList.HasPlayer(this.Winner))
            {
              str = Engine.PlayerList.FindById(this.Winner).ToString();
              break;
            }
            break;
          case TournMatchResult.Draw:
            str = "Draw";
            break;
          case TournMatchResult.DoubleLoss:
            str = "Double Loss";
            break;
        }
        return str;
      }
    }

    public TournMatch()
    {
      this._players = new TournPlayerArray();
      this._winner = Player.BYE_ID;
      this._status = TournMatchResult.Incomplete;
      this._round = 0;
      this._table = 0;
    }

    public TournMatch(ITournMatch match)
    {
      this.Copy(match);
    }

    public void Copy(ITournMatch match)
    {
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      tournPlayerArray.Append(match.Players);
      this._players = new TournPlayerArray();
      this._players.Append((ITournPlayerArray) tournPlayerArray);
      this._winner = match.Winner;
      this._status = match.Status;
      this._round = match.Round;
      this._table = match.Table;
    }

    public ITournPlayerArray Players
    {
      get
      {
        return (ITournPlayerArray) this._players;
      }
    }

    public long Loser
    {
      get
      {
        if (this.Status != TournMatchResult.Winner)
          return Player.BYE_ID;
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
        {
          if (player.ID != this.Winner)
            return player.ID;
        }
        return Player.BYE_ID;
      }
    }

    public long GetOpponentId(long playerId)
    {
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
      {
        if (player.ID != playerId)
          return player.ID;
      }
      return Player.BYE_ID;
    }

    public long Winner
    {
      get
      {
        return this._winner;
      }
      set
      {
        this._winner = value;
      }
    }

    public TournMatchResult Status
    {
      get
      {
        return this._status;
      }
      set
      {
        this._status = value;
      }
    }

    public bool Completed
    {
      get
      {
        return this.Status != TournMatchResult.Incomplete;
      }
    }

    public int Round
    {
      get
      {
        return this._round;
      }
      set
      {
        this._round = value;
      }
    }

    public int Table
    {
      get
      {
        return this._table;
      }
      set
      {
        this._table = value;
      }
    }

    public bool PlayoffMatch
    {
      get
      {
        return this._playoffMatch;
      }
      set
      {
        this._playoffMatch = value;
      }
    }

    public int Points
    {
      get
      {
        int val1 = 0;
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
          val1 = Math.Max(val1, player.Tie1_Wins);
        return val1;
      }
    }

    public int TotalPoints
    {
      get
      {
        int num = 0;
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
          num += player.Tie1_Wins;
        return num;
      }
    }

    public void FromXml(XmlNode node)
    {
      try
      {
        if (node["Winner"].InnerText.Length > 0)
          this.Winner = Convert.ToInt64(node["Winner"].InnerText);
        this.Status = (TournMatchResult) Enum.Parse(typeof (TournMatchResult), node["Status"].InnerText);
        this.Round = Convert.ToInt32(node["Round"].InnerText);
        this.PlayoffMatch = Convert.ToBoolean(node["PlayoffMatch"].InnerText);
        this.Table = Convert.ToInt32(node["Table"].InnerText);
        foreach (XmlNode selectNode in node.SelectNodes("Player"))
        {
          long int64 = Convert.ToInt64(selectNode.InnerText);
          if (int64 == Player.BYE_ID)
            this.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
          else if (Engine.PlayerList.HasPlayer(int64))
            this.AddPlayer((ITournPlayer) new TournPlayer(Engine.PlayerList.FindById(int64)));
          else
            this.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) new Player("(n/a)", "(n/a)", int64)));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int AddPlayer(ITournPlayer player)
    {
      if (!this.Players.HasPlayer(player.ID))
      {
        this.Players.AddPlayer(player);
        this.Players.SortByIDByesLast();
      }
      return this.Players.Count;
    }

    public string XmlKeyElementName
    {
      get
      {
        return nameof (TournMatch);
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Players)
        writer.WriteElementString("Player", player.ID.ToString());
      writer.WriteElementString("Round", this.Round.ToString());
      writer.WriteElementString("Status", Enum.GetName(typeof (TournMatchResult), (object) this.Status));
      writer.WriteElementString("Table", this.Table.ToString());
      writer.WriteElementString("Winner", this.Winner.ToString());
      writer.WriteElementString("PlayoffMatch", this.PlayoffMatch.ToString());
      writer.WriteEndElement();
    }

    public int CompareTo(object obj)
    {
      TournMatch tournMatch = (TournMatch) obj;
      return this.Round.CompareTo(tournMatch.Round) != 0 ? this.Round.CompareTo(tournMatch.Round) : this.Table.CompareTo(tournMatch.Table);
    }
  }
}
