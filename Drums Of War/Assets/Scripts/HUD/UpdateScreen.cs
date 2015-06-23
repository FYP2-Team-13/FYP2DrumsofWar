using UnityEngine;
using System.Collections;

public class UpdateScreen : MonoBehaviour {

	public float XPercent, YPercent, XSizePercent, YSize;
	bool rescaled = false;
	public bool fromRight;

	public bool background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print (Screen.width);
		if (!rescaled)
		{
			if (!fromRight)
			GetComponent<GUITexture>().pixelInset =  new Rect ( Screen.width * XPercent, Screen.height * YPercent,
		                                 Screen.width * XSizePercent, GetComponent<GUITexture>().pixelInset.height * YSize);
			else
				GetComponent<GUITexture>().pixelInset =  new Rect 
					( Screen.width - Screen.width * XSizePercent - Screen.width * XPercent, 
					 Screen.height * YPercent, Screen.width * XSizePercent, 
					 GetComponent<GUITexture>().pixelInset.height * YSize);

			if (background)
			{
				GetComponent<GUITexture>().pixelInset = new Rect (0, 0,  Screen.width, Screen.height);
			}

			rescaled = true;
		}
		//guiTexture.
	}
}
