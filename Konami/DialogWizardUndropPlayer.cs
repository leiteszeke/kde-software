// Decompiled with JetBrains decompiler
// Type: Konami.DialogWizardUndropPlayer
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogWizardUndropPlayer : Form
  {
    public TournMatchArray NewMatches = new TournMatchArray();
    private TournMatchArray PendingMatches = new TournMatchArray();
    public ITournament CurrentTournament;
    private ITournMatch playerVsBye;
    private ITournMatchArray CurrentMatches;
    private ITournPlayer currentPlayer;
    private IContainer components;
    private Button btnClose;
    private Button btnApplyChanges;
    private GroupBox groupBox2;
    private GroupBox groupBox1;
    private CheckBox chkPrevRoundP2Drop;
    private CheckBox chkPrevRoundP1Drop;
    private RadioButton radioREOByeLoss;
    private RadioButton radioREOByeWin;
    private RadioButton radioREOSwapDrops;
    private RadioButton radioREOVsCurrentPlayerWithBye;
    private CheckBox chkPrintNewResultSlips;
    private ListBox listNewPairings;
    private Label label3;
    private ListBox listCurrentPairings;
    private Label label2;
    private RadioButton radioREORePairings;
    private ComboBox ddlDroppedPlayers;
    private Label label1;

    public bool PrintNewMatchSlips
    {
      get
      {
        return this.chkPrintNewResultSlips.Checked;
      }
    }

    private void radioREOByeLoss_CheckedChanged(object sender, EventArgs e)
    {
      this.EnableOKButton();
    }

    private void radioREOByeWin_CheckedChanged(object sender, EventArgs e)
    {
      this.EnableOKButton();
    }

    private void radioREORePairings_CheckedChanged(object sender, EventArgs e)
    {
      this.EnableOKButton();
    }

    private void radioREOSwapDrops_CheckedChanged(object sender, EventArgs e)
    {
      this.EnableOKButton();
    }

    private void radioREOVsCurrentPlayerWithBye_CheckedChanged(object sender, EventArgs e)
    {
      this.EnableOKButton();
    }

    private void ddlDroppedPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.CurrentTournament == null)
      {
        int num = (int) MessageBox.Show("Error reading tournament info");
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }
      if (this.ddlDroppedPlayers.SelectedIndex < 0)
      {
        int num1 = (int) MessageBox.Show("Invalid Player");
      }
      else
      {
        this.currentPlayer = (ITournPlayer) this.ddlDroppedPlayers.SelectedItem;
        this.listCurrentPairings.Items.Clear();
        this.listNewPairings.Items.Clear();
        int round = this.CurrentTournament.CurrentRound - 1;
        ITournMatchArray byRound = this.CurrentTournament.Matches.GetByPlayer(this.currentPlayer.ID).GetByRound(round);
        if (byRound.Count == 0)
        {
          int num2 = (int) MessageBox.Show("Player was not in previous round");
        }
        else
        {
          if (byRound[0].Players[0].ID == byRound[0].Winner)
          {
            this.chkPrevRoundP1Drop.Text = byRound[0].Players[0].FullNameWithId + " (Winner)";
            this.chkPrevRoundP2Drop.Text = byRound[0].Players[1].FullNameWithId;
          }
          else if (byRound[0].Players[1].ID == byRound[0].Winner)
          {
            this.chkPrevRoundP1Drop.Text = byRound[0].Players[0].FullNameWithId;
            this.chkPrevRoundP2Drop.Text = byRound[0].Players[1].FullNameWithId + " (Winner)";
          }
          else
          {
            this.chkPrevRoundP1Drop.Text = string.Format("{0} ({1})", (object) byRound[0].Players[0].FullNameWithId, (object) byRound[0].StatusText);
            this.chkPrevRoundP2Drop.Text = byRound[0].Players[1].FullNameWithId;
          }
          this.chkPrevRoundP1Drop.Checked = byRound[0].Players[0].DropRound == round;
          this.chkPrevRoundP2Drop.Checked = byRound[0].Players[1].DropRound == round;
          this.radioREOSwapDrops.Enabled = byRound[0].Players[0].IsActive ^ byRound[0].Players[1].IsActive;
          this.CurrentMatches = this.CurrentTournament.Matches.GetPairedDown(this.CurrentTournament.CurrentRound);
          foreach (ITournMatch currentMatch in (IEnumerable<ITournMatch>) this.CurrentMatches)
          {
            if (currentMatch.Players.HasPlayer(Player.BYE_ID) && currentMatch.Winner != Player.BYE_ID)
            {
              this.playerVsBye = currentMatch;
              this.radioREOVsCurrentPlayerWithBye.Enabled = true;
              using (IEnumerator<ITournPlayer> enumerator = currentMatch.Players.GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  ITournPlayer current = enumerator.Current;
                  if (!current.IsBye)
                    this.radioREOVsCurrentPlayerWithBye.Text = string.Format("Pair vs. Bye Player: {0} ({1} pts)", (object) current.FullNameWithId, (object) current.Points);
                }
                break;
              }
            }
          }
          this.radioREOByeLoss.Enabled = true;
          this.radioREOByeWin.Enabled = true;
          this.radioREORePairings.Enabled = true;
          byRound.SortByPoints();
          for (int index = this.CurrentMatches.Count - 1; index >= 0; --index)
          {
            if (this.CurrentMatches[index].Points > this.currentPlayer.Tie1_Wins)
              this.CurrentMatches.RemoveAt(index);
          }
          Random random = new Random();
          for (int pointCount = 0; pointCount <= this.currentPlayer.Tie1_Wins; ++pointCount)
          {
            if (this.CurrentMatches.GetByPoints(this.CurrentTournament.CurrentRound, pointCount).Count == 0)
            {
              ITournMatchArray byPoints = this.CurrentTournament.Matches.GetByPoints(this.CurrentTournament.CurrentRound, pointCount);
              if (byPoints.Count > 0)
                this.CurrentMatches.AddMatch(byPoints[random.Next(byPoints.Count - 1)]);
            }
          }
          this.CurrentMatches.SortByPoints();
          foreach (ITournMatch currentMatch in (IEnumerable<ITournMatch>) this.CurrentMatches)
            this.listCurrentPairings.Items.Add((object) string.Format("#{0}: {1} ({2} pts) vs {3} ({4} pts)", (object) (currentMatch.Table + this.CurrentTournament.TableOffset), (object) currentMatch.Players[0].FullNameWithId, (object) currentMatch.Players[0].Tie1_Wins, (object) currentMatch.Players[1].FullNameWithId, (object) currentMatch.Players[1].Tie1_Wins));
          this.PendingMatches.Clear();
          ITournPlayer player1 = this.currentPlayer;
          foreach (ITournMatch currentMatch in (IEnumerable<ITournMatch>) this.CurrentMatches)
          {
            TournMatch tournMatch = new TournMatch(currentMatch);
            this.PendingMatches.AddMatch((ITournMatch) tournMatch);
            ITournPlayer currentPlayer = this.currentPlayer;
            ITournPlayer player2 = !tournMatch.Players[0].IsBye ? (!tournMatch.Players[1].IsBye ? (tournMatch.Players[0].Tie1_Wins <= tournMatch.Players[1].Tie1_Wins ? (tournMatch.Players[0].Tie1_Wins >= tournMatch.Players[1].Tie1_Wins ? tournMatch.Players[random.Next(tournMatch.Players.Count - 1)] : tournMatch.Players[0]) : tournMatch.Players[1]) : tournMatch.Players[1]) : tournMatch.Players[0];
            tournMatch.Players.RemovePlayer(player2);
            tournMatch.Players.AddPlayer(player1);
            tournMatch.Winner = Player.BYE_ID;
            tournMatch.Status = TournMatchResult.Incomplete;
            player1 = player2;
          }
          if (!player1.IsBye)
          {
            ITournMatch blankMatch = this.CreateBlankMatch();
            blankMatch.Players.AddPlayer(player1);
            blankMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
            blankMatch.Winner = player1.ID;
            blankMatch.Status = TournMatchResult.Winner;
            this.PendingMatches.AddMatch(blankMatch);
          }
          foreach (ITournMatch pendingMatch in (List<ITournMatch>) this.PendingMatches)
            this.listNewPairings.Items.Add((object) string.Format("#{0}: {1} ({2} pts) vs {3} ({4} pts)", (object) (pendingMatch.Table + this.CurrentTournament.TableOffset), (object) pendingMatch.Players[0].FullNameWithId, (object) pendingMatch.Players[0].Tie1_Wins, (object) pendingMatch.Players[1].FullNameWithId, (object) pendingMatch.Players[1].Tie1_Wins));
          this.chkPrintNewResultSlips.Enabled = true;
        }
      }
    }

    private void btnApplyChanges_Click(object sender, EventArgs e)
    {
      this.currentPlayer.DropRound = 0;
      this.currentPlayer.DropReason = CutType.Active;
      if (this.radioREOByeLoss.Checked)
      {
        ITournMatch blankMatch = this.CreateBlankMatch();
        blankMatch.Players.AddPlayer(this.currentPlayer);
        blankMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
        blankMatch.Winner = Player.BYE_ID;
        blankMatch.Status = TournMatchResult.Winner;
        this.PendingMatches.Clear();
        this.NewMatches.AddMatch(blankMatch);
      }
      else if (this.radioREOByeWin.Checked)
      {
        ITournMatch blankMatch = this.CreateBlankMatch();
        blankMatch.Players.AddPlayer(this.currentPlayer);
        blankMatch.Players.AddPlayer((ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer));
        blankMatch.Winner = this.currentPlayer.ID;
        blankMatch.Status = TournMatchResult.Winner;
        this.PendingMatches.Clear();
        this.NewMatches.AddMatch(blankMatch);
      }
      else if (this.radioREORePairings.Checked)
      {
        this.NewMatches.Append((ITournMatchArray) this.PendingMatches);
        this.PendingMatches.Clear();
      }
      else if (this.radioREOSwapDrops.Checked)
      {
        int round = this.CurrentTournament.CurrentRound - 1;
        ITournMatchArray byPlayer1 = this.CurrentTournament.Matches.GetByPlayer(this.currentPlayer.ID);
        if (byPlayer1.Count == 0)
        {
          int num = (int) MessageBox.Show("Error");
          return;
        }
        ITournMatchArray byRound1 = byPlayer1.GetByRound(round);
        if (byRound1.Count > 1)
        {
          int num = (int) MessageBox.Show("Error");
          return;
        }
        ITournPlayer byId = this.CurrentTournament.Players.FindById(byRound1[0].GetOpponentId(this.currentPlayer.ID));
        byId.DropRound = round;
        byId.DropReason = CutType.Drop;
        ITournMatchArray byPlayer2 = this.CurrentTournament.Matches.GetByPlayer(byId.ID);
        if (byPlayer2.Count == 0)
        {
          int num = (int) MessageBox.Show("Error");
          return;
        }
        ITournMatchArray byRound2 = byPlayer2.GetByRound(this.CurrentTournament.CurrentRound);
        if (byRound2.Count > 1)
        {
          int num = (int) MessageBox.Show("Error");
          return;
        }
        TournMatch tournMatch = new TournMatch(byRound2[0]);
        tournMatch.Players.RemovePlayer(byId);
        tournMatch.Players.AddPlayer(this.currentPlayer);
        tournMatch.Winner = Player.BYE_ID;
        tournMatch.Status = TournMatchResult.Incomplete;
        this.PendingMatches.Clear();
        this.NewMatches.AddMatch((ITournMatch) tournMatch);
      }
      else if (this.radioREOVsCurrentPlayerWithBye.Checked)
      {
        this.playerVsBye.Players.SortByIDByesLast();
        this.playerVsBye.Players.RemoveAt(this.playerVsBye.Players.Count - 1);
        this.playerVsBye.Players.AddPlayer(this.currentPlayer);
        this.playerVsBye.Winner = Player.BYE_ID;
        this.playerVsBye.Status = TournMatchResult.Incomplete;
        this.PendingMatches.Clear();
        this.NewMatches.AddMatch(this.playerVsBye);
      }
      this.DialogResult = DialogResult.OK;
    }

    public DialogWizardUndropPlayer()
    {
      this.InitializeComponent();
    }

    private ITournMatch CreateBlankMatch()
    {
      ITournMatch tournMatch = (ITournMatch) new TournMatch();
      tournMatch.Round = this.CurrentTournament.CurrentRound;
      ITournMatchArray byRound = this.CurrentTournament.Matches.GetByRound(tournMatch.Round);
      byRound.SortByRoundTable();
      tournMatch.Table = byRound[byRound.Count - 1].Table + 1;
      return tournMatch;
    }

    private void DialogWizardUndropPlayer_Load(object sender, EventArgs e)
    {
      if (this.CurrentTournament == null)
      {
        int num = (int) MessageBox.Show("Invalid tournament");
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }
      else
      {
        TournPlayerArray tournPlayerArray = new TournPlayerArray();
        int num1 = this.CurrentTournament.CurrentRound - 1;
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.CurrentTournament.Players)
        {
          if (player.DropRound == num1)
            tournPlayerArray.AddPlayer(player);
        }
        if (tournPlayerArray.Count == 0)
        {
          int num2 = (int) MessageBox.Show("No Dropped Players");
          this.DialogResult = DialogResult.Cancel;
          this.Close();
        }
        else
        {
          tournPlayerArray.SortByLastname();
          this.ddlDroppedPlayers.DataSource = (object) tournPlayerArray;
          this.ddlDroppedPlayers.SelectedIndex = 0;
        }
      }
    }

    private void EnableOKButton()
    {
      this.btnApplyChanges.Enabled = this.radioREOByeLoss.Checked || this.radioREOByeWin.Checked || (this.radioREORePairings.Checked || this.radioREOSwapDrops.Checked) || this.radioREOVsCurrentPlayerWithBye.Checked;
      this.listCurrentPairings.Enabled = this.radioREORePairings.Checked;
      this.listNewPairings.Enabled = this.radioREORePairings.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogWizardUndropPlayer));
      this.btnClose = new Button();
      this.btnApplyChanges = new Button();
      this.groupBox2 = new GroupBox();
      this.radioREOVsCurrentPlayerWithBye = new RadioButton();
      this.chkPrintNewResultSlips = new CheckBox();
      this.listNewPairings = new ListBox();
      this.label3 = new Label();
      this.listCurrentPairings = new ListBox();
      this.label2 = new Label();
      this.radioREORePairings = new RadioButton();
      this.radioREOSwapDrops = new RadioButton();
      this.radioREOByeLoss = new RadioButton();
      this.radioREOByeWin = new RadioButton();
      this.groupBox1 = new GroupBox();
      this.chkPrevRoundP2Drop = new CheckBox();
      this.chkPrevRoundP1Drop = new CheckBox();
      this.ddlDroppedPlayers = new ComboBox();
      this.label1 = new Label();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(336, 482);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "Cancel";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnApplyChanges.Enabled = false;
      this.btnApplyChanges.Location = new Point(221, 482);
      this.btnApplyChanges.Name = "btnApplyChanges";
      this.btnApplyChanges.Size = new Size(75, 23);
      this.btnApplyChanges.TabIndex = 5;
      this.btnApplyChanges.Text = "OK";
      this.btnApplyChanges.UseVisualStyleBackColor = true;
      this.btnApplyChanges.Click += new EventHandler(this.btnApplyChanges_Click);
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.radioREOVsCurrentPlayerWithBye);
      this.groupBox2.Controls.Add((Control) this.chkPrintNewResultSlips);
      this.groupBox2.Controls.Add((Control) this.listNewPairings);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.listCurrentPairings);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.radioREORePairings);
      this.groupBox2.Controls.Add((Control) this.radioREOSwapDrops);
      this.groupBox2.Controls.Add((Control) this.radioREOByeLoss);
      this.groupBox2.Controls.Add((Control) this.radioREOByeWin);
      this.groupBox2.Location = new Point(27, 118);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(575, 358);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Re-Enroll Options";
      this.radioREOVsCurrentPlayerWithBye.AutoSize = true;
      this.radioREOVsCurrentPlayerWithBye.Enabled = false;
      this.radioREOVsCurrentPlayerWithBye.Location = new Point(12, 44);
      this.radioREOVsCurrentPlayerWithBye.Name = "radioREOVsCurrentPlayerWithBye";
      this.radioREOVsCurrentPlayerWithBye.Size = new Size(116, 17);
      this.radioREOVsCurrentPlayerWithBye.TabIndex = 1;
      this.radioREOVsCurrentPlayerWithBye.TabStop = true;
      this.radioREOVsCurrentPlayerWithBye.Text = "Pair vs. Bye Player:";
      this.radioREOVsCurrentPlayerWithBye.UseVisualStyleBackColor = true;
      this.radioREOVsCurrentPlayerWithBye.CheckedChanged += new EventHandler(this.radioREOVsCurrentPlayerWithBye_CheckedChanged);
      this.chkPrintNewResultSlips.AutoSize = true;
      this.chkPrintNewResultSlips.Enabled = false;
      this.chkPrintNewResultSlips.Location = new Point(13, 324);
      this.chkPrintNewResultSlips.Name = "chkPrintNewResultSlips";
      this.chkPrintNewResultSlips.Size = new Size(121, 17);
      this.chkPrintNewResultSlips.TabIndex = 9;
      this.chkPrintNewResultSlips.Text = "Print new result slips";
      this.chkPrintNewResultSlips.UseVisualStyleBackColor = true;
      this.listNewPairings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.listNewPairings.Enabled = false;
      this.listNewPairings.FormattingEnabled = true;
      this.listNewPairings.Location = new Point(121, 234);
      this.listNewPairings.Name = "listNewPairings";
      this.listNewPairings.Size = new Size(420, 82);
      this.listNewPairings.TabIndex = 8;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(30, 234);
      this.label3.Name = "label3";
      this.label3.Size = new Size(72, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "New Pairings:";
      this.listCurrentPairings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.listCurrentPairings.Enabled = false;
      this.listCurrentPairings.FormattingEnabled = true;
      this.listCurrentPairings.Location = new Point(121, 144);
      this.listCurrentPairings.Name = "listCurrentPairings";
      this.listCurrentPairings.Size = new Size(420, 82);
      this.listCurrentPairings.TabIndex = 6;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(30, 144);
      this.label2.Name = "label2";
      this.label2.Size = new Size(84, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Current Pairings:";
      this.radioREORePairings.AutoSize = true;
      this.radioREORePairings.Enabled = false;
      this.radioREORePairings.Location = new Point(13, 119);
      this.radioREORePairings.Name = "radioREORePairings";
      this.radioREORePairings.Size = new Size(125, 17);
      this.radioREORePairings.TabIndex = 4;
      this.radioREORePairings.TabStop = true;
      this.radioREORePairings.Text = "Re-Pair as necessary";
      this.radioREORePairings.UseVisualStyleBackColor = true;
      this.radioREORePairings.CheckedChanged += new EventHandler(this.radioREORePairings_CheckedChanged);
      this.radioREOSwapDrops.AutoSize = true;
      this.radioREOSwapDrops.Enabled = false;
      this.radioREOSwapDrops.Location = new Point(13, 19);
      this.radioREOSwapDrops.Name = "radioREOSwapDrops";
      this.radioREOSwapDrops.Size = new Size(280, 17);
      this.radioREOSwapDrops.TabIndex = 0;
      this.radioREOSwapDrops.TabStop = true;
      this.radioREOSwapDrops.Text = "Drop other player and pair with that person's opponent";
      this.radioREOSwapDrops.UseVisualStyleBackColor = true;
      this.radioREOSwapDrops.CheckedChanged += new EventHandler(this.radioREOSwapDrops_CheckedChanged);
      this.radioREOByeLoss.AutoSize = true;
      this.radioREOByeLoss.Enabled = false;
      this.radioREOByeLoss.Location = new Point(13, 94);
      this.radioREOByeLoss.Name = "radioREOByeLoss";
      this.radioREOByeLoss.Size = new Size(124, 17);
      this.radioREOByeLoss.TabIndex = 3;
      this.radioREOByeLoss.TabStop = true;
      this.radioREOByeLoss.Text = "Bye Opponent - Loss";
      this.radioREOByeLoss.UseVisualStyleBackColor = true;
      this.radioREOByeLoss.CheckedChanged += new EventHandler(this.radioREOByeLoss_CheckedChanged);
      this.radioREOByeWin.AutoSize = true;
      this.radioREOByeWin.Enabled = false;
      this.radioREOByeWin.Location = new Point(13, 69);
      this.radioREOByeWin.Name = "radioREOByeWin";
      this.radioREOByeWin.Size = new Size(121, 17);
      this.radioREOByeWin.TabIndex = 2;
      this.radioREOByeWin.TabStop = true;
      this.radioREOByeWin.Text = "Bye Opponent - Win";
      this.radioREOByeWin.UseVisualStyleBackColor = true;
      this.radioREOByeWin.CheckedChanged += new EventHandler(this.radioREOByeWin_CheckedChanged);
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.chkPrevRoundP2Drop);
      this.groupBox1.Controls.Add((Control) this.chkPrevRoundP1Drop);
      this.groupBox1.Location = new Point(27, 41);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(575, 71);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Last Round";
      this.chkPrevRoundP2Drop.AutoSize = true;
      this.chkPrevRoundP2Drop.Enabled = false;
      this.chkPrevRoundP2Drop.Location = new Point(13, 42);
      this.chkPrevRoundP2Drop.Name = "chkPrevRoundP2Drop";
      this.chkPrevRoundP2Drop.Size = new Size(120, 17);
      this.chkPrevRoundP2Drop.TabIndex = 1;
      this.chkPrevRoundP2Drop.Text = "<Player 2> Dropped";
      this.chkPrevRoundP2Drop.UseVisualStyleBackColor = true;
      this.chkPrevRoundP1Drop.AutoSize = true;
      this.chkPrevRoundP1Drop.Enabled = false;
      this.chkPrevRoundP1Drop.Location = new Point(13, 19);
      this.chkPrevRoundP1Drop.Name = "chkPrevRoundP1Drop";
      this.chkPrevRoundP1Drop.Size = new Size(120, 17);
      this.chkPrevRoundP1Drop.TabIndex = 0;
      this.chkPrevRoundP1Drop.Text = "<Player 1> Dropped";
      this.chkPrevRoundP1Drop.UseVisualStyleBackColor = true;
      this.ddlDroppedPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlDroppedPlayers.FormattingEnabled = true;
      this.ddlDroppedPlayers.Location = new Point(204, 13);
      this.ddlDroppedPlayers.Name = "ddlDroppedPlayers";
      this.ddlDroppedPlayers.Size = new Size(256, 21);
      this.ddlDroppedPlayers.TabIndex = 7;
      this.ddlDroppedPlayers.SelectedIndexChanged += new EventHandler(this.ddlDroppedPlayers_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(110, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(88, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Dropped Players:";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(633, 517);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ddlDroppedPlayers);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnApplyChanges);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogWizardUndropPlayer);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (DialogWizardUndropPlayer);
      this.Load += new EventHandler(this.DialogWizardUndropPlayer_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
