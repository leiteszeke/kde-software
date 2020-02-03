// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.TournPlayerArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class TournPlayerArray : List<ITournPlayer>, ITournPlayerArray, IList<ITournPlayer>, ICollection<ITournPlayer>, IEnumerable<ITournPlayer>, IEnumerable, IBaseObject
  {
    private static TournPlayerSort_ById sorter_ByID = new TournPlayerSort_ById();
    private static TournPlayerSort_ByIdByesLast sorter_ByIdByesLast = new TournPlayerSort_ByIdByesLast();
    private static TournPlayerSort_ByLastName sorter_ByLastName = new TournPlayerSort_ByLastName();
    private static TournPlayerSort_ByName sorter_ByName = new TournPlayerSort_ByName();
    private static TournPlayerSort_ByRank sorter_ByRank = new TournPlayerSort_ByRank();
    public const string OPEN_DUELING_FIRSTNAME = "First Name";
    public const string OPEN_DUELING_LASTNAME = "Last Name";
    public const string OPEN_DUELING_POINTS = "Points";
    public const string OPEN_DUELING_TOURNPLAYER_OBJECT = "TournPlayer";
    private const string _XmlKeyElementName = "TournamentPlayers";
    private PlayerSortOrder _sortOrder;

    public DataTable GetOpenDuelingPoints()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("First Name", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Last Name", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Points", typeof (int)));
      dataTable.Columns.Add(new DataColumn("TournPlayer", typeof (TournPlayer)));
      foreach (TournPlayer tournPlayer in (List<ITournPlayer>) this)
      {
        DataRow row = dataTable.NewRow();
        row["First Name"] = (object) tournPlayer.FirstName;
        row["Last Name"] = (object) tournPlayer.LastName;
        row["Points"] = (object) tournPlayer.OpenDuelingPoints;
        row["TournPlayer"] = (object) tournPlayer;
        dataTable.Rows.Add(row);
      }
      return dataTable;
    }

    public TournPlayerArray()
    {
    }

    public TournPlayerArray(TournPlayerArray source)
    {
      foreach (TournPlayer player in (List<ITournPlayer>) source)
        this.AddPlayer((ITournPlayer) new TournPlayer(player));
    }

    public PlayerSortOrder SortOrder
    {
      get
      {
        return this._sortOrder;
      }
      set
      {
        this._sortOrder = value;
      }
    }

    public int Append(ITournPlayerArray NewTournPlayers)
    {
      if (this.Count == 0)
      {
        this.SortOrder = PlayerSortOrder.Unsorted;
        this.AddRange((IEnumerable<ITournPlayer>) NewTournPlayers);
        return NewTournPlayers.Count;
      }
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      int count = this.Count;
      foreach (ITournPlayer newTournPlayer in (IEnumerable<ITournPlayer>) NewTournPlayers)
      {
        if (!this.HasPlayer(newTournPlayer.ID))
          this.AddPlayer(newTournPlayer);
      }
      return this.Count - count;
    }

    public int ActivePlayerCount
    {
      get
      {
        int num = 0;
        foreach (TournPlayer tournPlayer in (List<ITournPlayer>) this)
        {
          if (tournPlayer.IsActive)
            ++num;
        }
        return num;
      }
    }

    public int TempPlayerCount
    {
      get
      {
        int num = 0;
        foreach (Player player in (List<ITournPlayer>) this)
        {
          if (Engine.GetCossyIdType(player.ID) != Engine.CossyIdType.CossyId)
            ++num;
        }
        return num;
      }
    }

    public void AssignRanks(int maxRound, bool IncludeDrops)
    {
      int num1 = 1;
      int num2 = 1;
      TournPlayer tournPlayer1 = (TournPlayer) null;
      this.SortByRank();
      foreach (TournPlayer tournPlayer2 in (List<ITournPlayer>) this)
      {
        bool flag = tournPlayer2.IsActive;
        if (tournPlayer2.DropRound > maxRound)
          flag = true;
        if (tournPlayer2.DropRound == maxRound && tournPlayer2.DropReason == CutType.PlayoffCut)
          flag = true;
        if (tournPlayer2.DropRound == maxRound && tournPlayer2.DropReason == CutType.TopX)
          flag = true;
        if (IncludeDrops)
          flag = true;
        if (flag)
        {
          if (tournPlayer1 == null || tournPlayer1.CompareRank((ITournPlayer) tournPlayer2) != 0)
            num2 = num1;
          tournPlayer2.Rank = num2;
          ++num1;
          tournPlayer1 = tournPlayer2;
        }
        else
          tournPlayer2.Rank = this.Count + 1;
      }
    }

    public void SortByID()
    {
      if (this._sortOrder == PlayerSortOrder.Id)
        return;
      this.Sort((IComparer<ITournPlayer>) TournPlayerArray.sorter_ByID);
      this._sortOrder = PlayerSortOrder.Id;
    }

    public void SortByIDByesLast()
    {
      if (this._sortOrder == PlayerSortOrder.IdByesLast)
        return;
      this.Sort((IComparer<ITournPlayer>) TournPlayerArray.sorter_ByIdByesLast);
      this._sortOrder = PlayerSortOrder.IdByesLast;
    }

    public void SortByName()
    {
      if (this._sortOrder == PlayerSortOrder.FirstName)
        return;
      this.Sort((IComparer<ITournPlayer>) TournPlayerArray.sorter_ByName);
      this._sortOrder = PlayerSortOrder.FirstName;
    }

    public void SortByLastname()
    {
      if (this._sortOrder == PlayerSortOrder.LastName)
        return;
      this.Sort((IComparer<ITournPlayer>) TournPlayerArray.sorter_ByLastName);
      this._sortOrder = PlayerSortOrder.LastName;
    }

    public bool HasPlayer(long ID)
    {
      return this.FindById(ID) != null;
    }

    public ITournPlayer FindById(long ID)
    {
      this.SortByID();
      int index = this.BinarySearch((ITournPlayer) new TournPlayer((IPlayer) new Player("", "", ID)), (IComparer<ITournPlayer>) TournPlayerArray.sorter_ByID);
      return index < 0 ? (ITournPlayer) null : this[index];
    }

    public void ReSort()
    {
      this.ForceSort(this.SortOrder);
    }

    public void ForceSort(PlayerSortOrder order)
    {
      this.SortOrder = PlayerSortOrder.Unsorted;
      if (order == PlayerSortOrder.Unsorted)
        order = PlayerSortOrder.Id;
      switch (order - 1)
      {
        case PlayerSortOrder.Unsorted:
          this.SortByID();
          break;
        case PlayerSortOrder.Id:
          this.SortByIDByesLast();
          break;
        case PlayerSortOrder.IdByesLast:
          this.SortByName();
          break;
        case PlayerSortOrder.FirstName:
          this.SortByLastname();
          break;
        case PlayerSortOrder.LastName:
          this.SortByRank();
          break;
        default:
          throw new Exception(string.Format("Sort Order Re-sort not implemented: {0}", (object) order));
      }
    }

    public void SortByRank()
    {
      if (this._sortOrder == PlayerSortOrder.Rank)
        return;
      this.Sort((IComparer<ITournPlayer>) TournPlayerArray.sorter_ByRank);
      this._sortOrder = PlayerSortOrder.Rank;
    }

    public int AddPlayer(ITournPlayer player)
    {
      this.SortByID();
      if (!this.HasPlayer(player.ID))
      {
        int num = this.BinarySearch(player, (IComparer<ITournPlayer>) TournPlayerArray.sorter_ByID);
        if (num < 0)
          this.Insert(~num, player);
      }
      return this.Count;
    }

    public int RemovePlayer(ITournPlayer player)
    {
      if (this.HasPlayer(player.ID))
      {
        this.Remove(this.FindById(player.ID));
        this.SortOrder = PlayerSortOrder.Unsorted;
      }
      return this.Count;
    }

    public string XmlKeyElementName
    {
      get
      {
        return "TournamentPlayers";
      }
    }

    public void ToFullXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.XmlKeyElementName);
      this.SortByID();
      foreach (IBaseObject baseObject in (List<ITournPlayer>) this)
        baseObject.ToFullXml(writer);
      writer.WriteEndElement();
    }

    public void FromXml(XmlNode node)
    {
      TournPlayer tournPlayer1 = new TournPlayer();
      foreach (XmlNode selectNode in node.SelectNodes(tournPlayer1.XmlKeyElementName))
      {
        TournPlayer tournPlayer2 = new TournPlayer();
        tournPlayer2.FromXml(selectNode);
        this.AddPlayer((ITournPlayer) tournPlayer2);
      }
    }

    public void Shuffle()
    {
      Random random = new Random();
      this.SortOrder = PlayerSortOrder.Unsorted;
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < this.Count; ++index2)
        {
          int index3 = random.Next(this.Count);
          if (index2 != index3)
          {
            ITournPlayer tournPlayer = this[index3];
            this[index3] = this[index2];
            this[index2] = tournPlayer;
          }
        }
      }
    }

    public void ShuffleKeepRank()
    {
      Random random = new Random();
      this.SortOrder = PlayerSortOrder.Unsorted;
      for (int index1 = 0; index1 < 100; ++index1)
      {
        for (int index2 = 0; index2 < this.Count; ++index2)
        {
          int index3 = random.Next(this.Count);
          if (index2 != index3 && this[index2].Tie1_Wins == this[index3].Tie1_Wins)
          {
            ITournPlayer tournPlayer = this[index3];
            this[index3] = this[index2];
            this[index2] = tournPlayer;
          }
        }
      }
    }

    public override bool Equals(object obj)
    {
      ITournPlayerArray tournPlayerArray = (ITournPlayerArray) obj;
      if (tournPlayerArray.Count != this.Count)
        return false;
      this.SortByID();
      tournPlayerArray.SortByID();
      for (int index = 0; index < this.Count; ++index)
      {
        if (this[index].ID.CompareTo(tournPlayerArray[index].ID) != 0)
          return false;
      }
      return true;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public IPlayerArray Downgrade()
    {
      PlayerArray playerArray = new PlayerArray();
      foreach (ITournPlayer tournPlayer in (List<ITournPlayer>) this)
        playerArray.AddPlayer((IPlayer) tournPlayer);
      return (IPlayerArray) playerArray;
    }
  }
}
