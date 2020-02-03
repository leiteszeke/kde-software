// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.PenaltyClass
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class PenaltyClass : IPenalty, IBaseObject, IComparable
  {
    private IPlayer _player = (IPlayer) new TournamentLibrary.Data_Layer.Player();
    private ITournStaff _judge = (ITournStaff) new TournStaff();
    private string _notes = string.Empty;
    private const string _XmlKeyElementName = "PlayerPenalty";
    private const string XmlKeyInfraction = "Infraction";
    private const string XmlKeyInfractionCode = "InfractionCode";
    private const string XmlKeyJudge = "Judge";
    private const string XmlKeyNotes = "Notes";
    private const string XmlKeyPenalty = "Penalty";
    private const string XmlKeyPenaltyCode = "PenaltyCode";
    private const string XmlKeyPlayer = "Player";
    private const string XmlKeyRound = "Round";
    private InfractionEnum _infraction;
    private int _round;
    private PenaltyEnum _penalty;

    public ITournStaff Judge
    {
      get
      {
        return this._judge;
      }
      set
      {
        this._judge = value;
      }
    }

    public static PenaltyEnum GetDefaultPenalty(InfractionEnum infraction)
    {
      switch (infraction)
      {
        case InfractionEnum.ProceduralErrorMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.ProceduralErrorMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.ProceduralErrorStrict:
          return PenaltyEnum.MatchLoss;
        case InfractionEnum.TardinessMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.TardinessStrict:
          return PenaltyEnum.MatchLoss;
        case InfractionEnum.DeckErrorMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.DeckErrorMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.DrawingCardsMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.DrawingCardsMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.MarkedCardsMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.MarkedCardsMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.SlowPlayMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.UnsportingConductMinor:
          return PenaltyEnum.Warning;
        case InfractionEnum.UnsportingConductMajor:
          return PenaltyEnum.GameLoss;
        case InfractionEnum.UnsportingConductSevere:
          return PenaltyEnum.DisqualificationWithoutPrize;
        case InfractionEnum.UnsportingConductCheating:
          return PenaltyEnum.DisqualificationWithoutPrize;
        default:
          return PenaltyEnum.Warning;
      }
    }

    public static string GetName(InfractionEnum infraction)
    {
      switch (infraction)
      {
        case InfractionEnum.None:
          return "None";
        case InfractionEnum.ProceduralErrorMinor:
          return "Procedural Error - Minor";
        case InfractionEnum.ProceduralErrorMajor:
          return "Procedural Error - Major";
        case InfractionEnum.ProceduralErrorStrict:
          return "Procedural Error - Strict";
        case InfractionEnum.TardinessMajor:
          return "Tardiness - Major";
        case InfractionEnum.TardinessStrict:
          return "Tardiness - Strict";
        case InfractionEnum.DeckErrorMinor:
          return "Deck Error - Minor";
        case InfractionEnum.DeckErrorMajor:
          return "Deck Error - Major";
        case InfractionEnum.DrawingCardsMinor:
          return "Drawing Cards - Minor";
        case InfractionEnum.DrawingCardsMajor:
          return "Drawing Cards - Major";
        case InfractionEnum.MarkedCardsMinor:
          return "Marked Cards - Minor";
        case InfractionEnum.MarkedCardsMajor:
          return "Marked Cards - Major";
        case InfractionEnum.SlowPlayMinor:
          return "Slow Play - Minor";
        case InfractionEnum.UnsportingConductMinor:
          return "Unsporting Conduct - Minor";
        case InfractionEnum.UnsportingConductMajor:
          return "Unsporting Conduct - Major";
        case InfractionEnum.UnsportingConductSevere:
          return "Unsporting Conduct - Severe";
        case InfractionEnum.UnsportingConductCheating:
          return "Unsporting Conduct - Cheating";
        default:
          return string.Empty;
      }
    }

    public IPlayer Player
    {
      get
      {
        return this._player;
      }
      set
      {
        this._player = value;
      }
    }

    public InfractionEnum Infraction
    {
      get
      {
        return this._infraction;
      }
      set
      {
        this._infraction = value;
      }
    }

    public PenaltyEnum Penalty
    {
      get
      {
        return this._penalty;
      }
      set
      {
        this._penalty = value;
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

    public string XmlKeyElementName
    {
      get
      {
        return "PlayerPenalty";
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      writer.WriteElementString("Infraction", Enum.GetName(typeof (InfractionEnum), (object) this.Infraction));
      writer.WriteElementString("InfractionCode", string.Format("{0:00}", (object) (int) Common.GetCode(this.Infraction)));
      writer.WriteElementString("PenaltyCode", string.Format("{0:00}", (object) (int) this.Penalty));
      writer.WriteElementString("Player", this.Player.IDFormatted);
      writer.WriteElementString("Judge", this.Judge.IDFormatted);
      writer.WriteElementString("Round", this.Round.ToString());
      writer.WriteElementString("Notes", this.Notes);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      try
      {
        if (node["Player"] != null)
        {
          long int64 = Convert.ToInt64(node["Player"].InnerText);
          this.Player = Engine.PlayerList.FindById(int64) ?? (IPlayer) new TournamentLibrary.Data_Layer.Player("", "", int64);
        }
        if (node["Judge"] != null)
        {
          this.Judge = (ITournStaff) new TournStaff((IPlayer) new TournamentLibrary.Data_Layer.Player("", "", Convert.ToInt64(node["Judge"].InnerText)));
          this.Judge.Position = StaffPosition.Judge;
        }
        this.Infraction = (InfractionEnum) Enum.Parse(typeof (InfractionEnum), node["Infraction"].InnerText);
        if (node["Penalty"] != null)
        {
          switch ((OldPenaltyEnum) Enum.Parse(typeof (OldPenaltyEnum), node["Penalty"].InnerText))
          {
            case OldPenaltyEnum.None:
              this.Penalty = PenaltyEnum.None;
              break;
            case OldPenaltyEnum.Caution:
              this.Penalty = PenaltyEnum.Warning;
              break;
            case OldPenaltyEnum.Warning:
              this.Penalty = PenaltyEnum.Warning;
              break;
            case OldPenaltyEnum.GameLoss:
              this.Penalty = PenaltyEnum.GameLoss;
              break;
            case OldPenaltyEnum.MatchLoss:
              this.Penalty = PenaltyEnum.MatchLoss;
              break;
            case OldPenaltyEnum.Disqualification:
              this.Penalty = PenaltyEnum.DisqualificationWithoutPrize;
              break;
            default:
              this.Penalty = PenaltyEnum.None;
              break;
          }
        }
        else
          this.Penalty = node["PenaltyCode"] == null ? PenaltyEnum.None : (PenaltyEnum) int.Parse(node["PenaltyCode"].InnerText);
        this.Round = Convert.ToInt32(node["Round"].InnerText);
        this.Notes = Common.ConvertInnerTextToString((XmlNode) node["Notes"], string.Empty);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int CompareTo(object obj)
    {
      PenaltyClass penaltyClass = (PenaltyClass) obj;
      if (this.Player.FullName != penaltyClass.Player.FullName)
        return this.Player.FullName.CompareTo(penaltyClass.Player.FullName);
      if (this.Player.ID != penaltyClass.Player.ID)
        return this.Player.ID.CompareTo(penaltyClass.Player.ID);
      if (this.Penalty != penaltyClass.Penalty)
        return this.Penalty.CompareTo((object) penaltyClass.Penalty);
      if (this.Round != penaltyClass.Round)
        return this.Round.CompareTo(penaltyClass.Round);
      if (this.Penalty != penaltyClass.Penalty)
        return this.Penalty.CompareTo((object) penaltyClass.Penalty);
      return this.Infraction != penaltyClass.Infraction ? this.Infraction.CompareTo((object) penaltyClass.Infraction) : this.Round.CompareTo(penaltyClass.Round);
    }
  }
}
