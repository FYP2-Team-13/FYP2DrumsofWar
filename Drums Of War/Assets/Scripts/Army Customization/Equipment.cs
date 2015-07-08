using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {

	public ArmyStats TheArmysStats;
	Inventory TheInventory;

	List<Item> ItemList;

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
		GameObject tempobject = GameObject.FindGameObjectWithTag ("TomVFX");
		EquipmentListBehaviour EquipmentList= tempobject.GetComponent<EquipmentListBehaviour> ();
//		EquipmentListBehaviour EquipmentList= GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EquipmentListBehaviour> ();
		EquipmentList.OpenEquipmentList (TheArmysStats.Helmet, ItemList, TheArmysStats);
//		GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EquipmentListBehaviour> ().OpenEquipmentList (TheArmysStats.Helmet, ItemList);
	}

	public void InventorySearchWithoutType (int searchvalue)
	{
		ItemList = TheInventory.GetItemsNotofType (searchvalue);
		EquipmentListBehaviour EquipmentList= GameObject.FindGameObjectWithTag ("TomVFX").GetComponent<EquipmentListBehaviour> ();
		EquipmentList.OpenEquipmentList (TheArmysStats.Weapon, ItemList, TheArmysStats);
//		GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EquipmentListBehaviour> ().OpenEquipmentList (TheArmysStats.Helmet, ItemList);
	}
}
