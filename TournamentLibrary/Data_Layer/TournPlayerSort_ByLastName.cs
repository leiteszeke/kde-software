// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournPlayerSort_ByLastName
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  internal class TournPlayerSort_ByLastName : IComparer<ITournPlayer>
  {
    public int Compare(ITournPlayer x, ITournPlayer y)
    {
      return x.LastName.CompareTo(y.LastName) != 0 ? x.LastName.CompareTo(y.LastName) : x.FirstName.CompareTo(y.FirstName);
    }
  }
}
