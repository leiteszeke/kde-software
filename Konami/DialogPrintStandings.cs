// Decompiled with JetBrains decompiler
// Type: Konami.DialogPrintStandings
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
  public class DialogPrintStandings : Form
  {
    private string _selectedPrinter = string.Empty;
    private IContainer components;
    private RadioButton radioAllPlayers;
    private RadioButton radioActivePlayers;
    private Button btnOK;
    private Button btnCancel;
    private CheckBox chkTiebreakers;
    private RadioButton rdoPagesAll;
    private RadioButton rdoPagesRange;
    private TextBox txtPageFrom;
    private CheckBox chkCollate;
    private NumericUpDown numCopies;
    private Label label1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private TextBox txtPageTo;
    private Label label2;
    private ComboBox ddlPrinters;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPrintStandings));
      this.radioAllPlayers = new RadioButton();
      this.radioActivePlayers = new RadioButton();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.chkTiebreakers = new CheckBox();
      this.rdoPagesAll = new RadioButton();
      this.rdoPagesRange = new RadioButton();
      this.txtPageFrom = new TextBox();
      this.chkCollate = new CheckBox();
      this.numCopies = new NumericUpDown();
      this.label1 = new Label();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.txtPageTo = new TextBox();
      this.label2 = new Label();
      this.ddlPrinters = new ComboBox();
      this.numCopies.BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.radioAllPlayers.AutoSize = true;
      this.radioAllPlayers.Checked = true;
      this.radioAllPlayers.Location = new Point(26, 30);
      this.radioAllPlayers.Name = "radioAllPlayers";
      this.radioAllPlayers.Size = new Size(73, 17);
      this.radioAllPlayers.TabIndex = 0;
      this.radioAllPlayers.TabStop = true;
      this.radioAllPlayers.Text = "All Players";
      this.radioAllPlayers.UseVisualStyleBackColor = true;
      this.radioActivePlayers.AutoSize = true;
      this.radioActivePlayers.Location = new Point(26, 66);
      this.radioActivePlayers.Name = "radioActivePlayers";
      this.radioActivePlayers.Size = new Size(92, 17);
      this.radioActivePlayers.TabIndex = 1;
      this.radioActivePlayers.Text = "Active Players";
      this.radioActivePlayers.UseVisualStyleBackColor = true;
      this.btnOK.Location = new Point(104, 397);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(204, 397);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.chkTiebreakers.AutoSize = true;
      this.chkTiebreakers.Checked = true;
      this.chkTiebreakers.CheckState = CheckState.Checked;
      this.chkTiebreakers.Location = new Point(26, 107);
      this.chkTiebreakers.Name = "chkTiebreakers";
      this.chkTiebreakers.Size = new Size(147, 17);
      this.chkTiebreakers.TabIndex = 4;
      this.chkTiebreakers.Text = "Include Tiebreaker Points";
      this.chkTiebreakers.UseVisualStyleBackColor = true;
      this.rdoPagesAll.AutoSize = true;
      this.rdoPagesAll.Checked = true;
      this.rdoPagesAll.Location = new Point(25, 32);
      this.rdoPagesAll.Name = "rdoPagesAll";
      this.rdoPagesAll.Size = new Size(69, 17);
      this.rdoPagesAll.TabIndex = 5;
      this.rdoPagesAll.TabStop = true;
      this.rdoPagesAll.Text = "All Pages";
      this.rdoPagesAll.UseVisualStyleBackColor = true;
      this.rdoPagesRange.AutoSize = true;
      this.rdoPagesRange.Location = new Point(25, 64);
      this.rdoPagesRange.Name = "rdoPagesRange";
      this.rdoPagesRange.Size = new Size(51, 17);
      this.rdoPagesRange.TabIndex = 6;
      this.rdoPagesRange.Text = "From:";
      this.rdoPagesRange.UseVisualStyleBackColor = true;
      this.txtPageFrom.Location = new Point(82, 63);
      this.txtPageFrom.Name = "txtPageFrom";
      this.txtPageFrom.Size = new Size(36, 20);
      this.txtPageFrom.TabIndex = 7;
      this.chkCollate.AutoSize = true;
      this.chkCollate.Checked = true;
      this.chkCollate.CheckState = CheckState.Checked;
      this.chkCollate.Location = new Point(205, 111);
      this.chkCollate.Name = "chkCollate";
      this.chkCollate.Size = new Size(58, 17);
      this.chkCollate.TabIndex = 12;
      this.chkCollate.Text = "Collate";
      this.chkCollate.UseVisualStyleBackColor = true;
      this.numCopies.Location = new Point(79, 110);
      this.numCopies.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numCopies.Name = "numCopies";
      this.numCopies.Size = new Size(75, 20);
      this.numCopies.TabIndex = 11;
      this.numCopies.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label1.AutoSize = true;
      this.label1.Location = new Point(23, 112);
      this.label1.Name = "label1";
      this.label1.Size = new Size(39, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Copies";
      this.groupBox1.Controls.Add((Control) this.radioAllPlayers);
      this.groupBox1.Controls.Add((Control) this.radioActivePlayers);
      this.groupBox1.Controls.Add((Control) this.chkTiebreakers);
      this.groupBox1.Location = new Point(25, 65);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(323, 150);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Player Options";
      this.groupBox2.Controls.Add((Control) this.txtPageTo);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.txtPageFrom);
      this.groupBox2.Controls.Add((Control) this.rdoPagesAll);
      this.groupBox2.Controls.Add((Control) this.chkCollate);
      this.groupBox2.Controls.Add((Control) this.rdoPagesRange);
      this.groupBox2.Controls.Add((Control) this.numCopies);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Location = new Point(25, 221);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(323, 152);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Printer Options";
      this.txtPageTo.Location = new Point(167, 63);
      this.txtPageTo.Name = "txtPageTo";
      this.txtPageTo.Size = new Size(46, 20);
      this.txtPageTo.TabIndex = 14;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(138, 66);
      this.label2.Name = "label2";
      this.label2.Size = new Size(23, 13);
      this.label2.TabIndex = 13;
      this.label2.Text = "To:";
      this.ddlPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPrinters.FormattingEnabled = true;
      this.ddlPrinters.Location = new Point(25, 24);
      this.ddlPrinters.Name = "ddlPrinters";
      this.ddlPrinters.Size = new Size(323, 21);
      this.ddlPrinters.TabIndex = 15;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(371, 451);
      this.Controls.Add((Control) this.ddlPrinters);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogPrintStandings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Print Standings";
      this.Load += new EventHandler(this.DialogPrintStandings_Load);
      this.numCopies.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }

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

    public bool Collate
    {
      get
      {
        return this.chkCollate.Checked;
      }
      set
      {
        this.chkCollate.Checked = value;
      }
    }

    public short Copies
    {
      get
      {
        return Convert.ToInt16(this.numCopies.Value);
      }
      set
      {
        this.numCopies.Value = (Decimal) value;
      }
    }

    public bool IncludeTiebreakers
    {
      get
      {
        return this.chkTiebreakers.Checked;
      }
      set
      {
        this.chkTiebreakers.Checked = value;
      }
    }

    public bool PrintAllPages
    {
      get
      {
        return this.rdoPagesAll.Checked;
      }
      set
      {
        this.rdoPagesAll.Checked = value;
        this.rdoPagesRange.Checked = !this.rdoPagesAll.Checked;
      }
    }

    public int PrintFrom
    {
      get
      {
        if (this.rdoPagesAll.Checked)
          return 1;
        int result1 = 1;
        int result2 = 1;
        if (this.txtPageFrom.Text.Length > 0)
          int.TryParse(this.txtPageFrom.Text, out result1);
        if (this.txtPageTo.Text.Length > 0)
          int.TryParse(this.txtPageTo.Text, out result2);
        return Math.Min(result1, result2);
      }
      set
      {
        this.txtPageFrom.Text = Convert.ToString(value);
      }
    }

    public int PrintTo
    {
      get
      {
        if (this.rdoPagesAll.Checked)
          return 1;
        int result1 = 1;
        int result2 = 1;
        if (this.txtPageFrom.Text.Length > 0)
          int.TryParse(this.txtPageFrom.Text, out result1);
        if (this.txtPageTo.Text.Length > 0)
          int.TryParse(this.txtPageTo.Text, out result2);
        return Math.Max(result1, result2);
      }
      set
      {
        this.txtPageTo.Text = Convert.ToString(value);
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
      int result = 0;
      bool flag1 = this.txtPageFrom.Text.Length == 0 || int.TryParse(this.txtPageFrom.Text, out result);
      bool flag2 = this.txtPageTo.Text.Length == 0 || int.TryParse(this.txtPageTo.Text, out result);
      if (!flag1 || !flag2)
        return;
      this.DialogResult = DialogResult.OK;
    }

    public DialogPrintStandings()
    {
      this.InitializeComponent();
    }

    private void DialogPrintStandings_Load(object sender, EventArgs e)
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
  }
}
