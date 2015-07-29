using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public AudioSource audioSwitch;
	public AudioSource audioSelect;
	public Canvas QuitMenu;
	public Button Play;
	public Button Exit;
	public GameObject menuArrow;
	public GameObject quitArrow;
	int menuCounter;
	int exitCounter;
	bool QuitMenubool;

	// Use this for initialization
	void Start () {
		QuitMenu = QuitMenu.GetComponent<Canvas>();
		Play = Play.GetComponent<Button>();
		Exit = Exit.GetComponent<Button> ();
		QuitMenu.enabled = false;	
		menuCounter = 1;
		exitCounter = 1;
		QuitMenubool = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)||(Input.GetAxis("Vertical")>0)) {
			if (QuitMenubool == false) {
				if (menuCounter != 1) {
					menuCounter--;
					audioSwitch.Play();
					//menuArrow.transform.Translate (0, 144, 0);
					menuArrow.transform.Translate (0, Screen.height*0.25f, 0);
				}
			}
			else
			{
				if(exitCounter != 1)
				{
					exitCounter--;
					audioSwitch.Play();
					quitArrow.transform.Translate (0,54,0);
				}
			}
		} 
		else if (Input.GetKeyDown (KeyCode.S)||(Input.GetAxis("Vertical")<0)) 
		{
			if (QuitMenubool == false)
			{
				if (menuCounter != 2) {
					menuCounter++;
					audioSwitch.Play();
					menuArrow.transform.Translate (0, -(Screen.height*0.25f), 0);
				}
			}
			else
			{
				if(exitCounter != 2)
				{
					exitCounter++;
					audioSwitch.Play();
					quitArrow.transform.Translate (0,-54,0);
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))//fire2 = circle
		{
			if(QuitMenubool == false)
			{
				if(menuCounter == 1)
				{
					audioSelect.Play();
					PlayPress();
				}
				else if(menuCounter == 2)
				{
					audioSelect.Play();
					ExitPress();
					QuitMenubool = true;
				}
				//else if(menuCounter == 2)
				//{
				//	LoadPress();
				//}
			}
			else
			{
				if(exitCounter == 1)
				{
					audioSelect.Play();
					YesPress();
				}
				else if(exitCounter == 2)
				{
					audioSelect.Play();
					NoPress();
					QuitMenubool = false;
				}
			}
		}
	}

	public void ExitPress()
	{
		QuitMenu.enabled = true;
		Play.enabled = false;
		Exit.enabled = false;
	}

	public void NoPress()
	{
		QuitMenu.enabled = false;
		Play.enabled = true;
		Exit.enabled = true;	
	}

	public void PlayPress()
	{
		Application.LoadLevel ("Camp Menu");
	}

	public void YesPress()
	{
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}
	public void LoadPress()
	{
		//load code here
	}
}
