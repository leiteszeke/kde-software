// Decompiled with JetBrains decompiler
// Type: TournamentLibrary.Data_Layer.PlayerArray
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Interfaces;

namespace TournamentLibrary.Data_Layer
{
  public class PlayerArray : List<IPlayer>, IPlayerArray, IList<IPlayer>, ICollection<IPlayer>, IEnumerable<IPlayer>, IEnumerable, IBaseObject
  {
    private static PlayerSort_ById _SortByIdComparer = new PlayerSort_ById();
    private static PlayerSort_ByLastName _SortByLastNameComparer = new PlayerSort_ByLastName();
    private static PlayerSort_ByFirstName _SortByFirstName = new PlayerSort_ByFirstName();
    private const string _XmlKeyElementName = "PlayerList";
    private PlayerSortOrder _sortOrder;

    public PlayerArray()
    {
    }

    public PlayerArray(IEnumerable<IPlayer> playerList)
      : base(playerList)
    {
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

    public static IPlayerArray LoadFromFile(string filename)
    {
      IPlayerArray playerArray1 = (IPlayerArray) new PlayerArray();
      if (File.Exists(filename))
      {
        if (new FileInfo(filename).Length == 0L)
        {
          File.Delete(filename);
        }
        else
        {
          XmlSerializer xmlSerializer = new XmlSerializer(typeof (Player[]), new XmlRootAttribute("PlayerList"));
          StreamReader streamReader = new StreamReader(filename);
          Player[] playerArray2 = (Player[]) xmlSerializer.Deserialize((TextReader) streamReader);
          streamReader.Close();
          streamReader.Dispose();
          playerArray1 = (IPlayerArray) new PlayerArray((IEnumerable<IPlayer>) playerArray2);
        }
      }
      return playerArray1;
    }

    public static void WriteToFile(IPlayerArray players, string filename)
    {
      PlayerArray.WriteToFile(players, filename, false);
    }

    public static void WriteToFile(IPlayerArray players, string filename, bool overwrite)
    {
      PlayerArray playerArray1 = new PlayerArray();
      PlayerArray playerArray2 = new PlayerArray();
      PlayerArray playerArray3 = new PlayerArray();
      if (File.Exists(filename) && !overwrite)
      {
        playerArray1.Append(PlayerArray.LoadFromFile(filename));
        playerArray1.SortByID();
        foreach (Player player in (IEnumerable<IPlayer>) players)
        {
          if (playerArray1.FindById(player.ID) == null)
          {
            if (Engine.GetCossyIdType(player.ID) == Engine.CossyIdType.CossyId)
              playerArray2.AddPlayer((IPlayer) player);
            else
              playerArray3.Add((IPlayer) player);
          }
        }
        playerArray2.Append((IPlayerArray) playerArray1);
      }
      else
      {
        foreach (Player player in (IEnumerable<IPlayer>) players)
        {
          if (Engine.GetCossyIdType(player.ID) == Engine.CossyIdType.CossyId)
            playerArray2.AddPlayer((IPlayer) player);
          else
            playerArray3.Add((IPlayer) player);
        }
      }
      if (playerArray3.Count > 0)
        PlayerArray.WriterPlayersToCsv(Path.Combine(Settings.DataStorageFolder, string.Format("Invalid COSSY IDs {0}.csv", (object) DateTime.Now.ToString("yyyyMMdd"))), (IPlayerArray) playerArray3);
      if (playerArray2.Count == 0)
        return;
      playerArray2.SortByLastname();
      Player[] playerArray4 = new Player[playerArray2.Count];
      playerArray2.CopyTo((IPlayer[]) playerArray4, 0);
      Type type = typeof (Player);
      for (int index = 0; index < playerArray4.Length; ++index)
      {
        if (playerArray4[index].GetType() != type)
          playerArray4[index] = new Player((IPlayer) playerArray4[index]);
      }
      StreamWriter streamWriter = new StreamWriter(filename, false);
      new XmlSerializer(typeof (Player[]), new XmlRootAttribute("PlayerList")).Serialize((TextWriter) streamWriter, (object) playerArray4);
      streamWriter.Close();
      streamWriter.Dispose();
    }

    public static void WriterPlayersToCsv(string filename, IPlayerArray players)
    {
      Engine.LogAction((ITournament) null, UserAction.Export_Player_List);
      StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
      streamWriter.WriteLine("\"ID\",\"First Name\",\"Last Name\"");
      foreach (IPlayer player in (IEnumerable<IPlayer>) players)
        streamWriter.WriteLine("\"{0}\",\"{1}\",\"{2}\"", new object[3]
        {
          (object) player.IDFormatted,
          (object) player.FirstName.Replace("\"", "\\\""),
          (object) player.LastName.Replace("\"", "\\\"")
        });
      streamWriter.Close();
      streamWriter.Dispose();
    }

    public void SortByID()
    {
      if (this._sortOrder == PlayerSortOrder.Id)
        return;
      this.Sort((IComparer<IPlayer>) PlayerArray._SortByIdComparer);
      this._sortOrder = PlayerSortOrder.Id;
    }

    public void SortByIDByesLast()
    {
      if (this._sortOrder == PlayerSortOrder.IdByesLast)
        return;
      this.Sort((IComparer<IPlayer>) new PlayerSort_ByIdByesLast());
      this._sortOrder = PlayerSortOrder.IdByesLast;
    }

    public void SortByFirstName()
    {
      if (this._sortOrder == PlayerSortOrder.FirstName)
        return;
      this.Sort((IComparer<IPlayer>) PlayerArray._SortByFirstName);
      this._sortOrder = PlayerSortOrder.FirstName;
    }

    public void SortByLastname()
    {
      if (this._sortOrder == PlayerSortOrder.LastName)
        return;
      this.Sort((IComparer<IPlayer>) PlayerArray._SortByLastNameComparer);
      this._sortOrder = PlayerSortOrder.LastName;
    }

    public bool HasPlayer(long ID)
    {
      return this.FindById(ID) != null;
    }

    public bool ChangePlayerId(long oldPlayerId, long newPlayerId)
    {
      IPlayer byId = this.FindById(oldPlayerId);
      if (byId == null || this.FindById(newPlayerId) != null)
        return false;
      byId.ID = newPlayerId;
      this.SortOrder = PlayerSortOrder.Unsorted;
      return true;
    }

    public IPlayer FindById(long ID)
    {
      this.SortByID();
      int index = this.BinarySearch((IPlayer) new Player()
      {
        ID = ID
      }, (IComparer<IPlayer>) PlayerArray._SortByIdComparer);
      return index < 0 ? (IPlayer) null : this[index];
    }

    public void ToFullXml(XmlWriter writer)
    {
      PlayerSortOrder sortOrder = this.SortOrder;
      this.SortByLastname();
      writer.WriteStartElement(this.XmlKeyElementName);
      foreach (IBaseObject baseObject in (List<IPlayer>) this)
        baseObject.ToFullXml(writer);
      writer.WriteEndElement();
      this.SortOrder = sortOrder;
      this.ReSort();
    }

    public string XmlKeyElementName
    {
      get
      {
        return "PlayerList";
      }
    }

    public IPlayerArray Append(IPlayerArray NewPlayers)
    {
      PlayerArray playerArray = new PlayerArray();
      if (NewPlayers == null || NewPlayers.Count == 0)
        return (IPlayerArray) playerArray;
      if (this.Count == 0)
      {
        foreach (IPlayer newPlayer in (IEnumerable<IPlayer>) NewPlayers)
          playerArray.AddPlayer(newPlayer);
      }
      else
      {
        for (int index = 0; index < NewPlayers.Count; ++index)
        {
          IPlayer newPlayer = NewPlayers[index];
          if (!this.HasPlayer(newPlayer.ID))
            playerArray.AddPlayer(newPlayer);
        }
      }
      if (playerArray.Count > 0)
      {
        this.AddRange((IPlayerArray) playerArray);
        this.SortOrder = PlayerSortOrder.Unsorted;
      }
      return (IPlayerArray) playerArray;
    }

    public IPlayerArray AddRange(IPlayerArray NewPlayers)
    {
      this.AddRange((IEnumerable<IPlayer>) NewPlayers);
      this.SortOrder = PlayerSortOrder.Unsorted;
      return NewPlayers;
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
          this.SortByFirstName();
          break;
        case PlayerSortOrder.FirstName:
          this.SortByLastname();
          break;
        default:
          throw new Exception(string.Format("Sort Order Re-sort not implemented: {0}", (object) order));
      }
    }

