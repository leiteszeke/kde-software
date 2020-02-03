// Decompiled with JetBrains decompiler
// Type: Konami.ManualPairings
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class ManualPairings : Form
  {
    public TournMatchArray NewMatches = new TournMatchArray();
    private IContainer components;
    private ListBox listUnassignedPlayers;
    private DataGridView dgMatches;
    private Button btnSplitMatch;
    private Button btnCreateMatch;
    private Button btnSave;
    private Button btnCancel;
    private Button btnAddByeLoss;
    private Button btnAddByeWin;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private ComboBox ddlOpenTables;
    private Label label1;
    public int Round;
    public ITournament Tournament;
    public ITournMatchArray Matches;
    private EventHandler idleEventHandler;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ManualPairings));
      this.listUnassignedPlayers = new ListBox();
      this.dgMatches = new DataGridView();
      this.btnSplitMatch = new Button();
      this.btnCreateMatch = new Button();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.btnAddByeLoss = new Button();
      this.btnAddByeWin = new Button();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.ddlOpenTables = new ComboBox();
      this.label1 = new Label();
      ((ISupportInitialize) this.dgMatches).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.listUnassignedPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.listUnassignedPlayers.FormattingEnabled = true;
      this.listUnassignedPlayers.Location = new Point(15, 19);
      this.listUnassignedPlayers.Name = "listUnassignedPlayers";
      this.listUnassignedPlayers.SelectionMode = SelectionMode.MultiExtended;
      this.listUnassignedPlayers.Size = new Size(217, 329);
      this.listUnassignedPlayers.Sorted = true;
      this.listUnassignedPlayers.TabIndex = 0;
      this.dgMatches.AllowUserToAddRows = false;
      this.dgMatches.AllowUserToDeleteRows = false;
      this.dgMatches.AllowUserToResizeRows = false;
      this.dgMatches.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgMatches.Location = new Point(19, 19);
      this.dgMatches.MultiSelect = false;
      this.dgMatches.Name = "dgMatches";
      this.dgMatches.ReadOnly = true;
      this.dgMatches.RowHeadersVisible = false;
      this.dgMatches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgMatches.Size = new Size(428, 356);
      this.dgMatches.TabIndex = 1;
      this.dgMatches.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgMatches_CellMouseDoubleClick);
      this.btnSplitMatch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSplitMatch.Location = new Point(189, 395);
      this.btnSplitMatch.Name = "btnSplitMatch";
      this.btnSplitMatch.Size = new Size(96, 23);
      this.btnSplitMatch.TabIndex = 8;
      this.btnSplitMatch.Text = "Split Match";
      this.btnSplitMatch.UseVisualStyleBackColor = true;
      this.btnSplitMatch.Click += new EventHandler(this.btnSplitMatch_Click);
      this.btnCreateMatch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreateMatch.Location = new Point(136, 363);
      this.btnCreateMatch.Name = "btnCreateMatch";
      this.btnCreateMatch.Size = new Size(96, 23);
      this.btnCreateMatch.TabIndex = 9;
      this.btnCreateMatch.Text = "Create Match";
      this.btnCreateMatch.UseVisualStyleBackColor = true;
      this.btnCreateMatch.Click += new EventHandler(this.btnCreateMatch_Click);
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new Point(256, 493);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 10;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(434, 493);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnAddByeLoss.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddByeLoss.Location = new Point(15, 401);
      this.btnAddByeLoss.Name = "btnAddByeLoss";
      this.btnAddByeLoss.Size = new Size(96, 23);
      this.btnAddByeLoss.TabIndex = 12;
      this.btnAddByeLoss.Text = "Add Bye - Loss";
      this.btnAddByeLoss.UseVisualStyleBackColor = true;
      this.btnAddByeLoss.Click += new EventHandler(this.btnAddByeLoss_Click);
      this.btnAddByeWin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddByeWin.Location = new Point(136, 401);
      this.btnAddByeWin.Name = "btnAddByeWin";
      this.btnAddByeWin.Size = new Size(96, 23);
      this.btnAddByeWin.TabIndex = 13;
      this.btnAddByeWin.Text = "Add Bye - Win";
      this.btnAddByeWin.UseVisualStyleBackColor = true;
      this.btnAddByeWin.Click += new EventHandler(this.btnAddByeWin_Click);
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.dgMatches);
      this.groupBox1.Controls.Add((Control) this.btnSplitMatch);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(464, 442);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Matches";
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.ddlOpenTables);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.listUnassignedPlayers);
      this.groupBox2.Controls.Add((Control) this.btnAddByeLoss);
      this.groupBox2.Controls.Add((Control) this.btnAddByeWin);
      this.groupBox2.Controls.Add((Control) this.btnCreateMatch);
      this.groupBox2.Location = new Point(482, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(256, 442);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Unassigned Players";
      this.ddlOpenTables.FormattingEnabled = true;
      this.ddlOpenTables.Location = new Point(53, 365);
      this.ddlOpenTables.Name = "ddlOpenTables";
      this.ddlOpenTables.Size = new Size(58, 21);
      this.ddlOpenTables.TabIndex = 15;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 368);
      this.label1.Name = "label1";
      this.label1.Size = new Size(37, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Table:";
      this.AcceptButton = (IButtonControl) this.btnSave;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(784, 559);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ManualPairings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (ManualPairings);
      this.Load += new EventHandler(this.ManualPairings_Load);
      ((ISupportInitialize) this.dgMatches).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }

    private void dgMatches_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex < 0 || e.RowIndex >= this.dgMatches.Rows.Count)
        return;
      this.SplitMatch(e.RowIndex);
    }

    private void btnAddByeLoss_Click(object sender, EventArgs e)
    {
      TournPlayer tournPlayer = new TournPlayer((IPlayer) Player.ByePlayer);
      this.CreateMatch(this.GetPlayer(this.listUnassignedPlayers.SelectedItems[0]), (ITournPlayer) tournPlayer, (ITournPlayer) tournPlayer);
    }

    private void btnAddByeWin_Click(object sender, EventArgs e)
    {
      TournPlayer tournPlayer = new TournPlayer((IPlayer) Player.ByePlayer);
      ITournPlayer player = this.GetPlayer(this.listUnassignedPlayers.SelectedItems[0]);
      this.CreateMatch(player, (ITournPlayer) tournPlayer, player);
    }

    private void btnCreateMatch_Click(object sender, EventArgs e)
    {
      this.CreateMatch(this.GetPlayer(this.listUnassignedPlayers.SelectedItems[0]), this.GetPlayer(this.listUnassignedPlayers.SelectedItems[1]), (ITournPlayer) null);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void btnSplitMatch_Click(object sender, EventArgs e)
    {
      if (this.dgMatches.SelectedRows.Count != 1 || this.dgMatches.SelectedRows[0] == null)
        return;
      this.SplitMatch(this.dgMatches.SelectedRows[0].Index);
    }

    public ManualPairings()
    {
      this.InitializeComponent();
      this.idleEventHandler = new EventHandler(this.OnIdle);
      Application.Idle += this.idleEventHandler;
    }

    private ITournPlayer GetPlayer(object objPlayer)
    {
      ITournPlayer tournPlayer = (ITournPlayer) null;
      if (objPlayer is ManualPairingObject)
        tournPlayer = ((ManualPairingObject) objPlayer)._player;
      if (objPlayer is ITournPlayer)
        tournPlayer = (ITournPlayer) objPlayer;
      return tournPlayer == null ? (ITournPlayer) null : this.Tournament.Players.FindById(tournPlayer.ID);
    }

    private void BindMatches()
    {
      this.dgMatches.DataSource = (object) TournMatchArray.GetDataTable(this.Matches, false, this.Tournament.TableOffset, this.Tournament.Players);
      this.dgMatches.Columns["MatchObject"].Visible = false;
      this.dgMatches.Columns["Player 1 Object"].Visible = false;
      this.dgMatches.Columns["Player 2 Object"].Visible = false;
      this.dgMatches.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      foreach (DataGridViewRow row in (IEnumerable) this.dgMatches.Rows)
      {
        if (row.Cells["MatchObject"].Value != null)
        {
          ITournMatch tournMatch = (ITournMatch) row.Cells["MatchObject"].Value;
          row.Cells["Result"].Value = (object) tournMatch.StatusText;
        }
      }
    }

    private void CreateMatch(ITournPlayer player1, ITournPlayer player2, ITournPlayer winner)
    {
      int table = int.Parse(this.ddlOpenTables.Text);
      if (this.Matches.GetByRoundTable(this.Round, table) == null)
      {
        TournMatch tournMatch = new TournMatch();
        tournMatch.Table = table;
        tournMatch.Round = this.Round;
        tournMatch.Players.AddPlayer(player1);
        tournMatch.Players.AddPlayer(player2);
        if (winner != null)
        {
          tournMatch.Winner = winner.ID;
          tournMatch.Status = TournMatchResult.Winner;
        }
        tournMatch.Players.SortByIDByesLast();
        this.Matches.AddMatch((ITournMatch) tournMatch);
        this.NewMatches.AddMatch((ITournMatch) tournMatch);
        this.Matches.SortByRoundTable();
        this.BindMatches();
        this.RemovePlayerFromUnassigned(tournMatch.Players[0].ID);
        this.RemovePlayerFromUnassigned(tournMatch.Players[1].ID);
        this.ddlOpenTables.Items.Remove((object) table.ToString());
        if (this.ddlOpenTables.Items.Count <= 0)
          return;
        this.ddlOpenTables.SelectedIndex = 0;
      }
      else
      {
        int num = (int) MessageBox.Show("Error assigning match to the table");
      }
    }

    private void LoadUnassignedPlayers()
    {
      if (this.Tournament == null || this.Tournament.Players == null)
        return;
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.Tournament.Players)
      {
        if (player.IsActive)
        {
          bool flag = false;
          foreach (ITournMatch match in (IEnumerable<ITournMatch>) this.Matches)
          {
            if (match.Players.HasPlayer(player.ID))
              flag = true;
          }
          if (!flag)
            this.listUnassignedPlayers.Items.Add((object) new ManualPairingObject(this.GetPlayer((object) player)));
        }
      }
    }

    private void ManualPairings_Load(object sender, EventArgs e)
    {
      if (this.Tournament == null)
        return;
      ITournMatchArray byRound = this.Tournament.Matches.GetByRound(this.Round);
      this.Matches = (ITournMatchArray) new TournMatchArray();
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) byRound)
        this.Matches.AddMatch((ITournMatch) new TournMatch(match));
      this.BindMatches();
      this.LoadUnassignedPlayers();
      this.Matches.SortByRoundTableByesLast();
      for (int index = 0; index < (this.listUnassignedPlayers.Items.Count + 1) / 2; ++index)
        this.ddlOpenTables.Items.Add((object) (this.Matches[this.Matches.Count - 1].Table + 1 + index));
      if (this.ddlOpenTables.Items.Count <= 0)
        return;
      this.ddlOpenTables.SelectedIndex = 0;
    }

    private void OnIdle(object sender, EventArgs e)
    {
      this.btnSave.Enabled = this.listUnassignedPlayers.Items.Count == 0;
      this.btnCreateMatch.Enabled = this.listUnassignedPlayers.SelectedItems.Count == 2;
      this.btnAddByeLoss.Enabled = this.listUnassignedPlayers.SelectedItems.Count == 1;
      this.btnAddByeWin.Enabled = this.listUnassignedPlayers.SelectedItems.Count == 1;
    }

    private void RemovePlayerFromUnassigned(long id)
    {
      for (int index = this.listUnassignedPlayers.Items.Count - 1; index >= 0; --index)
      {
        if (this.GetPlayer(this.listUnassignedPlayers.Items[index]).ID == id)
          this.listUnassignedPlayers.Items.RemoveAt(index);
      }
    }

    private void SplitMatch(int rowNumber)
    {
      TournMatch tournMatch = (TournMatch) ((DataRowView) this.dgMatches.Rows[rowNumber].DataBoundItem)["MatchObject"];
      while (tournMatch.Players.Count > 0)
      {
        if (!tournMatch.Players[0].IsBye)
          this.listUnassignedPlayers.Items.Add((object) new ManualPairingObject(this.GetPlayer((object) tournMatch.Players[0])));
        tournMatch.Players.RemoveAt(0);
      }
      bool flag = false;
      for (int index = 0; index < this.ddlOpenTables.Items.Count; ++index)
      {
        if (int.Parse(this.ddlOpenTables.Items[index].ToString()) > tournMatch.Table)
        {
          this.ddlOpenTables.Items.Insert(index, (object) tournMatch.Table.ToString());
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        this.ddlOpenTables.Items.Add((object) tournMatch.Table.ToString());
        this.ddlOpenTables.SelectedIndex = 0;
      }
      this.Matches.RemoveMatch((ITournMatch) tournMatch);
      this.dgMatches.Rows.RemoveAt(rowNumber);
    }
  }
}
