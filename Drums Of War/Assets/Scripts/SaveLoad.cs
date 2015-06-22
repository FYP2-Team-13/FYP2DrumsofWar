using UnityEngine;
using System.Collections;

using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoad {

//	public static List<inventory> savedInventoryData = new List<inventory>();
//
//
//
//	public static void Save() {
//		savedInventoryData.Add(inventory.current);

//		BinaryFormatter bf = new BinaryFormatter();
//		FileStream file = File.Create (Application.persistentDataPath + "/savedInventoryData.invent");
//		bf.Serialize(file, SaveLoad.savedInventoryData);

//		file.Close();
//	}
//
//	public static void Load() {
//		if(File.Exists(Application.persistentDataPath + "/savedInventoryData.invent")) {

//			BinaryFormatter bf = new BinaryFormatter();
//			FileStream file = File.Open(Application.persistentDataPath + "/savedInventoryData.invent", FileMode.Open);
//			SaveLoad.savedInventoryData = (List<inventory>)bf.Deserialize(file);

//			file.Close();
//		}
//	}
}