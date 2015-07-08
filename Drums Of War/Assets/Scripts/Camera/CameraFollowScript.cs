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
					if (Ally.transform.position.x > furthestdistance) {
						furthestdistance = Ally.transform.position.x;
					}
				}
			
				if (transform.position.x - furthestdistance < distance - 0.5) {
					gameObject.transform.Translate (Vector3.right * Time.deltaTime);
				} else if (transform.position.x - furthestdistance > distance + 0.5) {
					gameObject.transform.Translate (Vector3.left * Time.deltaTime);
				}
			}
		}
	}
}
