// Decompiled with JetBrains decompiler
// Type: Konami.DialogWizardChangeMatchResult
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogWizardChangeMatchResult : Form
  {
    public TournMatchArray newMatches = new TournMatchArray();
    public ITournament currentTournament;
    private ITournMatch currentMatch;
    private ITournMatch p1match;
    private ITournMatch p2match;
    private IContainer components;
    private Label label1;
    private TextBox txtRound;
    private Label label2;
    private TextBox txtTable;
    private Button btnLookup;
    private RadioButton radioResultsDraw;
    private RadioButton radioResultsDoubleLoss;
    private RadioButton radioResultsPlayer2;
    private RadioButton radioResultsPlayer1;
    private RadioButton radioResultsUnreported;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label lblMatch2;
    private Label lblMatch1;
    private CheckBox chkPrintMatchResultSlips;
    private CheckBox chkPlayerSwap;
    private Button btnApplyChanges;
    private Button btnClose;

    public bool PrintNewMatchSlips
    {
      get
      {
        return this.chkPrintMatchResultSlips.Checked;
      }
    }

    private void chkPlayerSwap_CheckedChanged(object sender, EventArgs e)
    {
      this.chkPrintMatchResultSlips.Enabled = this.chkPlayerSwap.Checked;
    }

    private void btnApplyChanges_Click(object sender, EventArgs e)
    {
      if (this.currentMatch == null)
      {
        int num1 = (int) MessageBox.Show("Invalid match");
      }
      else
      {
        if (this.radioResultsPlayer1.Checked)
        {
          this.currentMatch.Winner = this.currentMatch.Players[0].ID;
          this.currentMatch.Status = TournMatchResult.Winner;
        }
        else if (this.radioResultsPlayer2.Checked)
        {
          this.currentMatch.Winner = this.currentMatch.Players[1].ID;
          this.currentMatch.Status = TournMatchResult.Winner;
        }
        else if (this.radioResultsDraw.Checked)
        {
          this.currentMatch.Winner = Player.BYE_ID;
          this.currentMatch.Status = TournMatchResult.Draw;
        }
        else if (this.radioResultsDoubleLoss.Checked)
        {
          this.currentMatch.Winner = Player.BYE_ID;
          this.currentMatch.Status = TournMatchResult.DoubleLoss;
        }
        else if (this.radioResultsUnreported.Checked)
        {
          this.currentMatch.Winner = Player.BYE_ID;
          this.currentMatch.Status = TournMatchResult.Incomplete;
        }
        this.currentTournament.ClearTies();
        if (this.chkPlayerSwap.Checked && this.p1match != null && this.p2match != null)
        {
          ITournPlayer player1 = (ITournPlayer) null;
          ITournPlayer player2 = (ITournPlayer) null;
          for (int index = 0; index < this.p1match.Players.Count; ++index)
          {
            ITournPlayer player3 = this.p1match.Players[index];
            if (this.currentMatch.Players.HasPlayer(player3.ID))
              player1 = player3;
          }
          for (int index = 0; index < this.p2match.Players.Count; ++index)
          {
            ITournPlayer player3 = this.p2match.Players[index];
            if (this.currentMatch.Players.HasPlayer(player3.ID))
              player2 = player3;
          }
          if (player2 != null && player1 != null && player1.ID != player2.ID)
          {
            this.p1match.Players.RemovePlayer(player1);
            this.p2match.Players.RemovePlayer(player2);
            this.p1match.Players.AddPlayer(player2);
            this.p2match.Players.AddPlayer(player1);
            this.newMatches.AddMatch(this.p1match);
            this.newMatches.AddMatch(this.p2match);
          }
        }
        int num2 = (int) MessageBox.Show("Change Complete");
        this.ResetForm();
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnLookup_Click(object sender, EventArgs e)
    {
      this.currentMatch = (ITournMatch) null;
      this.p1match = (ITournMatch) null;
      this.p2match = (ITournMatch) null;
      this.InitMatchResults();
      this.InitCurrentMatches();
      int result1 = 0;
      int result2 = 0;
      int.TryParse(this.txtRound.Text, out result1);
      int.TryParse(this.txtTable.Text, out result2);
      if (result2 == 0 || result1 == 0)
      {
        int num1 = (int) MessageBox.Show("Invalid round or table");
      }
      else if (this.currentTournament == null)
      {
        int num2 = (int) MessageBox.Show("Invalid tournament");
      }
      else
      {
        int table = result2 - this.currentTournament.TableOffset;
        this.currentMatch = this.currentTournament.Matches.GetByRoundTable(result1, table);
        if (this.currentMatch == null)
        {
          int num3 = (int) MessageBox.Show("Match for round and table not found");
        }
        else
        {
          this.InitMatchResults();
          ITournMatchArray byRound = this.currentTournament.Matches.GetByRound(this.currentTournament.CurrentRound);
          ITournMatchArray byPlayer1 = byRound.GetByPlayer(this.currentMatch.Players[0].ID);
          ITournMatchArray byPlayer2 = byRound.GetByPlayer(this.currentMatch.Players[1].ID);
          this.p1match = byPlayer1.Count <= 0 ? (ITournMatch) null : byPlayer1[0];
          this.p2match = byPlayer2.Count <= 0 ? (ITournMatch) null : byPlayer2[0];
          if (this.p1match != null && this.p2match != null && this.p1match.Table > this.p2match.Table)
          {
            ITournMatch p2match = this.p2match;
            this.p2match = this.p1match;
            this.p1match = p2match;
          }
          this.InitCurrentMatches();
        }
      }
    }

    public DialogWizardChangeMatchResult()
    {
      this.InitializeComponent();
    }

    private void DialogWizardChangeMatchResult_Load(object sender, EventArgs e)
    {
      this.ResetForm();
      if (this.currentTournament == null)
        return;
      this.currentTournament.CalculateTies();
    }

    private void InitCurrentMatches()
    {
      if (this.p1match != null)
        this.lblMatch1.Text = string.Format("Table {0}: {1} ({2} pts) vs {3} ({4} pts)", (object) (this.p1match.Table + this.currentTournament.TableOffset), (object) this.p1match.Players[0].FullName, (object) this.p1match.Players[0].Tie1_Wins, (object) this.p1match.Players[1].FullName, (object) this.p1match.Players[1].Tie1_Wins);
      else if (this.currentMatch != null)
        this.lblMatch1.Text = string.Format("No match this round for {0}", (object) this.currentMatch.Players[0]);
      else
        this.lblMatch1.Text = "<Match 1>";
      if (this.p2match != null)
        this.lblMatch2.Text = string.Format("Table {0}: {1} ({2} pts) vs {3} ({4} pts)", (object) (this.p2match.Table + this.currentTournament.TableOffset), (object) this.p2match.Players[0].FullName, (object) this.p2match.Players[0].Tie1_Wins, (object) this.p2match.Players[1].FullName, (object) this.p2match.Players[1].Tie1_Wins);
      else if (this.currentMatch != null)
        this.lblMatch2.Text = string.Format("No match this round for {0}", (object) this.currentMatch.Players[1]);
      else
        this.lblMatch2.Text = "<Match 2>";
      this.chkPlayerSwap.Checked = false;
      this.chkPlayerSwap.Enabled = this.p1match != null && this.p2match != null;
    }

    private void InitMatchResults()
    {
      if (this.currentMatch != null)
      {
        this.radioResultsPlayer1.Text = this.currentMatch.Players[0].FullName + " Wins";
        this.radioResultsPlayer1.Checked = this.currentMatch.Winner == this.currentMatch.Players[0].ID;
        this.radioResultsPlayer2.Text = this.currentMatch.Players[1].FullName + " Wins";
        this.radioResultsPlayer2.Checked = this.currentMatch.Winner == this.currentMatch.Players[1].ID;
        this.radioResultsDraw.Checked = this.currentMatch.Status == TournMatchResult.Draw;
        this.radioResultsDoubleLoss.Checked = this.currentMatch.Status == TournMatchResult.DoubleLoss;
        this.radioResultsUnreported.Checked = this.currentMatch.Status == TournMatchResult.Incomplete;
        this.btnApplyChanges.Enabled = true;
      }
      else
      {
        this.radioResultsPlayer1.Text = "<Player 1> Wins";
        this.radioResultsPlayer1.Checked = false;
        this.radioResultsPlayer2.Text = "<Player 2> Wins";
        this.radioResultsPlayer2.Checked = false;
        this.radioResultsDraw.Checked = false;
        this.radioResultsDoubleLoss.Checked = false;
        this.radioResultsUnreported.Checked = false;
        this.btnApplyChanges.Enabled = false;
      }
    }

    private void ResetForm()
    {
      this.currentMatch = (ITournMatch) null;
      this.p1match = (ITournMatch) null;
      this.p2match = (ITournMatch) null;
      this.InitMatchResults();
      this.InitCurrentMatches();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogWizardChangeMatchResult));
      this.label1 = new Label();
      this.txtRound = new TextBox();
      this.label2 = new Label();
      this.txtTable = new TextBox();
      this.btnLookup = new Button();
      this.radioResultsDraw = new RadioButton();
      this.radioResultsDoubleLoss = new RadioButton();
      this.radioResultsPlayer2 = new RadioButton();
      this.radioResultsPlayer1 = new RadioButton();
      this.radioResultsUnreported = new RadioButton();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.chkPrintMatchResultSlips = new CheckBox();
      this.chkPlayerSwap = new CheckBox();
      this.lblMatch2 = new Label();
      this.lblMatch1 = new Label();
      this.btnApplyChanges = new Button();
      this.btnClose = new Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(71, 29);
      this.label1.Name = "label1";
      this.label1.Size = new Size(42, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Round:";
      this.txtRound.Location = new Point(119, 26);
      this.txtRound.Name = "txtRound";
      this.txtRound.Size = new Size(45, 20);
      this.txtRound.TabIndex = 1;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(170, 29);
      this.label2.Name = "label2";
      this.label2.Size = new Size(37, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Table:";
      this.txtTable.Location = new Point(213, 26);
      this.txtTable.Name = "txtTable";
      this.txtTable.Size = new Size(48, 20);
      this.txtTable.TabIndex = 3;
      this.btnLookup.Location = new Point(277, 24);
      this.btnLookup.Name = "btnLookup";
      this.btnLookup.Size = new Size(75, 23);
      this.btnLookup.TabIndex = 4;
      this.btnLookup.Text = "Lookup";
      this.btnLookup.UseVisualStyleBackColor = true;
      this.btnLookup.Click += new EventHandler(this.btnLookup_Click);
      this.radioResultsDraw.AutoSize = true;
      this.radioResultsDraw.Location = new Point(13, 79);
      this.radioResultsDraw.Name = "radioResultsDraw";
      this.radioResultsDraw.Size = new Size(50, 17);
      this.radioResultsDraw.TabIndex = 7;
      this.radioResultsDraw.TabStop = true;
      this.radioResultsDraw.Text = "Draw";
      this.radioResultsDraw.UseVisualStyleBackColor = true;
      this.radioResultsDoubleLoss.AutoSize = true;
      this.radioResultsDoubleLoss.Location = new Point(13, 102);
      this.radioResultsDoubleLoss.Name = "radioResultsDoubleLoss";
      this.radioResultsDoubleLoss.Size = new Size(84, 17);
      this.radioResultsDoubleLoss.TabIndex = 8;
      this.radioResultsDoubleLoss.TabStop = true;
      this.radioResultsDoubleLoss.Text = "Double Loss";
      this.radioResultsDoubleLoss.UseVisualStyleBackColor = true;
      this.radioResultsPlayer2.AutoSize = true;
      this.radioResultsPlayer2.Location = new Point(13, 55);
      this.radioResultsPlayer2.Name = "radioResultsPlayer2";
      this.radioResultsPlayer2.Size = new Size(102, 17);
      this.radioResultsPlayer2.TabIndex = 6;
      this.radioResultsPlayer2.TabStop = true;
      this.radioResultsPlayer2.Text = "<Player 2> Wins";
      this.radioResultsPlayer2.UseVisualStyleBackColor = true;
      this.radioResultsPlayer1.AutoSize = true;
      this.radioResultsPlayer1.Location = new Point(13, 30);
      this.radioResultsPlayer1.Name = "radioResultsPlayer1";
      this.radioResultsPlayer1.Size = new Size(102, 17);
      this.radioResultsPlayer1.TabIndex = 5;
      this.radioResultsPlayer1.TabStop = true;
      this.radioResultsPlayer1.Text = "<Player 1> Wins";
      this.radioResultsPlayer1.UseVisualStyleBackColor = true;
      this.radioResultsUnreported.AutoSize = true;
      this.radioResultsUnreported.Location = new Point(13, 125);
      this.radioResultsUnreported.Name = "radioResultsUnreported";
      this.radioResultsUnreported.Size = new Size(78, 17);
      this.radioResultsUnreported.TabIndex = 9;
      this.radioResultsUnreported.TabStop = true;
      this.radioResultsUnreported.Text = "Unreported";
      this.radioResultsUnreported.UseVisualStyleBackColor = true;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.radioResultsPlayer1);
      this.groupBox1.Controls.Add((Control) this.radioResultsUnreported);
      this.groupBox1.Controls.Add((Control) this.radioResultsPlayer2);
      this.groupBox1.Controls.Add((Control) this.radioResultsDraw);
      this.groupBox1.Controls.Add((Control) this.radioResultsDoubleLoss);
      this.groupBox1.Location = new Point(16, 69);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(398, 166);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Match Result";
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.chkPrintMatchResultSlips);
      this.groupBox2.Controls.Add((Control) this.chkPlayerSwap);
      this.groupBox2.Controls.Add((Control) this.lblMatch2);
      this.groupBox2.Controls.Add((Control) this.lblMatch1);
      this.groupBox2.Location = new Point(16, 241);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(398, 159);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Current Round Opponents";
      this.chkPrintMatchResultSlips.AutoSize = true;
      this.chkPrintMatchResultSlips.Location = new Point(13, 115);
      this.chkPrintMatchResultSlips.Name = "chkPrintMatchResultSlips";
      this.chkPrintMatchResultSlips.Size = new Size(155, 17);
      this.chkPrintMatchResultSlips.TabIndex = 3;
      this.chkPrintMatchResultSlips.Text = "Print Updated Result Slips?";
      this.chkPrintMatchResultSlips.UseVisualStyleBackColor = true;
      this.chkPlayerSwap.AutoSize = true;
      this.chkPlayerSwap.Location = new Point(13, 85);
      this.chkPlayerSwap.Name = "chkPlayerSwap";
      this.chkPlayerSwap.Size = new Size(96, 17);
      this.chkPlayerSwap.TabIndex = 2;
      this.chkPlayerSwap.Text = "Swap Players?";
      this.chkPlayerSwap.UseVisualStyleBackColor = true;
      this.chkPlayerSwap.CheckedChanged += new EventHandler(this.chkPlayerSwap_CheckedChanged);
      this.lblMatch2.AutoSize = true;
      this.lblMatch2.Location = new Point(10, 59);
      this.lblMatch2.Name = "lblMatch2";
      this.lblMatch2.Size = new Size(58, 13);
      this.lblMatch2.TabIndex = 1;
      this.lblMatch2.Text = "<Match 2>";
      this.lblMatch1.AutoSize = true;
      this.lblMatch1.Location = new Point(10, 33);
      this.lblMatch1.Name = "lblMatch1";
      this.lblMatch1.Size = new Size(58, 13);
      this.lblMatch1.TabIndex = 0;
      this.lblMatch1.Text = "<Match 1>";
      this.btnApplyChanges.Location = new Point(128, 424);
      this.btnApplyChanges.Name = "btnApplyChanges";
      this.btnApplyChanges.Size = new Size(75, 23);
      this.btnApplyChanges.TabIndex = 12;
      this.btnApplyChanges.Text = "Apply Changes";
      this.btnApplyChanges.UseVisualStyleBackColor = true;
      this.btnApplyChanges.Click += new EventHandler(this.btnApplyChanges_Click);
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(243, 424);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 13;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(440, 469);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnApplyChanges);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btnLookup);
      this.Controls.Add((Control) this.txtTable);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.txtRound);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogWizardChangeMatchResult);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Change Match Result Wizard";
      this.Load += new EventHandler(this.DialogWizardChangeMatchResult_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
