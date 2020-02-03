// Decompiled with JetBrains decompiler
// Type: Konami.DialogLogViewer
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;

namespace Konami
{
  public class DialogLogViewer : Form
  {
    private IContainer components;
    private ListBox listLogMessages;
    private Button btnClose;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogLogViewer));
      this.listLogMessages = new ListBox();
      this.btnClose = new Button();
      this.SuspendLayout();
      this.listLogMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listLogMessages.FormattingEnabled = true;
      this.listLogMessages.Location = new Point(12, 12);
      this.listLogMessages.Name = "listLogMessages";
      this.listLogMessages.Size = new Size(726, 420);
      this.listLogMessages.TabIndex = 0;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(341, 457);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnClose;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(750, 492);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.listLogMessages);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogLogViewer);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Log Viewer";
      this.Load += new EventHandler(this.DialogLogViewer_Load);
      this.ResumeLayout(false);
    }

    public DialogLogViewer()
    {
      this.InitializeComponent();
    }

    private void DialogLogViewer_Load(object sender, EventArgs e)
    {
      string[] array = new string[Engine.LogMessages.Count];
      Engine.LogMessages.CopyTo(array);
      this.listLogMessages.Items.AddRange((object[]) array);
    }
  }
}
