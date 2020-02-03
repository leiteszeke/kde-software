// Decompiled with JetBrains decompiler
// Type: Konami.DialogAbout
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Konami
{
  public class DialogAbout : Form
  {
    private IContainer components;
    private LinkLabel linkLabel1;
    private Label label2;
    private Label lblVersion;
    private Button btnClose;

    public DialogAbout()
    {
      this.InitializeComponent();
    }

    private void DialogAbout_Load(object sender, EventArgs e)
    {
      this.lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogAbout));
      this.linkLabel1 = new LinkLabel();
      this.label2 = new Label();
      this.lblVersion = new Label();
      this.btnClose = new Button();
      this.SuspendLayout();
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(140, 75);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(122, 13);
      this.linkLabel1.TabIndex = 1;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "http://www.konami.com";
      this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(97, 35);
      this.label2.Name = "label2";
      this.label2.Size = new Size(208, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "(c) 2009 Konami Digital Entertainment, Inc.";
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.lblVersion.AutoSize = true;
      this.lblVersion.ImageAlign = ContentAlignment.TopCenter;
      this.lblVersion.Location = new Point(166, 206);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new Size(78, 13);
      this.lblVersion.TabIndex = 3;
      this.lblVersion.Text = "Version 0.0.0.0";
      this.lblVersion.TextAlign = ContentAlignment.MiddleCenter;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(164, 247);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnClose;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Window;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Center;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(403, 297);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.lblVersion);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.linkLabel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogAbout);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Konami Tournament Software";
      this.Load += new EventHandler(this.DialogAbout_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
