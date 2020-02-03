// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.ITournMatchArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections;
using System.Collections.Generic;

namespace TournamentLibrary.Interfaces
{
  public interface ITournMatchArray : IList<ITournMatch>, ICollection<ITournMatch>, IEnumerable<ITournMatch>, IEnumerable, IBaseObject
  {
    void DeleteRound(int round);

    int AddMatch(ITournMatch match);

    int RemoveMatch(ITournMatch match);

    int Append(ITournMatchArray NewTournMatches);

    void SortByRoundTable();

    void SortByRoundTableByesLast();

    void SortByPoints();

    void SortByPointsByesLast();

    void Randomize();

    TournMatchSortOrder SortOrder { get; set; }

    ITournMatchArray UnreportedMatches { get; }

    ITournMatchArray GetByPlayer(long PlayerId);

    ITournMatch GetByRoundTable(int round, int table);

    ITournMatchArray GetByRound(int round);

    ITournMatchArray GetByRound(int round, bool hideCompleted);

    ITournMatchArray GetByRound(int highRound, int lowRound);

    ITournMatchArray GetByRound(int highRound, int lowRound, bool hideCompleted);

    ITournMatchArray GetByPoints(int round, int pointCount);

    ITournMatchArray GetByPoints(int round, int highPoint, int lowPoint);

    ITournMatchArray GetPairedDown(int round);
  }
}
