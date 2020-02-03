// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournamentArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournamentArray : List<ITournament>, ITournamentArray, IList<ITournament>, ICollection<ITournament>, IEnumerable<ITournament>, IEnumerable, IBaseObject
  {
    public string XmlKeyElementName
    {
      get
      {
        return nameof (TournamentArray);
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      foreach (IBaseObject baseObject in (List<ITournament>) this)
        baseObject.ToFullXml(writer);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      Tournament tournament1 = new Tournament();
      foreach (XmlNode selectNode in node.SelectNodes(tournament1.XmlKeyElementName))
      {
        Tournament tournament2 = new Tournament();
        tournament2.FromXml(selectNode);
        this.Add((ITournament) tournament2);
      }
    }

    public bool HasId(string id)
    {
      this.Sort();
      foreach (Tournament tournament in (List<ITournament>) this)
      {
        if (tournament.ID == id)
          return true;
      }
      return false;
    }

    public ITournament FindById(string id)
    {
      this.Sort();
      foreach (Tournament tournament in (List<ITournament>) this)
      {
        if (tournament.ID == id)
          return (ITournament) tournament;
      }
      return (ITournament) null;
    }
  }
}
