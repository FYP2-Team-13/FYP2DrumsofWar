using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

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
		if (Input.GetKeyDown (KeyCode.W)) {
			if (QuitMenubool == false) {
				if (menuCounter != 1) {
					menuCounter--;
					menuArrow.transform.Translate (0, 72, 0);
				}
			}
			else
			{
				if(exitCounter != 1)
				{
					exitCounter--;
					quitArrow.transform.Translate (0,54,0);
				}
			}
		} 
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (QuitMenubool == false)
			{
				if (menuCounter != 2) {
					menuCounter++;
					menuArrow.transform.Translate (0, -72, 0);
				}
			}
			else
			{
				if(exitCounter != 2)
				{
					exitCounter++;
					quitArrow.transform.Translate (0,-54,0);
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) )//|| Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if(QuitMenubool == false)
			{
				if(menuCounter == 1)
				{
					PlayPress();
				}
				else if(menuCounter == 2)
				{
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
					YesPress();
				}
				else if(exitCounter == 2)
				{
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
