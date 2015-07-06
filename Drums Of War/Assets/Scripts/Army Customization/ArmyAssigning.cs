using UnityEngine;
using System.Collections;

public class ArmyAssigning : MonoBehaviour {

	ConsistentArmy TheArmy;

	// Use this for initialization
	void Start () {
		TheArmy = GameObject.FindGameObjectWithTag ("Database").GetComponent<ConsistentArmy> ();
		GameObject[]temp = GameObject.FindGameObjectsWithTag ("AllyGroup");

		for (int i = 0; i < temp.Length; i++)
			temp[i].GetComponent<Equipment>().TheArmysStats = TheArmy.TheArmy [i];
	}
}
