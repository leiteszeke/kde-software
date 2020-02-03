// Decompiled with JetBrains decompiler
// Type: Konami.DialogNewPenalty
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
  public class DialogNewPenalty : Form
  {
    public IPenalty CurrentPenalty = (IPenalty) new PenaltyClass();
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private ComboBox ddlPlayers;
    private ComboBox ddlInfraction;
    private ComboBox ddlPenalty;
    private TextBox txtRound;
    private TextBox txtNotes;
    private Button btnOK;
    private Button btnCancel;
    private ComboBox ddlJudges;
    private Label label6;
    private Button btnEnterId;
    public ITournament CurrentTournament;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogNewPenalty));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.ddlPlayers = new ComboBox();
      this.ddlInfraction = new ComboBox();
      this.ddlPenalty = new ComboBox();
      this.txtRound = new TextBox();
      this.txtNotes = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.ddlJudges = new ComboBox();
      this.label6 = new Label();
      this.btnEnterId = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(28, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(39, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Player:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(28, 90);
      this.label2.Name = "label2";
      this.label2.Size = new Size(54, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Infraction:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(28, 123);
      this.label3.Name = "label3";
      this.label3.Size = new Size(45, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Penalty:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(28, 156);
      this.label4.Name = "label4";
      this.label4.Size = new Size(42, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Round:";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(28, 189);
      this.label5.Name = "label5";
      this.label5.Size = new Size(38, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Notes:";
      this.ddlPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPlayers.FormattingEnabled = true;
      this.ddlPlayers.Location = new Point(109, 20);
      this.ddlPlayers.MaxDropDownItems = 25;
      this.ddlPlayers.Name = "ddlPlayers";
      this.ddlPlayers.Size = new Size(198, 21);
      this.ddlPlayers.TabIndex = 1;
      this.ddlInfraction.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlInfraction.FormattingEnabled = true;
      this.ddlInfraction.Location = new Point(109, 86);
      this.ddlInfraction.Name = "ddlInfraction";
      this.ddlInfraction.Size = new Size(292, 21);
      this.ddlInfraction.TabIndex = 6;
      this.ddlInfraction.SelectedIndexChanged += new EventHandler(this.ddlInfraction_SelectedIndexChanged);
      this.ddlPenalty.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPenalty.FormattingEnabled = true;
      this.ddlPenalty.Location = new Point(109, 119);
      this.ddlPenalty.Name = "ddlPenalty";
      this.ddlPenalty.Size = new Size(292, 21);
      this.ddlPenalty.TabIndex = 8;
      this.txtRound.Location = new Point(109, 153);
      this.txtRound.MaxLength = 2;
      this.txtRound.Name = "txtRound";
      this.txtRound.Size = new Size(58, 20);
      this.txtRound.TabIndex = 10;
      this.txtNotes.Location = new Point(109, 187);
      this.txtNotes.MaxLength = 2000;
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new Size(292, 66);
      this.txtNotes.TabIndex = 12;
      this.btnOK.Location = new Point(99, 292);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 13;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(232, 292);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 14;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.ddlJudges.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlJudges.FormattingEnabled = true;
      this.ddlJudges.Location = new Point(109, 53);
      this.ddlJudges.MaxDropDownItems = 25;
      this.ddlJudges.Name = "ddlJudges";
      this.ddlJudges.Size = new Size(292, 21);
      this.ddlJudges.TabIndex = 4;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(28, 57);
      this.label6.Name = "label6";
      this.label6.Size = new Size(39, 13);
      this.label6.TabIndex = 3;
      this.label6.Text = "Judge:";
      this.btnEnterId.Location = new Point(313, 20);
      this.btnEnterId.Name = "btnEnterId";
      this.btnEnterId.Size = new Size(88, 23);
      this.btnEnterId.TabIndex = 2;
      this.btnEnterId.Text = "Enter ID";
      this.btnEnterId.UseVisualStyleBackColor = true;
      this.btnEnterId.Click += new EventHandler(this.btnEnterId_Click);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(428, 371);
      this.Controls.Add((Control) this.btnEnterId);
      this.Controls.Add((Control) this.ddlJudges);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtNotes);
      this.Controls.Add((Control) this.txtRound);
      this.Controls.Add((Control) this.ddlPenalty);
      this.Controls.Add((Control) this.ddlInfraction);
      this.Controls.Add((Control) this.ddlPlayers);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogNewPenalty);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Penalty";
      this.Load += new EventHandler(this.DialogNewPenalty_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void ddlInfraction_SelectedIndexChanged(object sender, EventArgs e)
    {
      PenaltyEnum defaultPenalty = PenaltyClass.GetDefaultPenalty(((InfractionListItem) this.ddlInfraction.SelectedItem).Value);
      this.ddlPenalty.SelectedIndex = -1;
      foreach (ListItemPenaltyEnum listItemPenaltyEnum in this.ddlPenalty.Items)
      {
        if (listItemPenaltyEnum.Value == defaultPenalty)
        {
          this.ddlPenalty.SelectedItem = (object) listItemPenaltyEnum;
          break;
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try
      {
        this.CurrentPenalty = (IPenalty) new PenaltyClass();
        if (this.ddlPlayers.SelectedItem == null)
          throw new Exception("No player selected");
        if (this.ddlJudges.SelectedItem == null)
          throw new Exception("No judge selected");
        if (this.ddlPenalty.SelectedItem == null)
          throw new Exception("No penalty selected");
        if (this.ddlInfraction.SelectedItem == null)
          throw new Exception("No infraction selected");
        this.CurrentPenalty.Player = (IPlayer) this.ddlPlayers.SelectedItem;
        this.CurrentPenalty.Judge = (ITournStaff) this.ddlJudges.SelectedItem;
        this.CurrentPenalty.Infraction = ((InfractionListItem) this.ddlInfraction.SelectedItem).Value;
        this.CurrentPenalty.Penalty = ((ListItemPenaltyEnum) this.ddlPenalty.SelectedItem).Value;
        this.CurrentPenalty.Notes = this.txtNotes.Text;
        this.CurrentPenalty.Round = Convert.ToInt32(this.txtRound.Text);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return;
      }
      this.DialogResult = DialogResult.OK;
    }

    public DialogNewPenalty()
    {
      this.InitializeComponent();
    }

    private void DialogNewPenalty_Load(object sender, EventArgs e)
    {
      if (this.CurrentTournament != null)
      {
        ITournPlayer[] array1 = new ITournPlayer[this.CurrentTournament.Players.Count];
        this.CurrentTournament.Players.SortByLastname();
        this.CurrentTournament.Players.CopyTo(array1, 0);
        this.ddlPlayers.Items.AddRange((object[]) array1);
        if (!this.CurrentPenalty.Player.IsBye)
        {
          for (int index = 0; index < this.ddlPlayers.Items.Count; ++index)
          {
            if (((IPlayer) this.ddlPlayers.Items[index]).ID == this.CurrentPenalty.Player.ID)
            {
              this.ddlPlayers.SelectedIndex = index;
              break;
            }
          }
        }
        TournStaffArray tournStaffArray = new TournStaffArray();
        foreach (TournStaff tournStaff in (IEnumerable<ITournStaff>) this.CurrentTournament.Staff)
        {
          if (tournStaff.Position == StaffPosition.Judge || tournStaff.Position == StaffPosition.JudgeTeamLead || (tournStaff.Position == StaffPosition.HeadJudge || tournStaff.Position == StaffPosition.AssistantHeadJudge))
            tournStaffArray.Add((ITournStaff) tournStaff);
        }
        ITournStaff[] array2 = new ITournStaff[tournStaffArray.Count];
        tournStaffArray.SortByLastname();
        tournStaffArray.CopyTo(array2, 0);
        this.ddlJudges.Items.AddRange((object[]) array2);
        if (!this.CurrentPenalty.Judge.IsBye)
        {
          for (int index = 0; index < this.ddlJudges.Items.Count; ++index)
          {
            if (((IPlayer) this.ddlJudges.Items[index]).ID == this.CurrentPenalty.Judge.ID)
            {
              this.ddlJudges.SelectedIndex = index;
              break;
            }
          }
        }
      }
      foreach (InfractionEnum inf in Enum.GetValues(typeof (InfractionEnum)))
        this.ddlInfraction.Items.Add((object) new InfractionListItem(inf));
      if (this.CurrentPenalty.Infraction != InfractionEnum.None)
        this.ddlInfraction.SelectedIndex = this.ddlInfraction.FindString(PenaltyClass.GetName(this.CurrentPenalty.Infraction));
      else
        this.ddlInfraction.SelectedIndex = 0;
      foreach (PenaltyEnum key in CommonEnumLists.PenaltyEnumNames.Keys)
      {
        ListItemPenaltyEnum listItemPenaltyEnum = new ListItemPenaltyEnum(key);
        this.ddlPenalty.Items.Add((object) listItemPenaltyEnum);
        if (listItemPenaltyEnum.Value == this.CurrentPenalty.Penalty)
          this.ddlPenalty.SelectedItem = (object) listItemPenaltyEnum;
      }
      this.txtNotes.Text = this.CurrentPenalty.Notes;
      this.txtRound.Text = this.CurrentPenalty.Round.ToString();
    }

    private void btnEnterId_Click(object sender, EventArgs e)
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
