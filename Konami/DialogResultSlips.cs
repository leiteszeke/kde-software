// Decompiled with JetBrains decompiler
// Type: Konami.DialogResultSlips
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using Konami.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogResultSlips : Form
  {
    private ITournMatchArray _matches = (ITournMatchArray) new TournMatchArray();
    private IContainer components;
    private CheckBox chkJudgeSignature;
    private RadioButton rdoAllMatches;
    private RadioButton rdoSpecificMatches;
    private TextBox txtSpecificMatches;
    private Label label1;
    private Button btnOK;
    private Button btnCancel;
    private Label label2;
    private ComboBox ddlRounds;
    private ITournament _tournament;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogResultSlips));
      this.rdoAllMatches = new RadioButton();
      this.rdoSpecificMatches = new RadioButton();
      this.txtSpecificMatches = new TextBox();
      this.label1 = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.chkJudgeSignature = new CheckBox();
      this.label2 = new Label();
      this.ddlRounds = new ComboBox();
      this.SuspendLayout();
      this.rdoAllMatches.AutoSize = true;
      this.rdoAllMatches.Checked = true;
      this.rdoAllMatches.Location = new Point(32, 31);
      this.rdoAllMatches.Name = "rdoAllMatches";
      this.rdoAllMatches.Size = new Size(80, 17);
      this.rdoAllMatches.TabIndex = 1;
      this.rdoAllMatches.TabStop = true;
      this.rdoAllMatches.Text = "All Matches";
      this.rdoAllMatches.UseVisualStyleBackColor = true;
      this.rdoSpecificMatches.AutoSize = true;
      this.rdoSpecificMatches.Location = new Point(32, 70);
      this.rdoSpecificMatches.Name = "rdoSpecificMatches";
      this.rdoSpecificMatches.Size = new Size(110, 17);
      this.rdoSpecificMatches.TabIndex = 2;
      this.rdoSpecificMatches.Text = "Specific Matches:";
      this.rdoSpecificMatches.UseVisualStyleBackColor = true;
      this.txtSpecificMatches.Location = new Point(148, 69);
      this.txtSpecificMatches.Name = "txtSpecificMatches";
      this.txtSpecificMatches.Size = new Size(147, 20);
      this.txtSpecificMatches.TabIndex = 3;
      this.txtSpecificMatches.Enter += new EventHandler(this.txtSpecificMatches_Enter);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(301, 72);
      this.label1.Name = "label1";
      this.label1.Size = new Size(119, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "(for example, \"1-5, 8,9\")";
      this.btnOK.Location = new Point(132, 225);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(278, 225);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.chkJudgeSignature.AutoSize = true;
      this.chkJudgeSignature.Checked = Settings.Default.ResultSlips_JudgeSignature;
      this.chkJudgeSignature.CheckState = CheckState.Checked;
      this.chkJudgeSignature.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "ResultSlips_JudgeSignature", true, DataSourceUpdateMode.OnPropertyChanged));
      this.chkJudgeSignature.Location = new Point(32, 191);
      this.chkJudgeSignature.Name = "chkJudgeSignature";
      this.chkJudgeSignature.Size = new Size(143, 17);
      this.chkJudgeSignature.TabIndex = 0;
      this.chkJudgeSignature.Text = "Require Judge Signature";
      this.chkJudgeSignature.UseVisualStyleBackColor = true;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(29, 130);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Round: ";
      this.ddlRounds.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlRounds.FormattingEnabled = true;
      this.ddlRounds.Location = new Point(80, (int) sbyte.MaxValue);
      this.ddlRounds.Name = "ddlRounds";
      this.ddlRounds.Size = new Size(70, 21);
      this.ddlRounds.TabIndex = 8;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(473, 273);
      this.Controls.Add((Control) this.ddlRounds);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.txtSpecificMatches);
      this.Controls.Add((Control) this.rdoSpecificMatches);
      this.Controls.Add((Control) this.rdoAllMatches);
      this.Controls.Add((Control) this.chkJudgeSignature);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogResultSlips);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Print Result Slips";
      this.Load += new EventHandler(this.DialogResultSlips_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public DialogResultSlips()
    {
      this.InitializeComponent();
    }

    public ITournament TargetTournament
    {
      get
      {
        return this._tournament;
      }
      set
      {
        this._tournament = value;
      }
    }

    public ITournMatchArray Matches
    {
      get
      {
        return this._matches;
      }
      set
      {
        this._matches = value;
      }
    }

    public int Round
    {
      get
      {
        int result = 0;
        int.TryParse(this.ddlRounds.SelectedItem.ToString(), out result);
        return result;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.TargetTournament == null)
        return;
      int result = 0;
      if (!int.TryParse(this.ddlRounds.SelectedItem.ToString(), out result))
        return;
      this.Matches = this.GetMatches();
      if (this.Matches == null || this.Matches.Count == 0)
        return;
      Settings.Default.Save();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private ITournMatchArray GetMatches()
    {
      if (this.rdoAllMatches.Checked)
      {
        ITournMatchArray byRound = this.TargetTournament.Matches.GetByRound(this.Round);
        ITournMatchArray tournMatchArray = (ITournMatchArray) new TournMatchArray();
        foreach (ITournMatch match in (IEnumerable<ITournMatch>) byRound)
        {
          if (match.Players.FindById(Player.BYE_ID) == null)
            tournMatchArray.AddMatch(match);
        }
        return tournMatchArray;
      }
      try
      {
        TournMatchArray tournMatchArray = new TournMatchArray();
        char[] separator = new char[1]{ '-' };
        string[] strArray1 = this.txtSpecificMatches.Text.Split(new char[1]
        {
          ','
        }, StringSplitOptions.RemoveEmptyEntries);
        if (strArray1.Length == 0)
          return (ITournMatchArray) tournMatchArray;
        foreach (string str in strArray1)
        {
          string[] strArray2 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          if (strArray2.Length != 0)
          {
            int result1 = 0;
            int result2 = 0;
            if (!int.TryParse(strArray2[0], out result1))
              throw new Exception("Invalid print range");
            if (strArray2.Length >= 2)
              int.TryParse(strArray2[1], out result2);
            int table = result1;
            do
            {
              ITournMatch byRoundTable = this.TargetTournament.Matches.GetByRoundTable(this.Round, table);
              if (byRoundTable != null)
                tournMatchArray.AddMatch(byRoundTable);
              ++table;
            }
            while (table <= result2);
          }
        }
        return (ITournMatchArray) tournMatchArray;
      }
      catch (Exception ex)
      {
      }
      return (ITournMatchArray) new TournMatchArray();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Settings.Default.Reload();
    }

    private void DialogResultSlips_Load(object sender, EventArgs e)
    {
      this.chkJudgeSignature.Checked = Settings.Default.ResultSlips_JudgeSignature;
      if (this.TargetTournament == null)
        return;
      int num = 1;
      do
      {
        this.ddlRounds.Items.Insert(0, (object) num.ToString());
        ++num;
      }
      while (num <= this.TargetTournament.CurrentRound);
      if (this.ddlRounds.Items.Count <= 0)
        return;
      this.ddlRounds.SelectedIndex = 0;
    }

    public bool AllMatches
    {
      get
      {
        return this.rdoAllMatches.Checked;
      }
    }

    public string SpecificMatches
    {
      get
      {
        return this.txtSpecificMatches.Text;
      }
    }

    private void txtSpecificMatches_Enter(object sender, EventArgs e)
    {
      this.rdoSpecificMatches.Checked = true;
    }
  }
}
