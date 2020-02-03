// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournPlayerArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace TournamentLibrary.Interfaces
{
  public interface ITournPlayerArray : IList<ITournPlayer>, ICollection<ITournPlayer>, IEnumerable<ITournPlayer>, IEnumerable, IBaseObject
  {
    int AddPlayer(ITournPlayer player);

    int RemovePlayer(ITournPlayer player);

    int Append(ITournPlayerArray NewTournPlayers);

    int ActivePlayerCount { get; }

    int TempPlayerCount { get; }

    void AssignRanks(int maxRound, bool IncludeDrops);

    void SortByID();

    void SortByIDByesLast();

    void SortByName();

    void SortByLastname();

    void SortByRank();

    ITournPlayer FindById(long ID);

    bool HasPlayer(long ID);

    void ReSort();

    void ForceSort(PlayerSortOrder order);

    DataTable GetOpenDuelingPoints();

    void Shuffle();

    IPlayerArray Downgrade();
  }
}
