﻿// Decompiled with JetBrains decompiler
// Type: DropListItem
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

public class DropListItem
{
  public string Name = string.Empty;
  public object Value;

  public DropListItem(string name, object val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString()
  {
    return this.Name;
  }
}
