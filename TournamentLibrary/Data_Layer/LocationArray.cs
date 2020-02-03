// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.LocationArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class LocationArray : List<ILocation>, ILocationArray, IList<ILocation>, ICollection<ILocation>, IEnumerable<ILocation>, IEnumerable, IBaseObject
  {
    public string XmlKeyElementName
    {
      get
      {
        return nameof (LocationArray);
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      foreach (IBaseObject baseObject in (List<ILocation>) this)
        baseObject.ToFullXml(writer);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      Location location1 = new Location();
      foreach (XmlNode selectNode in node.SelectNodes(location1.XmlKeyElementName))
      {
        Location location2 = new Location();
        location2.FromXml(selectNode);
        this.Add((ILocation) location2);
      }
    }

    public ILocation FindById(Guid id)
    {
      foreach (Location location in (List<ILocation>) this)
      {
        if (location.Id == id)
          return (ILocation) location;
      }
      return (ILocation) null;
    }

    void ILocationArray.Sort()
    {
      this.Sort();
    }
  }
}
