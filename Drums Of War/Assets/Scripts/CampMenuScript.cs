using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CampMenuScript : MonoBehaviour {

	//public Button left;
	//public Button right;
	//public Button enter;
	public GameObject MenuSelector;

	private int menuCounter;
	private int movingstate;
	Animator anim;

	Vector3 Left = new Vector3(-1,1,1);
	Vector3 Right = new Vector3(1,1,1);

	// Use this for initialization
	void Start () {
		//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
		menuCounter = 0;
		movingstate = 0;
		// = left.GetComponent<Button>();
		//right = right.GetComponent<Button>();
		//enter = enter.GetComponent<Button>();
		anim = MenuSelector.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movingstate == 1) {//moving left
			MenuSelector.transform.Translate (-Time.deltaTime * 15, 0, 0);
			MenuSelector.transform.localScale = Left;
			if (MenuSelector.transform.position.x <= (40 + (menuCounter * 15))) {
				//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
				movingstate = 0;
				anim.SetInteger ("State", 0);
			}
		} else if (movingstate == 2) {//moving right
			MenuSelector.transform.Translate (Time.deltaTime * 15, 0, 0);
			MenuSelector.transform.localScale = Right;
			if (MenuSelector.transform.position.x >= (40 + (menuCounter * 15))) {
				//MenuSelector.transform.Translate( 40 + menuCounter * 15,0,0);
				movingstate = 0;
				anim.SetInteger ("State", 0);
			}
		}

		if (movingstate == 0)
		{
			if (Input.GetKeyDown (KeyCode.A)||(Input.GetAxis("Horizontal")<0)) {
				GoLeft ();
			}
			if (Input.GetKeyDown (KeyCode.D)||(Input.GetAxis("Horizontal")>0)) {
				GoRight ();
			}
			if (Input.GetKeyDown (KeyCode.Space) || (Input.GetButtonDown("Fire2"))) {
				Enter ();
			}
			if (Input.GetKeyDown (KeyCode.Backspace)||(Input.GetButtonDown("Fire1"))) {
				Back ();
			}
		}
	}

	public void GoLeft()
	{

		if (menuCounter > 0) {
			anim.SetInteger("State",1);
			menuCounter --;
			movingstate = 1;
		}
	}

	public void GoRight()
	{

		if (menuCounter < 3) {
			anim.SetInteger("State",1);
			menuCounter++;
			movingstate = 2;
		}
	}

	public void Enter()
	{
		//if (menuCounter == 0) {
		//	Application.LoadLevel("Camp Screen");
		//}
		if (menuCounter == 1) {
			Application.LoadLevel("armory screen");
		}
		else if (menuCounter == 2) {
			Application.LoadLevel("army customize screen");
		}
		else if (menuCounter == 3) {
			Application.LoadLevel("level selection");
		}
	}

	void Back()
	{
		Application.LoadLevel("Main Menu");
	}
}
