using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public bool isActive;
	CanvasGroup Menu;
	
	bool keydown = false;

	// Use this for initialization
	void Start () {
		Menu = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			Menu.blocksRaycasts = Menu.interactable = true;
			Menu.alpha = 1;
		} else {
		Menu.blocksRaycasts = Menu.interactable = false;
		Menu.alpha = 0;
		}

		if (Input.GetKeyDown (KeyCode.Escape) && !keydown) {
			keydown = true;
			isActive = !isActive;
		}
		if (!Input.GetKeyDown (KeyCode.Escape)) {
			keydown = false;
		}
	}

	public void Resume ()
	{
		isActive = false;
	}

	public void Exit ()
	{
		Application.LoadLevel ("Camp Menu");
	}
}
