using UnityEngine; 
using System.Collections;

public class Database : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if (!SaveLoad.Load ()) {
			InventoryDatabase.current = new InventoryDatabase ();
		}
		else {
			foreach (InventoryDatabase g in SaveLoad.savedInventoryData) {
				foreach (ItemDatabase d in SaveLoad.ItemData) {
					g.item = d.ItemCheck(g.item);
				}
			}
		}
		foreach(InventoryDatabase g in SaveLoad.savedInventoryData) {
			GUILayout.Space(10);
			GUILayout.Button(g.item.idNum + " - " + g.item.itemName);
			
			GUILayout.Box("Select Save File");
		}

		GUILayout.Label("Knight");
		InventoryDatabase.current.item.itemName = GUILayout.TextField(InventoryDatabase.current.item.itemName, 20);

		GUILayout.Box("Select Save File");
		GUILayout.Space(10);
		GUILayout.Box("Select Save File");

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

}
