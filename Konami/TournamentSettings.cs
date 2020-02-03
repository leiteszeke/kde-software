// Decompiled with JetBrains decompiler
// Type: Konami.TournamentSettings
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class TournamentSettings : Form
  {
    private ITournament _tournament = (ITournament) new Tournament();
    private IContainer components;
    private Label lblTournamentName;
    private TextBox txtTournamentName;
    private Label lblDate;
    private DateTimePicker dateTournament;
    private Label lblLocation;
    private Button btnLocation;
    private Label lblOrganizer;
    private Button btnAddJudge;
    private Button btnDeleteJudge;
    private Label lblTournamentFormat;
    private ComboBox ddlFormats;
    private ComboBox ddlStructures;
    private Button btnOK;
    private Button btnCancel;
    private ComboBox ddlLocations;
    private DateTimePicker timeTournament;
    private TextBox txtTournamentId;
    private Label lblTournamentId;
    private ListBox listStaff;
    private Button btnEditJudge;
    private ComboBox ddlEventType;
    private Label label1;
    private Label label2;

    public string AcceptButtonText
    {
      get
      {
        return this.btnOK.Text;
      }
      set
      {
        this.btnOK.Text = value;
      }
    }

    public ITournament ThisTournament
    {
      get
      {
        return this._tournament;
      }
      set
      {
        this._tournament = value;
      }
    }

    private void ddlEventType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.CheckLegalFormats();
    }

    private void btnAddJudge_Click(object sender, EventArgs e)
    {
      DialogSelectPerson dialogSelectPerson = new DialogSelectPerson();
      dialogSelectPerson.Title = "Add Staff";
      dialogSelectPerson.AllowNewPlayers = true;
      dialogSelectPerson.EnableStaffPosition = true;
      if (dialogSelectPerson.ShowDialog() != DialogResult.OK)
        return;
      this.listStaff.Items.Add((object) new TournStaff(dialogSelectPerson.NewPlayer)
      {
        Position = dialogSelectPerson.SelectedStaffPosition
      });
    }

    private void btnDeleteJudge_Click(object sender, EventArgs e)
    {
      if (this.listStaff.SelectedIndex < 0)
        return;
      this.listStaff.Items.RemoveAt(this.listStaff.SelectedIndex);
    }

    private void btnEditJudge_Click(object sender, EventArgs e)
    {
      if (this.listStaff.SelectedIndex < 0)
        return;
      TournStaff selectedItem = (TournStaff) this.listStaff.SelectedItem;
      DialogSelectPerson dialogSelectPerson = new DialogSelectPerson();
      dialogSelectPerson.Title = "Add Staff";
      dialogSelectPerson.AllowNewPlayers = true;
      dialogSelectPerson.EnableStaffPosition = true;
      dialogSelectPerson.NewPlayer = (IPlayer) new Player((IPlayer) selectedItem);
      dialogSelectPerson.SelectedStaffPosition = selectedItem.Position;
      if (dialogSelectPerson.ShowDialog() != DialogResult.OK)
        return;
      this.listStaff.Items[this.listStaff.SelectedIndex] = (object) new TournStaff(dialogSelectPerson.NewPlayer)
      {
        Position = dialogSelectPerson.SelectedStaffPosition
      };
    }

    private void btnLocation_Click(object sender, EventArgs e)
    {
      LocationSettings locationSettings = new LocationSettings();
      if (locationSettings.ShowDialog() != DialogResult.OK)
        return;
      Engine.LocationList.Add((ILocation) locationSettings.SelectedLocation);
      this.ddlLocations.SelectedIndex = this.ddlLocations.Items.Add((object) locationSettings.SelectedLocation);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!Tournament.ValidateTournamentId(this.txtTournamentId.Text))
      {
        int num = (int) MessageBox.Show("Invalid Event Number.  Must be in the format 'A12-345678'");
      }
      else
      {
        this.ThisTournament.Name = this.txtTournamentName.Text;
        this.ThisTournament.ID = this.txtTournamentId.Text.ToUpper();
        this.ThisTournament.Date = new DateTime(this.dateTournament.Value.Year, this.dateTournament.Value.Month, this.dateTournament.Value.Day, this.timeTournament.Value.Hour, this.timeTournament.Value.Minute, 0);
        this.ThisTournament.Format = ((ListItemTournamentStyle) this.ddlFormats.SelectedItem).Value;
        this.ThisTournament.TournamentType = ((ListItemEventType) this.ddlEventType.SelectedItem).Value;
        this.ThisTournament.PairingStructure = ((ListItemTournamentStructure) this.ddlStructures.SelectedItem).Value;
        this.ThisTournament.Staff.Clear();
        foreach (ITournStaff tournStaff in this.listStaff.Items)
          this.ThisTournament.Staff.Add(tournStaff);
        if (this.ddlLocations.Text.Length > 0)
          this.ThisTournament.Location = (ILocation) this.ddlLocations.SelectedItem;
        this.DialogResult = DialogResult.OK;
      }
    }

    public TournamentSettings()
    {
      this.InitializeComponent();
    }

    private void CheckLegalFormats()
    {
      List<TournamentStyle> tournamentStyleList = Engine.LegalTournamentStyles(((ListItemEventType) this.ddlEventType.SelectedItem).Value);
      this.ddlFormats.SelectedIndex = -1;
      this.ddlFormats.Items.Clear();
      foreach (TournamentStyle val in tournamentStyleList)
      {
        this.ddlFormats.Items.Add((object) new ListItemTournamentStyle(val));
        this.ddlFormats.SelectedIndex = 0;
      }
    }

    private void LoadJudges()
    {
      this.listStaff.Items.Clear();
      if (this.ThisTournament.Staff.Count <= 0)
        return;
      this.ThisTournament.Staff.SortByPosition();
      this.listStaff.BeginUpdate();
      foreach (TournStaff tournStaff in (IEnumerable<ITournStaff>) this.ThisTournament.Staff)
        this.listStaff.Items.Add((object) tournStaff);
      this.listStaff.EndUpdate();
    }

    private void TournamentSettings_Load(object sender, EventArgs e)
    {
      this.txtTournamentName.Text = this.ThisTournament.Name;
      this.txtTournamentId.Text = this.ThisTournament.ID;
      this.dateTournament.Value = this.ThisTournament.Date;
      this.timeTournament.Value = this.ThisTournament.Date;
      this.LoadJudges();
      foreach (EventType key in CommonEnumLists.EventTypeNames.Keys)
      {
        ListItemEventType listItemEventType = new ListItemEventType(key);
        this.ddlEventType.Items.Add((object) listItemEventType);
        if (listItemEventType.Value == this.ThisTournament.TournamentType)
          this.ddlEventType.SelectedItem = (object) listItemEventType;
      }
      this.CheckLegalFormats();
      if (Engine.LocationList.FindById(this.ThisTournament.Location.Id) == null && !this.ThisTournament.Location.IsEmpty)
      {
        Engine.LocationList.Add(this.ThisTournament.Location);
        Engine.LocationList.Sort();
      }
      ILocation[] array = new ILocation[Engine.LocationList.Count];
      Engine.LocationList.CopyTo(array, 0);
      this.ddlLocations.Items.AddRange((object[]) array);
      foreach (TournamentPairingStructure key in CommonEnumLists.TournamentPairingStructureNames.Keys)
      {
        ListItemTournamentStructure tournamentStructure = new ListItemTournamentStructure(key);
        this.ddlStructures.Items.Add((object) tournamentStructure);
        if (tournamentStructure.Value == this.ThisTournament.PairingStructure)
          this.ddlStructures.SelectedItem = (object) tournamentStructure;
      }
      for (int index = 0; index < this.ddlLocations.Items.Count; ++index)
      {
        if (((ILocation) this.ddlLocations.Items[index]).Id == this.ThisTournament.Location.Id)
        {
          this.ddlLocations.SelectedIndex = index;
          break;
        }
      }
      if (this.ddlLocations.SelectedIndex >= 0 || this.ddlLocations.Items.Count <= 0)
        return;
      this.ddlLocations.SelectedIndex = 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TournamentSettings));
      this.lblTournamentName = new Label();
      this.txtTournamentName = new TextBox();
      this.lblDate = new Label();
      this.dateTournament = new DateTimePicker();
      this.lblLocation = new Label();
      this.btnLocation = new Button();
      this.lblOrganizer = new Label();
      this.btnAddJudge = new Button();
      this.btnDeleteJudge = new Button();
      this.lblTournamentFormat = new Label();
      this.ddlFormats = new ComboBox();
      this.ddlStructures = new ComboBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.ddlLocations = new ComboBox();
      this.timeTournament = new DateTimePicker();
      this.txtTournamentId = new TextBox();
      this.lblTournamentId = new Label();
      this.listStaff = new ListBox();
      this.btnEditJudge = new Button();
      this.ddlEventType = new ComboBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.SuspendLayout();
      this.lblTournamentName.AutoSize = true;
      this.lblTournamentName.Location = new Point(22, 43);
      this.lblTournamentName.Name = "lblTournamentName";
      this.lblTournamentName.Size = new Size(95, 13);
      this.lblTournamentName.TabIndex = 0;
      this.lblTournamentName.Text = "Tournament Name";
      this.txtTournamentName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTournamentName.Location = new Point(123, 40);
      this.txtTournamentName.Name = "txtTournamentName";
      this.txtTournamentName.Size = new Size(344, 20);
      this.txtTournamentName.TabIndex = 1;
      this.lblDate.AutoSize = true;
      this.lblDate.Location = new Point(22, 140);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(30, 13);
      this.lblDate.TabIndex = 6;
      this.lblDate.Text = "Date";
      this.dateTournament.Format = DateTimePickerFormat.Custom;
      this.dateTournament.Location = new Point(123, 134);
      this.dateTournament.Name = "dateTournament";
      this.dateTournament.Size = new Size(130, 20);
      this.dateTournament.TabIndex = 7;
      this.lblLocation.AutoSize = true;
      this.lblLocation.Location = new Point(22, 168);
      this.lblLocation.Name = "lblLocation";
      this.lblLocation.Size = new Size(48, 13);
      this.lblLocation.TabIndex = 9;
      this.lblLocation.Text = "Location";
      this.btnLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnLocation.Location = new Point(336, 165);
      this.btnLocation.Name = "btnLocation";
      this.btnLocation.Size = new Size(131, 23);
      this.btnLocation.TabIndex = 11;
      this.btnLocation.Text = "Add";
      this.btnLocation.UseVisualStyleBackColor = true;
      this.btnLocation.Click += new EventHandler(this.btnLocation_Click);
      this.lblOrganizer.AutoSize = true;
      this.lblOrganizer.Location = new Point(22, 197);
      this.lblOrganizer.Name = "lblOrganizer";
      this.lblOrganizer.Size = new Size(29, 13);
      this.lblOrganizer.TabIndex = 12;
      this.lblOrganizer.Text = "Staff";
      this.btnAddJudge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddJudge.Location = new Point(360, 197);
      this.btnAddJudge.Name = "btnAddJudge";
      this.btnAddJudge.Size = new Size(107, 23);
      this.btnAddJudge.TabIndex = 14;
      this.btnAddJudge.Text = "Add";
      this.btnAddJudge.UseVisualStyleBackColor = true;
      this.btnAddJudge.Click += new EventHandler(this.btnAddJudge_Click);
      this.btnDeleteJudge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDeleteJudge.Location = new Point(360, (int) byte.MaxValue);
      this.btnDeleteJudge.Name = "btnDeleteJudge";
      this.btnDeleteJudge.Size = new Size(107, 23);
      this.btnDeleteJudge.TabIndex = 16;
      this.btnDeleteJudge.Text = "Remove";
      this.btnDeleteJudge.UseVisualStyleBackColor = true;
      this.btnDeleteJudge.Click += new EventHandler(this.btnDeleteJudge_Click);
      this.lblTournamentFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblTournamentFormat.AutoSize = true;
      this.lblTournamentFormat.Location = new Point(22, 353);
      this.lblTournamentFormat.Name = "lblTournamentFormat";
      this.lblTournamentFormat.Size = new Size(30, 13);
      this.lblTournamentFormat.TabIndex = 17;
      this.lblTournamentFormat.Text = "Style";
      this.ddlFormats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlFormats.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlFormats.FormattingEnabled = true;
      this.ddlFormats.Location = new Point(123, 350);
      this.ddlFormats.Name = "ddlFormats";
      this.ddlFormats.Size = new Size(172, 21);
      this.ddlFormats.TabIndex = 18;
      this.ddlStructures.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.ddlStructures.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlStructures.FormattingEnabled = true;
      this.ddlStructures.Location = new Point(123, 382);
      this.ddlStructures.Name = "ddlStructures";
      this.ddlStructures.Size = new Size(172, 21);
      this.ddlStructures.TabIndex = 20;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOK.Location = new Point(157, 463);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 21;
      this.btnOK.Text = "Create";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(296, 462);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 22;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.ddlLocations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlLocations.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlLocations.FormattingEnabled = true;
      this.ddlLocations.Location = new Point(123, 165);
      this.ddlLocations.Name = "ddlLocations";
      this.ddlLocations.Size = new Size(207, 21);
      this.ddlLocations.TabIndex = 10;
      this.timeTournament.CustomFormat = "h:mm tt";
      this.timeTournament.Format = DateTimePickerFormat.Custom;
      this.timeTournament.Location = new Point(259, 133);
      this.timeTournament.Name = "timeTournament";
      this.timeTournament.ShowUpDown = true;
      this.timeTournament.Size = new Size(77, 20);
      this.timeTournament.TabIndex = 8;
      this.txtTournamentId.Location = new Point(123, 103);
      this.txtTournamentId.MaxLength = 10;
      this.txtTournamentId.Name = "txtTournamentId";
      this.txtTournamentId.Size = new Size(130, 20);
      this.txtTournamentId.TabIndex = 5;
      this.lblTournamentId.AutoSize = true;
      this.lblTournamentId.Location = new Point(22, 106);
      this.lblTournamentId.Name = "lblTournamentId";
      this.lblTournamentId.Size = new Size(55, 13);
      this.lblTournamentId.TabIndex = 4;
      this.lblTournamentId.Text = "Event No.";
      this.listStaff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listStaff.FormattingEnabled = true;
      this.listStaff.Location = new Point(123, 197);
      this.listStaff.Name = "listStaff";
      this.listStaff.Size = new Size(231, 134);
      this.listStaff.TabIndex = 13;
      this.btnEditJudge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEditJudge.Location = new Point(360, 226);
      this.btnEditJudge.Name = "btnEditJudge";
      this.btnEditJudge.Size = new Size(107, 23);
      this.btnEditJudge.TabIndex = 15;
      this.btnEditJudge.Text = "Edit";
      this.btnEditJudge.UseVisualStyleBackColor = true;
      this.btnEditJudge.Click += new EventHandler(this.btnEditJudge_Click);
      this.ddlEventType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlEventType.FormattingEnabled = true;
      this.ddlEventType.Location = new Point(123, 70);
      this.ddlEventType.Name = "ddlEventType";
      this.ddlEventType.Size = new Size(207, 21);
      this.ddlEventType.TabIndex = 3;
      this.ddlEventType.SelectedIndexChanged += new EventHandler(this.ddlEventType_SelectedIndexChanged);
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(22, 385);
      this.label1.Name = "label1";
      this.label1.Size = new Size(50, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Structure";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(22, 73);
      this.label2.Name = "label2";
      this.label2.Size = new Size(62, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Event Type";
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(493, 507);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ddlEventType);
      this.Controls.Add((Control) this.btnEditJudge);
      this.Controls.Add((Control) this.listStaff);
      this.Controls.Add((Control) this.txtTournamentId);
      this.Controls.Add((Control) this.lblTournamentId);
      this.Controls.Add((Control) this.timeTournament);
      this.Controls.Add((Control) this.ddlLocations);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.ddlStructures);
      this.Controls.Add((Control) this.ddlFormats);
      this.Controls.Add((Control) this.lblTournamentFormat);
      this.Controls.Add((Control) this.btnDeleteJudge);
      this.Controls.Add((Control) this.btnAddJudge);
      this.Controls.Add((Control) this.lblOrganizer);
      this.Controls.Add((Control) this.btnLocation);
      this.Controls.Add((Control) this.lblLocation);
      this.Controls.Add((Control) this.dateTournament);
      this.Controls.Add((Control) this.lblDate);
      this.Controls.Add((Control) this.txtTournamentName);
      this.Controls.Add((Control) this.lblTournamentName);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (TournamentSettings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Tournament Settings";
      this.Load += new EventHandler(this.TournamentSettings_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
