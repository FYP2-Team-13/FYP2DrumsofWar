using UnityEngine;
using System.Collections;

[System.Serializable]
public class InventoryDatabase {

	public static InventoryDatabase current;

	public Item item;

	// Use this for initialization
	public InventoryDatabase () {
		item = new Item();
	}
}
