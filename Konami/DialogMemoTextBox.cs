// Decompiled with JetBrains decompiler
// Type: Konami.DialogMemoTextBox
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Konami
{
  public class DialogMemoTextBox : Form
  {
    private IContainer components;
    private Button btnOK;
    private Button btnCancel;
    private TextBox txtText;

    public string CustomText
    {
      get
      {
        return this.txtText.Text;
      }
      set
      {
        this.txtText.Text = value;
      }
    }

    public string CustomTitle
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

    public DialogMemoTextBox()
    {
      this.InitializeComponent();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogMemoTextBox));
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.txtText = new TextBox();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOK.DialogResult = DialogResult.OK;
      this.btnOK.Location = new Point(94, 268);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(204, 268);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.txtText.AcceptsReturn = true;
      this.txtText.AcceptsTab = true;
      this.txtText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtText.Location = new Point(24, 23);
      this.txtText.Multiline = true;
      this.txtText.Name = "txtText";
      this.txtText.Size = new Size(324, 215);
      this.txtText.TabIndex = 2;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(379, 324);
      this.Controls.Add((Control) this.txtText);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogMemoTextBox);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (DialogMemoTextBox);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
