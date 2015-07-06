using UnityEngine;
using System.Collections;

public class HPShowScript : MonoBehaviour {

	public float HP, HPMax;

	// Use this for initialization
	void Start () {
		HPMax = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHPMax ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		HP = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHP ();

		float HPPercentage = HP / HPMax;
		transform.localScale = new Vector3 (HPPercentage * 10, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
