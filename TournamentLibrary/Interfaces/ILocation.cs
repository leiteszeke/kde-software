// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ILocation
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface ILocation : IBaseObject, IComparer<ILocation>, IComparable<ILocation>
  {
    Guid Id { get; set; }

    string Name { get; set; }

    string Address1 { get; set; }

    string Address2 { get; set; }

    string City { get; set; }

    string State { get; set; }

    string Country { get; set; }

    string Zip { get; set; }

    string Phone { get; set; }

    string WebSite { get; set; }

    bool IsEmpty { get; }

    void Copy(ILocation otherLoc);
  }
}
