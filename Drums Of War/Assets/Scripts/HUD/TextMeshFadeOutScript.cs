using UnityEngine;
using System.Collections;

public class TextMeshFadeOutScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector3.up * Time.deltaTime);
	}
}
