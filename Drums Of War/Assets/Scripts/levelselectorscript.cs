using UnityEngine;
using System.Collections;

public class levelselectorscript : MonoBehaviour {

	public GameObject arrow;
	int menuCounter;
	Vector3 Up = new Vector3(1,1,1);
	Vector3 Down = new Vector3(1,-1,1);

	// Use this for initialization
	void Start () {
		menuCounter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			if(menuCounter > 1)
			{

				if(menuCounter != 9)
					moveLeft();
				else
				{
					moveToEight();
				}
				menuCounter--;
			}
		}
		else if (Input.GetKeyDown (KeyCode.S))
		{
			if(menuCounter < 9)
			{
				menuCounter = menuCounter + 8;
				moveDown();
			}
		}
		else if (Input.GetKeyDown (KeyCode.D))
		{
			if(menuCounter < 16)
			{

				if(menuCounter != 8)
					moveRight();
				else
					moveToNine();
				menuCounter++;
			}
		} 
		else if (Input.GetKeyDown (KeyCode.W))
		{
			if(menuCounter > 8)
			{
				menuCounter = menuCounter - 8;
				moveUp();
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			Select();
		}
	}

	void moveDown()
	{
		arrow.transform.localScale = Down;
	}

	void moveUp()
	{
		arrow.transform.localScale = Up;
	}

	void moveLeft()
	{
		arrow.transform.Translate (-145, 0, 0);
	}

	void moveRight()
	{
		arrow.transform.Translate (145, 0, 0);
	}

	void moveToEight()
	{
		arrow.transform.localScale = Up;
		arrow.transform.Translate (1015, 0, 0);
	}

	void moveToNine()
	{
		arrow.transform.localScale = Down;
		arrow.transform.Translate (-1015, 0, 0);
	}

	void Select()
	{
		if (menuCounter == 1) {
			Application.LoadLevel("Level1");
		}
		else if (menuCounter == 2) {
			Application.LoadLevel("Level2");
		}
		else if (menuCounter == 3) {
			Application.LoadLevel("Level3");
		}
		else if (menuCounter == 4) {
			Application.LoadLevel("Level4");
		}
		else if (menuCounter == 5) {
			Application.LoadLevel("Level5");
		}
		else if (menuCounter == 6) {
			Application.LoadLevel("Level6");
		}
		else if (menuCounter == 7) {
			Application.LoadLevel("Level7");
		}
		else if (menuCounter == 8) {
			Application.LoadLevel("Level8");
		}
		else if (menuCounter == 9) {
			Application.LoadLevel("Level9");
		}
		else if (menuCounter == 10) {
			Application.LoadLevel("Level10");
		}
		else if (menuCounter == 11) {
			Application.LoadLevel("Level11");
		}
		else if (menuCounter == 12) {
			Application.LoadLevel("Level12");
		}
		else if (menuCounter == 13) {
			Application.LoadLevel("Level13");
		}
		else if (menuCounter == 14) {
			Application.LoadLevel("Level14");
		}
		else if (menuCounter == 15) {
			Application.LoadLevel("Level15");
		}
		else if (menuCounter == 16) {
			Application.LoadLevel("Camp Menu");
		}
	}
}
