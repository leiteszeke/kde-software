// Decompiled with JetBrains decompiler
// Type: Konami.DialogSelectPerson
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class DialogSelectPerson : Form
  {
    private IContainer components;
    private ComboBox ddlPeople;
    private Button btnOK;
    private Button btnCancel;
    private Button btnAddToList;
    private ComboBox ddlStaffPosition;
    private Button btnEnterId;
    public ITournPlayerArray PlayerList;
    private IPlayer selectedPlayer;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogSelectPerson));
      this.ddlPeople = new ComboBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.btnAddToList = new Button();
      this.ddlStaffPosition = new ComboBox();
      this.btnEnterId = new Button();
      this.SuspendLayout();
      this.ddlPeople.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlPeople.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlPeople.FormattingEnabled = true;
      this.ddlPeople.Location = new Point(43, 64);
      this.ddlPeople.Name = "ddlPeople";
      this.ddlPeople.Size = new Size(221, 21);
      this.ddlPeople.TabIndex = 0;
      this.btnOK.Location = new Point(84, 173);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(210, 173);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnAddToList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddToList.Location = new Point(278, 62);
      this.btnAddToList.Name = "btnAddToList";
      this.btnAddToList.Size = new Size(75, 23);
      this.btnAddToList.TabIndex = 1;
      this.btnAddToList.Text = "New";
      this.btnAddToList.UseVisualStyleBackColor = true;
      this.btnAddToList.Click += new EventHandler(this.btnAddToList_Click);
      this.ddlStaffPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ddlStaffPosition.DisplayMember = "Name";
      this.ddlStaffPosition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlStaffPosition.FormattingEnabled = true;
      this.ddlStaffPosition.Location = new Point(43, 114);
      this.ddlStaffPosition.Name = "ddlStaffPosition";
      this.ddlStaffPosition.Size = new Size(221, 21);
      this.ddlStaffPosition.TabIndex = 3;
      this.ddlStaffPosition.ValueMember = "Value";
      this.ddlStaffPosition.Visible = false;
      this.btnEnterId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEnterId.Location = new Point(359, 62);
      this.btnEnterId.Name = "btnEnterId";
      this.btnEnterId.Size = new Size(75, 23);
      this.btnEnterId.TabIndex = 2;
      this.btnEnterId.Text = "Enter ID";
      this.btnEnterId.UseVisualStyleBackColor = true;
      this.btnEnterId.Click += new EventHandler(this.btnEnterId_Click);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(490, 244);
      this.Controls.Add((Control) this.btnEnterId);
      this.Controls.Add((Control) this.ddlStaffPosition);
      this.Controls.Add((Control) this.btnAddToList);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.ddlPeople);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (DialogSelectPerson);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "SelectPerson";
      this.Load += new EventHandler(this.SelectPerson_Load);
      this.ResumeLayout(false);
    }

    public bool AllowNewPlayers
    {
      get
      {
        return this.btnAddToList.Visible;
      }
      set
      {
        this.btnAddToList.Visible = value;
      }
    }

    public bool EnableStaffPosition
    {
      get
      {
        return this.ddlStaffPosition.Visible;
      }
      set
      {
        this.ddlStaffPosition.Visible = value;
      }
    }

    public IPlayer NewPlayer
    {
      get
      {
        return this.selectedPlayer;
      }
      set
      {
        this.selectedPlayer = value;
      }
    }

    public StaffPosition SelectedStaffPosition
    {
      get
      {
        return (StaffPosition) ((DropListItem) this.ddlStaffPosition.SelectedItem).Value;
      }
      set
      {
        StaffPosition pos = value;
        DropListItem dropListItem = new DropListItem(TournStaff.GetName(pos), (object) pos);
        this.ddlStaffPosition.SelectedIndex = this.ddlStaffPosition.FindString(TournStaff.GetName(pos));
      }
    }

    public string Title
    {
      get
      {
        return this.Text;
      }
      set
      {
        this.Text = value;
      }
    }

    private void btnAddToList_Click(object sender, EventArgs e)
    {
      DialogNewPerson dialogNewPerson = new DialogNewPerson();
      if (dialogNewPerson.ShowDialog() != DialogResult.OK)
        return;
      Engine.PlayerList.AddPlayer(dialogNewPerson.NewPlayer);
      this.ddlPeople.Items.Insert(0, (object) dialogNewPerson.NewPlayer);
      this.ddlPeople.SelectedIndex = 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.selectedPlayer = (IPlayer) this.ddlPeople.SelectedItem;
      this.DialogResult = DialogResult.OK;
    }

    public DialogSelectPerson()
    {
      this.InitializeComponent();
      this.ddlStaffPosition.Items.Clear();
      foreach (StaffPosition pos in (StaffPosition[]) Enum.GetValues(typeof (StaffPosition)))
      {
        if (pos != StaffPosition.None)
          this.ddlStaffPosition.Items.Add((object) new DropListItem(TournStaff.GetName(pos), (object) pos));
      }
      this.ddlStaffPosition.SelectedIndex = 0;
    }

    private void SelectPerson_Load(object sender, EventArgs e)
    {
      this.ddlPeople.Items.Clear();
      if (this.PlayerList == null)
      {
        Engine.PlayerList.SortByLastname();
        IPlayer[] array = new IPlayer[Engine.PlayerList.Count];
        Engine.PlayerList.CopyTo(array, 0);
        this.ddlPeople.Items.AddRange((object[]) array);
      }
      else
      {
        PlayerArray playerArray = new PlayerArray();
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) this.PlayerList)
          playerArray.AddPlayer((IPlayer) player);
        playerArray.SortByLastname();
        IPlayer[] array = new IPlayer[playerArray.Count];
        playerArray.CopyTo(array, 0);
        this.ddlPeople.Items.AddRange((object[]) array);
      }
      if (this.selectedPlayer != null)
      {
        if (Engine.PlayerList.FindById(this.selectedPlayer.ID) != null)
          this.ddlPeople.SelectedItem = (object) Engine.PlayerList.FindById(this.selectedPlayer.ID);
        else
          this.ddlPeople.SelectedIndex = 0;
      }
      else
      {
        if (this.ddlPeople.Items.Count <= 0)
          return;
        this.ddlPeople.SelectedIndex = 0;
      }
    }

    private void btnEnterId_Click(object sender, EventArgs e)
    {
      DialogNewPerson dialogNewPerson = new DialogNewPerson();
      dialogNewPerson.ReadOnly = true;
      dialogNewPerson.Title = "Enter ID";
      if (dialogNewPerson.ShowDialog() != DialogResult.OK)
        return;
      this.ddlPeople.SelectedIndex = -1;
      for (int index = 0; index < this.ddlPeople.Items.Count; ++index)
      {
        if (((IPlayer) this.ddlPeople.Items[index]).ID == dialogNewPerson.NewPlayer.ID)
        {
          this.ddlPeople.SelectedIndex = index;
          break;
        }
      }
    }
  }
}
