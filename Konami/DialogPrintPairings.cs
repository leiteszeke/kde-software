// Decompiled with JetBrains decompiler
// Type: Konami.DialogPrintPairings
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
  public class DialogPrintPairings : Form
  {
    private string _selectedPrinter = string.Empty;
    private IContainer components;
    private RadioButton radioPrintByPlayer;
    private RadioButton radioPrintByTable;
    private Button btnOK;
    private Button btnCancel;
    private ComboBox ddlPrinters;
    private Label label1;
    private NumericUpDown numCopies;
    private RadioButton radioPrintByBracket;

    public int Copies
    {
      get
      {
        return Convert.ToInt32(this.numCopies.Value);
      }
      set
      {
        this.numCopies.Value = (Decimal) value;
      }
    }

    public bool PrintByPlayer
    {
      get
      {
        return this.radioPrintByPlayer.Checked;
      }
      set
      {
        this.radioPrintByPlayer.Checked = value;
      }
    }

    public bool PrintByTable
    {
      get
      {
        return this.radioPrintByTable.Checked;
      }
      set
      {
        this.radioPrintByTable.Checked = value;
      }
    }

    public bool PrintBrackets
    {
      get
      {
        return this.radioPrintByBracket.Checked;
      }
      set
      {
        this.radioPrintByBracket.Checked = value;
      }
    }

    public string SelectedPrinter
    {
      get
      {
        return this.ddlPrinters.SelectedIndex >= 0 ? this.ddlPrinters.SelectedItem.ToString() : string.Empty;
      }
      set
      {
        this._selectedPrinter = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    public DialogPrintPairings()
    {
      this.InitializeComponent();
    }

    private void DialogPrintPairings_Load(object sender, EventArgs e)
    {
      this.ddlPrinters.Items.Clear();
      ArrayList arrayList = new ArrayList((ICollection) PrinterSettings.InstalledPrinters);
      arrayList.Sort();
      this.ddlPrinters.Items.AddRange(arrayList.ToArray());
      int stringExact = this.ddlPrinters.FindStringExact(this._selectedPrinter);
      if (stringExact >= 0)
      {
        this.ddlPrinters.SelectedIndex = stringExact;
      }
      else
      {
        if (this.ddlPrinters.Items.Count <= 0)
          return;
        this.ddlPrinters.SelectedIndex = 0;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPrintPairings));
      this.radioPrintByPlayer = new RadioButton();
      this.radioPrintByTable = new RadioButton();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.ddlPrinters = new ComboBox();
      this.label1 = new Label();
      this.numCopies = new NumericUpDown();
      this.radioPrintByBracket = new RadioButton();
      this.numCopies.BeginInit();
      this.SuspendLayout();
      this.radioPrintByPlayer.AutoSize = true;
      this.radioPrintByPlayer.Checked = true;
      this.radioPrintByPlayer.Location = new Point(28, 66);
      this.radioPrintByPlayer.Name = "radioPrintByPlayer";
      this.radioPrintByPlayer.Size = new Size(93, 17);
      this.radioPrintByPlayer.TabIndex = 0;
      this.radioPrintByPlayer.TabStop = true;
      this.radioPrintByPlayer.Text = "Print By Player";
      this.radioPrintByPlayer.UseVisualStyleBackColor = true;
      this.radioPrintByTable.AutoSize = true;
      this.radioPrintByTable.Location = new Point(142, 66);
      this.radioPrintByTable.Name = "radioPrintByTable";
      this.radioPrintByTable.Size = new Size(91, 17);
      this.radioPrintByTable.TabIndex = 1;
      this.radioPrintByTable.Text = "Print By Table";
      this.radioPrintByTable.UseVisualStyleBackColor = true;
      this.btnOK.Location = new Point(104, 169);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(213, 169);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.ddlPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPrinters.FormattingEnabled = true;
      this.ddlPrinters.Location = new Point(28, 22);
      this.ddlPrinters.Name = "ddlPrinters";
      this.ddlPrinters.Size = new Size(327, 21);
      this.ddlPrinters.TabIndex = 4;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(25, 117);
      this.label1.Name = "label1";
      this.label1.Size = new Size(39, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Copies";
      this.numCopies.Location = new Point(81, 115);
      this.numCopies.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numCopies.Name = "numCopies";
      this.numCopies.Size = new Size(75, 20);
      this.numCopies.TabIndex = 8;
      this.numCopies.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.radioPrintByBracket.AutoSize = true;
      this.radioPrintByBracket.Location = new Point(264, 66);
      this.radioPrintByBracket.Name = "radioPrintByBracket";
      this.radioPrintByBracket.Size = new Size(91, 17);
      this.radioPrintByBracket.TabIndex = 9;
      this.radioPrintByBracket.Text = "Print Brackets";
      this.radioPrintByBracket.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(393, 225);
      this.Controls.Add((Control) this.radioPrintByBracket);
      this.Controls.Add((Control) this.numCopies);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ddlPrinters);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.radioPrintByTable);
      this.Controls.Add((Control) this.radioPrintByPlayer);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogPrintPairings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Print Pairings";
      this.Load += new EventHandler(this.DialogPrintPairings_Load);
      this.numCopies.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
