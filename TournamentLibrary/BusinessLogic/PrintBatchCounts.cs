// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.PrintBatchCounts
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;

namespace TournamentLibrary.BusinessLogic
{
  public class PrintBatchCounts
  {
    public Dictionary<Engine.PrintPairingsAction, int> BatchCounts = new Dictionary<Engine.PrintPairingsAction, int>();

    public int GetCount(Engine.PrintPairingsAction action)
    {
      return this.BatchCounts.ContainsKey(action) ? this.BatchCounts[action] : 0;
    }

    public int AddCount(Engine.PrintPairingsAction action, int delta)
    {
      if (!this.BatchCounts.ContainsKey(action))
        this.BatchCounts.Add(action, 0);
      this.BatchCounts[action] = Math.Max(0, this.BatchCounts[action] + delta);
      if (action == Engine.PrintPairingsAction.ResultSlips)
        this.BatchCounts[action] = Math.Min(1, this.BatchCounts[action]);
      return this.BatchCounts[action];
    }
  }
}
