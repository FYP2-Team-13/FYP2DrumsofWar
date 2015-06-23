using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<AI> ();
		script.Set (10f, 1f, 1.5f, 1f, 100f, -1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
