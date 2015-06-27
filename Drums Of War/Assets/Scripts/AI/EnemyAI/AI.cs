using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public enum AI_ENEMY_State
	{
			Enemy_Idle = 0
		,	Enemy_Forward
		,	Enemy_Attack
		,	Enemy_Dead
	}

	//<stats>
	public AI_ENEMY_State state = AI_ENEMY_State.Enemy_Idle;

	Vector3 direction = Vector3.zero;

	public bool iswall;
	
	public float health = 100;
	float moveSpeed = 1.0f;

	public float attackDamage = 0;
	public float attackSpeed = 0;
	public float attackRange = 0;
	//</stats>

	public GameObject Target;

	private float prevTime;
	float now;
	float diff;
	

	// Use this for initialization
	void Start () {
		//state = AI_ENEMY_State.Enemy_Idle;

		prevTime = Time.time;
	}

	public void Set (float ADamage, float ASpeed, float ARange, float MSpeed, float HP, int forceState)
	{
		this.attackDamage = ADamage;
		this.attackSpeed = ASpeed * 1000;
		this.attackRange = ARange;
		this.moveSpeed = MSpeed;
		this.health = HP;

		//for testing
		this.SetState(forceState);
	}

	public void SetState (int set) { //just incase I need to force state change
		if (set == 0)
			state = AI_ENEMY_State.Enemy_Idle;
		if (set == 1)
			state = AI_ENEMY_State.Enemy_Forward;
		if (set == 2)
			state = AI_ENEMY_State.Enemy_Attack;
	}

	// Update is called once per frame
	void Update () {
		
		if (state != AI_ENEMY_State.Enemy_Dead) {
			if (!iswall) {
				this.transform.Translate (direction * moveSpeed * Time.deltaTime);
			}

			now = Time.time;
			diff = (now - prevTime) * 1000;

			Search (); //look for closest
			states (); //check states and act according
		}
			//Destroy(this.gameObject, 1);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Finish")
			Physics2D.IgnoreCollision (GetComponent<Collider2D>(), col.collider);
	}

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
			    && script.GetHP() > 0)
			{
				//Check if he is the closest enemy
				if (EnemyDistance < Nearest)
				{
					Nearest = EnemyDistance;
					Target = node;
				}
			}

			if (EnemyDistance < attackRange)
				state = AI_ENEMY_State.Enemy_Attack;
			else if (EnemyDistance < attackRange + 10f)
				state = AI_ENEMY_State.Enemy_Forward;
			else if (Target == null)
				state = AI_ENEMY_State.Enemy_Idle;
		}

	}


	void states() {
		switch (state) {
		case AI_ENEMY_State.Enemy_Idle:
			{
				direction = Vector3.zero;
			}
			break;
		case AI_ENEMY_State.Enemy_Forward:
			{
			//moving
				direction.Set (-1, 0, 0);
			}
			break;
		case AI_ENEMY_State.Enemy_Attack:
			{
			//stop moving and start to attack
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

		//if can't attack now
		if (diff < attackSpeed)
			return;

		prevTime = now;

		if (attackRange > 3.0f) {
			var Range = this.GetComponent<Range> ();
			Range.createProjectile ();
			return;
		}

		var script = Target.GetComponent<AllyClass> ();
		script.TakeDamage(attackDamage);
	}

	public void TakeDamage (float damage)
	{
		//print (damage);
		if (Random.Range (0, 100) < 100) {
			health -= damage;
			//print (health);
			if (health < 1) {
				gameObject.layer = LayerMask.NameToLayer ("Dead");
				gameObject.tag = "Finish";
				state = AI_ENEMY_State.Enemy_Dead;
				return;
			}
		}
	}

	void OnBecameInvisible()
	{
		if (state == AI_ENEMY_State.Enemy_Dead) {
			Destroy (gameObject);
		}
	}
}
