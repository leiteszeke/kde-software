// Decompiled with JetBrains decompiler
// Type: Konami.LocationSettings
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.Data_Layer;

namespace Konami
{
  public class LocationSettings : Form
  {
    private Location selectedLocation = new Location();
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label8;
    private Label label9;
    private TextBox textName;
    private TextBox textAddress1;
    private TextBox textAddress2;
    private TextBox textCountry;
    private TextBox textState;
    private TextBox textCity;
    private TextBox textWebsite;
    private TextBox textPhone;
    private TextBox textZip;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LocationSettings));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.textName = new TextBox();
      this.textAddress1 = new TextBox();
      this.textAddress2 = new TextBox();
      this.textCountry = new TextBox();
      this.textState = new TextBox();
      this.textCity = new TextBox();
      this.textWebsite = new TextBox();
      this.textPhone = new TextBox();
      this.textZip = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(45, 43);
      this.label1.Name = "label1";
      this.label1.Size = new Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(45, 76);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Address";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(45, 142);
      this.label3.Name = "label3";
      this.label3.Size = new Size(24, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "City";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(45, 175);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "State/Province";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(45, 241);
      this.label5.Name = "label5";
      this.label5.Size = new Size(56, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Zip/Postal";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(45, 208);
      this.label6.Name = "label6";
      this.label6.Size = new Size(43, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "Country";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(45, 274);
      this.label8.Name = "label8";
      this.label8.Size = new Size(38, 13);
      this.label8.TabIndex = 7;
      this.label8.Text = "Phone";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(45, 307);
      this.label9.Name = "label9";
      this.label9.Size = new Size(46, 13);
      this.label9.TabIndex = 8;
      this.label9.Text = "Website";
      this.textName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textName.Location = new Point(165, 39);
      this.textName.Name = "textName";
      this.textName.Size = new Size(216, 20);
      this.textName.TabIndex = 9;
      this.textAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textAddress1.Location = new Point(165, 72);
      this.textAddress1.Name = "textAddress1";
      this.textAddress1.Size = new Size(216, 20);
      this.textAddress1.TabIndex = 10;
      this.textAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textAddress2.Location = new Point(165, 105);
      this.textAddress2.Name = "textAddress2";
      this.textAddress2.Size = new Size(216, 20);
      this.textAddress2.TabIndex = 11;
      this.textCountry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textCountry.Location = new Point(165, 204);
      this.textCountry.Name = "textCountry";
      this.textCountry.Size = new Size(216, 20);
      this.textCountry.TabIndex = 14;
      this.textState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textState.Location = new Point(165, 171);
      this.textState.Name = "textState";
      this.textState.Size = new Size(216, 20);
      this.textState.TabIndex = 13;
      this.textCity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textCity.Location = new Point(165, 138);
      this.textCity.Name = "textCity";
      this.textCity.Size = new Size(216, 20);
      this.textCity.TabIndex = 12;
      this.textWebsite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textWebsite.Location = new Point(165, 303);
      this.textWebsite.Name = "textWebsite";
      this.textWebsite.Size = new Size(216, 20);
      this.textWebsite.TabIndex = 17;
      this.textPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textPhone.Location = new Point(165, 270);
      this.textPhone.Name = "textPhone";
      this.textPhone.Size = new Size(216, 20);
      this.textPhone.TabIndex = 16;
      this.textZip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textZip.Location = new Point(165, 237);
      this.textZip.Name = "textZip";
      this.textZip.Size = new Size(216, 20);
      this.textZip.TabIndex = 15;
      this.btnOK.Location = new Point(117, 377);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 18;
      this.btnOK.Text = "Create";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(276, 377);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 19;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(469, 464);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.textWebsite);
      this.Controls.Add((Control) this.textPhone);
      this.Controls.Add((Control) this.textZip);
      this.Controls.Add((Control) this.textCountry);
      this.Controls.Add((Control) this.textState);
      this.Controls.Add((Control) this.textCity);
      this.Controls.Add((Control) this.textAddress2);
      this.Controls.Add((Control) this.textAddress1);
      this.Controls.Add((Control) this.textName);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (LocationSettings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Location Settings";
      this.Load += new EventHandler(this.LocationSettings_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Location SelectedLocation
    {
      get
      {
        return this.selectedLocation;
      }
      set
      {
        this.selectedLocation = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.selectedLocation.Name = this.textName.Text;
      this.selectedLocation.Address1 = this.textAddress1.Text;
      this.selectedLocation.Address2 = this.textAddress2.Text;
      this.selectedLocation.City = this.textCity.Text;
      this.selectedLocation.Country = this.textCountry.Text;
      this.selectedLocation.Phone = this.textPhone.Text;
      this.selectedLocation.State = this.textState.Text;
      this.selectedLocation.WebSite = this.textWebsite.Text;
      this.selectedLocation.Zip = this.textZip.Text;
      this.DialogResult = DialogResult.OK;
    }

    public LocationSettings()
    {
      this.InitializeComponent();
    }

    private void LocationSettings_Load(object sender, EventArgs e)
    {
      if (this.selectedLocation != null)
      {
        this.textName.Text = this.selectedLocation.Name;
        this.textAddress1.Text = this.selectedLocation.Address1;
        this.textAddress2.Text = this.selectedLocation.Address2;
        this.textCity.Text = this.selectedLocation.City;
        this.textCountry.Text = this.selectedLocation.Country;
        this.textPhone.Text = this.selectedLocation.Phone;
        this.textState.Text = this.selectedLocation.State;
        this.textWebsite.Text = this.selectedLocation.WebSite;
        this.textZip.Text = this.selectedLocation.Zip;
        this.btnOK.Text = "Update";
      }
      else
        this.btnOK.Text = "Create";
    }
  }
}
