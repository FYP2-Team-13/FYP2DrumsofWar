using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquipmentListBehaviour : MonoBehaviour {

	public bool isActive;
	CanvasGroup Menu;
	List <Item> PotentialList;
	Item ItemtoChange;

	public List<GameObject> ListObjects = new List<GameObject> ();
	List<Text> ListUI;

	int PageIndex;

	// Use this for initialization
	void Start () {
		Menu = GetComponent<CanvasGroup> ();

		foreach (GameObject aobject in ListObjects)
		{
		//	ListUI.Add(aobject.GetComponentInChildren<Text>(Text));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			Menu.blocksRaycasts = Menu.interactable = true;
			Menu.alpha = 1;

//			foreach (Text text in ListUI)
//			{
//				if (ListUI.IndexOf (text) + (PageIndex * ListUI.Count + ListUI.IndexOf (text)) < PotentialList.Count)
//				{
//					//int index = TheInventoryUI.IndexOf (Slot) + (PageNumber * TheInventoryUI.Count);
//					text.text = PotentialList[PageIndex * ListUI.Count + ListUI.IndexOf (text)].itemName;
//				} else {
//					text.text = "Empty";
//				}
//			}
		} else {
			Menu.blocksRaycasts = Menu.interactable = false;
			Menu.alpha = 0;
		}
	}

	public void OpenEquipmentList (Item ItemtoChange, List<Item> TheList)
	{
		PageIndex = 0;
		isActive = true;
		PotentialList = TheList;
		this.ItemtoChange = ItemtoChange;
	}

	public void NextPage()
	{
		PageIndex ++;
//		if (CurrentBody >= ArmyForceDatabase.SpriteDatabase.Count ) {
//			CurrentBody -= ArmyForceDatabase.SpriteDatabase.Count;
		//}
	}
	
	public void PrevPage()
	{
		PageIndex--;
//		if (CurrentBody < 0) {
//			CurrentBody += ArmyForceDatabase.SpriteDatabase.Count;
		//}
	}
}
