// Decompiled with JetBrains decompiler
// Type: Konami.DialogPrinterSelect
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Konami
{
  public class DialogPrinterSelect : Form
  {
    public string SelectedPrinter = "";
    private IContainer components;
    private ListBox listPrinters;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPrinterSelect));
      this.listPrinters = new ListBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.listPrinters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listPrinters.FormattingEnabled = true;
      this.listPrinters.Location = new Point(12, 12);
      this.listPrinters.Name = "listPrinters";
      this.listPrinters.Size = new Size(328, 238);
      this.listPrinters.TabIndex = 0;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnOK.Location = new Point(87, 271);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(188, 271);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(352, 317);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.listPrinters);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogPrinterSelect);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Printer Select";
      this.Load += new EventHandler(this.DialogPrinterSelect_Load);
      this.ResumeLayout(false);
    }

    public DialogPrinterSelect()
    {
      this.InitializeComponent();
    }

    private void DialogPrinterSelect_Load(object sender, EventArgs e)
    {
      this.listPrinters.Items.Clear();
      ArrayList arrayList = new ArrayList((ICollection) PrinterSettings.InstalledPrinters);
      arrayList.Sort();
      this.listPrinters.Items.AddRange(arrayList.ToArray());
      int stringExact = this.listPrinters.FindStringExact(this.SelectedPrinter);
      if (stringExact >= 0)
      {
        this.listPrinters.SelectedIndex = stringExact;
      }
      else
      {
        if (this.listPrinters.Items.Count <= 0)
          return;
        this.listPrinters.SelectedIndex = 0;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.listPrinters.SelectedItem.ToString()))
        return;
      this.SelectedPrinter = this.listPrinters.SelectedItem.ToString();
      this.DialogResult = DialogResult.OK;
    }
  }
}
