using UnityEngine;
using System.Collections;

using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;


public class SaveLoad {

	public static List<InventoryDatabase> savedInventoryData = new List<InventoryDatabase>();
	public static float unlockedLevel;
	public static List<ItemDatabase> ItemData = new List<ItemDatabase>();
	public TextAsset Database;

	public static void Save() {
		//overwriting data
		SaveLoad.savedInventoryData.Clear();
		SaveLoad.savedInventoryData.Add(InventoryDatabase.current);

		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Create (Application.persistentDataPath + "/InventoryData.data");
		bf.Serialize(file, SaveLoad.savedInventoryData);
		file.Close();

				   file = File.Create (Application.persistentDataPath + "/LevelData.data");
		bf.Serialize(file, SaveLoad.unlockedLevel);
		file.Close();
	}

	public static bool Load() {
		if (File.Exists (Application.persistentDataPath + "/InventoryData.data")) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream file = File.Open (Application.persistentDataPath + "/InventoryData.data", FileMode.Open);
			savedInventoryData = (List<InventoryDatabase>)bf.Deserialize (file);
			file.Close ();

			file = File.Open (Application.persistentDataPath + "/LevelData.data", FileMode.Open);
			unlockedLevel = (float)bf.Deserialize (file);
			file.Close ();

			//Inventory();

			return true;
		} else
			return false;
	}
	

//	public static void Inventory() {
//		foreach (InventoryDatabase mydata in savedInventoryData) {
//			foreach (ItemDatabase data in ItemData) {
//				if (mydata.item.itemName == data.ItemList )
//			{
//					mydata.item = data.ItemList;
//				continue;
//			}
//		}
//		}
//	}
}