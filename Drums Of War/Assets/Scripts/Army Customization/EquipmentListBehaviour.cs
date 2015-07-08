using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EquipmentListBehaviour : MonoBehaviour {

	public bool isActive;
	CanvasGroup Menu;
	public List <Item> PotentialList = new List<Item> ();
	Item ItemtoChange;
	ArmyStats TheArmy;

	//public List<GameObject> ListObjects = new List<GameObject> ();
	public List<Text> ListUI;

	int PageIndex;

	// Use this for initialization
	void Start () {
		Menu = GetComponent<CanvasGroup> ();

		GameObject[] ListObjects = GameObject.FindGameObjectsWithTag ("SnareVFX");

		foreach (GameObject aobject in ListObjects)
		{
		//	ListUI.Add(aobject.GetComponentInChildren<Text>(Text));
			ListUI.Add (aobject.GetComponent<Text>());
		}
	}

	// Update is called once per frame
	void Update () {
		if (isActive) {
			Menu.blocksRaycasts = Menu.interactable = true;
			Menu.alpha = 1;

			foreach (Text text in ListUI)
			{
				if ( (PageIndex * ListUI.Count + ListUI.IndexOf (text)) < PotentialList.Count)
				{
					//int index = TheInventoryUI.IndexOf (Slot) + (PageNumber * TheInventoryUI.Count);
					text.text = PotentialList[PageIndex * ListUI.Count + ListUI.IndexOf (text)].itemName;
				} else {
					text.text = "Empty";
				}
			}
		} else {
			Menu.blocksRaycasts = Menu.interactable = false;
			Menu.alpha = 0;
		}
	}

	public void OpenEquipmentList (Item ItemtoChange, List<Item> TheList, ArmyStats Army)
	{
		PageIndex = 0;
		isActive = true;
		PotentialList = TheList;
		this.ItemtoChange = ItemtoChange;
		TheArmy = Army;
	}

	public void NextPage (bool forward)
	{
		if (forward) {
			if ((PageIndex+1) * ListUI.Count < PotentialList.Count) {
				PageIndex++;
			}
		} else {
			if (PageIndex > 0)
			{
				PageIndex--;
			}
		}
	}

	public void ChangeEquipment (int index)
	{
		isActive = false;



		if (TheArmy.Helmet == ItemtoChange) {
			Inventory theInventory = GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory> ();
			theInventory.NewItem (TheArmy.Helmet.getIdNum());

			TheArmy.Helmet = PotentialList [PageIndex * ListUI.Count + index];

//			theInventory.RemoveItem(PageIndex * ListUI.Count + index);
			theInventory.RemoveItem(theInventory.TheInventory.IndexOf(PotentialList[PageIndex * ListUI.Count + index]));

		} else {
			Inventory theInventory = GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory> ();
			theInventory.NewItem (TheArmy.Weapon.getIdNum());

			TheArmy.Weapon = PotentialList [PageIndex * ListUI.Count + index];

			theInventory.RemoveItem(theInventory.TheInventory.IndexOf(PotentialList[PageIndex * ListUI.Count + index]));
		}
	}
}