    public int RemoveDuplicates()
    {
      int num = 0;
      this.SortByID();
      for (bool flag = false; !flag; flag = true)
      {
        for (int index = 0; index < this.Count - 1; ++index)
        {
          if (this[index].ID == this[index + 1].ID)
          {
            ++num;
            this.RemoveAt(index + 1);
            break;
          }
        }
      }
      return num;
    }

    public void FromXml(XmlNode node)
    {
      Player player1 = new Player();
      foreach (XmlNode selectNode in node.SelectNodes(player1.XmlKeyElementName))
      {
        Player player2 = new Player();
        player2.FromXml(selectNode);
        this.AddPlayer((IPlayer) player2);
      }
    }

    public int AddPlayer(IPlayer player)
    {
      this.SortByID();
      int num = this.BinarySearch(player, (IComparer<IPlayer>) PlayerArray._SortByIdComparer);
      if (num < 0)
        this.Insert(~num, player);
      return this.Count;
    }

    public int DeletePlayer(IPlayer player)
    {
      if (this.HasPlayer(player.ID))
      {
        this.Remove(this.FindById(player.ID));
        this.SortOrder = PlayerSortOrder.Unsorted;
      }
      return this.Count;
    }

    public IPlayer MatchName(string firstFragment, string lastFragment, bool firstName)
    {
      if (string.IsNullOrEmpty(firstFragment) && string.IsNullOrEmpty(lastFragment))
        return (IPlayer) null;
      if (string.IsNullOrEmpty(firstFragment))
        firstFragment = string.Empty;
      if (string.IsNullOrEmpty(lastFragment))
        lastFragment = string.Empty;
      int index1;
      if (firstName)
      {
        this.SortByFirstName();
        index1 = this.BinarySearch((IPlayer) new Player(firstFragment, lastFragment, Player.BYE_ID), (IComparer<IPlayer>) PlayerArray._SortByFirstName);
      }
      else
      {
        this.SortByLastname();
        index1 = this.BinarySearch((IPlayer) new Player(firstFragment, lastFragment, Player.BYE_ID), (IComparer<IPlayer>) PlayerArray._SortByLastNameComparer);
      }
      if (index1 < 0)
      {
        int index2 = index1 * -1 - 1;
        return this.Count > index2 && this[index2].FirstName.ToLower().StartsWith(firstFragment.ToLower()) && this[index2].LastName.ToLower().StartsWith(lastFragment.ToLower()) ? this[index2] : (IPlayer) null;
      }
      if (index1 >= this.Count)
        index1 = this.Count - 1;
      return this[index1];
    }
  }
}
