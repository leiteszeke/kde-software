// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ILocationArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface ILocationArray : IList<ILocation>, ICollection<ILocation>, IEnumerable<ILocation>, IEnumerable, IBaseObject
  {
    void Sort();

    ILocation FindById(Guid id);
  }
}
