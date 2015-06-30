using UnityEngine;
using System.Collections;

public class DatabaseMultiInstancePrevention : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] AllDatabase = GameObject.FindGameObjectsWithTag (tag);
		if (AllDatabase.Length > 1)
			Destroy (gameObject);
		else 
			DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
