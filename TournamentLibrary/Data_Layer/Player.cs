// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.Player
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Xml;
using System.Xml.Serialization;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class Player : IPlayer, IComparable, IBaseObject
  {
    public static long BYE_ID = 0;
    public static Player ByePlayer = new Player("*** BYE ***", "", Player.BYE_ID);
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private const string _XmlKeyElementName = "Player";
    private const string XmlKeyFirstName = "FirstName";
    private const string XmlKeyId = "ID";
    private const string XmlKeyLastName = "LastName";
    private long _ID;

    private string _displayFormattedId
    {
      get
      {
        return Utility.MakeDisplayCOSSY(this.ID);
      }
    }

    public Player()
    {
    }

    public Player(IPlayer player)
      : this(player.FirstName, player.LastName, player.ID)
    {
    }

    public Player(string FirstName, string LastName, long ID)
    {
      this.FirstName = FirstName;
      this.LastName = LastName;
      this.ID = ID;
    }

    public static bool ValidateNumber(string ID)
    {
      foreach (char c in ID)
      {
        if (!char.IsDigit(c))
          return false;
      }
      return true;
    }

    [XmlElement]
    public string FirstName
    {
      get
      {
        return this._firstName == null ? string.Empty : this._firstName;
      }
      set
      {
        if (value == null)
          return;
        this._firstName = value.Trim();
      }
    }

    [XmlElement]
    public string LastName
    {
      get
      {
        return this._lastName == null ? string.Empty : this._lastName;
      }
      set
      {
        if (value == null)
          return;
        this._lastName = value.Trim();
      }
    }

    [XmlIgnore]
    public string FullName
    {
      get
      {
        if (this.FirstName.Length > 0 && this.LastName.Length > 0)
          return string.Format("{0}, {1}", (object) this.LastName, (object) this.FirstName);
        return this.FirstName.Length > 0 ? this.FirstName : this.LastName;
      }
    }

    [XmlIgnore]
    public string FullNameWithId
    {
      get
      {
        return this.IsBye ? this.FullName : this.FullName + " (" + this._displayFormattedId + ")";
      }
    }

    [XmlIgnore]
    public string IDFormatted
    {
      get
      {
        return this._displayFormattedId;
      }
    }

    [XmlElement]
    public long ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    public int CompareTo(object obj)
    {
      return new PlayerSort_ById().Compare((IPlayer) this, (IPlayer) obj);
    }

    public override string ToString()
    {
      if (this.IsBye)
        return this.FullName;
      string str = "";
      if (Settings.ShowPlayerIds_ShowOnScreen)
        str = " (" + this._displayFormattedId + ")";
      return this.FullName + str;
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      writer.WriteElementString("ID", this._displayFormattedId);
      writer.WriteElementString("FirstName", this.FirstName);
      writer.WriteElementString("LastName", this.LastName);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      try
      {
        this.ID = Common.ConvertInnerTextToLong((XmlNode) node["ID"], Player.BYE_ID);
        this.FirstName = Common.ConvertInnerTextToString((XmlNode) node["FirstName"], string.Empty);
        this.LastName = Common.ConvertInnerTextToString((XmlNode) node["LastName"], string.Empty);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    [XmlIgnore]
    public string XmlKeyElementName
    {
      get
      {
        return nameof (Player);
      }
    }

    [XmlIgnore]
    public bool IsBye
    {
      get
      {
        return this.ID.CompareTo(Player.BYE_ID) == 0;
      }
    }
  }
}
