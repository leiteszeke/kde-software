// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournStaff
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Xml;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournStaff : Player, ITournStaff, IPlayer, IComparable, IBaseObject
  {
    private const string XmlStaffPosition = "XmlStaffPosition";
    private const string XmlStaffPositionCode = "XmlStaffPositionCode";
    private StaffPosition _position;

    public StaffPosition Position
    {
      get
      {
        return this._position;
      }
      set
      {
        this._position = value;
      }
    }

    public TournStaff()
    {
    }

    public TournStaff(IPlayer source)
      : base(source)
    {
    }

    public static string GetName(StaffPosition pos)
    {
      switch (pos)
      {
        case StaffPosition.None:
          return "None";
        case StaffPosition.Organizer:
          return "Organizer";
        case StaffPosition.HeadJudge:
          return "Head Judge";
        case StaffPosition.AssistantHeadJudge:
          return "Assistant Head Judge";
        case StaffPosition.JudgeTeamLead:
          return "Floor Judge - Team Lead";
        case StaffPosition.Judge:
          return "Floor Judge";
        case StaffPosition.Scorekeeper:
          return "Scorekeeper";
        case StaffPosition.EventManager:
          return "Event Manager";
        case StaffPosition.EventStaff:
          return "Event Staff";
        default:
          return string.Empty;
      }
    }

    public override string ToString()
    {
      return string.Format("{0} ({1})", (object) base.ToString(), (object) TournStaff.GetName(this.Position));
    }

    public new string XmlKeyElementName
    {
      get
      {
        return "XmlStaff";
      }
    }

    public new void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      base.ToFullXml(writer);
      writer.WriteElementString("XmlStaffPositionCode", string.Format("{0:00}", (object) (int) this.Position));
      writer.WriteEndElement();
    }

    public new void FromXml(XmlNode node)
    {
      if (node[base.XmlKeyElementName] != null)
        base.FromXml((XmlNode) node[base.XmlKeyElementName]);
      else
        base.FromXml(node);
      if (node["XmlStaffPositionCode"] != null)
        this.Position = (StaffPosition) Convert.ToInt32(node["XmlStaffPositionCode"].InnerText);
      else if (node["XmlStaffPosition"] != null)
        this.Position = (StaffPosition) Enum.Parse(typeof (StaffPosition), node["XmlStaffPosition"].InnerText);
      else
        this.Position = StaffPosition.None;
    }
  }
}
