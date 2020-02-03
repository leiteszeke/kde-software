// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.BusinessLogic.Settings
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using Microsoft.Win32;
using System.Drawing;

namespace TournamentLibrary.BusinessLogic
{
  public class Settings
  {
    public static bool ShowPlayerIds_ShowOnPrintouts = false;
    public static bool ShowPlayerIds_ShowOnScreen = false;
    public static bool ToolBar_IconsAndText = false;
    public static bool ToolBar_IconsOnly = true;
    public static bool ToolBar_TextOnly = false;
    public static string DataStorageFolder = "(no folder)";
    public static string PrinterFont = "Arial";
    public static string PrinterFontSize = "10";
    public static Size ToolBarButtonSize = new Size(16, 16);
    private const string APP_KEY = "HKEY_CURRENT_USER\\Software\\Konami\\TournamentSoftware";
    public const string FILENAME_GLOBALPLAYERS = "AllPlayers.XML";
    public const string FILENAME_LOCATIONS = "Locations.XML";
    public const string REGKEY_DATADIRECTORY = "DataDirectory";
    public const string EMPTY_TOURN_ID = "0";

    public static string GetRegKey(string key)
    {
      return Settings.GetRegKey(key, string.Empty);
    }

    public static string GetRegKey(string key, string defaultValue)
    {
      return (Registry.GetValue("HKEY_CURRENT_USER\\Software\\Konami\\TournamentSoftware", key, (object) defaultValue) ?? (object) string.Empty).ToString();
    }

    public static void SetRegKey(string key, object value)
    {
      Registry.SetValue("HKEY_CURRENT_USER\\Software\\Konami\\TournamentSoftware", key, value);
    }
  }
}
