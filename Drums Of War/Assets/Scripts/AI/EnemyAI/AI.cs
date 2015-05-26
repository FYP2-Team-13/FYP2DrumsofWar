using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public float health = 100;
	public float state = 0; // 0 neutral, 1 move, 2 attack
	//public float AItype = 0; // 1 ally 2 enemy, 3 neutral

	float moveSpeed;
	Vector3 direction = Vector3.zero;

	public float attackRange = 0;
	public float attackSpeed = 0;
	public float attackDamage = 0;

	public GameObject Target;

	private float prevTime;
	float now;
	float diff;

	// Use this for initialization
	void Start () {
		moveSpeed = 1;
		state = 1;

		attackDamage = 1;
		attackSpeed = 1000;

		prevTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (direction * moveSpeed * Time.deltaTime);

		now = Time.time;
		diff = (now - prevTime) * 1000;


		states();

		if (health < 1)
			Destroy(this.gameObject, 1);
	}

	void OnCollisionEnter2D( Collision2D col ) {

		if (state == 1) {

			if (this.gameObject.tag == "Ally") {
				if (col.gameObject.tag == "Enemy") {
					Target = col.gameObject;
					state = 2;
				}
			} 

			else if (this.gameObject.tag == "Enemy") {
				if (col.gameObject.tag == "Ally") {
					Target = col.gameObject;
					state = 2;
				}
			}
		}
	}



	void states() {
		if (state == 0)
			return;
		else if (state == 1) {
			if (this.gameObject.tag == "Ally")
				direction.Set(1,0,0);
			else if (this.gameObject.tag == "Enemy")
				direction.Set(-1,0,0);
		}
		else if (state == 2) {
			direction = Vector3.zero;

			Attacking();
		}
	}

	void Attacking () {
		if (diff < attackSpeed)
			return;

		prevTime = now;

		var script = Target.GetComponent<AI>();
		script.health -= attackDamage;

		if (script.health < 1)
			state = 1;
	}
}
