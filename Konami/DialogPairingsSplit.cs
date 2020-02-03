// Decompiled with JetBrains decompiler
// Type: Konami.DialogPairingsSplit
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogPairingsSplit : Form
  {
    private string cheats = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int MAX_GROUPS = 12;
    public ITournament SelectedTournament;
    public PrinterSplitList Splits;
    private IContainer components;
    private RadioButton rdoNone;
    private GroupBox groupBox1;
    private ComboBox ddlGroupCount;
    private RadioButton rdoGroups;
    private Button btnOK;
    private Label lblGroup0;
    private Label lblGroup2;
    private Label lblGroup4;
    private Label lblGroup6;
    private Label lblGroup8;
    private Label lblGroup10;
    private TextBox txtGroup0;
    private TextBox txtGroup4;
    private TextBox txtGroup2;
    private TextBox txtGroup6;
    private TextBox txtGroup8;
    private Label lblCounts0;
    private Label lblCounts4;
    private Label lblCounts2;
    private Label lblCounts6;
    private Label lblCounts8;
    private Label lblCounts10;
    private Label lblTo0;
    private Label lblTo2;
    private Label lblTo4;
    private Label lblTo6;
    private Label lblTo8;
    private Label lblTo10;
    private Label lblTo11;
    private Label lblTo9;
    private Label lblTo7;
    private Label lblTo5;
    private Label lblTo3;
    private Label lblTo1;
    private Label lblCounts11;
    private Label lblCounts9;
    private Label lblCounts7;
    private Label lblCounts3;
    private Label lblCounts5;
    private Label lblCounts1;
    private TextBox txtGroup9;
    private TextBox txtGroup7;
    private TextBox txtGroup3;
    private TextBox txtGroup5;
    private TextBox txtGroup1;
    private Label lblGroup11;
    private Label lblGroup9;
    private Label lblGroup7;
    private Label lblGroup5;
    private Label lblGroup3;
    private Label lblGroup1;
    private TextBox txtGroup10;
    private TextBox txtGroup11;

    public int SplitCount
    {
      get
      {
        return this.rdoNone.Checked ? 0 : Math.Min(12, Convert.ToInt32(this.ddlGroupCount.SelectedItem));
      }
      set
      {
        int num = value;
        this.rdoNone.Checked = num == 0;
        this.rdoGroups.Checked = num > 0;
        this.ddlGroupCount.SelectedIndex = 0;
        if (num <= 0 || this.ddlGroupCount.FindStringExact(num.ToString()) < 0)
          return;
        this.ddlGroupCount.SelectedItem = (object) num.ToString();
      }
    }

    private void txtGroupEnd_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsLetter(e.KeyChar))
        return;
      TextBox textBox = (TextBox) sender;
      int result = 0;
      int.TryParse(textBox.Name.Substring(textBox.Name.Length - 1, 1), out result);
      if (!this.Splits.ContainsKey(result))
        return;
      int startIndex = this.cheats.IndexOf(char.ToUpper(e.KeyChar).ToString(), StringComparison.CurrentCultureIgnoreCase);
      if (startIndex < 0)
        return;
      this.Splits[result].LastChar = this.cheats.Substring(startIndex, 1);
      string str = "";
      if (startIndex < this.cheats.Length - 1)
        str = this.cheats.Substring(startIndex + 1, 1);
      if (this.Splits[result + 1] != null)
        this.Splits[result + 1].FirstChar = str;
      Control[] controlArray = this.Controls.Find("lblGroup" + (result + 1).ToString(), true);
      if (controlArray.Length <= 0)
        return;
      controlArray[0].Text = string.Format("{0}", (object) str);
    }

    private void txtGroupEnd_TextChanged(object sender, EventArgs e)
    {
      this.ShowCounts();
      ((TextBoxBase) sender).SelectAll();
    }

    private void rdoSplitCount_CheckedChanged(object sender, EventArgs e)
    {
      this.ddlGroupCount.Enabled = this.rdoGroups.Checked;
      this.ResetGroups();
      this.ShowGroup();
      this.ShowCounts();
    }

    private void ddlGroupCount_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.PrepSplits();
      this.ResetGroups();
      this.ShowGroup();
      this.ShowCounts();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public DialogPairingsSplit()
    {
      this.InitializeComponent();
    }

    private void DialogPairingsSplit_Load(object sender, EventArgs e)
    {
      this.ddlGroupCount.SelectedIndexChanged += new EventHandler(this.ddlGroupCount_SelectedIndexChanged);
      this.PrepSplits();
      this.ShowGroup();
    }

    private void PrepSplits()
    {
      if (this.Splits == null)
        this.Splits = new PrinterSplitList();
      if (this.Splits.Count != 0)
        return;
      for (int index = 0; index < 12; ++index)
        this.Splits.Add(index, new PrinterSplits(index, this.cheats.Substring(0, 1), this.cheats.Substring(this.cheats.Length - 1, 1)));
    }

    private void ResetGroups()
    {
      this.PrepSplits();
      for (int index = 0; index < this.SplitCount; ++index)
      {
        this.Splits[index].FirstChar = this.cheats.Substring(index * 26 / this.SplitCount, 1);
        this.Splits[index].LastChar = this.cheats.Substring((index + 1) * 26 / this.SplitCount - 1, 1);
      }
    }

    private void ShowCounts()
    {
      this.PrepSplits();
      if (this.SelectedTournament == null)
        return;
      Engine.GetPrinterSplits(this.SelectedTournament.ActivePlayers, this.Splits);
      foreach (int key in this.Splits.Keys)
      {
        Control[] controlArray = this.Controls.Find("lblCounts" + key.ToString(), false);
        if (controlArray.Length > 0)
          controlArray[0].Text = string.Format("{0} Players", (object) this.Splits[key].Counts);
      }
    }

    private void ShowGroup()
    {
      for (int index = 0; index < 12; ++index)
      {
        Control[] controlArray1 = this.Controls.Find("lblGroup" + index.ToString(), true);
        Control[] controlArray2 = this.Controls.Find("lblTo" + index.ToString(), true);
        Control[] controlArray3 = this.Controls.Find("lblCounts" + index.ToString(), true);
        controlArray1[0].Visible = this.SplitCount > index;
        controlArray2[0].Visible = this.SplitCount > index;
        controlArray2[0].Text = "to";
        controlArray3[0].Visible = this.SplitCount > index;
        Control[] controlArray4 = this.Controls.Find("txtGroup" + index.ToString(), true);
        if (controlArray4.Length > 0)
        {
          TextBox textBox = (TextBox) controlArray4[0];
          controlArray1[0].Text = this.Splits[index].FirstChar;
          if (this.SplitCount > index + 1)
          {
            textBox.Visible = true;
            textBox.ReadOnly = false;
            textBox.Text = this.Splits[index].LastChar;
            Control[] controlArray5 = this.Controls.Find("lblGroup" + (index + 1).ToString(), true);
            if (controlArray5.Length > 0)
              controlArray5[0].Text = this.Splits[index + 1].FirstChar;
          }
          else if (this.SplitCount == index + 1)
          {
            textBox.Visible = true;
            textBox.ReadOnly = true;
            textBox.Text = this.Splits[index].LastChar;
          }
          else
          {
            textBox.Visible = false;
            textBox.ReadOnly = false;
          }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPairingsSplit));
      this.rdoNone = new RadioButton();
      this.groupBox1 = new GroupBox();
      this.ddlGroupCount = new ComboBox();
      this.rdoGroups = new RadioButton();
      this.btnOK = new Button();
      this.lblGroup0 = new Label();
      this.lblGroup2 = new Label();
      this.lblGroup4 = new Label();
      this.lblGroup6 = new Label();
      this.lblGroup8 = new Label();
      this.lblGroup10 = new Label();
      this.txtGroup0 = new TextBox();
      this.txtGroup4 = new TextBox();
      this.txtGroup2 = new TextBox();
      this.txtGroup6 = new TextBox();
      this.txtGroup8 = new TextBox();
      this.lblCounts0 = new Label();
      this.lblCounts4 = new Label();
      this.lblCounts2 = new Label();
      this.lblCounts6 = new Label();
      this.lblCounts8 = new Label();
      this.lblCounts10 = new Label();
      this.lblTo0 = new Label();
      this.lblTo2 = new Label();
      this.lblTo4 = new Label();
      this.lblTo6 = new Label();
      this.lblTo8 = new Label();
      this.lblTo10 = new Label();
      this.lblTo11 = new Label();
      this.lblTo9 = new Label();
      this.lblTo7 = new Label();
      this.lblTo5 = new Label();
      this.lblTo3 = new Label();
      this.lblTo1 = new Label();
      this.lblCounts11 = new Label();
      this.lblCounts9 = new Label();
      this.lblCounts7 = new Label();
      this.lblCounts3 = new Label();
      this.lblCounts5 = new Label();
      this.lblCounts1 = new Label();
      this.txtGroup9 = new TextBox();
      this.txtGroup7 = new TextBox();
      this.txtGroup3 = new TextBox();
      this.txtGroup5 = new TextBox();
      this.txtGroup1 = new TextBox();
      this.lblGroup11 = new Label();
      this.lblGroup9 = new Label();
      this.lblGroup7 = new Label();
      this.lblGroup5 = new Label();
      this.lblGroup3 = new Label();
      this.lblGroup1 = new Label();
      this.txtGroup10 = new TextBox();
      this.txtGroup11 = new TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.rdoNone.AutoSize = true;
      this.rdoNone.Location = new Point(43, 33);
      this.rdoNone.Name = "rdoNone";
      this.rdoNone.Size = new Size(51, 17);
      this.rdoNone.TabIndex = 0;
      this.rdoNone.TabStop = true;
      this.rdoNone.Text = "None";
      this.rdoNone.UseVisualStyleBackColor = true;
      this.rdoNone.CheckedChanged += new EventHandler(this.rdoSplitCount_CheckedChanged);
      this.groupBox1.Controls.Add((Control) this.ddlGroupCount);
      this.groupBox1.Controls.Add((Control) this.rdoGroups);
      this.groupBox1.Controls.Add((Control) this.rdoNone);
      this.groupBox1.Location = new Point(115, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(217, 102);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Split Count";
      this.ddlGroupCount.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlGroupCount.FormattingEnabled = true;
      this.ddlGroupCount.Items.AddRange(new object[11]
      {
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12"
      });
      this.ddlGroupCount.Location = new Point(118, 55);
      this.ddlGroupCount.Name = "ddlGroupCount";
      this.ddlGroupCount.Size = new Size(48, 21);
      this.ddlGroupCount.TabIndex = 2;
      this.rdoGroups.AutoSize = true;
      this.rdoGroups.Location = new Point(43, 56);
      this.rdoGroups.Name = "rdoGroups";
      this.rdoGroups.Size = new Size(59, 17);
      this.rdoGroups.TabIndex = 1;
      this.rdoGroups.TabStop = true;
      this.rdoGroups.Text = "Groups";
      this.rdoGroups.UseVisualStyleBackColor = true;
      this.rdoGroups.CheckedChanged += new EventHandler(this.rdoSplitCount_CheckedChanged);
      this.btnOK.DialogResult = DialogResult.Cancel;
      this.btnOK.Location = new Point(174, 306);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.lblGroup0.AutoSize = true;
      this.lblGroup0.Location = new Point(42, 126);
      this.lblGroup0.Name = "lblGroup0";
      this.lblGroup0.Size = new Size(52, 13);
      this.lblGroup0.TabIndex = 1;
      this.lblGroup0.Text = "lblGroup0";
      this.lblGroup0.TextAlign = ContentAlignment.TopRight;
      this.lblGroup0.Visible = false;
      this.lblGroup2.AutoSize = true;
      this.lblGroup2.Location = new Point(42, 154);
      this.lblGroup2.Name = "lblGroup2";
      this.lblGroup2.Size = new Size(52, 13);
      this.lblGroup2.TabIndex = 9;
      this.lblGroup2.Text = "lblGroup2";
      this.lblGroup2.TextAlign = ContentAlignment.TopRight;
      this.lblGroup2.Visible = false;
      this.lblGroup4.AutoSize = true;
      this.lblGroup4.Location = new Point(42, 182);
      this.lblGroup4.Name = "lblGroup4";
      this.lblGroup4.Size = new Size(52, 13);
      this.lblGroup4.TabIndex = 17;
      this.lblGroup4.Text = "lblGroup4";
      this.lblGroup4.TextAlign = ContentAlignment.TopRight;
      this.lblGroup4.Visible = false;
      this.lblGroup6.AutoSize = true;
      this.lblGroup6.Location = new Point(42, 210);
      this.lblGroup6.Name = "lblGroup6";
      this.lblGroup6.Size = new Size(52, 13);
      this.lblGroup6.TabIndex = 25;
      this.lblGroup6.Text = "lblGroup6";
      this.lblGroup6.TextAlign = ContentAlignment.TopRight;
      this.lblGroup6.Visible = false;
      this.lblGroup8.AutoSize = true;
      this.lblGroup8.Location = new Point(42, 238);
      this.lblGroup8.Name = "lblGroup8";
      this.lblGroup8.Size = new Size(52, 13);
      this.lblGroup8.TabIndex = 33;
      this.lblGroup8.Text = "lblGroup8";
      this.lblGroup8.TextAlign = ContentAlignment.TopRight;
      this.lblGroup8.Visible = false;
      this.lblGroup10.AutoSize = true;
      this.lblGroup10.Location = new Point(42, 266);
      this.lblGroup10.Name = "lblGroup10";
      this.lblGroup10.Size = new Size(58, 13);
      this.lblGroup10.TabIndex = 43;
      this.lblGroup10.Text = "lblGroup10";
      this.lblGroup10.TextAlign = ContentAlignment.TopRight;
      this.lblGroup10.Visible = false;
      this.txtGroup0.Location = new Point(105, 123);
      this.txtGroup0.MaxLength = 1;
      this.txtGroup0.Name = "txtGroup0";
      this.txtGroup0.Size = new Size(28, 20);
      this.txtGroup0.TabIndex = 3;
      this.txtGroup0.Visible = false;
      this.txtGroup0.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup0.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup4.Location = new Point(105, 179);
      this.txtGroup4.MaxLength = 1;
      this.txtGroup4.Name = "txtGroup4";
      this.txtGroup4.Size = new Size(28, 20);
      this.txtGroup4.TabIndex = 19;
      this.txtGroup4.Visible = false;
      this.txtGroup4.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup4.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup2.Location = new Point(105, 151);
      this.txtGroup2.MaxLength = 1;
      this.txtGroup2.Name = "txtGroup2";
      this.txtGroup2.Size = new Size(28, 20);
      this.txtGroup2.TabIndex = 11;
      this.txtGroup2.Visible = false;
      this.txtGroup2.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup2.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup6.Location = new Point(105, 207);
      this.txtGroup6.MaxLength = 1;
      this.txtGroup6.Name = "txtGroup6";
      this.txtGroup6.Size = new Size(28, 20);
      this.txtGroup6.TabIndex = 27;
      this.txtGroup6.Visible = false;
      this.txtGroup6.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup6.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup8.Location = new Point(105, 235);
      this.txtGroup8.MaxLength = 1;
      this.txtGroup8.Name = "txtGroup8";
      this.txtGroup8.Size = new Size(28, 20);
      this.txtGroup8.TabIndex = 35;
      this.txtGroup8.Visible = false;
      this.txtGroup8.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup8.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.lblCounts0.AutoSize = true;
      this.lblCounts0.Location = new Point(139, 126);
      this.lblCounts0.Name = "lblCounts0";
      this.lblCounts0.Size = new Size(56, 13);
      this.lblCounts0.TabIndex = 4;
      this.lblCounts0.Text = "lblCounts0";
      this.lblCounts0.Visible = false;
      this.lblCounts4.AutoSize = true;
      this.lblCounts4.Location = new Point(139, 182);
      this.lblCounts4.Name = "lblCounts4";
      this.lblCounts4.Size = new Size(56, 13);
      this.lblCounts4.TabIndex = 20;
      this.lblCounts4.Text = "lblCounts4";
      this.lblCounts4.Visible = false;
      this.lblCounts2.AutoSize = true;
      this.lblCounts2.Location = new Point(139, 154);
      this.lblCounts2.Name = "lblCounts2";
      this.lblCounts2.Size = new Size(56, 13);
      this.lblCounts2.TabIndex = 12;
      this.lblCounts2.Text = "lblCounts2";
      this.lblCounts2.Visible = false;
      this.lblCounts6.AutoSize = true;
      this.lblCounts6.Location = new Point(139, 210);
      this.lblCounts6.Name = "lblCounts6";
      this.lblCounts6.Size = new Size(56, 13);
      this.lblCounts6.TabIndex = 28;
      this.lblCounts6.Text = "lblCounts6";
      this.lblCounts6.Visible = false;
      this.lblCounts8.AutoSize = true;
      this.lblCounts8.Location = new Point(139, 238);
      this.lblCounts8.Name = "lblCounts8";
      this.lblCounts8.Size = new Size(56, 13);
      this.lblCounts8.TabIndex = 36;
      this.lblCounts8.Text = "lblCounts8";
      this.lblCounts8.Visible = false;
      this.lblCounts10.AutoSize = true;
      this.lblCounts10.Location = new Point(139, 266);
      this.lblCounts10.Name = "lblCounts10";
      this.lblCounts10.Size = new Size(62, 13);
      this.lblCounts10.TabIndex = 46;
      this.lblCounts10.Text = "lblCounts10";
      this.lblCounts10.Visible = false;
      this.lblTo0.AutoSize = true;
      this.lblTo0.Location = new Point(78, 126);
      this.lblTo0.Name = "lblTo0";
      this.lblTo0.Size = new Size(20, 13);
      this.lblTo0.TabIndex = 2;
      this.lblTo0.Text = "To";
      this.lblTo0.TextAlign = ContentAlignment.TopRight;
      this.lblTo0.Visible = false;
      this.lblTo2.AutoSize = true;
      this.lblTo2.Location = new Point(78, 154);
      this.lblTo2.Name = "lblTo2";
      this.lblTo2.Size = new Size(20, 13);
      this.lblTo2.TabIndex = 10;
      this.lblTo2.Text = "To";
      this.lblTo2.TextAlign = ContentAlignment.TopRight;
      this.lblTo2.Visible = false;
      this.lblTo4.AutoSize = true;
      this.lblTo4.Location = new Point(79, 182);
      this.lblTo4.Name = "lblTo4";
      this.lblTo4.Size = new Size(20, 13);
      this.lblTo4.TabIndex = 18;
      this.lblTo4.Text = "To";
      this.lblTo4.TextAlign = ContentAlignment.TopRight;
      this.lblTo4.Visible = false;
      this.lblTo6.AutoSize = true;
      this.lblTo6.Location = new Point(78, 210);
      this.lblTo6.Name = "lblTo6";
      this.lblTo6.Size = new Size(20, 13);
      this.lblTo6.TabIndex = 26;
      this.lblTo6.Text = "To";
      this.lblTo6.TextAlign = ContentAlignment.TopRight;
      this.lblTo6.Visible = false;
      this.lblTo8.AutoSize = true;
      this.lblTo8.Location = new Point(78, 238);
      this.lblTo8.Name = "lblTo8";
      this.lblTo8.Size = new Size(20, 13);
      this.lblTo8.TabIndex = 34;
      this.lblTo8.Text = "To";
      this.lblTo8.TextAlign = ContentAlignment.TopRight;
      this.lblTo8.Visible = false;
      this.lblTo10.AutoSize = true;
      this.lblTo10.Location = new Point(78, 266);
      this.lblTo10.Name = "lblTo10";
      this.lblTo10.Size = new Size(20, 13);
      this.lblTo10.TabIndex = 44;
      this.lblTo10.Text = "To";
      this.lblTo10.TextAlign = ContentAlignment.TopRight;
      this.lblTo10.Visible = false;
      this.lblTo11.AutoSize = true;
      this.lblTo11.Location = new Point(282, 266);
      this.lblTo11.Name = "lblTo11";
      this.lblTo11.Size = new Size(20, 13);
      this.lblTo11.TabIndex = 48;
      this.lblTo11.Text = "To";
      this.lblTo11.TextAlign = ContentAlignment.TopRight;
      this.lblTo11.Visible = false;
      this.lblTo9.AutoSize = true;
      this.lblTo9.Location = new Point(282, 238);
      this.lblTo9.Name = "lblTo9";
      this.lblTo9.Size = new Size(20, 13);
      this.lblTo9.TabIndex = 39;
      this.lblTo9.Text = "To";
      this.lblTo9.TextAlign = ContentAlignment.TopRight;
      this.lblTo9.Visible = false;
      this.lblTo7.AutoSize = true;
      this.lblTo7.Location = new Point(282, 210);
      this.lblTo7.Name = "lblTo7";
      this.lblTo7.Size = new Size(20, 13);
      this.lblTo7.TabIndex = 30;
      this.lblTo7.Text = "To";
      this.lblTo7.TextAlign = ContentAlignment.TopRight;
      this.lblTo7.Visible = false;
      this.lblTo5.AutoSize = true;
      this.lblTo5.Location = new Point(283, 182);
      this.lblTo5.Name = "lblTo5";
      this.lblTo5.Size = new Size(20, 13);
      this.lblTo5.TabIndex = 22;
      this.lblTo5.Text = "To";
      this.lblTo5.TextAlign = ContentAlignment.TopRight;
      this.lblTo5.Visible = false;
      this.lblTo3.AutoSize = true;
      this.lblTo3.Location = new Point(282, 154);
      this.lblTo3.Name = "lblTo3";
      this.lblTo3.Size = new Size(20, 13);
      this.lblTo3.TabIndex = 14;
      this.lblTo3.Text = "To";
      this.lblTo3.TextAlign = ContentAlignment.TopRight;
      this.lblTo3.Visible = false;
      this.lblTo1.AutoSize = true;
      this.lblTo1.Location = new Point(282, 126);
      this.lblTo1.Name = "lblTo1";
      this.lblTo1.Size = new Size(20, 13);
      this.lblTo1.TabIndex = 6;
      this.lblTo1.Text = "To";
      this.lblTo1.TextAlign = ContentAlignment.TopRight;
      this.lblTo1.Visible = false;
      this.lblCounts11.AutoSize = true;
      this.lblCounts11.Location = new Point(343, 266);
      this.lblCounts11.Name = "lblCounts11";
      this.lblCounts11.Size = new Size(62, 13);
      this.lblCounts11.TabIndex = 0;
      this.lblCounts11.Text = "lblCounts11";
      this.lblCounts11.Visible = false;
      this.lblCounts9.AutoSize = true;
      this.lblCounts9.Location = new Point(343, 238);
      this.lblCounts9.Name = "lblCounts9";
      this.lblCounts9.Size = new Size(56, 13);
      this.lblCounts9.TabIndex = 42;
      this.lblCounts9.Text = "lblCounts9";
      this.lblCounts9.Visible = false;
      this.lblCounts7.AutoSize = true;
      this.lblCounts7.Location = new Point(343, 210);
      this.lblCounts7.Name = "lblCounts7";
      this.lblCounts7.Size = new Size(56, 13);
      this.lblCounts7.TabIndex = 32;
      this.lblCounts7.Text = "lblCounts7";
      this.lblCounts7.Visible = false;
      this.lblCounts3.AutoSize = true;
      this.lblCounts3.Location = new Point(343, 154);
      this.lblCounts3.Name = "lblCounts3";
      this.lblCounts3.Size = new Size(56, 13);
      this.lblCounts3.TabIndex = 16;
      this.lblCounts3.Text = "lblCounts3";
      this.lblCounts3.Visible = false;
      this.lblCounts5.AutoSize = true;
      this.lblCounts5.Location = new Point(343, 182);
      this.lblCounts5.Name = "lblCounts5";
      this.lblCounts5.Size = new Size(56, 13);
      this.lblCounts5.TabIndex = 24;
      this.lblCounts5.Text = "lblCounts5";
      this.lblCounts5.Visible = false;
      this.lblCounts1.AutoSize = true;
      this.lblCounts1.Location = new Point(343, 126);
      this.lblCounts1.Name = "lblCounts1";
      this.lblCounts1.Size = new Size(56, 13);
      this.lblCounts1.TabIndex = 8;
      this.lblCounts1.Text = "lblCounts1";
      this.lblCounts1.Visible = false;
      this.txtGroup9.Location = new Point(309, 235);
      this.txtGroup9.MaxLength = 1;
      this.txtGroup9.Name = "txtGroup9";
      this.txtGroup9.Size = new Size(28, 20);
      this.txtGroup9.TabIndex = 41;
      this.txtGroup9.Visible = false;
      this.txtGroup9.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup9.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup7.Location = new Point(309, 207);
      this.txtGroup7.MaxLength = 1;
      this.txtGroup7.Name = "txtGroup7";
      this.txtGroup7.Size = new Size(28, 20);
      this.txtGroup7.TabIndex = 31;
      this.txtGroup7.Visible = false;
      this.txtGroup7.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup7.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup3.Location = new Point(309, 151);
      this.txtGroup3.MaxLength = 1;
      this.txtGroup3.Name = "txtGroup3";
      this.txtGroup3.Size = new Size(28, 20);
      this.txtGroup3.TabIndex = 15;
      this.txtGroup3.Visible = false;
      this.txtGroup3.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup3.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup5.Location = new Point(309, 179);
      this.txtGroup5.MaxLength = 1;
      this.txtGroup5.Name = "txtGroup5";
      this.txtGroup5.Size = new Size(28, 20);
      this.txtGroup5.TabIndex = 23;
      this.txtGroup5.Visible = false;
      this.txtGroup5.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup5.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup1.Location = new Point(309, 123);
      this.txtGroup1.MaxLength = 1;
      this.txtGroup1.Name = "txtGroup1";
      this.txtGroup1.Size = new Size(28, 20);
      this.txtGroup1.TabIndex = 7;
      this.txtGroup1.Visible = false;
      this.txtGroup1.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup1.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.lblGroup11.AutoSize = true;
      this.lblGroup11.Location = new Point(246, 266);
      this.lblGroup11.Name = "lblGroup11";
      this.lblGroup11.Size = new Size(58, 13);
      this.lblGroup11.TabIndex = 47;
      this.lblGroup11.Text = "lblGroup11";
      this.lblGroup11.TextAlign = ContentAlignment.TopRight;
      this.lblGroup11.Visible = false;
      this.lblGroup9.AutoSize = true;
      this.lblGroup9.Location = new Point(246, 238);
      this.lblGroup9.Name = "lblGroup9";
      this.lblGroup9.Size = new Size(52, 13);
      this.lblGroup9.TabIndex = 38;
      this.lblGroup9.Text = "lblGroup9";
      this.lblGroup9.TextAlign = ContentAlignment.TopRight;
      this.lblGroup9.Visible = false;
      this.lblGroup7.AutoSize = true;
      this.lblGroup7.Location = new Point(246, 210);
      this.lblGroup7.Name = "lblGroup7";
      this.lblGroup7.Size = new Size(52, 13);
      this.lblGroup7.TabIndex = 29;
      this.lblGroup7.Text = "lblGroup7";
      this.lblGroup7.TextAlign = ContentAlignment.TopRight;
      this.lblGroup7.Visible = false;
      this.lblGroup5.AutoSize = true;
      this.lblGroup5.Location = new Point(246, 182);
      this.lblGroup5.Name = "lblGroup5";
      this.lblGroup5.Size = new Size(52, 13);
      this.lblGroup5.TabIndex = 21;
      this.lblGroup5.Text = "lblGroup5";
      this.lblGroup5.TextAlign = ContentAlignment.TopRight;
      this.lblGroup5.Visible = false;
      this.lblGroup3.AutoSize = true;
      this.lblGroup3.Location = new Point(246, 154);
      this.lblGroup3.Name = "lblGroup3";
      this.lblGroup3.Size = new Size(52, 13);
      this.lblGroup3.TabIndex = 13;
      this.lblGroup3.Text = "lblGroup3";
      this.lblGroup3.TextAlign = ContentAlignment.TopRight;
      this.lblGroup3.Visible = false;
      this.lblGroup1.AutoSize = true;
      this.lblGroup1.Location = new Point(246, 126);
      this.lblGroup1.Name = "lblGroup1";
      this.lblGroup1.Size = new Size(52, 13);
      this.lblGroup1.TabIndex = 5;
      this.lblGroup1.Text = "lblGroup1";
      this.lblGroup1.TextAlign = ContentAlignment.TopRight;
      this.lblGroup1.Visible = false;
      this.txtGroup10.Location = new Point(105, 263);
      this.txtGroup10.MaxLength = 1;
      this.txtGroup10.Name = "txtGroup10";
      this.txtGroup10.Size = new Size(28, 20);
      this.txtGroup10.TabIndex = 45;
      this.txtGroup10.Visible = false;
      this.txtGroup10.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup10.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.txtGroup11.Location = new Point(309, 263);
      this.txtGroup11.MaxLength = 1;
      this.txtGroup11.Name = "txtGroup11";
      this.txtGroup11.Size = new Size(28, 20);
      this.txtGroup11.TabIndex = 49;
      this.txtGroup11.Visible = false;
      this.txtGroup11.TextChanged += new EventHandler(this.txtGroupEnd_TextChanged);
      this.txtGroup11.KeyPress += new KeyPressEventHandler(this.txtGroupEnd_KeyPress);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.CancelButton = (IButtonControl) this.btnOK;
      this.ClientSize = new Size(442, 359);
      this.Controls.Add((Control) this.txtGroup11);
      this.Controls.Add((Control) this.txtGroup10);
      this.Controls.Add((Control) this.lblTo11);
      this.Controls.Add((Control) this.lblTo9);
      this.Controls.Add((Control) this.lblTo7);
      this.Controls.Add((Control) this.lblTo5);
      this.Controls.Add((Control) this.lblTo3);
      this.Controls.Add((Control) this.lblTo1);
      this.Controls.Add((Control) this.lblCounts11);
      this.Controls.Add((Control) this.lblCounts9);
      this.Controls.Add((Control) this.lblCounts7);
      this.Controls.Add((Control) this.lblCounts3);
      this.Controls.Add((Control) this.lblCounts5);
      this.Controls.Add((Control) this.lblCounts1);
      this.Controls.Add((Control) this.txtGroup9);
      this.Controls.Add((Control) this.txtGroup7);
      this.Controls.Add((Control) this.txtGroup3);
      this.Controls.Add((Control) this.txtGroup5);
      this.Controls.Add((Control) this.txtGroup1);
      this.Controls.Add((Control) this.lblGroup11);
      this.Controls.Add((Control) this.lblGroup9);
      this.Controls.Add((Control) this.lblGroup7);
      this.Controls.Add((Control) this.lblGroup5);
      this.Controls.Add((Control) this.lblGroup3);
      this.Controls.Add((Control) this.lblGroup1);
      this.Controls.Add((Control) this.lblTo10);
      this.Controls.Add((Control) this.lblTo8);
      this.Controls.Add((Control) this.lblTo6);
      this.Controls.Add((Control) this.lblTo4);
      this.Controls.Add((Control) this.lblTo2);
      this.Controls.Add((Control) this.lblTo0);
      this.Controls.Add((Control) this.lblCounts10);
      this.Controls.Add((Control) this.lblCounts8);
      this.Controls.Add((Control) this.lblCounts6);
      this.Controls.Add((Control) this.lblCounts2);
      this.Controls.Add((Control) this.lblCounts4);
      this.Controls.Add((Control) this.lblCounts0);
      this.Controls.Add((Control) this.txtGroup8);
      this.Controls.Add((Control) this.txtGroup6);
      this.Controls.Add((Control) this.txtGroup2);
      this.Controls.Add((Control) this.txtGroup4);
      this.Controls.Add((Control) this.txtGroup0);
      this.Controls.Add((Control) this.lblGroup10);
      this.Controls.Add((Control) this.lblGroup8);
      this.Controls.Add((Control) this.lblGroup6);
      this.Controls.Add((Control) this.lblGroup4);
      this.Controls.Add((Control) this.lblGroup2);
      this.Controls.Add((Control) this.lblGroup0);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.groupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogPairingsSplit);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Pairings Split";
      this.Load += new EventHandler(this.DialogPairingsSplit_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
