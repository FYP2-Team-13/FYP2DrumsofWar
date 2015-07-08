using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetItemDetail : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CreateRandomItem()
	{
		GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ().CreateRandomItem ();
	}

	public void OnMouseOver()
	{
		if (GetComponent<Text> ().text != "Empty") {
			ArmoryInventory theArmory = transform.parent.gameObject.GetComponent<ArmoryInventory> ();
			theArmory.FocusOnItem (theArmory.TheInventoryUI.IndexOf (this.gameObject.GetComponent<Text> ()));
		}
	}

	public void Clicked()
	{
		//print (GetComponent<Text> ().text);
		if (GetComponent<Text> ().text != "Empty") {
			EquipmentListBehaviour theArmory = transform.parent.parent.gameObject.GetComponent<EquipmentListBehaviour> ();
			theArmory.ChangeEquipment (theArmory.ListUI.IndexOf (GetComponent<Text> ()));
		}
	}

	public void OnMouseLeave()
	{
		transform.parent.gameObject.GetComponent<ArmoryInventory> ().StopFocus ();
	}
}
