// Decompiled with JetBrains decompiler
// Type: Konami.DialogSimpleTextBox
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Konami
{
  public class DialogSimpleTextBox : Form
  {
    private IContainer components;
    private Label lblMessage;
    private TextBox txtInput;
    private Button btnOK;
    private Button btnCancel;

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

    public string Message
    {
      get
      {
        return this.lblMessage.Text;
      }
      set
      {
        this.lblMessage.Text = value;
      }
    }

    public string Input
    {
      get
      {
        return this.txtInput.Text;
      }
      set
      {
        this.txtInput.Text = value;
      }
    }

    public int IntInput
    {
      get
      {
        int result = -1;
        int.TryParse(this.Input, out result);
        return result;
      }
      set
      {
        this.Input = value.ToString();
      }
    }

    public bool IsIntInput
    {
      get
      {
        int result = 0;
        return int.TryParse(this.Input, out result);
      }
    }

    public void Bind(string title, string message, string input)
    {
      this.Title = title;
      this.Message = message;
      this.Input = input;
    }

    public DialogSimpleTextBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogSimpleTextBox));
      this.lblMessage = new Label();
      this.txtInput = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessage.Location = new Point(12, 9);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(359, 73);
      this.lblMessage.TabIndex = 0;
      this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
      this.txtInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtInput.Location = new Point(138, 85);
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new Size(122, 20);
      this.txtInput.TabIndex = 1;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOK.DialogResult = DialogResult.OK;
      this.btnOK.Location = new Point(87, 130);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(222, 130);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(383, 177);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtInput);
      this.Controls.Add((Control) this.lblMessage);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogSimpleTextBox);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (DialogSimpleTextBox);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
