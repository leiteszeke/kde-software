// Decompiled with JetBrains decompiler
// Type: Konami.PreferencesDialog
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class PreferencesDialog : Form
  {
    private Size largeIcon = new Size(48, 48);
    private Size smallIcon = new Size(24, 24);
    private IContainer components;
    private Button btnSave;
    private Button btnCancel;
    private CheckBox chkShowIds_EnrollPlayerScreen;
    private GroupBox groupBox2;
    private ComboBox ddlFontList;
    private TextBox txtFontSize;
    private Label lblPrinterFontSizeSample;
    private GroupBox groupBox1;
    private CheckBox chkShowIdOnPairings;
    private GroupBox groupBox3;
    private Button btnChangeDataFolder;
    private FolderBrowserDialog folderBrowserDialog1;
    private TextBox txtDataFolder;
    private GroupBox groupBox4;
    private ComboBox ddlLocations;
    private Button btnEditLocation;

    private void txtFontSize_TextChanged(object sender, EventArgs e)
    {
      Console.WriteLine(nameof (txtFontSize_TextChanged));
      this.UpdateSample();
    }

    private void ddlFontList_SelectedIndexChanged(object sender, EventArgs e)
    {
      Console.WriteLine(nameof (ddlFontList_SelectedIndexChanged));
      this.UpdateSample();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Konami.Properties.Settings.Default.Reload();
    }

    private void btnChangeDataFolder_Click(object sender, EventArgs e)
    {
      this.folderBrowserDialog1.Description = "Choose Destination of Konami Tournament Data folder";
      this.folderBrowserDialog1.SelectedPath = !Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.txtDataFolder.Text = Path.Combine(this.folderBrowserDialog1.SelectedPath, "Konami Software");
      Konami.Properties.Settings.Default.DataStorageFolder = this.txtDataFolder.Text;
      Konami.Properties.Settings.Default.Save();
      Konami.Properties.Settings.Default.Reload();
    }

    private void btnEditLocation_Click(object sender, EventArgs e)
    {
      if (this.ddlLocations.SelectedIndex < 0 || !(this.ddlLocations.SelectedItem is ILocation))
        return;
      ILocation selectedItem = (ILocation) this.ddlLocations.SelectedItem;
      LocationSettings locationSettings = new LocationSettings();
      locationSettings.SelectedLocation = new Location(selectedItem);
      if (locationSettings.ShowDialog() != DialogResult.OK)
        return;
      selectedItem.Copy((ILocation) locationSettings.SelectedLocation);
      this.ResetLocationList();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Konami.Properties.Settings.Default.Save();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    public PreferencesDialog()
    {
      this.InitializeComponent();
      this.lblPrinterFontSizeSample.Text = "Sample Text";
    }

    private void PreferencesDialog_Load(object sender, EventArgs e)
    {
      this.chkShowIds_EnrollPlayerScreen.Checked = Konami.Properties.Settings.Default.ShowPlayerIds_DisplayOnScreen;
      this.chkShowIdOnPairings.Checked = Konami.Properties.Settings.Default.ShowPlayerIds_ShowOnPrintouts;
      foreach (FontFamily family in new InstalledFontCollection().Families)
        this.ddlFontList.Items.Add((object) family.Name);
      if (this.ddlFontList.FindStringExact(Konami.Properties.Settings.Default.PrinterFont) > 0)
        this.ddlFontList.SelectedIndex = this.ddlFontList.FindStringExact(Konami.Properties.Settings.Default.PrinterFont);
      else if (this.ddlFontList.Items.Count > 0)
        this.ddlFontList.SelectedIndex = 0;
      this.txtFontSize.Text = Konami.Properties.Settings.Default.PrinterFontSize;
      this.UpdateSample();
      this.ResetLocationList();
    }

    private void ResetLocationList()
    {
      int selectedIndex = this.ddlLocations.SelectedIndex;
      this.ddlLocations.Items.Clear();
      if (Engine.LocationList.Count > 0)
      {
        ILocation[] array = new ILocation[Engine.LocationList.Count];
        Engine.LocationList.CopyTo(array, 0);
        this.ddlLocations.Items.AddRange((object[]) array);
        this.ddlLocations.SelectedIndex = Math.Max(0, selectedIndex);
        this.btnEditLocation.Enabled = true;
      }
      else
      {
        this.ddlLocations.SelectedIndex = -1;
        this.btnEditLocation.Enabled = false;
      }
    }

    private void UpdateSample()
    {
      int result = 12;
      if (!int.TryParse(this.txtFontSize.Text, out result) || this.ddlFontList.SelectedItem == null)
        return;
      this.lblPrinterFontSizeSample.Font = new Font(this.ddlFontList.SelectedItem.ToString(), (float) result, GraphicsUnit.Point);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PreferencesDialog));
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.groupBox2 = new GroupBox();
      this.chkShowIdOnPairings = new CheckBox();
      this.chkShowIds_EnrollPlayerScreen = new CheckBox();
      this.lblPrinterFontSizeSample = new Label();
      this.groupBox1 = new GroupBox();
      this.txtFontSize = new TextBox();
      this.ddlFontList = new ComboBox();
      this.groupBox3 = new GroupBox();
      this.txtDataFolder = new TextBox();
      this.btnChangeDataFolder = new Button();
      this.folderBrowserDialog1 = new FolderBrowserDialog();
      this.groupBox4 = new GroupBox();
      this.ddlLocations = new ComboBox();
      this.btnEditLocation = new Button();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new Point(129, 341);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(225, 341);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.chkShowIdOnPairings);
      this.groupBox2.Controls.Add((Control) this.chkShowIds_EnrollPlayerScreen);
      this.groupBox2.Location = new Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(186, 128);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Show Player IDs";
      this.chkShowIdOnPairings.AutoSize = true;
      this.chkShowIdOnPairings.Checked = Konami.Properties.Settings.Default.ShowPlayerIds_ShowOnPrintouts;
      this.chkShowIdOnPairings.CheckState = CheckState.Checked;
      this.chkShowIdOnPairings.DataBindings.Add(new Binding("Checked", (object) Konami.Properties.Settings.Default, "ShowPlayerIds_ShowOnPrintouts", true, DataSourceUpdateMode.OnPropertyChanged));
      this.chkShowIdOnPairings.Location = new Point(6, 51);
      this.chkShowIdOnPairings.Name = "chkShowIdOnPairings";
      this.chkShowIdOnPairings.Size = new Size(84, 17);
      this.chkShowIdOnPairings.TabIndex = 1;
      this.chkShowIdOnPairings.Text = "On Printouts";
      this.chkShowIdOnPairings.UseVisualStyleBackColor = true;
      this.chkShowIds_EnrollPlayerScreen.AutoSize = true;
      this.chkShowIds_EnrollPlayerScreen.Checked = Konami.Properties.Settings.Default.ShowPlayerIds_DisplayOnScreen;
      this.chkShowIds_EnrollPlayerScreen.CheckState = CheckState.Checked;
      this.chkShowIds_EnrollPlayerScreen.DataBindings.Add(new Binding("Checked", (object) Konami.Properties.Settings.Default, "ShowPlayerIds_DisplayOnScreen", true, DataSourceUpdateMode.OnPropertyChanged));
      this.chkShowIds_EnrollPlayerScreen.Location = new Point(6, 28);
      this.chkShowIds_EnrollPlayerScreen.Name = "chkShowIds_EnrollPlayerScreen";
      this.chkShowIds_EnrollPlayerScreen.Size = new Size(77, 17);
      this.chkShowIds_EnrollPlayerScreen.TabIndex = 0;
      this.chkShowIds_EnrollPlayerScreen.Text = "On Screen";
      this.chkShowIds_EnrollPlayerScreen.UseVisualStyleBackColor = true;
      this.lblPrinterFontSizeSample.AutoSize = true;
      this.lblPrinterFontSizeSample.Location = new Point(6, 73);
      this.lblPrinterFontSizeSample.Name = "lblPrinterFontSizeSample";
      this.lblPrinterFontSizeSample.Size = new Size(66, 13);
      this.lblPrinterFontSizeSample.TabIndex = 7;
      this.lblPrinterFontSizeSample.Text = "Sample Text";
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.txtFontSize);
      this.groupBox1.Controls.Add((Control) this.lblPrinterFontSizeSample);
      this.groupBox1.Controls.Add((Control) this.ddlFontList);
      this.groupBox1.Location = new Point(204, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(213, 128);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Printer Font and Size";
      this.txtFontSize.DataBindings.Add(new Binding("Text", (object) Konami.Properties.Settings.Default, "PrinterFontSize", true, DataSourceUpdateMode.OnPropertyChanged));
      this.txtFontSize.Location = new Point(156, 33);
      this.txtFontSize.MaxLength = 3;
      this.txtFontSize.Name = "txtFontSize";
      this.txtFontSize.Size = new Size(31, 20);
      this.txtFontSize.TabIndex = 1;
      this.txtFontSize.Text = Konami.Properties.Settings.Default.PrinterFontSize;
      this.txtFontSize.TextChanged += new EventHandler(this.txtFontSize_TextChanged);
      this.ddlFontList.DataBindings.Add(new Binding("Text", (object) Konami.Properties.Settings.Default, "PrinterFont", true, DataSourceUpdateMode.OnPropertyChanged));
      this.ddlFontList.FormattingEnabled = true;
      this.ddlFontList.Location = new Point(6, 33);
      this.ddlFontList.Name = "ddlFontList";
      this.ddlFontList.Size = new Size(135, 21);
      this.ddlFontList.TabIndex = 0;
      this.ddlFontList.Text = Konami.Properties.Settings.Default.PrinterFont;
      this.ddlFontList.SelectedIndexChanged += new EventHandler(this.ddlFontList_SelectedIndexChanged);
      this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox3.Controls.Add((Control) this.txtDataFolder);
      this.groupBox3.Controls.Add((Control) this.btnChangeDataFolder);
      this.groupBox3.Location = new Point(12, 146);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(405, 78);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Data Folder";
      this.txtDataFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDataFolder.DataBindings.Add(new Binding("Text", (object) Konami.Properties.Settings.Default, "DataStorageFolder", true, DataSourceUpdateMode.OnPropertyChanged));
      this.txtDataFolder.Location = new Point(6, 29);
      this.txtDataFolder.Name = "txtDataFolder";
      this.txtDataFolder.ReadOnly = true;
      this.txtDataFolder.Size = new Size(312, 20);
      this.txtDataFolder.TabIndex = 2;
      this.txtDataFolder.Text = Konami.Properties.Settings.Default.DataStorageFolder;
      this.btnChangeDataFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnChangeDataFolder.Location = new Point(324, 27);
      this.btnChangeDataFolder.Name = "btnChangeDataFolder";
      this.btnChangeDataFolder.Size = new Size(75, 23);
      this.btnChangeDataFolder.TabIndex = 1;
      this.btnChangeDataFolder.Text = "Change";
      this.btnChangeDataFolder.UseVisualStyleBackColor = true;
      this.btnChangeDataFolder.Click += new EventHandler(this.btnChangeDataFolder_Click);
      this.groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox4.Controls.Add((Control) this.ddlLocations);
      this.groupBox4.Controls.Add((Control) this.btnEditLocation);
      this.groupBox4.Location = new Point(12, 230);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(405, 84);
      this.groupBox4.TabIndex = 4;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Locations";
      this.ddlLocations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlLocations.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlLocations.FormattingEnabled = true;
      this.ddlLocations.Location = new Point(6, 32);
      this.ddlLocations.Name = "ddlLocations";
      this.ddlLocations.Size = new Size(312, 21);
      this.ddlLocations.TabIndex = 2;
      this.btnEditLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEditLocation.Location = new Point(324, 30);
      this.btnEditLocation.Name = "btnEditLocation";
      this.btnEditLocation.Size = new Size(75, 23);
      this.btnEditLocation.TabIndex = 1;
      this.btnEditLocation.Text = "Change";
      this.btnEditLocation.UseVisualStyleBackColor = true;
      this.btnEditLocation.Click += new EventHandler(this.btnEditLocation_Click);
      this.AcceptButton = (IButtonControl) this.btnSave;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(429, 389);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (PreferencesDialog);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Preferences";
      this.Load += new EventHandler(this.PreferencesDialog_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
