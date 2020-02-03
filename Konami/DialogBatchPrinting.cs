// Decompiled with JetBrains decompiler
// Type: Konami.DialogBatchPrinting
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
  public class DialogBatchPrinting : Form
  {
    public PrintBatchCounts BatchCounts = new PrintBatchCounts();
    public string TournamentName = "";
    public bool Print;
    private IContainer components;
    private Label lblTournament;
    private Label lblPrintOption0;
    private Button btnOption0Add;
    private Button btnOption0Subtract;
    private TextBox txtOption0;
    private TextBox txtOption1;
    private Button btnOption1Subtract;
    private Button btnOption1Add;
    private Label lblPrintOption1;
    private TextBox txtOption2;
    private Button btnOption2Subtract;
    private Button btnOption2Add;
    private Label lblPrintOption2;
    private TextBox txtOption3;
    private Button btnOption3Subtract;
    private Button btnOption3Add;
    private Label lblPrintOption3;
    private TextBox txtOption4;
    private Button btnOption4Subtract;
    private Button btnOption4Add;
    private Label lblPrintOption4;
    private Button btnPrint;
    private Button btnClose;
    private TextBox txtOption7;
    private Button btnOption7Subtract;
    private Button btnOption7Add;
    private Label lblPrintOption7;
    private TextBox txtOption6;
    private Button btnOption6Subtract;
    private Button btnOption6Add;
    private Label lblPrintOption6;
    private TextBox txtOption5;
    private Button btnOption5Subtract;
    private Button btnOption5Add;
    private Label lblPrintOption5;
    private TextBox txtOption9;
    private Button btnOption9Subtract;
    private Button btnOption9Add;
    private Label lblPrintOption9;
    private TextBox txtOption8;
    private Button btnOption8Subtract;
    private Button btnOption8Add;
    private Label lblPrintOption8;

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnOption0Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(1, 1);
    }

    private void btnOption0Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(1, -1);
    }

    private void btnOption1Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(2, 1);
    }

    private void btnOption1Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(2, -1);
    }

    private void btnOption2Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(3, 1);
    }

    private void btnOption2Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(3, -1);
    }

    private void btnOption3Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(4, 1);
    }

    private void btnOption3Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(4, -1);
    }

    private void btnOption4Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(5, 1);
    }

    private void btnOption4Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(5, -1);
    }

    private void btnOption5Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(6, 1);
    }

    private void btnOption5Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(6, -1);
    }

    private void btnOption6Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(7, 1);
    }

    private void btnOption6Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(7, -1);
    }

    private void btnOption7Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(8, 1);
    }

    private void btnOption7Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(8, -1);
    }

    private void btnOption8Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(9, 1);
    }

    private void btnOption8Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(9, -1);
    }

    private void btnOption9Add_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(10, 1);
    }

    private void btnOption9Subtract_Click(object sender, EventArgs e)
    {
      this.ChangeCounts(10, -1);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      this.Print = true;
      this.Close();
    }

    public DialogBatchPrinting()
    {
      this.InitializeComponent();
    }

    private void ChangeCounts(int buttonNumber, int count)
    {
      this.BatchCounts.AddCount((Engine.PrintPairingsAction) buttonNumber, count);
      this.DisplayCounts();
    }

    private void DialogBatchPrinting_Load(object sender, EventArgs e)
    {
      this.DisplayCounts();
    }

    private void DisplayCounts()
    {
      this.lblTournament.Text = this.TournamentName;
      foreach (Engine.PrintPairingsAction action in (Engine.PrintPairingsAction[]) Enum.GetValues(typeof (Engine.PrintPairingsAction)))
      {
        switch (action)
        {
          case Engine.PrintPairingsAction.None:
          case Engine.PrintPairingsAction.PairedDownPlayers:
            continue;
          default:
            int num = (int) (action - 1);
            this.Controls[string.Format("lblPrintOption{0}", (object) num)].Text = CommonEnumLists.PrintPairingsActionNames[action];
            this.Controls[string.Format("txtOption{0}", (object) num)].Text = this.BatchCounts.GetCount(action).ToString();
            continue;
        }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogBatchPrinting));
      this.lblTournament = new Label();
      this.lblPrintOption0 = new Label();
      this.btnOption0Add = new Button();
      this.btnOption0Subtract = new Button();
      this.txtOption0 = new TextBox();
      this.txtOption1 = new TextBox();
      this.btnOption1Subtract = new Button();
      this.btnOption1Add = new Button();
      this.lblPrintOption1 = new Label();
      this.txtOption2 = new TextBox();
      this.btnOption2Subtract = new Button();
      this.btnOption2Add = new Button();
      this.lblPrintOption2 = new Label();
      this.txtOption3 = new TextBox();
      this.btnOption3Subtract = new Button();
      this.btnOption3Add = new Button();
      this.lblPrintOption3 = new Label();
      this.txtOption4 = new TextBox();
      this.btnOption4Subtract = new Button();
      this.btnOption4Add = new Button();
      this.lblPrintOption4 = new Label();
      this.btnPrint = new Button();
      this.btnClose = new Button();
      this.txtOption7 = new TextBox();
      this.btnOption7Subtract = new Button();
      this.btnOption7Add = new Button();
      this.lblPrintOption7 = new Label();
      this.txtOption6 = new TextBox();
      this.btnOption6Subtract = new Button();
      this.btnOption6Add = new Button();
      this.lblPrintOption6 = new Label();
      this.txtOption5 = new TextBox();
      this.btnOption5Subtract = new Button();
      this.btnOption5Add = new Button();
      this.lblPrintOption5 = new Label();
      this.txtOption9 = new TextBox();
      this.btnOption9Subtract = new Button();
      this.btnOption9Add = new Button();
      this.lblPrintOption9 = new Label();
      this.txtOption8 = new TextBox();
      this.btnOption8Subtract = new Button();
      this.btnOption8Add = new Button();
      this.lblPrintOption8 = new Label();
      this.SuspendLayout();
      this.lblTournament.AutoSize = true;
      this.lblTournament.Location = new Point(13, 26);
      this.lblTournament.Name = "lblTournament";
      this.lblTournament.Size = new Size(107, 13);
      this.lblTournament.TabIndex = 0;
      this.lblTournament.Text = "<Tournament Name>";
      this.lblPrintOption0.AutoSize = true;
      this.lblPrintOption0.Location = new Point(13, 59);
      this.lblPrintOption0.Name = "lblPrintOption0";
      this.lblPrintOption0.Size = new Size(85, 13);
      this.lblPrintOption0.TabIndex = 1;
      this.lblPrintOption0.Text = "PairingsByPlayer";
      this.btnOption0Add.Location = new Point(233, 54);
      this.btnOption0Add.Name = "btnOption0Add";
      this.btnOption0Add.Size = new Size(48, 23);
      this.btnOption0Add.TabIndex = 2;
      this.btnOption0Add.Text = "+";
      this.btnOption0Add.UseVisualStyleBackColor = true;
      this.btnOption0Add.Click += new EventHandler(this.btnOption0Add_Click);
      this.btnOption0Subtract.Location = new Point(287, 54);
      this.btnOption0Subtract.Name = "btnOption0Subtract";
      this.btnOption0Subtract.Size = new Size(48, 23);
      this.btnOption0Subtract.TabIndex = 3;
      this.btnOption0Subtract.Text = "-";
      this.btnOption0Subtract.UseVisualStyleBackColor = true;
      this.btnOption0Subtract.Click += new EventHandler(this.btnOption0Subtract_Click);
      this.txtOption0.Location = new Point(341, 56);
      this.txtOption0.Name = "txtOption0";
      this.txtOption0.ReadOnly = true;
      this.txtOption0.Size = new Size(47, 20);
      this.txtOption0.TabIndex = 4;
      this.txtOption1.Location = new Point(341, 85);
      this.txtOption1.Name = "txtOption1";
      this.txtOption1.ReadOnly = true;
      this.txtOption1.Size = new Size(47, 20);
      this.txtOption1.TabIndex = 8;
      this.btnOption1Subtract.Location = new Point(287, 83);
      this.btnOption1Subtract.Name = "btnOption1Subtract";
      this.btnOption1Subtract.Size = new Size(48, 23);
      this.btnOption1Subtract.TabIndex = 7;
      this.btnOption1Subtract.Text = "-";
      this.btnOption1Subtract.UseVisualStyleBackColor = true;
      this.btnOption1Subtract.Click += new EventHandler(this.btnOption1Subtract_Click);
      this.btnOption1Add.Location = new Point(233, 83);
      this.btnOption1Add.Name = "btnOption1Add";
      this.btnOption1Add.Size = new Size(48, 23);
      this.btnOption1Add.TabIndex = 6;
      this.btnOption1Add.Text = "+";
      this.btnOption1Add.UseVisualStyleBackColor = true;
      this.btnOption1Add.Click += new EventHandler(this.btnOption1Add_Click);
      this.lblPrintOption1.AutoSize = true;
      this.lblPrintOption1.Location = new Point(13, 88);
      this.lblPrintOption1.Name = "lblPrintOption1";
      this.lblPrintOption1.Size = new Size(85, 13);
      this.lblPrintOption1.TabIndex = 5;
      this.lblPrintOption1.Text = "PairingsByPlayer";
      this.txtOption2.Location = new Point(341, 114);
      this.txtOption2.Name = "txtOption2";
      this.txtOption2.ReadOnly = true;
      this.txtOption2.Size = new Size(47, 20);
      this.txtOption2.TabIndex = 12;
      this.btnOption2Subtract.Location = new Point(287, 112);
      this.btnOption2Subtract.Name = "btnOption2Subtract";
      this.btnOption2Subtract.Size = new Size(48, 23);
      this.btnOption2Subtract.TabIndex = 11;
      this.btnOption2Subtract.Text = "-";
      this.btnOption2Subtract.UseVisualStyleBackColor = true;
      this.btnOption2Subtract.Click += new EventHandler(this.btnOption2Subtract_Click);
      this.btnOption2Add.Location = new Point(233, 112);
      this.btnOption2Add.Name = "btnOption2Add";
      this.btnOption2Add.Size = new Size(48, 23);
      this.btnOption2Add.TabIndex = 10;
      this.btnOption2Add.Text = "+";
      this.btnOption2Add.UseVisualStyleBackColor = true;
      this.btnOption2Add.Click += new EventHandler(this.btnOption2Add_Click);
      this.lblPrintOption2.AutoSize = true;
      this.lblPrintOption2.Location = new Point(13, 117);
      this.lblPrintOption2.Name = "lblPrintOption2";
      this.lblPrintOption2.Size = new Size(85, 13);
      this.lblPrintOption2.TabIndex = 9;
      this.lblPrintOption2.Text = "PairingsByPlayer";
      this.txtOption3.Location = new Point(341, 143);
      this.txtOption3.Name = "txtOption3";
      this.txtOption3.ReadOnly = true;
      this.txtOption3.Size = new Size(47, 20);
      this.txtOption3.TabIndex = 16;
      this.btnOption3Subtract.Location = new Point(287, 141);
      this.btnOption3Subtract.Name = "btnOption3Subtract";
      this.btnOption3Subtract.Size = new Size(48, 23);
      this.btnOption3Subtract.TabIndex = 15;
      this.btnOption3Subtract.Text = "-";
      this.btnOption3Subtract.UseVisualStyleBackColor = true;
      this.btnOption3Subtract.Click += new EventHandler(this.btnOption3Subtract_Click);
      this.btnOption3Add.Location = new Point(233, 141);
      this.btnOption3Add.Name = "btnOption3Add";
      this.btnOption3Add.Size = new Size(48, 23);
      this.btnOption3Add.TabIndex = 14;
      this.btnOption3Add.Text = "+";
      this.btnOption3Add.UseVisualStyleBackColor = true;
      this.btnOption3Add.Click += new EventHandler(this.btnOption3Add_Click);
      this.lblPrintOption3.AutoSize = true;
      this.lblPrintOption3.Location = new Point(13, 146);
      this.lblPrintOption3.Name = "lblPrintOption3";
      this.lblPrintOption3.Size = new Size(85, 13);
      this.lblPrintOption3.TabIndex = 13;
      this.lblPrintOption3.Text = "PairingsByPlayer";
      this.txtOption4.Location = new Point(341, 172);
      this.txtOption4.Name = "txtOption4";
      this.txtOption4.ReadOnly = true;
      this.txtOption4.Size = new Size(47, 20);
      this.txtOption4.TabIndex = 20;
      this.btnOption4Subtract.Location = new Point(287, 170);
      this.btnOption4Subtract.Name = "btnOption4Subtract";
      this.btnOption4Subtract.Size = new Size(48, 23);
      this.btnOption4Subtract.TabIndex = 19;
      this.btnOption4Subtract.Text = "-";
      this.btnOption4Subtract.UseVisualStyleBackColor = true;
      this.btnOption4Subtract.Click += new EventHandler(this.btnOption4Subtract_Click);
      this.btnOption4Add.Location = new Point(233, 170);
      this.btnOption4Add.Name = "btnOption4Add";
      this.btnOption4Add.Size = new Size(48, 23);
      this.btnOption4Add.TabIndex = 18;
      this.btnOption4Add.Text = "+";
      this.btnOption4Add.UseVisualStyleBackColor = true;
      this.btnOption4Add.Click += new EventHandler(this.btnOption4Add_Click);
      this.lblPrintOption4.AutoSize = true;
      this.lblPrintOption4.Location = new Point(13, 175);
      this.lblPrintOption4.Name = "lblPrintOption4";
      this.lblPrintOption4.Size = new Size(85, 13);
      this.lblPrintOption4.TabIndex = 17;
      this.lblPrintOption4.Text = "PairingsByPlayer";
      this.btnPrint.Location = new Point(118, 367);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(75, 23);
      this.btnPrint.TabIndex = 43;
      this.btnPrint.Text = "Print";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(245, 367);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 44;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.txtOption7.Location = new Point(341, 259);
      this.txtOption7.Name = "txtOption7";
      this.txtOption7.ReadOnly = true;
      this.txtOption7.Size = new Size(47, 20);
      this.txtOption7.TabIndex = 34;
      this.btnOption7Subtract.Location = new Point(287, 257);
      this.btnOption7Subtract.Name = "btnOption7Subtract";
      this.btnOption7Subtract.Size = new Size(48, 23);
      this.btnOption7Subtract.TabIndex = 33;
      this.btnOption7Subtract.Text = "-";
      this.btnOption7Subtract.UseVisualStyleBackColor = true;
      this.btnOption7Subtract.Click += new EventHandler(this.btnOption7Subtract_Click);
      this.btnOption7Add.Location = new Point(233, 257);
      this.btnOption7Add.Name = "btnOption7Add";
      this.btnOption7Add.Size = new Size(48, 23);
      this.btnOption7Add.TabIndex = 32;
      this.btnOption7Add.Text = "+";
      this.btnOption7Add.UseVisualStyleBackColor = true;
      this.btnOption7Add.Click += new EventHandler(this.btnOption7Add_Click);
      this.lblPrintOption7.AutoSize = true;
      this.lblPrintOption7.Location = new Point(13, 262);
      this.lblPrintOption7.Name = "lblPrintOption7";
      this.lblPrintOption7.Size = new Size(85, 13);
      this.lblPrintOption7.TabIndex = 31;
      this.lblPrintOption7.Text = "PairingsByPlayer";
      this.txtOption6.Location = new Point(341, 230);
      this.txtOption6.Name = "txtOption6";
      this.txtOption6.ReadOnly = true;
      this.txtOption6.Size = new Size(47, 20);
      this.txtOption6.TabIndex = 30;
      this.btnOption6Subtract.Location = new Point(287, 228);
      this.btnOption6Subtract.Name = "btnOption6Subtract";
      this.btnOption6Subtract.Size = new Size(48, 23);
      this.btnOption6Subtract.TabIndex = 29;
      this.btnOption6Subtract.Text = "-";
      this.btnOption6Subtract.UseVisualStyleBackColor = true;
      this.btnOption6Subtract.Click += new EventHandler(this.btnOption6Subtract_Click);
      this.btnOption6Add.Location = new Point(233, 228);
      this.btnOption6Add.Name = "btnOption6Add";
      this.btnOption6Add.Size = new Size(48, 23);
      this.btnOption6Add.TabIndex = 28;
      this.btnOption6Add.Text = "+";
      this.btnOption6Add.UseVisualStyleBackColor = true;
      this.btnOption6Add.Click += new EventHandler(this.btnOption6Add_Click);
      this.lblPrintOption6.AutoSize = true;
      this.lblPrintOption6.Location = new Point(13, 233);
      this.lblPrintOption6.Name = "lblPrintOption6";
      this.lblPrintOption6.Size = new Size(85, 13);
      this.lblPrintOption6.TabIndex = 27;
      this.lblPrintOption6.Text = "PairingsByPlayer";
      this.txtOption5.Location = new Point(341, 201);
      this.txtOption5.Name = "txtOption5";
      this.txtOption5.ReadOnly = true;
      this.txtOption5.Size = new Size(47, 20);
      this.txtOption5.TabIndex = 26;
      this.btnOption5Subtract.Location = new Point(287, 199);
      this.btnOption5Subtract.Name = "btnOption5Subtract";
      this.btnOption5Subtract.Size = new Size(48, 23);
      this.btnOption5Subtract.TabIndex = 25;
      this.btnOption5Subtract.Text = "-";
      this.btnOption5Subtract.UseVisualStyleBackColor = true;
      this.btnOption5Subtract.Click += new EventHandler(this.btnOption5Subtract_Click);
      this.btnOption5Add.Location = new Point(233, 199);
      this.btnOption5Add.Name = "btnOption5Add";
      this.btnOption5Add.Size = new Size(48, 23);
      this.btnOption5Add.TabIndex = 24;
      this.btnOption5Add.Text = "+";
      this.btnOption5Add.UseVisualStyleBackColor = true;
      this.btnOption5Add.Click += new EventHandler(this.btnOption5Add_Click);
      this.lblPrintOption5.AutoSize = true;
      this.lblPrintOption5.Location = new Point(13, 204);
      this.lblPrintOption5.Name = "lblPrintOption5";
      this.lblPrintOption5.Size = new Size(85, 13);
      this.lblPrintOption5.TabIndex = 23;
      this.lblPrintOption5.Text = "PairingsByPlayer";
      this.txtOption9.Location = new Point(341, 317);
      this.txtOption9.Name = "txtOption9";
      this.txtOption9.ReadOnly = true;
      this.txtOption9.Size = new Size(47, 20);
      this.txtOption9.TabIndex = 42;
      this.btnOption9Subtract.Location = new Point(287, 315);
      this.btnOption9Subtract.Name = "btnOption9Subtract";
      this.btnOption9Subtract.Size = new Size(48, 23);
      this.btnOption9Subtract.TabIndex = 41;
      this.btnOption9Subtract.Text = "-";
      this.btnOption9Subtract.UseVisualStyleBackColor = true;
      this.btnOption9Subtract.Click += new EventHandler(this.btnOption9Subtract_Click);
      this.btnOption9Add.Location = new Point(233, 315);
      this.btnOption9Add.Name = "btnOption9Add";
      this.btnOption9Add.Size = new Size(48, 23);
      this.btnOption9Add.TabIndex = 40;
      this.btnOption9Add.Text = "+";
      this.btnOption9Add.UseVisualStyleBackColor = true;
      this.btnOption9Add.Click += new EventHandler(this.btnOption9Add_Click);
      this.lblPrintOption9.AutoSize = true;
      this.lblPrintOption9.Location = new Point(13, 320);
      this.lblPrintOption9.Name = "lblPrintOption9";
      this.lblPrintOption9.Size = new Size(85, 13);
      this.lblPrintOption9.TabIndex = 39;
      this.lblPrintOption9.Text = "PairingsByPlayer";
      this.txtOption8.Location = new Point(341, 288);
      this.txtOption8.Name = "txtOption8";
      this.txtOption8.ReadOnly = true;
      this.txtOption8.Size = new Size(47, 20);
      this.txtOption8.TabIndex = 38;
      this.btnOption8Subtract.Location = new Point(287, 286);
      this.btnOption8Subtract.Name = "btnOption8Subtract";
      this.btnOption8Subtract.Size = new Size(48, 23);
      this.btnOption8Subtract.TabIndex = 37;
      this.btnOption8Subtract.Text = "-";
      this.btnOption8Subtract.UseVisualStyleBackColor = true;
      this.btnOption8Subtract.Click += new EventHandler(this.btnOption8Subtract_Click);
      this.btnOption8Add.Location = new Point(233, 286);
      this.btnOption8Add.Name = "btnOption8Add";
      this.btnOption8Add.Size = new Size(48, 23);
      this.btnOption8Add.TabIndex = 36;
      this.btnOption8Add.Text = "+";
      this.btnOption8Add.UseVisualStyleBackColor = true;
      this.btnOption8Add.Click += new EventHandler(this.btnOption8Add_Click);
      this.lblPrintOption8.AutoSize = true;
      this.lblPrintOption8.Location = new Point(13, 291);
      this.lblPrintOption8.Name = "lblPrintOption8";
      this.lblPrintOption8.Size = new Size(85, 13);
      this.lblPrintOption8.TabIndex = 35;
      this.lblPrintOption8.Text = "PairingsByPlayer";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(440, 420);
      this.Controls.Add((Control) this.txtOption9);
      this.Controls.Add((Control) this.btnOption9Subtract);
      this.Controls.Add((Control) this.btnOption9Add);
      this.Controls.Add((Control) this.lblPrintOption9);
      this.Controls.Add((Control) this.txtOption8);
      this.Controls.Add((Control) this.btnOption8Subtract);
      this.Controls.Add((Control) this.btnOption8Add);
      this.Controls.Add((Control) this.lblPrintOption8);
      this.Controls.Add((Control) this.txtOption7);
      this.Controls.Add((Control) this.btnOption7Subtract);
      this.Controls.Add((Control) this.btnOption7Add);
      this.Controls.Add((Control) this.lblPrintOption7);
      this.Controls.Add((Control) this.txtOption6);
      this.Controls.Add((Control) this.btnOption6Subtract);
      this.Controls.Add((Control) this.btnOption6Add);
      this.Controls.Add((Control) this.lblPrintOption6);
      this.Controls.Add((Control) this.txtOption5);
      this.Controls.Add((Control) this.btnOption5Subtract);
      this.Controls.Add((Control) this.btnOption5Add);
      this.Controls.Add((Control) this.lblPrintOption5);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.txtOption4);
      this.Controls.Add((Control) this.btnOption4Subtract);
      this.Controls.Add((Control) this.btnOption4Add);
      this.Controls.Add((Control) this.lblPrintOption4);
      this.Controls.Add((Control) this.txtOption3);
      this.Controls.Add((Control) this.btnOption3Subtract);
      this.Controls.Add((Control) this.btnOption3Add);
      this.Controls.Add((Control) this.lblPrintOption3);
      this.Controls.Add((Control) this.txtOption2);
      this.Controls.Add((Control) this.btnOption2Subtract);
      this.Controls.Add((Control) this.btnOption2Add);
      this.Controls.Add((Control) this.lblPrintOption2);
      this.Controls.Add((Control) this.txtOption1);
      this.Controls.Add((Control) this.btnOption1Subtract);
      this.Controls.Add((Control) this.btnOption1Add);
      this.Controls.Add((Control) this.lblPrintOption1);
      this.Controls.Add((Control) this.txtOption0);
      this.Controls.Add((Control) this.btnOption0Subtract);
      this.Controls.Add((Control) this.btnOption0Add);
      this.Controls.Add((Control) this.lblPrintOption0);
      this.Controls.Add((Control) this.lblTournament);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogBatchPrinting);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (DialogBatchPrinting);
      this.Load += new EventHandler(this.DialogBatchPrinting_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
