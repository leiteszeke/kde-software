// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.Common
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.IO;
using System.Xml;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.BusinessLogic
{
  public static class Common
  {
    public static Random RandomGenerator = new Random();

    public static InfractionEnumCodes GetCode(InfractionEnum infraction)
    {
      switch (infraction)
      {
        case InfractionEnum.None:
          return InfractionEnumCodes.Other;
        case InfractionEnum.ProceduralErrorMinor:
          return InfractionEnumCodes.ProceduralError;
        case InfractionEnum.ProceduralErrorMajor:
          return InfractionEnumCodes.ProceduralError;
        case InfractionEnum.ProceduralErrorStrict:
          return InfractionEnumCodes.ProceduralError;
        case InfractionEnum.TardinessMajor:
          return InfractionEnumCodes.Tardiness;
        case InfractionEnum.TardinessStrict:
          return InfractionEnumCodes.Tardiness;
        case InfractionEnum.DeckErrorMinor:
          return InfractionEnumCodes.DeckError;
        case InfractionEnum.DeckErrorMajor:
          return InfractionEnumCodes.DeckError;
        case InfractionEnum.DrawingCardsMinor:
          return InfractionEnumCodes.DrawingCards;
        case InfractionEnum.DrawingCardsMajor:
          return InfractionEnumCodes.DrawingCards;
        case InfractionEnum.MarkedCardsMinor:
          return InfractionEnumCodes.MarkedCards;
        case InfractionEnum.MarkedCardsMajor:
          return InfractionEnumCodes.MarkedCards;
        case InfractionEnum.SlowPlayMinor:
          return InfractionEnumCodes.SlowPlay;
        case InfractionEnum.UnsportingConductMinor:
          return InfractionEnumCodes.UnsportingConduct;
        case InfractionEnum.UnsportingConductMajor:
          return InfractionEnumCodes.UnsportingConduct;
        case InfractionEnum.UnsportingConductSevere:
          return InfractionEnumCodes.UnsportingConduct;
        case InfractionEnum.UnsportingConductCheating:
          return InfractionEnumCodes.UnsportingConduct;
        default:
          return InfractionEnumCodes.Other;
      }
    }

    public static int ConvertInnerTextToInt(XmlNode node, int defaultValue)
    {
      if (node == null)
        return defaultValue;
      return node.HasChildNodes ? Common.ConvertStringToInt((object) node.ChildNodes[0].Value, defaultValue) : Common.ConvertStringToInt((object) node.InnerText, defaultValue);
    }

    public static long ConvertInnerTextToLong(XmlNode node, long defaultValue)
    {
      if (node == null)
        return defaultValue;
      return node.HasChildNodes ? Common.ConvertStringToLong((object) node.ChildNodes[0].Value, defaultValue) : Common.ConvertStringToLong((object) node.InnerText, defaultValue);
    }

    public static int ConvertStringToInt(object target, int defaultValue)
    {
      int num = defaultValue;
      try
      {
        num = Convert.ToInt32(target);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public static long ConvertStringToLong(object target, long defaultValue)
    {
      long num = defaultValue;
      try
      {
        num = Convert.ToInt64(target);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public static string CleanFilename(string filename)
    {
      string str = filename;
      foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
        str = str.Replace(invalidFileNameChar, '_');
      foreach (char invalidPathChar in Path.GetInvalidPathChars())
        str = str.Replace(invalidPathChar, '_');
      return str;
    }

    public static string ConvertInnerTextToString(XmlNode node, string defaultValue)
    {
      if (node == null)
        return defaultValue;
      return node.HasChildNodes ? node.ChildNodes[0].Value : node.Value;
    }

    public static string ConvertToString(object target, string defaultValue)
    {
      string str = defaultValue;
      try
      {
        str = Convert.ToString(target);
      }
      catch (Exception ex)
      {
      }
      return str;
    }
  }
}
