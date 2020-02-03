// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.Location
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
  public class Location : ILocation, IBaseObject, IComparer<ILocation>, IComparable<ILocation>
  {
    private string _Address1 = string.Empty;
    private string _Address2 = string.Empty;
    private string _City = string.Empty;
    private string _Country = string.Empty;
    private string _Name = string.Empty;
    private string _Phone = string.Empty;
    private string _State = string.Empty;
    private string _WebSite = string.Empty;
    private string _Zip = string.Empty;
    private const string XmlKeyAddress1 = "Address1";
    private const string XmlKeyAddress2 = "Address2";
    private const string XmlKeyCity = "City";
    private const string XmlKeyCountry = "Country";
    private const string XmlKeyId = "Id";
    private const string XmlKeyName = "Name";
    private const string XmlKeyPhone = "Phone";
    private const string XmlKeyState = "State";
    private const string XmlKeyWebSite = "WebSite";
    private const string XmlKeyZip = "Zip";
    private Guid _Id;

    public bool IsEmpty
    {
      get
      {
        return this.Address1 == string.Empty && this.Address2 == string.Empty && (this.City == string.Empty && this.Country == string.Empty) && (this.Name == string.Empty && this.Phone == string.Empty && (this.State == string.Empty && this.WebSite == string.Empty)) && this.Zip == string.Empty;
      }
    }

    public Location()
    {
      this._Id = Guid.NewGuid();
    }

    public Location(ILocation otherLoc)
    {
      this.Copy(otherLoc);
    }

    public override string ToString()
    {
      return this.Name;
    }

    public void Copy(ILocation otherLoc)
    {
      this.Id = otherLoc.Id;
      this.Name = otherLoc.Name;
      this.Address1 = otherLoc.Address1;
      this.Address2 = otherLoc.Address2;
      this.City = otherLoc.City;
      this.State = otherLoc.State;
      this.Country = otherLoc.Country;
      this.Zip = otherLoc.Zip;
      this.Phone = otherLoc.Phone;
      this.WebSite = otherLoc.WebSite;
    }

    public Guid Id
    {
      get
      {
        return this._Id;
      }
      set
      {
        this._Id = value;
      }
    }

    public string Name
    {
      get
      {
        return this._Name == null ? string.Empty : this._Name;
      }
      set
      {
        if (value == null)
          return;
        this._Name = value;
      }
    }

    public string Address1
    {
      get
      {
        return this._Address1;
      }
      set
      {
        if (value == null)
          return;
        this._Address1 = value;
      }
    }

    public string Address2
    {
      get
      {
        return this._Address2;
      }
      set
      {
        if (value == null)
          return;
        this._Address2 = value;
      }
    }

    public string City
    {
      get
      {
        return this._City;
      }
      set
      {
        if (value == null)
          return;
        this._City = value;
      }
    }

    public string State
    {
      get
      {
        return this._State;
      }
      set
      {
        if (value == null)
          return;
        this._State = value;
      }
    }

    public string Country
    {
      get
      {
        return this._Country;
      }
      set
      {
        if (value == null)
          return;
        this._Country = value;
      }
    }

    public string Zip
    {
      get
      {
        return this._Zip;
      }
      set
      {
        if (value == null)
          return;
        this._Zip = value;
      }
    }

    public string Phone
    {
      get
      {
        return this._Phone;
      }
      set
      {
        if (value == null)
          return;
        this._Phone = value;
      }
    }

    public string WebSite
    {
      get
      {
        return this._WebSite;
      }
      set
      {
        if (value == null)
          return;
        this._WebSite = value;
      }
    }

    public string XmlKeyElementName
    {
      get
      {
        return nameof (Location);
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      writer.WriteElementString("Id", this.Id.ToString());
      writer.WriteElementString("Name", this.Name);
      writer.WriteElementString("Address1", this.Address1);
      writer.WriteElementString("Address2", this.Address2);
      writer.WriteElementString("City", this.City);
      writer.WriteElementString("State", this.State);
      writer.WriteElementString("Country", this.Country);
      writer.WriteElementString("Zip", this.Zip);
      writer.WriteElementString("Phone", this.Phone);
      writer.WriteElementString("WebSite", this.WebSite);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      this.Id = new Guid(node["Id"].InnerText);
      this.Name = Common.ConvertInnerTextToString((XmlNode) node["Name"], string.Empty);
      this.Address1 = Common.ConvertInnerTextToString((XmlNode) node["Address1"], string.Empty);
      this.Address2 = Common.ConvertInnerTextToString((XmlNode) node["Address2"], string.Empty);
      this.City = Common.ConvertInnerTextToString((XmlNode) node["City"], string.Empty);
      this.State = Common.ConvertInnerTextToString((XmlNode) node["State"], string.Empty);
      this.Country = Common.ConvertInnerTextToString((XmlNode) node["Country"], string.Empty);
      this.Zip = Common.ConvertInnerTextToString((XmlNode) node["Zip"], string.Empty);
      this.Phone = Common.ConvertInnerTextToString((XmlNode) node["Phone"], string.Empty);
      this.WebSite = Common.ConvertInnerTextToString((XmlNode) node["WebSite"], string.Empty);
    }

    public int Compare(ILocation x, ILocation y)
    {
      if (x.Id == y.Id)
        return 0;
      if (x.Name.CompareTo(y.Name) != 0)
        return x.Name.CompareTo(y.Name);
      if (x.Country.CompareTo(y.Country) != 0)
        return x.Country.CompareTo(y.Country);
      if (x.State.CompareTo(y.State) != 0)
        return x.State.CompareTo(y.State);
      return x.City.CompareTo(y.City) != 0 ? x.City.CompareTo(y.City) : x.Address1.CompareTo(y.Address1);
    }

    public int CompareTo(ILocation other)
    {
      ILocation location1 = (ILocation) this;
      ILocation location2 = other;
      if (location1.Id == location2.Id)
        return 0;
      if (location1.Name.CompareTo(location2.Name) != 0)
        return location1.Name.CompareTo(location2.Name);
      if (location1.Country.CompareTo(location2.Country) != 0)
        return location1.Country.CompareTo(location2.Country);
      if (location1.State.CompareTo(location2.State) != 0)
        return location1.State.CompareTo(location2.State);
      return location1.City.CompareTo(location2.City) != 0 ? location1.City.CompareTo(location2.City) : location1.Address1.CompareTo(location2.Address1);
    }
  }
}
