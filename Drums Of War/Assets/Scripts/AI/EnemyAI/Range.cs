using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
		var script = this.gameObject.GetComponent<AI> ();
		script.Set (0f, 1f, 5.0f, 1f, 10f, -1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createProjectile () {
		var scr = this.gameObject.GetComponent<AI> ();

		GameObject temparrow = (GameObject)Instantiate (projectile, transform.position + ((Vector3.left + Vector3.up) * 1.5f), transform.rotation);
		temparrow.gameObject.tag = "EnemyArrow";
		temparrow.gameObject.layer = gameObject.layer;
		ArrowAngleScript tempscript = temparrow.GetComponent<ArrowAngleScript> ();
		tempscript.CalculateAngle (scr.Target.transform, scr.attackRange * 2, scr.attackDamage, "Ally");
	}
}
