using UnityEngine;
using System.Collections;

public class SpawnObjectHere : MonoBehaviour {

	public int AmountOfRange;
	public int AmountOfMelee;
	public GroupSpawning theSpawner;

	void Start()
	{
		theSpawner.createGroup (AmountOfMelee, AmountOfRange, this.transform.position);
	}
}
