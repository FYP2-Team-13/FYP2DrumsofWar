using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {

	public ArmyStats TheArmysStats;
	Inventory TheInventory;

	List<Item> ItemList;
	int PageIndex = 0;

	// Use this for initialization
	void Start () {
		TheInventory = GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RecruitUnit ()
	{
		TheArmysStats.RecruitUnit ();
	}

	public void InventorySearchOfType (int searchvalue)
	{
		ItemList = TheInventory.GetItemsofType (searchvalue);
	}

	public void InventorySearchWithoutType (int searchvalue)
	{
		ItemList = TheInventory.GetItemsNotofType (searchvalue);
	}

	public void NextIndex ()
	{
	}
}
