// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.IPlayerArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface IPlayerArray : IList<IPlayer>, ICollection<IPlayer>, IEnumerable<IPlayer>, IEnumerable, IBaseObject
  {
    int AddPlayer(IPlayer player);

    int DeletePlayer(IPlayer player);

    IPlayerArray Append(IPlayerArray NewPlayers);

    IPlayerArray AddRange(IPlayerArray NewPlayers);

    void SortByID();

    void SortByIDByesLast();

    void SortByFirstName();

    void SortByLastname();

    IPlayer FindById(long ID);

    bool HasPlayer(long ID);

    bool ChangePlayerId(long oldPlayerId, long newPlayerId);

    void ReSort();

    void ForceSort(PlayerSortOrder order);

    IPlayer MatchName(string firstFragment, string lastFragment, bool firstName);
  }
}
