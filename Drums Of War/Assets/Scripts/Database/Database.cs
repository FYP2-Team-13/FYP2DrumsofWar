using UnityEngine; 
using System.Collections;

public class Database : MonoBehaviour {


	// Use this for initialization
	void Start () {
		InventoryDatabase.current = new InventoryDatabase ();
	}

	void OnGUI() {
//		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		GUILayout.BeginVertical();
//		GUILayout.FlexibleSpace();

		if (!SaveLoad.Load ()) {
			SaveLoad.Create();
			//InventoryDatabase.current = new InventoryDatabase ();
		}
		else {
			foreach (InventoryDatabase g in SaveLoad.savedInventoryData) {
				foreach (ItemDatabase d in ItemDatabase) {
					Item tempData = d.ItemCheck(g.item);
					g.item = tempData;
					GUILayout.Box("checking");
				}
			}
		}
		foreach(InventoryDatabase g in SaveLoad.savedInventoryData) {
			GUILayout.Space(10);
			GUILayout.Button(g.item.idNum + " - " + g.item.itemName);
			
			GUILayout.Box("savefiles");
		}


		GUILayout.Label("Knight");
		InventoryDatabase.current.item.itemName = GUILayout.TextField(InventoryDatabase.current.item.itemName, 20);
		string temp = GUILayout.TextArea(InventoryDatabase.current.item.idNum.ToString());

		InventoryDatabase.current.item.idNum = int.Parse(temp);

		if(GUILayout.Button("Save")) {
			SaveLoad.Save();
		}
		if(GUILayout.Button("OverSave")) {
			SaveLoad.Overwriting();
		}

//		GUILayout.FlexibleSpace();
//		GUILayout.EndVertical();
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		GUILayout.EndArea();
	}

}
