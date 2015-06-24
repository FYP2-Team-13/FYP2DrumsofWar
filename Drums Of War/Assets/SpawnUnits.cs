using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnUnits : MonoBehaviour {
	GroupSpawning theGroupSpawn;
	public GameObject ObjectThatHoldsGroupSpawn;
	List<Transform> thePositions = new List<Transform>();

	// Use this for initialization
	void Start () {
		theGroupSpawn = ObjectThatHoldsGroupSpawn.GetComponent<GroupSpawning> ();
		for (int i = 0; i < this.transform.childCount; i++) {
			thePositions.Add(this.transform.GetChild(i));
		}
		for (int i = 0; i < thePositions.Count; i++) {
			theGroupSpawn.createGroup(5,5,thePositions[i].position);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
