using UnityEngine;
using System.Collections;

public class GroupSpawning : MonoBehaviour {

	private GameObject Melee;
	private GameObject Mid;
	private GameObject Range;

	float spacing = 1.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void createGroup (float meleeAmnt, float midAmnt, float rangeAmnt,
	                         Vector3 pos)
	{
		float total = meleeAmnt + midAmnt + rangeAmnt;

		for (int me = 0; me < meleeAmnt; me++) {
			Vector3 tempPos = pos;
			tempPos.x -= ((total - 1)/2 - me) * spacing;
			Instantiate(Melee, tempPos, Quaternion.identity);
		}
		for (int mi = 0; mi < midAmnt; mi++) {
			Vector3 tempPos = pos;
			tempPos.x -= ((midAmnt - 1)/2 - mi) * spacing;
			Instantiate(Mid, tempPos, Quaternion.identity);
		}
		for (int ra = 0; ra < rangeAmnt; ra++) {
			Vector3 tempPos = pos;
			tempPos.x += ((total - 1)/2 - ra) * spacing;
			Instantiate(Range, tempPos, Quaternion.identity);
		}
	}
}