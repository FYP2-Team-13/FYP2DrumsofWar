using UnityEngine;
using System.Collections;

public class AllyClass : MonoBehaviour {
	
	public enum AI_Ally_State
	{
			Ally_Idle = 0
		,	Ally_Advance
		,	Ally_Attack
		,	Ally_Defend
		,	Ally_Retreat
		,	Ally_Dead
	}

	public enum Unit_Type
	{
		Type_Melee = 0
		,Type_Range
	}

	AI_Ally_State AIState = AI_Ally_State.Ally_Idle;
	public Unit_Type Type = Unit_Type.Type_Melee;

	//Stats
	float Hitpoints = 100, HitpointMax = 100;

	//Attack
	float AttackRange = 1.0f,
	AttackSpeed = 1.5f,
	AttackDamage = 10,
	LastAttack = 0.0f;

	//Defense
	float Defense = 1.0f,
	Evasion = 5;

	//End of Stats

	float MoveSpeed = 1.00f;
	float Vision = 15;

	float PrevTime;// = Time.time;

	GameObject Target;
	public string AllyTag, EnemyTag;

	// Use this for initialization
	void Start () {
		PrevTime = Time.time;
	}

	public void Set (float Attack, float Speed, float Range, float Defense, float Evasion, float HP)
	{
		this.AttackDamage = Attack;
		this.AttackSpeed = Speed;
		this.AttackRange = Range;
		this.Defense = Defense;
		this.Evasion = Evasion;
		this.Hitpoints = this.HitpointMax = HP;
	}

	public AI_Ally_State GetAIState ()
	{
		return AIState;
	}

	public void SetAIState (AI_Ally_State state)
	{
		AIState = state;
	}

	void UpdateTargets()
	{ 
		Target = null;// Reset Targets
		if (EnemyTag != null) {// check if there is tag to find enemy
			GameObject[] nodes = GameObject.FindGameObjectsWithTag(EnemyTag);
			float Nearest = 999f;
			foreach (GameObject node in nodes)
			{
				float EnemyDistance = (node.transform.position - transform.position).magnitude;
				
				//Check if the Enemy is in Vision Range
				if (EnemyDistance < Vision)
				{
					//Check if he is the closest enemy
					if (EnemyDistance < Nearest)
					{
						Nearest = EnemyDistance;
						Target = node;
					}
				}
			}
			//if (Target != null) // We have a Target
			//{
				//Fighting = true;
			//}
			//else
				//Fighting = false;
		}
	}

	void UpdateState()
	{
		switch (AIState) {
		case AI_Ally_State.Ally_Advance: {
			gameObject.transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime) ;
			//print (Vector2.right * MoveSpeed * Time.deltaTime);
			//gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * MoveSpeed * Time.deltaTime) ;
			}
			break;
		case AI_Ally_State.Ally_Attack: {
				UpdateTargets();
				if (Target != null)
				{
					//if (Target.transform
					gameObject.transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime) ;
				}
			}
			break;
		case AI_Ally_State.Ally_Retreat: {
			gameObject.transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime) ;
			}
			break;
		default:
			break;
		}
	}

	public void ReceiveCommand (string Melee, string Range)
	{
		//string temp;
		//if (Type == Unit_Type.Type_Melee) 
		//	temp = Melee;
		//else
		//	temp = Range;
		if (AIState != AI_Ally_State.Ally_Dead) {
			switch ((Type == Unit_Type.Type_Melee ? Melee : Range)) {
			case "Advance":
				{
					AIState = AI_Ally_State.Ally_Advance;
				}
				break;
			case "Attack":
				{
					AIState = AI_Ally_State.Ally_Attack;
				}
				break;
			case "Defend":
				{
					AIState = AI_Ally_State.Ally_Defend;
				}
				break;
			case "Retreat":
				{
					AIState = AI_Ally_State.Ally_Retreat;
				}
				break;
			default:
				AIState = AI_Ally_State.Ally_Idle;
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Rigidbody2D>().
		if (Time.time - PrevTime > (float)(1 / 30)) {
			UpdateState();

			PrevTime = Time.time;
		}
	}

	//Use this function when an enemy attacks the unit
	public void TakeDamage (float damage)
	{
		if (Random.Range (0, 100) < 100 - Evasion) {
			Hitpoints -= damage - Defense;
			if (Hitpoints < 1)
				AIState = AI_Ally_State.Ally_Dead;
		}
	}

	public void Heal (float healvalue)
	{
		Hitpoints += healvalue;
		if (Hitpoints > HitpointMax)
			Hitpoints = HitpointMax;
	}

	public float GetHP()
	{
		return Hitpoints;
	}

	void Attack (GameObject Target)
	{
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag == EnemyTag) {
			//insert attacking here
			col.gameObject.GetComponent<AI>().TakeDamage (AttackDamage);
		}
	}
}
