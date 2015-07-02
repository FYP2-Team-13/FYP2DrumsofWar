using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorCustomizationScript : MonoBehaviour {

	public GameObject RedObject, BlueObject, GreenObject;
	ConsistentArmy ArmyForceDatabase;

	Slider RedSlider, BlueSlider, GreenSlider;
	Color CurrentColor;
	List<GameObject> AllUnits = new List<GameObject>();
	public GameObject OriginalColor;

	public int CurrentBody = 0;

	// Use this for initialization
	void Start () {
		GameObject[] TempAllUnits = GameObject.FindGameObjectsWithTag ("Ally");
		for (int i = 0; i < TempAllUnits.Length; i ++) {
			if (TempAllUnits[i] != OriginalColor)
				AllUnits.Add(TempAllUnits[i]);
			else
				OriginalColor = TempAllUnits[i];
		}

		RedSlider = RedObject.GetComponent<Slider> ();
		BlueSlider = BlueObject.GetComponent<Slider> ();
		GreenSlider = GreenObject.GetComponent<Slider> ();

		ArmyForceDatabase = GameObject.FindGameObjectWithTag ("Database").GetComponent<ConsistentArmy> ();
	}
	
	// Update is called once per frame
	void Update () {
		CurrentColor = new Color (RedSlider.value, BlueSlider.value, GreenSlider.value);
		foreach (GameObject Unit in AllUnits) {
			Unit.transform.Find("Body_Origin").gameObject.GetComponent<SpriteRenderer>().color = CurrentColor;
			Unit.transform.Find("Body_Origin").gameObject.GetComponent<SpriteRenderer>().sprite = ArmyForceDatabase.GetSprite(CurrentBody);
			Unit.transform.Find("Body_FrontHand").gameObject.GetComponent<SpriteRenderer>().color = CurrentColor;
			Unit.transform.Find("Body_BackHand").gameObject.GetComponent<SpriteRenderer>().color = CurrentColor;
			Unit.transform.Find("Body_FrontLeg").gameObject.GetComponent<SpriteRenderer>().color = CurrentColor;
			Unit.transform.Find("Body_BackLeg").gameObject.GetComponent<SpriteRenderer>().color = CurrentColor;
		}
	}

	public void Comfirm ()
	{
		ArmyForceDatabase.SetArmyColor (CurrentColor);
		ArmyForceDatabase.SetSprite (ArmyForceDatabase.GetSprite (CurrentBody));
		//print (ArmyForceDatabase.ArmyColor);
	}

	public void Revert ()
	{
	}

	public void NextBody()
	{
		CurrentBody ++;
		if (CurrentBody >= ArmyForceDatabase.SpriteDatabase.Count ) {
			CurrentBody -= ArmyForceDatabase.SpriteDatabase.Count;
		}
	}

	public void PrevBody()
	{
		CurrentBody--;
		if (CurrentBody < 0) {
			CurrentBody += ArmyForceDatabase.SpriteDatabase.Count;
		}
	}

	public void PurchaseUnit (int Index)
	{
		if (ArmyForceDatabase.TheArmy [Index].RecruitUnit ())//Add in money here 
		{
			//Recruiting Successful
		} else {
			//Recruiting Failed
		}
	}
}
