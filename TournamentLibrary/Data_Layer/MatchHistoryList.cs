// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.MatchHistoryList
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class MatchHistoryList : Dictionary<long, TournPlayerArray>
  {
    public bool HasPlayed(ITournPlayer p1, ITournPlayer p2)
    {
      if (this.ContainsKey(p1.ID))
        return this[p1.ID].HasPlayer(p2.ID);
      return this.ContainsKey(p2.ID) && this[p2.ID].HasPlayer(p1.ID);
    }

    public void AddMatch(ITournMatch match)
    {
      foreach (ITournPlayer player1 in (IEnumerable<ITournPlayer>) match.Players)
      {
        if (!player1.IsBye)
        {
          foreach (ITournPlayer player2 in (IEnumerable<ITournPlayer>) match.Players)
          {
            if (!player2.IsBye && player1.ID != player2.ID)
            {
              TournPlayerArray tournPlayerArray = new TournPlayerArray();
              if (this.ContainsKey(player1.ID))
                tournPlayerArray = this[player1.ID];
              else
                this.Add(player1.ID, tournPlayerArray);
              tournPlayerArray.AddPlayer(player2);
            }
          }
        }
      }
    }
  }
}
