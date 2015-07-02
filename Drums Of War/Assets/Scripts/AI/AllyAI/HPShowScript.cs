using UnityEngine;
using System.Collections;

public class HPShowScript : MonoBehaviour {

	float HP, HPMax;

	// Use this for initialization
	void Start () {
		HP = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHP ();
		HPMax = gameObject.transform.parent.gameObject.GetComponent<AllyClass> ().GetHPMax ();
	}
	
	// Update is called once per frame
	void Update () {
		float HPPercentage = HP / HPMax;
		gameObject.transform.localScale.Set (HPPercentage * 10, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
