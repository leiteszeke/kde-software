// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.Countries
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.Collections.Generic;

namespace TournamentLibrary.Data_Layer
{
  public class Countries
  {
    private static string[] _countries = new string[3]
    {
      "United States",
      "Canada",
      "United Kingdom"
    };

    public static List<string> GetCountryList()
    {
      return new List<string>((IEnumerable<string>) Countries._countries);
    }
  }
}
