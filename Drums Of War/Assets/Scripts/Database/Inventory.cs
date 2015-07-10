using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Inventory : MonoBehaviour {

	public List<Item> TheInventory = new List<Item>();
	ItemDatabase theItemDatabase;
	int Currency;
	int nextlevel;

	// Use this for initialization
	void Start () {
		theItemDatabase = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase> ();

		if (Load ()) {
			print ("Load Successful");
		} else {
			print ("Load Failed");
			nextlevel = 1;
			Currency = 0;
		}
	}

	public void NewItem( int id )
	{
		TheInventory.Add (theItemDatabase.GetItem (id));
	}

	public void RemoveItem (int index)
	{
		TheInventory.Remove (TheInventory [index]);
	}

	public List<Item> GetItemsofType (int type)
	{
		List<Item> ItemsOfType = new List<Item> ();
		foreach (Item item in TheInventory) {
			if (item.type == type)
			{
				ItemsOfType.Add (item);
			}
		}
		return ItemsOfType;
	}

	public List<Item> GetItemsNotofType (int type)
	{
		List<Item> ItemsNotOfType = new List<Item> ();
		foreach (Item item in TheInventory) {
			if (item.type != type)
			{
				ItemsNotOfType.Add (item);
			}
		}
		return ItemsNotOfType;
	}

	public void AddMoney (int Value)
	{
		if (Value > 0)
		{
			Currency += Value;
		}
	}

	public bool RemoveMoney (int Value)
	{
		if (Currency < Value) {
			return false;
		} else {
			Currency -= Value;
			return true;
		}
	}

	public bool Load()
	{
		if (File.Exists (Application.persistentDataPath + "/Inventory.data")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Inventory.data", FileMode.Open);

			InventoryIDS InventoryData = (InventoryIDS)bf.Deserialize(file);
			file.Close();

			Currency = InventoryData.Currency;
			nextlevel = InventoryData.nextlevel;

			foreach (int id in InventoryData.ItemIDs)
			{
				TheInventory.Add(theItemDatabase.GetItem(id) );
			}

			return true;	
		} else {
			return false;
		}
	}

	public void Save ()
	{
		InventoryIDS InventoryID = new InventoryIDS ();

		foreach (Item item in TheInventory) {
			InventoryID.ItemIDs.Add (item.getIdNum() );
		}
		InventoryID.Currency = Currency;
		InventoryID.nextlevel = nextlevel;
		
		BinaryFormatter bf = new BinaryFormatter ();
		if (!File.Exists (Application.persistentDataPath + "/Inventory.data")) {
			FileStream filetemp = File.Create (Application.persistentDataPath + "/Inventory.data");
			filetemp.Close();
		}
		FileStream file = File.Open (Application.persistentDataPath + "/Inventory.data", FileMode.Open);
		
		bf.Serialize (file, InventoryID);
		file.Close (); 
		
		print ("Save Successful");
	}

	void OnApplicationQuit()
	{
		Save();
	}

	public void CreateRandomItem ()
	{
		int id = Random.Range (0, theItemDatabase.GetAllItems ().Count);
		Item RandomedItem = theItemDatabase.GetAllItems () [id];
		TheInventory.Add (RandomedItem);
	}

	public int GetNextLevel ()
	{
		return nextlevel;
	}

	public void SetNextLevel (int level)
	{
		nextlevel = level;
	}
}

[System.Serializable]
public class InventoryIDS
{
	public List<int> ItemIDs = new List<int>();
	public int Currency, nextlevel;
}