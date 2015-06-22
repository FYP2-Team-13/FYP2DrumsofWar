using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

	//public GameObject projectile;

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<AI> ();
		script.Set (0f, 1f, 5.0f, 1f, 10f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	public void createProjectile () {
//		var scr = this.gameObject.GetComponent<AI> ();
//		//scr.SetState (0);
//
//		Vector3 tempPos = scr.gameObject.transform.position;
//		tempPos.y += 5;
//
//		Instantiate(projectile, tempPos, Quaternion.identity);
//	}
}
