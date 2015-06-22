using UnityEngine;
using System.Collections;

public class Mid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<AI> ();
		script.Set (5f, 3f, 2f, 1f, 50f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
