using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	Vector3 tempPos;

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<GroupSpawning> ();

		tempPos.Set (15f, -3.06f, 0);

		script.createGroup(2,2,tempPos);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
