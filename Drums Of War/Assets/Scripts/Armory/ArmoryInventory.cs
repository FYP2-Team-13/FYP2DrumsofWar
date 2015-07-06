using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ArmoryInventory : MonoBehaviour {

	public GameObject InventorySlot;
	public List<Text> TheInventoryUI = new List<Text>();
	Inventory TheInventory;
	public int PageNumber = 0;
	public GameObject ItemDetails;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < 3; x ++) {
			for (int y = 0; y < 8; y ++)
			{
				GameObject TempGameObject = (GameObject)Instantiate(InventorySlot,(Vector3.right * x * 200 + Vector3.right * 130) + (Vector3.down * y * 40 + Vector3.up * 487), InventorySlot.transform.rotation);
				TempGameObject.transform.SetParent (gameObject.transform);
				TheInventoryUI.Add (TempGameObject.GetComponent<Text>());
			}
		}
		GameObject Temp = GameObject.FindGameObjectWithTag ("Database");
		TheInventory = Temp.GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Text Slot in TheInventoryUI) {
			if (TheInventoryUI.IndexOf (Slot) + (PageNumber * TheInventoryUI.Count) < TheInventory.TheInventory.Count)
			{
				int index = TheInventoryUI.IndexOf (Slot) + (PageNumber * TheInventoryUI.Count);
				Slot.text = TheInventory.TheInventory[index].itemName;
			} else {
				Slot.text = "Empty";
			}
		}
	}

	public void NextPage (bool forward)
	{
		if (forward) {
			if ((PageNumber+1) * TheInventoryUI.Count < TheInventory.TheInventory.Count) {
				PageNumber++;
			}
		} else {
			if (PageNumber > 0)
			{
				PageNumber--;
			}
		}

	}

	public void FocusOnItem (int index)
	{
		ItemDetails.GetComponent<ItemDetails>().TheItem = TheInventory.TheInventory [index + PageNumber * TheInventoryUI.Count];
	}

	public void StopFocus ()
	{
		ItemDetails.GetComponent<ItemDetails> ().TheItem = null;
	}

	public void BackToCamp()
	{
		Application.LoadLevel ("Camp Menu");
	}
}
