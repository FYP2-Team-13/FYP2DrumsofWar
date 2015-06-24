using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FaderScripte : MonoBehaviour {

	public bool Fade; //true for in, false for out
	float minimum = 0.0f;
	float maximum = 1;
	public float duration = 1.0f;
	float startTime;
	Image sprite;

	// Use this for initialization
	void Start () {
		Fade = false;
		sprite = GetComponent<Image> ();
		//TheSprite.color = new Color (1, 1, 1, 0);
	}

	public void StartFade ()
	{
		Fade = true;
		startTime = Time.time;
		sprite.color = new Color (1, 1, 1, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Fade) {
			float t = (Time.time - startTime) / duration;
			sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t));
			//Fade = false;
		}
		if (Fade && sprite.color.a == maximum) {
			//load main menu
		}
	}
}
