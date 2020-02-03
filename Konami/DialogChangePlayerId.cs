// Decompiled with JetBrains decompiler
// Type: Konami.DialogChangePlayerId
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;

namespace Konami
{
  public class DialogChangePlayerId : Form
  {
    private long _newId = Player.BYE_ID;
    private long _oldId = Player.BYE_ID;
    private IContainer components;
    private Label label1;
    private Label label2;
    private TextBox txtOldID;
    private TextBox txtNewID;
    private Button btnOK;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogChangePlayerId));
      this.label1 = new Label();
      this.label2 = new Label();
      this.txtOldID = new TextBox();
      this.txtNewID = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(87, 33);
      this.label1.Name = "label1";
      this.label1.Size = new Size(40, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Old ID:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(87, 81);
      this.label2.Name = "label2";
      this.label2.Size = new Size(46, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "New ID:";
      this.txtOldID.Location = new Point(145, 30);
      this.txtOldID.MaxLength = 10;
      this.txtOldID.Name = "txtOldID";
      this.txtOldID.Size = new Size(112, 20);
      this.txtOldID.TabIndex = 2;
      this.txtNewID.Location = new Point(145, 78);
      this.txtNewID.MaxLength = 10;
      this.txtNewID.Name = "txtNewID";
      this.txtNewID.Size = new Size(112, 20);
      this.txtNewID.TabIndex = 3;
      this.btnOK.Location = new Point(58, 149);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(218, 149);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(356, 223);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtNewID);
      this.Controls.Add((Control) this.txtOldID);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogChangePlayerId);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Change Player ID";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public long NewPlayerID
    {
      get
      {
        return this._newId;
      }
      set
      {
        this._newId = value;
        this.txtNewID.Text = Utility.MakeDisplayCOSSY(this._newId);
      }
    }

    public long OldPlayerID
    {
      get
      {
        return this._oldId;
      }
      set
      {
        this._oldId = value;
        this.txtOldID.Text = Utility.MakeDisplayCOSSY(this._oldId);
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      long.TryParse(this.txtOldID.Text, out this._oldId);
      if (this.OldPlayerID == Player.BYE_ID)
      {
        int num = (int) MessageBox.Show("Invalid Old ID");
        this.txtOldID.SelectAll();
      }
      else if (Engine.PlayerList.FindById(this.OldPlayerID) == null)
      {
        int num = (int) MessageBox.Show("Player with Old ID not found");
        this.txtOldID.SelectAll();
      }
      else
      {
        long.TryParse(this.txtNewID.Text, out this._newId);
        if (this.NewPlayerID == Player.BYE_ID)
        {
          int num = (int) MessageBox.Show("Invalid New ID");
          this.txtNewID.SelectAll();
        }
        else
        {
          if (Engine.PlayerList.FindById(this.NewPlayerID) != null)
          {
            if (MessageBox.Show("New ID Already used.  Continue?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              this.DialogResult = DialogResult.OK;
            }
            else
            {
              this.txtNewID.SelectAll();
              return;
            }
          }
          this.DialogResult = DialogResult.OK;
        }
      }
    }

    public DialogChangePlayerId()
    {
      this.InitializeComponent();
    }
  }
}
