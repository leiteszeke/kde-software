// Decompiled with JetBrains decompiler
// Type: Konami.DialogChangePlayerName
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
  public class DialogChangePlayerName : Form
  {
    public PlayerArray ChangedPlayers = new PlayerArray();
    private long _selectedPlayerId = Player.BYE_ID;
    public IPlayerArray DisplayedPlayerList;
    private IContainer components;
    private ComboBox ddlPlayers;
    private Label label1;
    private Label label2;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private Button btnApply;
    private Button btnClose;
    private TextBox txtCossyId;
    private Label label3;

    public long SelectedPlayerId
    {
      get
      {
        return this._selectedPlayerId;
      }
      set
      {
        this._selectedPlayerId = value;
      }
    }

    private void ddlPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlPlayers.SelectedItem == null)
      {
        this.txtCossyId.Text = string.Empty;
        this.txtFirstName.Text = string.Empty;
        this.txtLastName.Text = string.Empty;
      }
      else
      {
        IPlayer byId = this.DisplayedPlayerList.FindById(((IPlayer) this.ddlPlayers.SelectedItem).ID);
        if (byId != null)
        {
          this.txtCossyId.Text = byId.IDFormatted;
          this.txtFirstName.Text = byId.FirstName;
          this.txtLastName.Text = byId.LastName;
        }
        else
        {
          this.txtCossyId.Text = string.Empty;
          this.txtFirstName.Text = string.Empty;
          this.txtLastName.Text = string.Empty;
        }
      }
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      if (this.ddlPlayers.SelectedItem == null)
      {
        this.txtCossyId.Text = string.Empty;
        this.txtFirstName.Text = string.Empty;
        this.txtLastName.Text = string.Empty;
      }
      else
      {
        IPlayer selectedItem = (IPlayer) this.ddlPlayers.SelectedItem;
        long id = selectedItem.ID;
        IPlayer byId = this.DisplayedPlayerList.FindById(selectedItem.ID);
        if (byId != null)
        {
          byId.FirstName = this.txtFirstName.Text;
          byId.LastName = this.txtLastName.Text;
        }
        if (this.ChangedPlayers.HasPlayer(byId.ID))
          this.ChangedPlayers.Remove(byId);
        this.ChangedPlayers.AddPlayer(byId);
        this.ShowPlayers(id);
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public DialogChangePlayerName()
    {
      this.InitializeComponent();
    }

    private void DialogChangePlayerName_Load(object sender, EventArgs e)
    {
      this.ShowPlayers(this._selectedPlayerId);
    }

    private void ShowPlayers()
    {
      this.ShowPlayers(Player.BYE_ID);
    }

    private void ShowPlayers(long selectedPlayer)
    {
      this.ddlPlayers.DataSource = (object) null;
      if (this.DisplayedPlayerList == null)
        return;
      this.DisplayedPlayerList.SortByLastname();
      this.ddlPlayers.DataSource = (object) this.DisplayedPlayerList;
      this.ddlPlayers.Enabled = this.DisplayedPlayerList.Count > 0;
      this.txtFirstName.Enabled = this.DisplayedPlayerList.Count > 0;
      this.txtLastName.Enabled = this.DisplayedPlayerList.Count > 0;
      if (selectedPlayer == Player.BYE_ID)
        return;
      IPlayer player = this.ChangedPlayers.FindById(selectedPlayer) ?? this.DisplayedPlayerList.FindById(selectedPlayer);
      if (player == null)
        return;
      int num = this.ddlPlayers.Items.IndexOf((object) player);
      if (num < 0)
        return;
      this.ddlPlayers.SelectedIndex = num;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogChangePlayerName));
      this.ddlPlayers = new ComboBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.txtFirstName = new TextBox();
      this.txtLastName = new TextBox();
      this.btnApply = new Button();
      this.btnClose = new Button();
      this.txtCossyId = new TextBox();
      this.label3 = new Label();
      this.SuspendLayout();
      this.ddlPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPlayers.FormattingEnabled = true;
      this.ddlPlayers.Location = new Point(21, 40);
      this.ddlPlayers.Name = "ddlPlayers";
      this.ddlPlayers.Size = new Size(353, 21);
      this.ddlPlayers.TabIndex = 0;
      this.ddlPlayers.SelectedIndexChanged += new EventHandler(this.ddlPlayers_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(18, 117);
      this.label1.Name = "label1";
      this.label1.Size = new Size(80, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "New first name:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(18, 156);
      this.label2.Name = "label2";
      this.label2.Size = new Size(80, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "New last name:";
      this.txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFirstName.Location = new Point(132, 114);
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new Size(242, 20);
      this.txtFirstName.TabIndex = 3;
      this.txtLastName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtLastName.Location = new Point(132, 153);
      this.txtLastName.Name = "txtLastName";
      this.txtLastName.Size = new Size(242, 20);
      this.txtLastName.TabIndex = 5;
      this.btnApply.Location = new Point(90, 208);
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new Size(75, 23);
      this.btnApply.TabIndex = 6;
      this.btnApply.Text = "Apply";
      this.btnApply.UseVisualStyleBackColor = true;
      this.btnApply.Click += new EventHandler(this.btnApply_Click);
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(241, 208);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 7;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.txtCossyId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCossyId.Location = new Point(132, 78);
      this.txtCossyId.Name = "txtCossyId";
      this.txtCossyId.ReadOnly = true;
      this.txtCossyId.Size = new Size(104, 20);
      this.txtCossyId.TabIndex = 9;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(18, 81);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "COSSY ID:";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(411, 273);
      this.Controls.Add((Control) this.txtCossyId);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnApply);
      this.Controls.Add((Control) this.txtLastName);
      this.Controls.Add((Control) this.txtFirstName);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ddlPlayers);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogChangePlayerName);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Change Player Name";
      this.Load += new EventHandler(this.DialogChangePlayerName_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
