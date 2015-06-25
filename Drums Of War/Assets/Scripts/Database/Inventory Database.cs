using UnityEngine;
using System.Collections;

using System.Collections.Generic;

[System.Serializable]
public class InventoryDatabase : MonoBehaviour {

	public static InventoryDatabase current;

	public Item item;

	// Use this for initialization
	void Start () {
		item = new Item();
	}
}
