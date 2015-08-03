using UnityEngine;
using System.Collections;

public class levelselectorscript : MonoBehaviour {

	public AudioSource audioSwitch;
	public AudioSource audioSelect;
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
		if (Input.GetKeyDown (KeyCode.A)||(Input.GetAxis("Horizontal")<0)) 
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
		else if (Input.GetKeyDown (KeyCode.S)||(Input.GetAxis("Vertical")<0))
		{
			if(menuCounter < 9)
			{
				menuCounter = menuCounter + 8;
				moveDown();
			}
		}
		else if (Input.GetKeyDown (KeyCode.D)||(Input.GetAxis("Horizontal")>0))
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
		else if (Input.GetKeyDown (KeyCode.W)||(Input.GetAxis("Vertical")>0))
		{
			if(menuCounter > 8)
			{
				menuCounter = menuCounter - 8;
				moveUp();
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space)||(Input.GetButtonDown("Fire2")))
		{
			Select();
		}
	}

	void moveDown()
	{
		audioSwitch.Play();
		arrow.transform.localScale = Down;
	}

	void moveUp()
	{
		audioSwitch.Play();
		arrow.transform.localScale = Up;
	}

	void moveLeft()
	{
		audioSwitch.Play();
		arrow.transform.Translate (-(Screen.width*0.1075f), 0, 0);
	}

	void moveRight()
	{
		audioSwitch.Play();
		arrow.transform.Translate (Screen.width*0.1075f, 0, 0);
	}

	void moveToEight()
	{
		audioSwitch.Play();
		arrow.transform.localScale = Up;
		arrow.transform.Translate (Screen.width*0.7535f, 0, 0);
	}

	void moveToNine()
	{
		audioSwitch.Play();
		arrow.transform.localScale = Down;
		arrow.transform.Translate (-(Screen.width*0.7535f), 0, 0);
	}

	void Select()
	{
		audioSelect.Play ();
		int level = GameObject.FindGameObjectWithTag ("Database").GetComponent<Inventory> ().nextlevel;
		if (menuCounter <= level) {
			if (menuCounter == 1) {
				Application.LoadLevel ("Level1");
			} else if (menuCounter == 2) {
				Application.LoadLevel ("Level2");
			} else if (menuCounter == 3) {
				Application.LoadLevel ("Level3");
			} else if (menuCounter == 4) {
				Application.LoadLevel ("Level4");
			} else if (menuCounter == 5) {
				Application.LoadLevel ("Level5");
			} else if (menuCounter == 6) {
				Application.LoadLevel ("Level6");
			} else if (menuCounter == 7) {
				Application.LoadLevel ("Level7");
			} else if (menuCounter == 8) {
				Application.LoadLevel ("Level8");
			} else if (menuCounter == 9) {
				Application.LoadLevel ("Level9");
			} else if (menuCounter == 10) {
				Application.LoadLevel ("Level10");
			} else if (menuCounter == 11) {
				Application.LoadLevel ("Level11");
			} else if (menuCounter == 12) {
				Application.LoadLevel ("Level12");
			} else if (menuCounter == 13) {
				Application.LoadLevel ("Level13");
			} else if (menuCounter == 14) {
				Application.LoadLevel ("Level14");
			} else if (menuCounter == 15) {
				Application.LoadLevel ("Level15");
			}
		}
		else if (menuCounter == 16) {
			Application.LoadLevel("Camp Menu");
		}
	}
}
