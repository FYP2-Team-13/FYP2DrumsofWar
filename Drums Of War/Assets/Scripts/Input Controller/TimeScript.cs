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

	GameObject SnareVFX, TomVFX, HihatVFX, BassVFX;
	//public GameObject DebugText;
	//TextEditor Text;

	bool Endbeat = true;

	KeyCode Hihats, Snare, Bass, Toms;
	// Use this for initialization
	void Start () {
		TheInputScript = TheInputHandler.GetComponent<InputHandler> ();
		 //Text = DebugText.GetComponent<TextEditor> ();
		SnareVFX = GameObject.FindGameObjectWithTag ("SnareVFX");
		TomVFX = GameObject.FindGameObjectWithTag ("TomVFX");
		HihatVFX = GameObject.FindGameObjectWithTag ("HiHatVFX");
		BassVFX = GameObject.FindGameObjectWithTag ("BassVFX");

		Hihats = KeyCode.W;
		Snare = KeyCode.A;
		Toms = KeyCode.D;
		Bass = KeyCode.S;
	}

	bool BeatCheck ()
	{
		if (TheBeat.GetBeatType () != BeatScript.BeatType.Beat_Rest) {
			TheBeat.SetBeatType(BeatScript.BeatType.Beat_Rest);
			return false;
		}
		if (Endbeat) {
			if (time <= 0.25f) { //if the key hits before the "beat" ended
				//insert Beat Script sending
				//print ("hit");
				return true;
			} else {
				//TheBeat.SetBeatType(BeatScript.BeatType.Beat_Fail );
				//print ("miss");
				return false;
			}
		} else {
			if (time >= 0.00f) { // if the key hits after the "beat" starts
				//insert Beat Script sending
//				print ("hit");
				return true;
			} else {
//				print ("miss");
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
		//GUI.Label (new Rect (Screen.width / 2 - 15, Screen.height / 2 - 15, 30, 30), "Hit");
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
		
		//GUI.Label(new Rect (0, 100, 100, 100), time.ToString());

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
		if (( (Input.GetKeyDown (Hihats))||(Input.GetButtonDown("Fire3")) ) && !keydown) { //Hit Hat key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Hithat); //Set Beat
				HihatVFX.GetComponent<FadeOutScript>().ResetFade(false);
				//CreateVFX ( (int)TheBeat.GetBeatType() );
				//Instantiate (VFX[3],)
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (( (Input.GetKeyDown (Snare)) || (Input.GetButtonDown("Jump")) ) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Snare);//Set Beat
				SnareVFX.GetComponent<FadeOutScript>().ResetFade(true);
				//CreateVFX ( (int)TheBeat.GetBeatType() );
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (( (Input.GetKeyDown (Toms))||(Input.GetButtonDown("Fire2")) ) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Tom);//Set Beat
				TomVFX.GetComponent<FadeOutScript>().ResetFade(true);
				//CreateVFX ( (int)TheBeat.GetBeatType() );
			}
			SendBeat();
			CreateSFX();
			//print (TheBeat.GetBeatType() );
		}

		if (( (Input.GetKeyDown (Bass))||(Input.GetButtonDown("Fire1")) ) && !keydown) { //Snare key pressed
			keydown = true; //stop next instance of keydown
			if (BeatCheck() ) {
				TheBeat.SetBeatType (BeatScript.BeatType.Beat_Bass);//Set Beat
				BassVFX.GetComponent<FadeOutScript>().ResetFade(false);
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
