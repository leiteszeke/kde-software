// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Interfaces.IPlayer
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;

namespace TournamentLibrary.Interfaces
{
  public interface IPlayer : IComparable, IBaseObject
  {
    string FirstName { get; set; }

    string LastName { get; set; }

    long ID { get; set; }

    string IDFormatted { get; }

    bool IsBye { get; }

    string FullName { get; }

    string FullNameWithId { get; }
  }
}
