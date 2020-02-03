// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.IBaseObject
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Xml;

namespace TournamentLibrary.Interfaces
{
  public interface IBaseObject
  {
    string XmlKeyElementName { get; }

    void ToFullXml(XmlWriter writer);

    void FromXml(XmlNode node);
  }
}
