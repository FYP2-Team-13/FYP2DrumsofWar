﻿using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

	public GameObject projectile;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createProjectile () {
		var scr = this.gameObject.GetComponent<AI> ();
		if (scr.Target != null) {
			GameObject temparrow = (GameObject)Instantiate (projectile, transform.position + ((Vector3.left + Vector3.up) * 1.5f), transform.rotation);
			temparrow.gameObject.tag = "Arrow";
			temparrow.gameObject.layer = LayerMask.NameToLayer (tag + "Arrow");
			ArrowAngleScript tempscript = temparrow.GetComponent<ArrowAngleScript> ();
			tempscript.CalculateAngle (scr.Target.transform, scr.attackRange * 2, scr.attackDamage, "Ally", false);
		}
	}
}
