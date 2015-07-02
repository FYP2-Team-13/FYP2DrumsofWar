


using UnityEngine; 
using System.Collections;

public class Database : MonoBehaviour {


	// Use this for initialization
	void Start () {
		InventoryDatabase.current = new InventoryDatabase ();
	
		if (!SaveLoad.Load ()) {
			SaveLoad.Create();
		}


		foreach (InventoryDatabase g in SaveLoad.savedInventoryData) {
		foreach (Item d in ItemDatabase.ItemList) {
				if(g.item.getIdNum() == d.getIdNum())
					g.item = d;
		}
		}
	}

}
