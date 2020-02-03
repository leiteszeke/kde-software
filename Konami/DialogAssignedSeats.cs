// Decompiled with JetBrains decompiler
// Type: Konami.DialogAssignedSeats
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogAssignedSeats : Form
  {
    private DataTable dtTable = new DataTable();
    public const string DataColumn = "Data";
    public const string NameColumn = "Name";
    public const string TableColumn = "Table";
    private IContainer components;
    private ComboBox ddlPlayers;
    private Label label1;
    private DataGridView dgAssignedSeats;
    private TextBox txtSeat;
    private Button btnAssign;
    private Button btnDelete;
    private Label label2;
    private Button btnOK;
    private Button btnFindByCossyID;
    public ITournament CurrentTournament;
    private EventHandler idleEventHandler;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogAssignedSeats));
      this.ddlPlayers = new ComboBox();
      this.label1 = new Label();
      this.dgAssignedSeats = new DataGridView();
      this.txtSeat = new TextBox();
      this.btnAssign = new Button();
      this.btnDelete = new Button();
      this.label2 = new Label();
      this.btnOK = new Button();
      this.btnFindByCossyID = new Button();
      ((ISupportInitialize) this.dgAssignedSeats).BeginInit();
      this.SuspendLayout();
      this.ddlPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPlayers.FormattingEnabled = true;
      this.ddlPlayers.Location = new Point(15, 50);
      this.ddlPlayers.Name = "ddlPlayers";
      this.ddlPlayers.Size = new Size(204, 21);
      this.ddlPlayers.TabIndex = 1;
      this.ddlPlayers.SelectedIndexChanged += new EventHandler(this.ddlPlayers_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 34);
      this.label1.Name = "label1";
      this.label1.Size = new Size(41, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Players";
      this.dgAssignedSeats.AllowUserToAddRows = false;
      this.dgAssignedSeats.AllowUserToDeleteRows = false;
      this.dgAssignedSeats.AllowUserToResizeRows = false;
      this.dgAssignedSeats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssignedSeats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgAssignedSeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgAssignedSeats.Location = new Point(15, 90);
      this.dgAssignedSeats.MultiSelect = false;
      this.dgAssignedSeats.Name = "dgAssignedSeats";
      this.dgAssignedSeats.ReadOnly = true;
      this.dgAssignedSeats.RowHeadersVisible = false;
      this.dgAssignedSeats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgAssignedSeats.Size = new Size(263, 184);
      this.dgAssignedSeats.TabIndex = 5;
      this.dgAssignedSeats.SelectionChanged += new EventHandler(this.dgAssignedSeats_SelectionChanged);
      this.txtSeat.Location = new Point(238, 51);
      this.txtSeat.Name = "txtSeat";
      this.txtSeat.Size = new Size(42, 20);
      this.txtSeat.TabIndex = 3;
      this.btnAssign.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAssign.Location = new Point(301, 90);
      this.btnAssign.Name = "btnAssign";
      this.btnAssign.Size = new Size(75, 23);
      this.btnAssign.TabIndex = 6;
      this.btnAssign.Text = "Assign";
      this.btnAssign.UseVisualStyleBackColor = true;
      this.btnAssign.Click += new EventHandler(this.btnAssign_Click);
      this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.Location = new Point(301, 132);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(75, 23);
      this.btnDelete.TabIndex = 7;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(235, 34);
      this.label2.Name = "label2";
      this.label2.Size = new Size(29, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Seat";
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOK.DialogResult = DialogResult.Cancel;
      this.btnOK.Location = new Point(158, 301);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 8;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnFindByCossyID.Location = new Point(301, 51);
      this.btnFindByCossyID.Name = "btnFindByCossyID";
      this.btnFindByCossyID.Size = new Size(75, 23);
      this.btnFindByCossyID.TabIndex = 4;
      this.btnFindByCossyID.Text = "Find by ID";
      this.btnFindByCossyID.UseVisualStyleBackColor = true;
      this.btnFindByCossyID.Click += new EventHandler(this.btnFindByCossyID_Click);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnOK;
      this.ClientSize = new Size(402, 348);
      this.Controls.Add((Control) this.btnFindByCossyID);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAssign);
      this.Controls.Add((Control) this.txtSeat);
      this.Controls.Add((Control) this.dgAssignedSeats);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ddlPlayers);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimizeBox = false;
      this.Name = nameof (DialogAssignedSeats);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Assigned Seats";
      this.Load += new EventHandler(this.DialogAssignedSeats_Load);
      ((ISupportInitialize) this.dgAssignedSeats).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public DialogAssignedSeats()
    {
      this.idleEventHandler = new EventHandler(this.OnIdle);
      Application.Idle += this.idleEventHandler;
      this.InitializeComponent();
      this.dtTable.Columns.Clear();
      this.dtTable.Columns.Add("Data", typeof (ITournPlayer));
      this.dtTable.Columns.Add("Name", typeof (string));
      this.dtTable.Columns.Add("Table", typeof (int));
    }

    private void btnAssign_Click(object sender, EventArgs e)
    {
      ITournPlayer selectedItem = (ITournPlayer) this.ddlPlayers.SelectedItem;
      int result = 0;
      if (int.TryParse(this.txtSeat.Text, out result))
        selectedItem.AssignedSeat = result;
      this.DisplaySeats();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dgAssignedSeats.SelectedRows.Count <= 0)
        return;
      DataGridViewRow selectedRow = this.dgAssignedSeats.SelectedRows[0];
      if (selectedRow.Cells.Count <= 0)
        return;
      ((ITournPlayer) selectedRow.Cells[0].Value).AssignedSeat = -1;
      this.DisplaySeats();
    }

    private void DialogAssignedSeats_Load(object sender, EventArgs e)
    {
      if (this.CurrentTournament == null)
        this.Close();
      this.CurrentTournament.Players.SortByLastname();
      this.ddlPlayers.DataSource = (object) this.CurrentTournament.Players;
      this.DisplaySeats();
    }

    private void DisplaySeats()
    {
      this.dtTable.Rows.Clear();
      this.CurrentTournament.Players.SortByLastname();
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.CurrentTournament.Players)
      {
        if (player.AssignedSeat > 0)
        {
          DataRow row = this.dtTable.NewRow();
          row["Data"] = (object) player;
          row["Name"] = (object) player.ToString();
          row["Table"] = (object) player.AssignedSeat;
          this.dtTable.Rows.Add(row);
        }
      }
      this.dgAssignedSeats.DataSource = (object) new DataView(this.dtTable);
      this.dgAssignedSeats.Columns["Data"].Visible = false;
    }

    private void OnIdle(object sender, EventArgs e)
    {
      this.btnDelete.Enabled = this.dgAssignedSeats.SelectedRows.Count > 0;
    }

    private void dgAssignedSeats_SelectionChanged(object sender, EventArgs e)
    {
      if (this.dgAssignedSeats.SelectedRows.Count <= 0)
        return;
      int num = this.ddlPlayers.Items.IndexOf((object) (ITournPlayer) this.dgAssignedSeats.SelectedRows[0].Cells[0].Value);
      if (num < 0)
        return;
      this.ddlPlayers.SelectedIndex = num;
    }

    private void ddlPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlPlayers.SelectedIndex < 0)
        return;
      ITournPlayer selectedItem = (ITournPlayer) this.ddlPlayers.SelectedItem;
      if (selectedItem.AssignedSeat < 0)
        this.txtSeat.Text = "";
      else
        this.txtSeat.Text = selectedItem.AssignedSeat.ToString();
    }

    private void btnFindByCossyID_Click(object sender, EventArgs e)
    {
      DialogNewPerson dialogNewPerson = new DialogNewPerson();
      dialogNewPerson.ReadOnly = true;
      dialogNewPerson.Title = "Enter ID";
      if (dialogNewPerson.ShowDialog() != DialogResult.OK)
        return;
      this.ddlPlayers.SelectedIndex = -1;
      for (int index = 0; index < this.ddlPlayers.Items.Count; ++index)
      {
        if (((IPlayer) this.ddlPlayers.Items[index]).ID == dialogNewPerson.NewPlayer.ID)
        {
          this.ddlPlayers.SelectedIndex = index;
          break;
        }
      }
    }
  }
}
