using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour {

	public ArmyStats TheArmysStats;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RecruitUnit ()
	{
		TheArmysStats.RecruitUnit ();
	}
}
