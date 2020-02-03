// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournStaffArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournStaffArray : List<ITournStaff>, ITournStaffArray, IList<ITournStaff>, ICollection<ITournStaff>, IEnumerable<ITournStaff>, IEnumerable, IBaseObject
  {
    public string XmlKeyElementName
    {
      get
      {
        return "XmlStaffArray";
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      foreach (IBaseObject baseObject in (List<ITournStaff>) this)
        baseObject.ToFullXml(writer);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      TournStaff tournStaff1 = new TournStaff();
      foreach (XmlNode selectNode in node.SelectNodes(tournStaff1.XmlKeyElementName))
      {
        TournStaff tournStaff2 = new TournStaff();
        tournStaff2.FromXml(selectNode);
        this.Add((ITournStaff) tournStaff2);
      }
    }

    public int Append(ITournStaffArray staff)
    {
      this.AddRange((IEnumerable<ITournStaff>) staff);
      return this.Count;
    }

    public void SortByPosition()
    {
      this.Sort((IComparer<ITournStaff>) new TournStaffSort_ByPosition());
    }

    public void SortByLastname()
    {
      this.Sort((IComparer<ITournStaff>) new TournStaffSort_ByLastName());
    }

    public void SortByID()
    {
      this.Sort((IComparer<ITournStaff>) new TournStaffSort_ById());
    }

    public ITournStaff FindById(long ID)
    {
      this.SortByID();
      int index = this.BinarySearch((ITournStaff) new TournStaff((IPlayer) new Player("", "", ID)), (IComparer<ITournStaff>) new TournStaffSort_ById());
      return index < 0 ? (ITournStaff) null : this[index];
    }
  }
}
