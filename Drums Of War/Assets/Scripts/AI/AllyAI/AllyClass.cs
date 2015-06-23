﻿using UnityEngine;
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
	public Unit_Type Type = Unit_Type.Type_Range;
	Animator TheAnimator;

	//Stats
	float Hitpoints = 100, HitpointMax = 100;

	//Attack
	float AttackRange = 10.0f,
	AttackSpeed = 0.75f,
	AttackDamage = 10,
	LastAttack;

	//Defense
	float Defense = 1.0f,
	Evasion = 5;

	//End of Stats

	float MoveSpeed = 1.00f;
	float Vision = 15;

	float PrevTime;// = Time.time;

	GameObject Target;
	public string EnemyTag;

	//variables for Firing Arrow
	public GameObject Arrow;

	// Use this for initialization
	void Start () {
		PrevTime = Time.time;
		LastAttack = 0.0f;
		TheAnimator = GetComponent<Animator> ();
		if (Type == Unit_Type.Type_Range)
			TheAnimator.SetInteger ("WeaponType", 1);
	}

	public void Set (Unit_Type Type, float Attack, float Speed, float Range, float Defense, float Evasion, float HP)
	{
		this.Type = Type;
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
					if (CheckAttackRange() ) // Can I hit it?
					{
						Attack();
					} else { // What can I do if I can't hit it?
						CalculateMoveSpeed (Target.transform.position);
						gameObject.transform.Translate (Vector3.right * MoveSpeed * 2.0f * Time.deltaTime) ;
					}
				}
			}
			break;
		case AI_Ally_State.Ally_Retreat: {
			gameObject.transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime) ;
			}
			break;
		default:
			break;
		}
	}

	public void ReceiveCommand (string Melee, string Range, Vector3 position)
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
					CalculateMoveSpeed (position);
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
					CalculateMoveSpeed (position);
				}
				break;
			default:
				AIState = AI_Ally_State.Ally_Idle;
				TheAnimator.SetInteger("State", 0);
				break;
			}
			if (AIState != AI_Ally_State.Ally_Idle)
				TheAnimator.SetInteger("State", 1);
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
			Hitpoints -= (damage - Defense) * (AIState == AI_Ally_State.Ally_Defend? 0.5f: 1);
			if (Hitpoints < 1)
			{
				AIState = AI_Ally_State.Ally_Dead;
				gameObject.transform.parent.gameObject.GetComponent<AllyGroup>().UnitDied();
				gameObject.transform.tag = "Finish";
			}
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

	void Attack ()
	{
		if (CheckAttackRange ()) {
			if (Type == Unit_Type.Type_Melee) {//Melee Attacks
				DoAttackMelee(Target, AttackDamage * (AIState == AI_Ally_State.Ally_Attack? 1.0f: 0.7f) );
			} 
			else if (Type == Unit_Type.Type_Range) { // Range Attacks
				DoAttackRange();
			}
		}
	}

	void DoAttackRange ()
	{
		if (CheckLastAttack ()) {
			GameObject temparrow = (GameObject)Instantiate (Arrow, transform.position + ((Vector3.right + Vector3.up) * 1.5f), transform.rotation);
			temparrow.gameObject.tag = gameObject.tag + "Arrow";
			temparrow.gameObject.layer = gameObject.layer;
			ArrowAngleScript tempscript = temparrow.GetComponent<ArrowAngleScript> ();
			tempscript.CalculateAngle (Target.transform, AttackRange * 2, AttackDamage, EnemyTag);
			TheAnimator.SetInteger("State", 2);
		}
	}

	void DoAttackMelee (GameObject target, float damage)
	{
		if (CheckLastAttack() ) {
			target.GetComponent<AI>().TakeDamage (damage);
			TheAnimator.SetInteger ("State", 2);
			//print ("Attack");
		}
	}

	bool CheckLastAttack()	{
		//print (Time.time);
		//print (LastAttack);
		if (Time.time - LastAttack > AttackSpeed) {// Check if the attack delay has passed
			LastAttack = Time.time; // Reset Time
			return true;
		}
		return false;
	}

	bool CheckAttackRange()
	{
		//print (Target.transform.position);
		//print (transform.position);
		if ((Target.transform.position.x - transform.position.x) < AttackRange)
			//print ("attack!");
			return true;
		return false;
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag == gameObject.tag) {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.collider);
			return;
		}
	}

	public void CalculateMoveSpeed (Vector3 destination) {
		float distance = destination.x - transform.position.x;
		MoveSpeed = distance / 2.0f;
	}
}
