// Decompiled with JetBrains decompiler
// Type: Konami.Properties.Settings
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Konami.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("True")]
    [DebuggerNonUserCode]
    public bool ToolBar_IconsOnly
    {
      get
      {
        return (bool) this[nameof (ToolBar_IconsOnly)];
      }
      set
      {
        this[nameof (ToolBar_IconsOnly)] = (object) value;
      }
    }

    [DefaultSettingValue("False")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public bool ToolBar_TextOnly
    {
      get
      {
        return (bool) this[nameof (ToolBar_TextOnly)];
      }
      set
      {
        this[nameof (ToolBar_TextOnly)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    public bool ToolBar_IconsAndText
    {
      get
      {
        return (bool) this[nameof (ToolBar_IconsAndText)];
      }
      set
      {
        this[nameof (ToolBar_IconsAndText)] = (object) value;
      }
    }

    [DefaultSettingValue("True")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public bool ShowPlayerIds_DisplayOnScreen
    {
      get
      {
        return (bool) this[nameof (ShowPlayerIds_DisplayOnScreen)];
      }
      set
      {
        this[nameof (ShowPlayerIds_DisplayOnScreen)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("Arial")]
    [DebuggerNonUserCode]
    public string PrinterFont
    {
      get
      {
        return (string) this[nameof (PrinterFont)];
      }
      set
      {
        this[nameof (PrinterFont)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowPlayerIds_ShowOnPrintouts
    {
      get
      {
        return (bool) this[nameof (ShowPlayerIds_ShowOnPrintouts)];
      }
      set
      {
        this[nameof (ShowPlayerIds_ShowOnPrintouts)] = (object) value;
      }
    }

    [DefaultSettingValue("16, 16")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public Size ToolBarButtonSize
    {
      get
      {
        return (Size) this[nameof (ToolBarButtonSize)];
      }
      set
      {
        this[nameof (ToolBarButtonSize)] = (object) value;
      }
    }

    [DefaultSettingValue("(no folder)")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string DataStorageFolder
    {
      get
      {
        return (string) this[nameof (DataStorageFolder)];
      }
      set
      {
        this[nameof (DataStorageFolder)] = (object) value;
      }
    }

    [DefaultSettingValue("True")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public bool ResultSlips_JudgeSignature
    {
      get
      {
        return (bool) this[nameof (ResultSlips_JudgeSignature)];
      }
      set
      {
        this[nameof (ResultSlips_JudgeSignature)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("10")]
    [DebuggerNonUserCode]
    public string PrinterFontSize
    {
      get
      {
        return (string) this[nameof (PrinterFontSize)];
      }
      set
      {
        this[nameof (PrinterFontSize)] = (object) value;
      }
    }

    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
    {
    }

    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
    {
    }
  }
}
