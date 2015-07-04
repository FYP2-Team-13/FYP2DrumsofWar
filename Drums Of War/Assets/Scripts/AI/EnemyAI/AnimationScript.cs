using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	AI TheAI;
	Animator TheAnimator;

	// Use this for initialization
	void Start () {
		TheAI = gameObject.transform.parent.gameObject.GetComponent<AI> ();
		TheAnimator = GetComponent<Animator> ();

		if (gameObject.transform.parent.gameObject.GetComponent<Melee> ()) {//it's a melee unit
			TheAnimator.SetInteger ("WeaponType", 0);
		} else {
			TheAnimator.SetInteger("WeaponType",1);
		}

	}
	
	// Update is called once per frame
	void Update () {
		switch (TheAI.state) {
		case AI.AI_ENEMY_State.Enemy_Idle:
		{
			TheAnimator.SetInteger("State", 0);
		}
			break;
		case AI.AI_ENEMY_State.Enemy_Forward:
		{
			TheAnimator.SetInteger("State", 1);
		}
			break;
		case AI.AI_ENEMY_State.Enemy_Attack:
		{
			TheAnimator.SetInteger("State", 2);
		}
			break;
		case AI.AI_ENEMY_State.Enemy_Dead:
		{
			TheAnimator.SetBool("Dead", true);
		}
			break;
		default:
			break;
		}
	}
}
