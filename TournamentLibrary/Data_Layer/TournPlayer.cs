// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournPlayer
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournPlayer : Player, ITournPlayer, IPlayer, IComparable, IBaseObject
  {
    private int _assignedSeat = -1;
    private string _notes = string.Empty;
    private const int TIE_SPACES = 5;
    private const string _XmlKeyElementName = "TournPlayer";
    private const string XmlAssignedSeat = "AssignedSeat";
    private const string XmlKeyDropReason = "DropReason";
    private const string XmlKeyDropRound = "DropRound";
    private const string XmlKeyPlayoffPoints = "PlayoffPoints";
    private const string XmlKeyPoints = "Points";
    private const string XmlKeyRank = "Rank";
    private const string XmlKeyWins = "Wins";
    private const string XmlNotes = "Notes";
    private const string XmlOpenDueling = "OpenDueling";
    private CutType _dropReason;
    private int _dropRound;
    private int _matchCount;
    private int _openDuelingPoints;
    private int _playoffPoints;
    private int _rank;
    private int _tie1;
    private int _tie2;
    private int _tie3;
    private int _tie4;

    public CutType DropReason
    {
      get
      {
        return this._dropReason;
      }
      set
      {
        this._dropReason = value;
      }
    }

    public TournPlayer()
    {
    }

    public TournPlayer(IPlayer player)
      : base(player)
    {
    }

    public TournPlayer(TournPlayer player)
      : base(player.FirstName, player.LastName, player.ID)
    {
      this._dropRound = player.DropRound;
      this._matchCount = player.MatchCount;
      this._playoffPoints = player.PlayoffPoints;
      this._tie1 = player._tie1;
      this._tie2 = player._tie2;
      this._tie3 = player._tie3;
      this._tie4 = player._tie4;
      this._openDuelingPoints = player._openDuelingPoints;
    }

    public int CompareRank(ITournPlayer other)
    {
      return new TournPlayerSort_ByRank().Compare((ITournPlayer) this, other);
    }

    public override string ToString()
    {
      return this.IsActive || this.IsBye ? base.ToString() : string.Format("{0} ({1} - Round {2})", (object) base.ToString(), (object) this.DropReason, (object) this.DropRound);
    }

    public int DropRound
    {
      get
      {
        return this._dropRound;
      }
      set
      {
        this._dropRound = value;
      }
    }

    public bool IsActive
    {
      get
      {
        return this.DropRound == 0 || this.DropReason == CutType.Active;
      }
    }

    public void ClearTies()
    {
      this.Tie1_Wins = 0;
      this.Tie2_Points = 0;
      this.MatchCount = 0;
      this.PlayoffPoints = 0;
    }

    public int Rank
    {
      get
      {
        return this._rank;
      }
      set
      {
        this._rank = value;
      }
    }

    public int Points
    {
      get
      {
        return this.Tie1_Wins * 3;
      }
    }

    public int Tie1_Wins
    {
      get
      {
        return this._tie1;
      }
      set
      {
        this._tie1 = value;
      }
    }

    public int Tie2_Points
    {
      get
      {
        return this._tie2;
      }
      set
      {
        this._tie2 = value;
      }
    }

    public int OpenDuelingPoints
    {
      get
      {
        return this._openDuelingPoints;
      }
      set
      {
        this._openDuelingPoints = value;
      }
    }

    public int MatchCount
    {
      get
      {
        return this._matchCount;
      }
      set
      {
        this._matchCount = value;
      }
    }

    public int PlayoffPoints
    {
      get
      {
        return this._playoffPoints;
      }
      set
      {
        this._playoffPoints = value;
      }
    }

    public int AssignedSeat
    {
      get
      {
        return this._assignedSeat;
      }
      set
      {
        this._assignedSeat = value;
      }
    }

    public string Notes
    {
      get
      {
        return this._notes;
      }
      set
      {
        this._notes = value;
      }
    }

    int IComparable.CompareTo(object obj)
    {
      return this.CompareRank((ITournPlayer) obj);
    }

    public new void FromXml(XmlNode node)
    {
      if (node[base.XmlKeyElementName] != null)
        base.FromXml((XmlNode) node[base.XmlKeyElementName]);
      else
        base.FromXml(node);
      this.DropRound = Common.ConvertInnerTextToInt((XmlNode) node["DropRound"], this.DropRound);
      if (node["DropReason"] != null)
        this.DropReason = (CutType) Enum.Parse(typeof (CutType), node["DropReason"].InnerText);
      this.PlayoffPoints = Common.ConvertInnerTextToInt((XmlNode) node["PlayoffPoints"], this.PlayoffPoints);
      this.Rank = Common.ConvertInnerTextToInt((XmlNode) node["Rank"], this.Rank);
      this.Tie1_Wins = Common.ConvertInnerTextToInt((XmlNode) node["Wins"], this.Tie1_Wins);
      this.Tie2_Points = Common.ConvertInnerTextToInt((XmlNode) node["Points"], this.Tie2_Points);
      this.OpenDuelingPoints = Common.ConvertInnerTextToInt((XmlNode) node["OpenDueling"], this.OpenDuelingPoints);
      this.AssignedSeat = Common.ConvertInnerTextToInt((XmlNode) node["AssignedSeat"], this.AssignedSeat);
      this.Notes = Common.ConvertInnerTextToString((XmlNode) node["Notes"], string.Empty);
    }

    public new string XmlKeyElementName
    {
      get
      {
        return nameof (TournPlayer);
      }
    }

    public new void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      base.ToFullXml(writer);
      writer.WriteElementString("DropRound", this.DropRound.ToString());
      writer.WriteElementString("Rank", this.Rank.ToString());
      writer.WriteElementString("PlayoffPoints", this.PlayoffPoints.ToString());
      writer.WriteElementString("Wins", this.Tie1_Wins.ToString());
      writer.WriteElementString("Points", this.Tie2_Points.ToString());
      writer.WriteElementString("OpenDueling", this.OpenDuelingPoints.ToString());
      writer.WriteElementString("DropReason", Enum.GetName(typeof (CutType), (object) this.DropReason));
      writer.WriteElementString("AssignedSeat", this.AssignedSeat.ToString());
      writer.WriteElementString("Notes", this.Notes);
      writer.WriteEndElement();
    }
  }
}
