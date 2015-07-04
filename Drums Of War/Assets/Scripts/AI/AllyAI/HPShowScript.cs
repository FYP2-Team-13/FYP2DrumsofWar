using UnityEngine;
using System.Collections;

public class HPShowScript : MonoBehaviour {

	float HP, HPMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HP = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHP ();
		HPMax = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHPMax ();

		float HPPercentage = HP / HPMax;
		gameObject.transform.localScale.Set (HPPercentage * 10, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
