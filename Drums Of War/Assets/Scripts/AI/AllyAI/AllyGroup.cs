using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllyGroup : MonoBehaviour {

	public Vector3 Theposition;
	float unitspacing = 0.5f;
	public List<AllyClass> Allies = new List<AllyClass>();
	public GameObject Unit;
	AllyClass.Unit_Type GroupType;
	public int Quantity;

	// Use this for initialization
	void Start () {
		Theposition.Set ( transform.position.x,transform.position.y, transform.position.z );
		transform.Translate (-transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int NumofUnits) {
		Quantity = NumofUnits;
		for (int i = 0; i < NumofUnits; i++) {
			GameObject tempunit = (GameObject)Instantiate(Unit, Theposition + (Vector3.left * i * unitspacing), gameObject.transform.rotation );
			tempunit.transform.parent = gameObject.transform;
			AllyClass tempscript = tempunit.GetComponent<AllyClass>();
			Allies.Add(tempscript);
		}
	}

	public void InitStats (AllyClass.Unit_Type Type, float Attack, float Speed, float Range, float Evasion, float HP)
	{
		GroupType = Type;
		foreach (AllyClass Ally in Allies) {
			Ally.GetComponent<AllyClass>().Set(Type, Attack, Speed, Range, Evasion, HP);
		}
	}

	public void SetAnimation (int i)
	{
		foreach (AllyClass Ally in Allies) {
			Ally.GetComponent<AllyClass>().SetWeaponAnim(i);
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

	public void ReceiveCommand (string Melee, string Range, Vector3 newposition)
	{
		if (
			(GroupType == AllyClass.Unit_Type.Type_Melee && Melee == "Advance")
		    || (GroupType == AllyClass.Unit_Type.Type_Range && Range == "Advance") 
			|| (GroupType == AllyClass.Unit_Type.Type_Mage && Range == "Advance") 
			) 
		{
			Theposition = newposition + Vector3.right * 2.0f;
		}
		if (
			(GroupType == AllyClass.Unit_Type.Type_Melee && Melee == "Retreat")
			|| (GroupType == AllyClass.Unit_Type.Type_Range && Range == "Retreat") 
			|| (GroupType == AllyClass.Unit_Type.Type_Mage && Range == "Retreat") 
			) 
		{
			Theposition = newposition + Vector3.left * 4.0f;
		}
		int i = 0;
		foreach (AllyClass Ally in Allies) {
			Ally.ReceiveCommand(Melee, Range, Theposition + (Vector3.left * i * unitspacing) );
			i++;
		}
	}

	public void DanceBeat (BeatScript thebeat)
	{
		int dancebeat = 0;
		switch (thebeat.GetBeatType()) 
		{
			case BeatScript.BeatType.Beat_Snare:
			{
				dancebeat = 1;
			}
			break;
			case BeatScript.BeatType.Beat_Tom:
			{
				dancebeat = 2;
			}
				break;
			case BeatScript.BeatType.Beat_Bass:
			{
				dancebeat = 4;
			}
				break;
			case BeatScript.BeatType.Beat_Hithat:
			{
				dancebeat = 3;
			}
				break;
			default:
				break;
		}

		foreach (AllyClass Ally in Allies)
		{
			Ally.GetComponent<Animator>().SetInteger ("DanceState", dancebeat);
		}
	}

	public void removeunit (AllyClass unit)
	{
		Allies.Remove (unit);
	}
}
