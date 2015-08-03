using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldScript : MonoBehaviour {

	string StartText;

	// Use this for initialization
	void Start () {
		StartText = GetComponent<Text> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		int data = GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ().Currency;
		GetComponent<Text> ().text = StartText + data;
	}
}
