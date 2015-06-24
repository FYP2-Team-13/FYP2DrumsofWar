using UnityEngine;
using System.Collections;

public class ReachEndPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D col )
	{
		if (col.transform.tag == "Ally") {
			transform.tag = "Finish";
			GameObject.FindGameObjectWithTag("InputHandler").GetComponent<InputHandler>().PlayEnding(true);
		}
	}
}
