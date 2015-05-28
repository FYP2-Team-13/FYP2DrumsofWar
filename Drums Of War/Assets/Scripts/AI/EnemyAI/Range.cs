using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<AI> ();
		script.Set (10f, 1f, 10.0f, 1f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
