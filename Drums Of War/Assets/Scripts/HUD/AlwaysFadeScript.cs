using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlwaysFadeScript : MonoBehaviour {

	Image TheImage;
	public float duration;
	float startTime;
	bool In = true;

	// Use this for initialization
	void Start () {
		TheImage = GetComponent<Image> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
			float t = (Time.time - startTime) / duration;
		if (In) {
			TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b,Mathf.SmoothStep(0.0f, 1.0f, t));

		} else {
			TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b,Mathf.SmoothStep(1.0f, 0.0f, t));

		}
		if (TheImage.color.a == 1.0f)
		{
			In = false;
			startTime = Time.time;
		}else if (TheImage.color.a == 0.0f)
		{
			In = true;
			startTime = Time.time;
		}
	}
}
