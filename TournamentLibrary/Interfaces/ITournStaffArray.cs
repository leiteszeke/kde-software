// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournStaffArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface ITournStaffArray : IList<ITournStaff>, ICollection<ITournStaff>, IEnumerable<ITournStaff>, IEnumerable, IBaseObject
  {
    int Append(ITournStaffArray staff);

    void SortByPosition();

    void SortByLastname();

    void SortByID();

    ITournStaff FindById(long ID);
  }
}
