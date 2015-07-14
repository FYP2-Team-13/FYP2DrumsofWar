using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	int value;
	public bool isItem = false;

	public void Setvalue (int value)
	{
		this.value = value;
	}

	public int Getvalue ()
	{
		return value;
	}

	void OnCollisionEnter2D( Collision2D col )
	{
		if (col.gameObject.tag == "Ally") {
			print ("Collected");
			if (isItem)
				GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().NewItem(value);
			else
				GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().AddMoney(value);
			Destroy (gameObject);
		}
	}
}
