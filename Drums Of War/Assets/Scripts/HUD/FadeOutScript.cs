﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutScript : MonoBehaviour {
	//As long as the item's alpha still exist, reduce the item's alpha
	Image TheImage;
	Text TheText;
	RectTransform TheRect;
	public float duration;
	float startTime;

	// Use this for initialization
	void Start () {
		TheImage = GetComponent<Image> ();
		TheText = GetComponent<Text> ();
		TheRect = GetComponent<RectTransform> ();
	}

	public void ResetFade (bool VerticalChange)
	{
		print (TheRect.position.y);
		startTime = Time.time;
		if (VerticalChange) {
			TheRect.position = new Vector3 (TheRect.position.x, Random.Range (30, 329), TheRect.position.z);
		} else {
			TheRect.position = new Vector3 (Random.Range (75, 563), TheRect.position.y, TheRect.position.z);
		}
		if (TheText != null) {
			TheText.color = new Color (TheText.color.r, TheText.color.g, TheText.color.b, 1.0f);
		}
		if (TheImage != null) {
			TheImage.color = new Color (TheImage.color.r, TheImage.color.g, TheImage.color.b, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (TheText != null) {
			if (TheText.color.a > 0) {
				float t = (Time.time - startTime) / duration;
				TheText.color = new Color(TheText.color.r, TheText.color.g, TheText.color.b,Mathf.SmoothStep(1.0f, 0.0f, t));
			}
		}
		if (TheImage != null) {
			float t = (Time.time - startTime) / duration;
			TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b,Mathf.SmoothStep(1.0f, 0.0f, t));
		}
	}
}