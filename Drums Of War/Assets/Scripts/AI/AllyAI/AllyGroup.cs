using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllyGroup : MonoBehaviour {

	public List<AllyClass> Allies = new List<AllyClass>();
	public GameObject Unit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int NumofUnits, AllyClass.Unit_Type Type, float Attack, float Speed, float Range, float Defense, float Evasion, float HP) {
		for (int i = 0; i < NumofUnits; i++) {
			GameObject tempunit = (GameObject)Instantiate(Unit, gameObject.transform.position + (Vector3.right * i * 1.2f), gameObject.transform.rotation );
			tempunit.transform.parent = gameObject.transform;
			AllyClass tempscript = tempunit.GetComponent<AllyClass>();
			tempscript.Set(Type, Attack, Speed, Range, Defense, Evasion, HP);
			Allies.Add(tempscript);
		}
	}

	public void ReceiveCommand (string Melee, string Range)
	{
		foreach (AllyClass Ally in Allies) {
			Ally.ReceiveCommand(Melee, Range);
		}
	}
}
