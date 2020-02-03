// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.PlayerSort_ByLastName
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class PlayerSort_ByLastName : IComparer<IPlayer>
  {
    public int Compare(IPlayer x, IPlayer y)
    {
      int num = x.LastName.CompareTo(y.LastName);
      return num == 0 ? x.FirstName.CompareTo(y.FirstName) : num;
    }
  }
}
