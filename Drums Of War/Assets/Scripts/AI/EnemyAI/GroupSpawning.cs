using UnityEngine;
using System.Collections;

public class GroupSpawning : MonoBehaviour {

	public GameObject Melee;
	public GameObject Range;

	float spacing = 1.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void createGroup (float meleeAmnt, float rangeAmnt,
	                         Vector3 pos)
	{
		float total = meleeAmnt + rangeAmnt;

		for (int me = 0; me < meleeAmnt; me++) {
			Vector3 tempPos = pos;
			tempPos.x -= ((total - 1)/2 - me) * spacing;
			Instantiate(Melee, tempPos, Quaternion.identity);
		}
		for (int ra = 0; ra < rangeAmnt; ra++) {
			Vector3 tempPos = pos;
			tempPos.x += ((total - 1)/2 - ra) * spacing;
			Instantiate(Range, tempPos, Quaternion.identity);
		}
	}
}