using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CampMenuScript : MonoBehaviour {

	public Button left;
	public Button right;
	public Button enter;
	public GameObject MenuSelector;

	private int menuCounter;
	private int movingstate;

	// Use this for initialization
	void Start () {
		//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
		menuCounter = 0;
		movingstate = 0;
		left = left.GetComponent<Button>();
		right = right.GetComponent<Button>();
		enter = enter.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if(movingstate == 1)//moving left
		{
			MenuSelector.transform.Translate(-Time.deltaTime * 15,0,0);
			if(MenuSelector.transform.position.x <= (40 + (menuCounter * 15)))
			{
				//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
				movingstate = 0;
			}
		}
		else if(movingstate == 2)//moving right
		{
			MenuSelector.transform.Translate(Time.deltaTime * 15,0,0);
			if(MenuSelector.transform.position.x >= (40 + (menuCounter * 15)))
			{
				//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
				movingstate = 0;
			}
		}

	}

	public void GoLeft()
	{

		if (menuCounter > 0) {
			menuCounter --;
			movingstate = 1;
		}
	}

	public void GoRight()
	{

		if (menuCounter < 3) {
			menuCounter++;
			movingstate = 2;
		}
	}

	public void Enter()
	{
		if (menuCounter == 0) {
			Application.LoadLevel("Camp Screen");
		}
		else if (menuCounter == 1) {
			Application.LoadLevel("armory screen");
		}
		else if (menuCounter == 2) {
			Application.LoadLevel("army customize screen");
		}
		else if (menuCounter == 3) {
			Application.LoadLevel("level selection");
		}
	}
}
