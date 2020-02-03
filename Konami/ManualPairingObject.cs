// Decompiled with JetBrains decompiler
// Type: Konami.ManualPairingObject
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using TournamentLibrary.Interfaces;

namespace Konami
{
  internal class ManualPairingObject
  {
    public ITournPlayer _player;

    public override string ToString()
    {
      return this._player == null ? "" : string.Format("{0} ({1} points)", (object) this._player.FullName, (object) this._player.Tie1_Wins);
    }

    public ManualPairingObject(ITournPlayer player)
    {
      this._player = player;
    }
  }
}
