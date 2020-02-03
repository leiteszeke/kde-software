// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournamentArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface ITournamentArray : IList<ITournament>, ICollection<ITournament>, IEnumerable<ITournament>, IEnumerable, IBaseObject
  {
    bool HasId(string id);

    ITournament FindById(string id);
  }
}
