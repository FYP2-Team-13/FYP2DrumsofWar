using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public enum AI_ENEMY_State
	{
			Enemy_Idle = 0
		,	Enemy_Forward
		,	Enemy_Attack
	}

	//stats
	AI_ENEMY_State state = AI_ENEMY_State.Enemy_Idle;

	Vector3 direction = Vector3.zero;
	
	public float health = 100;
	float moveSpeed = 1.0f;

	public float attackDamage = 0;
	public float attackSpeed = 0;
	public float attackRange = 0;

	public GameObject Target;

	private float prevTime;
	float now;
	float diff;
	

	// Use this for initialization
	void Start () {
		state = AI_ENEMY_State.Enemy_Forward;

		prevTime = Time.time;
	}

	public void Set (float ADamage, float ASpeed, float ARange, float MSpeed, float HP)
	{
		this.attackDamage = ADamage;
		this.attackSpeed = ASpeed * 1000;
		this.attackRange = ARange;
		this.moveSpeed = MSpeed;
		this.health = HP;
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate (direction * moveSpeed * Time.deltaTime);

		now = Time.time;
		diff = (now - prevTime) * 1000;

		Search ();
		states();

		if (health < 1)
			Destroy(this.gameObject, 1);
	}

//	void OnCollisionEnter2D( Collision2D col ) {
//		if (state == AI_ENEMY_State.Enemy_Forward) {
//			if (col.gameObject.tag == "Ally") {
//				Target = col.gameObject;
//				state = AI_ENEMY_State.Enemy_Attack;
//			}
//		}
//	}

	void Search () {

		GameObject[] nodes = GameObject.FindGameObjectsWithTag("Ally");

		Target = null;// Reset Targets
	
		float Nearest = 999f;
		foreach (GameObject node in nodes)
		{
			var script = node.GetComponent<AllyClass> ();
			float EnemyDistance = (node.transform.position - transform.position).magnitude;
			
			//Check if the Enemy is in Attack Range
			if (EnemyDistance < attackRange 
//			    && script.Hitpoints > 0 
			    )
			{
				//Check if he is the closest enemy
				if (EnemyDistance < Nearest)
				{
					Nearest = EnemyDistance;
					Target = node;
				}
			}
		}
		if (Target == null)
			state = AI_ENEMY_State.Enemy_Forward;
		else
			state = AI_ENEMY_State.Enemy_Attack;
	}


	void states() {
		switch (state) {
		case AI_ENEMY_State.Enemy_Idle:
			{
		
			}
			break;
		case AI_ENEMY_State.Enemy_Forward:
			{
				direction.Set (-1, 0, 0);
			}
			break;
		case AI_ENEMY_State.Enemy_Attack:
			{
				direction = Vector3.zero;

				Attacking ();
			}
			break;
		default:
			{

			}
			break;
		}
	}

	void Attacking () {

		if (diff < attackSpeed)
			return;

		prevTime = now;

//		if (Target.gameObject.tag == "Ally") {
			var script = Target.GetComponent<AllyClass> ();
			script.TakeDamage(attackDamage);

//		}

	}

	public void TakeDamage (float damage)
	{
		if (Random.Range (0, 100) < 100)
			health -= damage;
	}
}
