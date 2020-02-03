// Decompiled with JetBrains decompiler
// Type: Konami.DialogMatchHistory
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
  public class DialogMatchHistory : Form
  {
    public ITournament currentTournament;
    public ITournPlayer currentPlayer;
    private IContainer components;
    private ComboBox ddlPlayers;
    private Button btnClose;
    private TextBox txtHistory;

    private void ddlPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.currentTournament == null)
        return;
      ITournPlayer selectedItem = (ITournPlayer) this.ddlPlayers.SelectedItem;
      if (selectedItem == null)
        return;
      ITournMatchArray byPlayer = this.currentTournament.Matches.GetByPlayer(selectedItem.ID);
      byPlayer.SortByRoundTable();
      string format = "Round {0} Table {1}: {2} vs {3}\r\n";
      this.txtHistory.Text = "";
      foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) byPlayer)
      {
        ITournPlayer tournPlayer = (ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer);
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tournMatch.Players)
        {
          if (player.ID != selectedItem.ID)
          {
            tournPlayer = player;
            break;
          }
        }
        string str = tournMatch.Status != TournMatchResult.Winner ? Enum.GetName(typeof (TournMatchResult), (object) tournMatch.Status) : (tournMatch.Winner == selectedItem.ID ? "Wins" : "Loses");
        this.txtHistory.Text += string.Format(format, (object) tournMatch.Round, (object) (tournMatch.Table + this.currentTournament.TableOffset), (object) str, (object) tournPlayer.ToString());
      }
    }

    public DialogMatchHistory()
    {
      this.InitializeComponent();
    }

    private void DialogMatchHistory_Load(object sender, EventArgs e)
    {
      if (this.currentTournament == null)
        return;
      this.ddlPlayers.Items.Clear();
      this.ddlPlayers.ValueMember = "ID";
      this.ddlPlayers.DisplayMember = "FullName";
      this.ddlPlayers.DataSource = (object) this.currentTournament.Players;
      if (this.ddlPlayers.Items.Count <= 0)
        return;
      if (this.currentPlayer != null)
      {
        int num = this.ddlPlayers.Items.IndexOf((object) this.currentTournament.Players.FindById(this.currentPlayer.ID));
        if (num > 0)
          this.ddlPlayers.SelectedIndex = num;
        else
          this.ddlPlayers.SelectedIndex = 0;
      }
      else
        this.ddlPlayers.SelectedIndex = 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogMatchHistory));
      this.ddlPlayers = new ComboBox();
      this.btnClose = new Button();
      this.txtHistory = new TextBox();
      this.SuspendLayout();
      this.ddlPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPlayers.FormattingEnabled = true;
      this.ddlPlayers.Location = new Point(12, 30);
      this.ddlPlayers.MaxDropDownItems = 30;
      this.ddlPlayers.Name = "ddlPlayers";
      this.ddlPlayers.Size = new Size(444, 21);
      this.ddlPlayers.Sorted = true;
      this.ddlPlayers.TabIndex = 0;
      this.ddlPlayers.SelectedIndexChanged += new EventHandler(this.ddlPlayers_SelectedIndexChanged);
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(191, 275);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.txtHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtHistory.HideSelection = false;
      this.txtHistory.Location = new Point(12, 57);
      this.txtHistory.Multiline = true;
      this.txtHistory.Name = "txtHistory";
      this.txtHistory.ReadOnly = true;
      this.txtHistory.Size = new Size(444, 193);
      this.txtHistory.TabIndex = 3;
      this.AcceptButton = (IButtonControl) this.btnClose;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(468, 319);
      this.Controls.Add((Control) this.txtHistory);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.ddlPlayers);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogMatchHistory);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Match History";
      this.Load += new EventHandler(this.DialogMatchHistory_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
