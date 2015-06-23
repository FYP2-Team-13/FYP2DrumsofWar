using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllyGroup : MonoBehaviour {

	public Vector3 position;
	float unitspacing = 0.5f;
	public List<AllyClass> Allies = new List<AllyClass>();
	public GameObject Unit;
	AllyClass.Unit_Type GroupType;
	int Quantity;

	// Use this for initialization
	void Start () {
		position = transform.position;
		transform.Translate (-transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int NumofUnits, AllyClass.Unit_Type Type, float Attack, float Speed, float Range, float Defense, float Evasion, float HP) {
		Quantity = NumofUnits;
		GroupType = Type;
		for (int i = 0; i < NumofUnits; i++) {
			GameObject tempunit = (GameObject)Instantiate(Unit, position + (Vector3.left * i * unitspacing), gameObject.transform.rotation );
			tempunit.transform.parent = gameObject.transform;
			AllyClass tempscript = tempunit.GetComponent<AllyClass>();
			tempscript.Set(Type, Attack, Speed, Range, Defense, Evasion, HP);
			Allies.Add(tempscript);
		}
	}

	public int GetQuantity ()
	{
		return Quantity;
	}

	public void UnitDied ()
	{
		Quantity -= 1;
		GameObject.FindGameObjectWithTag ("InputHandler").GetComponent<InputHandler> ().CheckDefeat ();
	}

	public void ReceiveCommand (string Melee, string Range)
	{
		if (
			(GroupType == AllyClass.Unit_Type.Type_Melee && Melee == "Advance")
		    || (GroupType == AllyClass.Unit_Type.Type_Range && Range == "Advance") 
		    ) 
		{
			position += Vector3.right * 2.0f;
		}
		if (
			(GroupType == AllyClass.Unit_Type.Type_Melee && Melee == "Retreat")
			|| (GroupType == AllyClass.Unit_Type.Type_Range && Range == "Retreat") 
			) 
		{
			position += Vector3.left * 4.0f;
		}
		int i = 0;
		foreach (AllyClass Ally in Allies) {
			Ally.ReceiveCommand(Melee, Range, position + (Vector3.left * i * unitspacing) );
			i++;
		}
	}

	public void removeunit (AllyClass unit)
	{
		Allies.Remove (unit);
	}
}
