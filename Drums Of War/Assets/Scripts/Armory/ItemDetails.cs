using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDetails : MonoBehaviour {

	Text Name, Attack_Damage, Attack_Speed, HP_Increase, Evasion;
	public Text ItemType;
	public Item TheItem;

	// Use this for initialization
	void Start () {
		Name = gameObject.transform.FindChild ("Name").GetComponent<Text> ();
		ItemType = gameObject.transform.FindChild ("Type").GetComponent<Text> ();
		Attack_Damage = gameObject.transform.FindChild ("Attack Damage").GetComponent<Text> ();
		Attack_Speed = gameObject.transform.FindChild ("Attack Speed").GetComponent<Text> ();
		HP_Increase = gameObject.transform.FindChild ("HP Increase").GetComponent<Text> ();
		Evasion = gameObject.transform.FindChild ("Evasion").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TheItem != null) {
			Name.text = TheItem.itemName;
			Attack_Damage.text = "+" + TheItem.attackDamage + " Damage";
			Attack_Speed.text = "+" + TheItem.attackSpeed + " Speed";
			HP_Increase.text = "+" + TheItem.HealthPoint + " Hit Points";
			Evasion.text = "+" + TheItem.Evasion + " Evasion";

			string itemtype = "";
			switch (TheItem.type)
			{
			case 1:
				itemtype = "Sword";
				break;
			case 2:
				itemtype = "Javelin";
				break;
			case 3:
				itemtype = "Bow";
				break;
			case 4:
				itemtype = "Dagger";
				break;
			case 5:
				itemtype = "Magic Item";
				break;
			case 6:
				itemtype = "Mask";
				break;
			default:
				break;
			}

			ItemType.text = itemtype;
		} else {
			Name.text = ItemType.text = Attack_Damage.text = Attack_Speed.text = HP_Increase.text = Evasion.text = "";
		}
	}
}
