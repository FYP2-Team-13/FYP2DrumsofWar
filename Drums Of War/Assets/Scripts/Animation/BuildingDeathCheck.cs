using UnityEngine;
using System.Collections;

public class BuildingDeathCheck : MonoBehaviour {

	bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (gameObject.transform.parent.GetComponent<AI>().state == AI.AI_ENEMY_State.Enemy_Dead)
			{
				isDead = true;
				gameObject.GetComponent<Animator>().SetBool ("IsDead", true);
			}
		}
	}
}
