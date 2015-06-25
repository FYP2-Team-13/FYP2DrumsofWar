using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public float idNum;
	public string name;

	
	public float attackDamage;
	public float attackSpeed;
	public float Defense;
	public float Evasion;

	public float beingUsed;

	void Start () {
		idNum = 1;
		name = "";
		
		
		attackDamage = 1;
		attackSpeed = 1;
		Defense = 1;
		Evasion = 1;
		
		beingUsed = 0;
	}
}
