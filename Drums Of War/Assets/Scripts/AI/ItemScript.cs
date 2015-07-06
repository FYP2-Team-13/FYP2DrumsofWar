using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	int id;

	public void SetID (int id)
	{
		this.id = id;
	}

	public int GetID ()
	{
		return id;
	}

	void OnCollisionEnter2D( Collision2D col )
	{
		if (col.gameObject.tag == "Ally") {
			GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().NewItem(id);
			Destroy (gameObject);
		}
	}
}
