using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public float distance;
	public bool Following = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Following) {
			GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Ally");
			float furthestdistance = 0;
			if (nodes.Length > 0) {
				foreach (GameObject Ally in nodes) {
					if (transform.position.x - Ally.gameObject.transform.position.x > furthestdistance) {
						furthestdistance = transform.position.x - Ally.gameObject.transform.position.x;
					}
				}
			
				if (furthestdistance < distance - 0.5) {
					gameObject.transform.Translate (Vector3.right * Time.deltaTime);
				} else if (furthestdistance > distance + 0.5) {
					gameObject.transform.Translate (Vector3.left * Time.deltaTime);
				}
			}
		}
	}
}
