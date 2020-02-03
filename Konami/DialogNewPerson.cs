// Decompiled with JetBrains decompiler
// Type: Konami.DialogNewPerson
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogNewPerson : Form
  {
    private IContainer components;
    private TextBox txtCurrentPlayerID;
    private Label label4;
    private Label label1;
    private Label label2;
    private TextBox txtCurrentPlayerFirstName;
    private TextBox txtCurrentPlayerLastName;
    private Button btnOK;
    private Button btnCancel;
    private EventHandler idleEventHandler;
    private IPlayer _newPlayer;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogNewPerson));
      this.txtCurrentPlayerID = new TextBox();
      this.label4 = new Label();
      this.label1 = new Label();
      this.label2 = new Label();
      this.txtCurrentPlayerFirstName = new TextBox();
      this.txtCurrentPlayerLastName = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.txtCurrentPlayerID.BackColor = SystemColors.Window;
      this.txtCurrentPlayerID.Location = new Point(121, 51);
      this.txtCurrentPlayerID.MaxLength = 10;
      this.txtCurrentPlayerID.Name = "txtCurrentPlayerID";
      this.txtCurrentPlayerID.Size = new Size(116, 20);
      this.txtCurrentPlayerID.TabIndex = 0;
      this.txtCurrentPlayerID.TextChanged += new EventHandler(this.txtCurrentPlayerID_TextChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(41, 54);
      this.label4.Name = "label4";
      this.label4.Size = new Size(21, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "ID:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(41, 80);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 13);
      this.label1.TabIndex = 13;
      this.label1.Text = "First Name:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(40, 106);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Last Name:";
      this.txtCurrentPlayerFirstName.Location = new Point(121, 77);
      this.txtCurrentPlayerFirstName.Name = "txtCurrentPlayerFirstName";
      this.txtCurrentPlayerFirstName.Size = new Size(250, 20);
      this.txtCurrentPlayerFirstName.TabIndex = 2;
      this.txtCurrentPlayerLastName.Location = new Point(121, 103);
      this.txtCurrentPlayerLastName.Name = "txtCurrentPlayerLastName";
      this.txtCurrentPlayerLastName.Size = new Size(250, 20);
      this.txtCurrentPlayerLastName.TabIndex = 3;
      this.btnOK.Location = new Point(81, 158);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(230, 158);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(408, 232);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtCurrentPlayerID);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.txtCurrentPlayerFirstName);
      this.Controls.Add((Control) this.txtCurrentPlayerLastName);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogNewPerson);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "NewPerson";
      this.Load += new EventHandler(this.NewPerson_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public IPlayer NewPlayer
    {
      get
      {
        return this._newPlayer;
      }
      set
      {
        this._newPlayer = value;
      }
    }

    public string PlayerId
    {
      get
      {
        return this.txtCurrentPlayerID.Text;
      }
      set
      {
        this.txtCurrentPlayerID.Text = value;
      }
    }

    public bool ReadOnly
    {
      get
      {
        return this.txtCurrentPlayerFirstName.ReadOnly;
      }
      set
      {
        this.txtCurrentPlayerFirstName.ReadOnly = value;
        this.txtCurrentPlayerLastName.ReadOnly = value;
      }
    }

    public string Title
    {
      get
      {
        return this.Text;
      }
      set
      {
        this.Text = value;
      }
    }

    private void txtCurrentPlayerID_TextChanged(object sender, EventArgs e)
    {
      this.FindPlayer();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this._newPlayer == null)
        return;
      this._newPlayer.FirstName = this.txtCurrentPlayerFirstName.Text;
      this._newPlayer.LastName = this.txtCurrentPlayerLastName.Text;
      this.DialogResult = DialogResult.OK;
    }

    public DialogNewPerson()
    {
      this.InitializeComponent();
      this.idleEventHandler = new EventHandler(this.OnIdle);
      Application.Idle += this.idleEventHandler;
    }

    private void FindPlayer()
    {
      if (this.txtCurrentPlayerID.Text.Length == 10)
      {
        long result = Player.BYE_ID;
        if (long.TryParse(this.txtCurrentPlayerID.Text, out result) && result != Player.BYE_ID)
        {
          this._newPlayer = Engine.PlayerList.FindById(result);
          if (this._newPlayer == null)
          {
            this._newPlayer = (IPlayer) new Player(this.txtCurrentPlayerFirstName.Text, this.txtCurrentPlayerLastName.Text, result);
          }
          else
          {
            this.txtCurrentPlayerFirstName.Text = this._newPlayer.FirstName;
            this.txtCurrentPlayerLastName.Text = this._newPlayer.LastName;
          }
        }
        else
        {
          this._newPlayer = (IPlayer) null;
          this.txtCurrentPlayerFirstName.Text = string.Empty;
          this.txtCurrentPlayerLastName.Text = string.Empty;
        }
      }
      else
      {
        this._newPlayer = (IPlayer) null;
        this.txtCurrentPlayerFirstName.Text = string.Empty;
        this.txtCurrentPlayerLastName.Text = string.Empty;
      }
    }

    private void NewPerson_Load(object sender, EventArgs e)
    {
      if (this.txtCurrentPlayerID.Text.Length > 0)
      {
        this.txtCurrentPlayerID.ReadOnly = true;
        this.txtCurrentPlayerFirstName.TabIndex = 1;
        this.txtCurrentPlayerLastName.TabIndex = 2;
        this.btnOK.TabIndex = 3;
        this.btnCancel.TabIndex = 4;
        this.txtCurrentPlayerID.TabIndex = 5;
      }
      else
      {
        this.txtCurrentPlayerID.TabIndex = 1;
        this.txtCurrentPlayerFirstName.TabIndex = 2;
        this.txtCurrentPlayerLastName.TabIndex = 3;
        this.btnOK.TabIndex = 4;
        this.btnCancel.TabIndex = 5;
      }
      if (this._newPlayer == null || this._newPlayer.IsBye)
        return;
      this.txtCurrentPlayerID.TextChanged -= new EventHandler(this.txtCurrentPlayerID_TextChanged);
      this.txtCurrentPlayerID.Text = this._newPlayer.IDFormatted;
      this.txtCurrentPlayerFirstName.Text = this._newPlayer.FirstName;
      this.txtCurrentPlayerLastName.Text = this._newPlayer.LastName;
      this.txtCurrentPlayerID.TextChanged += new EventHandler(this.txtCurrentPlayerID_TextChanged);
    }

    private void OnIdle(object sender, EventArgs e)
    {
      this.btnOK.Enabled = this._newPlayer != null && this.txtCurrentPlayerLastName.Text.Length > 0 && this.txtCurrentPlayerFirstName.Text.Length > 0;
    }
  }
}
