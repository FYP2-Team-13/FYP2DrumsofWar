using UnityEngine;
using System.Collections;

public class IgnoreAllyCollision : MonoBehaviour {

	public string IgnoreTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == IgnoreTag)
			Physics2D.IgnoreCollision (GetComponent<Collider2D>(), col.collider);
	}
}
