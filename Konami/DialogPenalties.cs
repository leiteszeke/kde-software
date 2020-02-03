// Decompiled with JetBrains decompiler
// Type: Konami.DialogPenalties
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogPenalties : Form
  {
    private IContainer components;
    private DataGridView dgPenalties;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnClose;
    private Button btnEditPenalty;
    public IPlayer PreselectedPlayer;
    public ITournament currentTournament;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPenalties));
      this.dgPenalties = new DataGridView();
      this.btnAdd = new Button();
      this.btnDelete = new Button();
      this.btnClose = new Button();
      this.btnEditPenalty = new Button();
      ((ISupportInitialize) this.dgPenalties).BeginInit();
      this.SuspendLayout();
      this.dgPenalties.AllowUserToAddRows = false;
      this.dgPenalties.AllowUserToResizeRows = false;
      this.dgPenalties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPenalties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgPenalties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgPenalties.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.dgPenalties.Location = new Point(12, 12);
      this.dgPenalties.MultiSelect = false;
      this.dgPenalties.Name = "dgPenalties";
      this.dgPenalties.ReadOnly = true;
      this.dgPenalties.RowHeadersVisible = false;
      this.dgPenalties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgPenalties.Size = new Size(672, 378);
      this.dgPenalties.TabIndex = 0;
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAdd.Location = new Point(129, 410);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(75, 23);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add Penalty";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDelete.Location = new Point(363, 410);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(75, 23);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete Penalty";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(480, 410);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.btnEditPenalty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEditPenalty.Location = new Point(246, 410);
      this.btnEditPenalty.Name = "btnEditPenalty";
      this.btnEditPenalty.Size = new Size(75, 23);
      this.btnEditPenalty.TabIndex = 2;
      this.btnEditPenalty.Text = "Edit Penalty";
      this.btnEditPenalty.UseVisualStyleBackColor = true;
      this.btnEditPenalty.Click += new EventHandler(this.btnEditPenalty_Click);
      this.AcceptButton = (IButtonControl) this.btnClose;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(696, 445);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnEditPenalty);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.dgPenalties);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogPenalties);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Penalties";
      this.Load += new EventHandler(this.DialogPenalties_Load);
      ((ISupportInitialize) this.dgPenalties).EndInit();
      this.ResumeLayout(false);
    }

    public DialogPenalties()
    {
      this.InitializeComponent();
    }

    private void DialogPenalties_Load(object sender, EventArgs e)
    {
      DataTable table = this.GenerateTable();
      foreach (IPenalty penalty in this.currentTournament.Penalties)
      {
        DataRow row = table.NewRow();
        row["PenaltyObject"] = (object) penalty;
        row["Player"] = (object) penalty.Player.FullName;
        row["Infraction"] = (object) PenaltyClass.GetName(penalty.Infraction);
        row["Penalty"] = (object) CommonEnumLists.PenaltyEnumNames[penalty.Penalty];
        row["Round"] = (object) penalty.Round;
        row["Judge"] = (object) penalty.Judge.FullName;
        row["Notes"] = (object) penalty.Notes;
        table.Rows.Add(row);
      }
      this.dgPenalties.DataSource = (object) table;
      this.dgPenalties.Columns["PenaltyObject"].Visible = false;
      if (this.PreselectedPlayer == null)
        return;
      int val1 = 1000000;
      for (int val2 = 0; val2 < this.dgPenalties.Rows.Count; ++val2)
      {
        DataGridViewRow row = this.dgPenalties.Rows[val2];
        if (((PenaltyClass) row.Cells["PenaltyObject"].Value).Player.ID == this.PreselectedPlayer.ID)
        {
          if (val1 == 1000000)
          {
            val1 = Math.Min(val1, val2);
            this.dgPenalties.FirstDisplayedScrollingRowIndex = val1;
          }
          row.Selected = true;
          break;
        }
        row.Selected = false;
      }
      if (val1 != 1000000)
        return;
      int num = (int) MessageBox.Show(string.Format("{0} does not have any penalties", (object) this.PreselectedPlayer.FullNameWithId));
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      DialogNewPenalty dialogNewPenalty = new DialogNewPenalty();
      dialogNewPenalty.CurrentTournament = this.currentTournament;
      if (dialogNewPenalty.ShowDialog() != DialogResult.OK)
        return;
      this.currentTournament.Penalties.Add(dialogNewPenalty.CurrentPenalty);
      this.AddRow((DataTable) this.dgPenalties.DataSource, dialogNewPenalty.CurrentPenalty);
    }

    private void btnEditPenalty_Click(object sender, EventArgs e)
    {
      if (this.dgPenalties.SelectedRows.Count != 1)
        return;
      DialogNewPenalty dialogNewPenalty = new DialogNewPenalty();
      dialogNewPenalty.CurrentTournament = this.currentTournament;
      dialogNewPenalty.CurrentPenalty = (IPenalty) this.dgPenalties.SelectedRows[0].Cells["PenaltyObject"].Value;
      if (dialogNewPenalty.ShowDialog() != DialogResult.OK)
        return;
      this.dgPenalties.SelectedRows[0].Cells["PenaltyObject"].Value = (object) dialogNewPenalty.CurrentPenalty;
      this.dgPenalties.SelectedRows[0].Cells["Player"].Value = (object) dialogNewPenalty.CurrentPenalty.Player.FullName;
      this.dgPenalties.SelectedRows[0].Cells["Infraction"].Value = (object) PenaltyClass.GetName(dialogNewPenalty.CurrentPenalty.Infraction);
      this.dgPenalties.SelectedRows[0].Cells["Penalty"].Value = (object) CommonEnumLists.PenaltyEnumNames[dialogNewPenalty.CurrentPenalty.Penalty];
      this.dgPenalties.SelectedRows[0].Cells["Round"].Value = (object) dialogNewPenalty.CurrentPenalty.Round;
      this.dgPenalties.SelectedRows[0].Cells["Judge"].Value = (object) dialogNewPenalty.CurrentPenalty.Judge.FullName;
      this.dgPenalties.SelectedRows[0].Cells["Notes"].Value = (object) dialogNewPenalty.CurrentPenalty.Notes;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dgPenalties.SelectedRows.Count != 1)
        return;
      this.currentTournament.Penalties.Remove((IPenalty) this.dgPenalties.SelectedRows[0].Cells["PenaltyObject"].Value);
      this.dgPenalties.Rows.Remove(this.dgPenalties.SelectedRows[0]);
    }

    private DataTable GenerateTable()
    {
      return new DataTable()
      {
        Columns = {
          {
            "PenaltyObject",
            typeof (PenaltyClass)
          },
          {
            "Player",
            typeof (string)
          },
          {
            "Infraction",
            typeof (string)
          },
          {
            "Penalty",
            typeof (string)
          },
          {
            "Round",
            typeof (int)
          },
          {
            "Judge",
            typeof (string)
          },
          {
            "Notes",
            typeof (string)
          }
        }
      };
    }

    private void AddRow(DataTable penaltyTable, IPenalty penalty)
    {
      DataRow row = penaltyTable.NewRow();
      row["PenaltyObject"] = (object) penalty;
      row["Player"] = (object) penalty.Player.FullName;
      row["Infraction"] = (object) PenaltyClass.GetName(penalty.Infraction);
      row["Penalty"] = (object) CommonEnumLists.PenaltyEnumNames[penalty.Penalty];
      row["Round"] = (object) penalty.Round;
      row["Judge"] = (object) penalty.Judge.FullName;
      row["Notes"] = (object) penalty.Notes;
      penaltyTable.Rows.Add(row);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }
  }
}
