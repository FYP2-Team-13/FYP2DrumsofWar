using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentItemScript : MonoBehaviour {
	
	string StartText;
	public int ButtonType;

	// Use this for initialization
	void Start () {
		StartText = GetComponent<Text> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		ArmyStats theArmy = gameObject.transform.parent.parent.gameObject.GetComponent<Equipment> ().TheArmysStats;
		string data;
		switch (ButtonType) {
		case 0:
			data = theArmy.Helmet.itemName;
			break;
		case 1:
			data = theArmy.Weapon.itemName;
			break;
		case 2:
			data = "(" + theArmy.Quantity.ToString() + ")";
			break;
		default:
			data = "";
			break;
		}

		GetComponent<Text> ().text = StartText + data;
	}
}
