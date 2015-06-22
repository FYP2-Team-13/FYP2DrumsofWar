using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	Vector3 direction = Vector3.zero;
	float moveSpeed = 1.0f;
	float damage;

	// Use this for initialization
	void Start () {
		//this.transform.Translate (0, 5, 0);
		direction.Set (-1.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (direction * moveSpeed * Time.deltaTime);
		direction.y -= 0.1f;
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag == "Ally") {
			var script = col.gameObject.GetComponent<AllyClass> ();
			script.TakeDamage(1.0f);
		}
		if (col.gameObject.tag == "Enemy") {
			var script = col.gameObject.GetComponent<AI> ();
			script.TakeDamage(1.0f);
		}
		
		Destroy(this.gameObject);
	}
}
