using UnityEngine;
using System.Collections;

public class TimeScript : MonoBehaviour {

	BeatScript TheBeat = new BeatScript();
	float time = 0.0f;
	public GameObject Beat;
	bool keydown = false;
	public GameObject TheInputHandler;
	InputHandler TheInputScript;
	public GameObject DrumSFX;

	public GameObject Canvas;
	//public GameObject[] VFX;
	//public GameObject DebugText;
	//TextEditor Text;

	bool Endbeat = true;

	public KeyCode Hihats, Snare, Bass, Toms;
	// Use this for initialization
	void Start () {
		TheInputScript = TheInputHandler.GetComponent<InputHandler> ();
		 //Text = DebugText.GetComponent<TextEditor> ();
	}

	bool BeatCheck ()
	{
		if (TheBeat.GetBeatType () != BeatScript.BeatType.Beat_Rest) {
			TheBeat.SetBeatType(BeatScript.BeatType.Beat_Rest);
			return false;
		}
		if (Endbeat) {
			if (time <= 0.245f) { //if the key hits before the "beat" ended
				//insert Beat Script sending
				return true;
			} else {
				//TheBeat.SetBeatType(BeatScript.BeatType.Beat_Fail );
				return false;
			}
		} else {
			if (time >= 0.05f) { // if the key hits after the "beat" starts
				//insert Beat Script sending
				return true;
			} else {
				return false;
			}
		}
	}

	void CreateSFX()
	{
		GameObject TempSFX = (GameObject) Instantiate(DrumSFX);
		TempSFX.gameObject.transform.parent = gameObject.transform;
		TempSFX.GetComponent<DrumAudio>().Set(TheBeat);
		Destroy (TempSFX, 1.0f);
		GUI.Label (new Rect (Screen.width / 2 - 15, Screen.height / 2 - 15, 30, 30), "Hit");
	}

	//void CreateVFX (int beat)
	//{
	//	GameObject TempVFX = (GameObject) Instantiate(VFX[beat - 1]);
	//	//Rect VFXLoc = new Rect(TempVFX.GetComponent<Rect>() );
	//	TempVFX.gameObject.transform.SetParent(Canvas.transform);
	//	//TempVFX.GetComponent<RectTransform> (). = VFXLoc;
	//	//TempVFX.GetComponent<DrumAudio>().Set(TheBeat);
	//	Destroy (TempVFX, 1.0f);
	//}

	void SendBeat ()
	{
		TheInputScript.ReceiveSequence (TheBeat);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;//Time Update
		
		GUI.Label(new Rect (0, 100, 100, 100), time.ToString());

		if (time >= 0.25f) { // Check if the beat has ended
			//print (time);
			time = 0.0f; // reset time
			if (Endbeat)
			{
				if (TheBeat.GetBeatType() == BeatScript.BeatType.Beat_Rest)
				{
					//print (TheBeat.GetBeatType() );
					SendBeat();
				}
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Rest); //Reset Beat
			}
			Endbeat = !Endbeat; //swap out for new beat cycle
		}

		//check keyboard inputs
		if (Input.GetKeyDown (Hihats) && !keydown) { //Hit Hat key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Hithat); //Set Beat
				//CreateVFX ( (int)TheBeat.GetBeatType() );
				//Instantiate (VFX[3],)
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (Input.GetKeyDown (Snare) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Snare);//Set Beat
				//CreateVFX ( (int)TheBeat.GetBeatType() );
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (Input.GetKeyDown (Toms) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Tom);//Set Beat
				//CreateVFX ( (int)TheBeat.GetBeatType() );
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (Input.GetKeyDown (Bass) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Bass);//Set Beat
				//CreateVFX ( (int)TheBeat.GetBeatType() );
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (!Input.GetKeyDown (Hihats) 
		    && !Input.GetKeyDown (Snare) 
		    && !Input.GetKeyDown (Toms)
		    && !Input.GetKeyDown (Bass)) {
			// reset keydown when no keys are pressed
			keydown = false;
		}
	}


}
