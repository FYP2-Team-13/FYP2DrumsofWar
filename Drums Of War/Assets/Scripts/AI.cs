using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	float health = 100;
	public float state = 0; // 0 neutral, 1 move, 2 attack
	//public float AItype = 0; // 1 ally 2 enemy, 3 neutral

	float moveSpeed;
	Vector3 direction = Vector3.zero;

	public float attackRange = 0;
	public float attackSpeed = 0;
	public float attackDamage = 0;
	//public GameObject Target;

	// Use this for initialization
	void Start () {
		moveSpeed = 1;
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (direction * moveSpeed * Time.deltaTime);


		states();
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag != this.gameObject.tag) {
			state = 2;
		}
	}


	void states() {
		if (state == 0)
			return;
		else if (state == 1) {
			if (this.gameObject.tag == "Player")
				direction.Set(1,0,0);
			else if (this.gameObject.tag == "Enemy")
				direction.Set(-1,0,0);
		}
		else if (state == 2) {
			direction = Vector3.zero;
		}
	}
	


}
