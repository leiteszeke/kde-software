// Decompiled with JetBrains decompiler
// Type: Konami.DialogPlayoffs
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Konami
{
  public class DialogPlayoffs : Form
  {
    private int _day2Record;
    private int _playoffCount;
    private int _topXCut;
    private IContainer components;
    private TextBox txtPlayoffCount;
    private Button btnOK;
    private Button btnCancel;
    private RadioButton radioSingleElim;
    private RadioButton radioDay2;
    private TextBox txtDay2Count;
    private RadioButton radioTopX;
    private TextBox txtTopX;

    public bool IsDay2Cut
    {
      get
      {
        return this.radioDay2.Checked;
      }
      set
      {
        this.radioDay2.Checked = value;
      }
    }

    public int Day2Record
    {
      get
      {
        return this._day2Record;
      }
      set
      {
        this._day2Record = value;
        this.txtDay2Count.Text = this._day2Record.ToString();
      }
    }

    public int PlayoffCount
    {
      get
      {
        return this._playoffCount;
      }
      set
      {
        this._playoffCount = value;
        this.txtPlayoffCount.Text = this._playoffCount.ToString();
      }
    }

    public int TopXCut
    {
      get
      {
        int.TryParse(this.txtTopX.Text, out this._topXCut);
        return this._topXCut;
      }
      set
      {
        this.txtTopX.Text = Convert.ToString(value);
      }
    }

    public bool IsTopXCut
    {
      get
      {
        return this.radioTopX.Checked;
      }
      set
      {
        this.radioTopX.Checked = value;
      }
    }

    public bool IsSingleElimCut
    {
      get
      {
        return this.radioSingleElim.Checked;
      }
      set
      {
        this.radioSingleElim.Checked = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (int.TryParse(this.txtPlayoffCount.Text, out this._playoffCount) && this.radioSingleElim.Checked)
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      if (int.TryParse(this.txtDay2Count.Text, out this._day2Record) && this.radioDay2.Checked)
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      if (!int.TryParse(this.txtTopX.Text, out this._topXCut) || !this.radioTopX.Checked)
        return;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    public DialogPlayoffs()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPlayoffs));
      this.txtPlayoffCount = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.radioSingleElim = new RadioButton();
      this.radioDay2 = new RadioButton();
      this.txtDay2Count = new TextBox();
      this.radioTopX = new RadioButton();
      this.txtTopX = new TextBox();
      this.SuspendLayout();
      this.txtPlayoffCount.Location = new Point(180, 33);
      this.txtPlayoffCount.Name = "txtPlayoffCount";
      this.txtPlayoffCount.Size = new Size(50, 20);
      this.txtPlayoffCount.TabIndex = 1;
      this.btnOK.Location = new Point(48, 176);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 6;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(155, 176);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.radioSingleElim.AutoSize = true;
      this.radioSingleElim.Checked = true;
      this.radioSingleElim.Location = new Point(30, 34);
      this.radioSingleElim.Name = "radioSingleElim";
      this.radioSingleElim.Size = new Size(142, 17);
      this.radioSingleElim.TabIndex = 0;
      this.radioSingleElim.TabStop = true;
      this.radioSingleElim.Text = "Single Elim Player Count:";
      this.radioSingleElim.UseVisualStyleBackColor = true;
      this.radioDay2.AutoSize = true;
      this.radioDay2.Location = new Point(30, 72);
      this.radioDay2.Name = "radioDay2";
      this.radioDay2.Size = new Size(132, 17);
      this.radioDay2.TabIndex = 2;
      this.radioDay2.Text = "Day 2 Minimum Points:";
      this.radioDay2.UseVisualStyleBackColor = true;
      this.txtDay2Count.Location = new Point(180, 71);
      this.txtDay2Count.Name = "txtDay2Count";
      this.txtDay2Count.Size = new Size(50, 20);
      this.txtDay2Count.TabIndex = 3;
      this.radioTopX.AutoSize = true;
      this.radioTopX.Location = new Point(30, 113);
      this.radioTopX.Name = "radioTopX";
      this.radioTopX.Size = new Size(107, 17);
      this.radioTopX.TabIndex = 4;
      this.radioTopX.TabStop = true;
      this.radioTopX.Text = "Day 2 Top X Cut:";
      this.radioTopX.UseVisualStyleBackColor = true;
      this.txtTopX.Location = new Point(180, 112);
      this.txtTopX.Name = "txtTopX";
      this.txtTopX.Size = new Size(50, 20);
      this.txtTopX.TabIndex = 5;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(284, 237);
      this.Controls.Add((Control) this.txtTopX);
      this.Controls.Add((Control) this.radioTopX);
      this.Controls.Add((Control) this.txtDay2Count);
      this.Controls.Add((Control) this.radioDay2);
      this.Controls.Add((Control) this.radioSingleElim);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtPlayoffCount);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DialogPlayoffs);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Playoffs";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
