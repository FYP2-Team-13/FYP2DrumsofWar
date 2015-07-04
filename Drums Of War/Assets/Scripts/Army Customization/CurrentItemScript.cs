using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentItemScript : MonoBehaviour {
	
	string StartText;

	// Use this for initialization
	void Start () {
		StartText = GetComponent<Text> ().text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateItem (string name)
	{
		GetComponent<Text> ().text = StartText + name;
	}
}
