using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas QuitMenu;
	public Button Play;
	public Button Exit;
	public GameObject arrow;
	int menuCounter;

	// Use this for initialization
	void Start () {
		QuitMenu = QuitMenu.GetComponent<Canvas>();
		Play = Play.GetComponent<Button>();
		Exit = Exit.GetComponent<Button> ();
		QuitMenu.enabled = false;	
		menuCounter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			if(menuCounter != 1)
			{
				menuCounter--;
				arrow.transform.Translate(77,0,0);
			}
		}
		else if (Input.GetKeyDown (KeyCode.S)) {
			if(menuCounter != 2)
			{
				menuCounter++;
				arrow.transform.Translate(-77,0,0);
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
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}
}
