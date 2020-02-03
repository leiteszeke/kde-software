// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.PlayerPoints
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;

namespace TournamentLibrary.Data_Layer
{
  internal class PlayerPoints
  {
    public long PlayerId = Player.BYE_ID;
    public List<long> Opps = new List<long>();
    public const int POINTSPERMATCH = 3;
    public const int POINTSPERTIE = 1;
    public int Draws;
    public int Matches;
    public int OppDraws;
    public int OppMatches;
    public int OppOppDraws;
    public int OppOppMatches;
    public int OppOppWins;
    public int OppWins;
    public int PlayoffPoints;
    public int Wins;

    public int OppOppWinPoints
    {
      get
      {
        return this.OppOppWins * 3 + this.OppOppDraws;
      }
    }

    public int OppWinPoints
    {
      get
      {
        return this.OppWins * 3 + this.OppDraws;
      }
    }

    public int WinPoints
    {
      get
      {
        return this.Wins * 3 + this.Draws;
      }
    }

    public PlayerPoints()
    {
    }

    public PlayerPoints(long playerId)
    {
      this.PlayerId = playerId;
    }
  }
}
