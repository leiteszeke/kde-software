// Decompiled with JetBrains decompiler
// Type: Konami.DialogPrintPlayers
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Konami
{
  public class DialogPrintPlayers : Form
  {
    private IContainer components;
    private RadioButton radioAllPlayers;
    private RadioButton radioActivePlayers;
    private Button btnOK;
    private Button btnCancel;
    private CheckBox chkSortById;

    public bool ActivePlayers
    {
      get
      {
        return this.radioActivePlayers.Checked;
      }
      set
      {
        this.radioActivePlayers.Checked = value;
      }
    }

    public bool AllPlayers
    {
      get
      {
        return this.radioAllPlayers.Checked;
      }
      set
      {
        this.radioAllPlayers.Checked = value;
      }
    }

    public bool SortById
    {
      get
      {
        return this.chkSortById.Checked;
      }
      set
      {
        this.chkSortById.Checked = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    public DialogPrintPlayers()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPrintPlayers));
      this.radioAllPlayers = new RadioButton();
      this.radioActivePlayers = new RadioButton();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.chkSortById = new CheckBox();
      this.SuspendLayout();
      this.radioAllPlayers.AutoSize = true;
      this.radioAllPlayers.Checked = true;
      this.radioAllPlayers.Location = new Point(30, 23);
      this.radioAllPlayers.Name = "radioAllPlayers";
      this.radioAllPlayers.Size = new Size(73, 17);
      this.radioAllPlayers.TabIndex = 0;
      this.radioAllPlayers.TabStop = true;
      this.radioAllPlayers.Text = "All Players";
      this.radioAllPlayers.UseVisualStyleBackColor = true;
      this.radioActivePlayers.AutoSize = true;
      this.radioActivePlayers.Location = new Point(30, 59);
      this.radioActivePlayers.Name = "radioActivePlayers";
      this.radioActivePlayers.Size = new Size(92, 17);
      this.radioActivePlayers.TabIndex = 1;
      this.radioActivePlayers.Text = "Active Players";
      this.radioActivePlayers.UseVisualStyleBackColor = true;
      this.btnOK.Location = new Point(59, 141);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(169, 141);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.chkSortById.AutoSize = true;
      this.chkSortById.Location = new Point(30, 95);
      this.chkSortById.Name = "chkSortById";
      this.chkSortById.Size = new Size(74, 17);
      this.chkSortById.TabIndex = 4;
      this.chkSortById.Text = "Sort By ID";
      this.chkSortById.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(295, 187);
      this.Controls.Add((Control) this.chkSortById);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.radioActivePlayers);
      this.Controls.Add((Control) this.radioAllPlayers);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogPrintPlayers);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Print Players";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
