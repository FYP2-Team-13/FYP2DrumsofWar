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

		ConsistentArmy ArmyCustomization = GameObject.FindGameObjectWithTag ("Database").GetComponent<ConsistentArmy> ();
		if (ArmyCustomization != null) {
			Color ArmyColor = ArmyCustomization.GetArmyColor();
			Color EnemyColor = new Color (1f - ArmyColor.r, 1f - ArmyColor.g, 1f - ArmyColor.b); 

			int spriteindex = ArmyCustomization.SpriteDatabase.IndexOf(ArmyCustomization.GetCurrentBodySprite() );
			spriteindex += ArmyCustomization.SpriteDatabase.Count/2;
			if (spriteindex >= ArmyCustomization.SpriteDatabase.Count)
			{
				spriteindex -= ArmyCustomization.SpriteDatabase.Count;
			}

			gameObject.transform.Find("Body_Origin").gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;
			gameObject.transform.Find("Body_Origin").gameObject.GetComponent<SpriteRenderer>().sprite = ArmyCustomization.SpriteDatabase[spriteindex];
			gameObject.transform.Find("Body_FrontHand").gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;
			gameObject.transform.Find("Body_BackHand").gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;
			gameObject.transform.Find("Body_FrontLeg").gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;
			gameObject.transform.Find("Body_BackLeg").gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;
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
