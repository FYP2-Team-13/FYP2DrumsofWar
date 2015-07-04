using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentNumberScript : MonoBehaviour {

	string StartText;
	
	// Use this for initialization
	void Start () {
		StartText = GetComponent<Text> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
