// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.InfractionListItem
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.BusinessLogic
{
  public class InfractionListItem
  {
    public InfractionEnum Value;

    public InfractionListItem(InfractionEnum inf)
    {
      this.Value = inf;
    }

    public override string ToString()
    {
      return PenaltyClass.GetName(this.Value);
    }
  }
}
