using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

	SequenceClass Sequence;
	int drumindex = 0;
	float TimeDur = 0.0f;
	SequenceDatabase TheDatabase;
	bool runningcommand = false;
	public Sprite WinImage, LoseImage;
	public AudioClip WinSFX, LoseSFX;

	public List<AllyGroup> Allies = new List<AllyGroup>();
	public string AllyTag;

	void Reset ()
	{
		TimeDur = 0.0f;
		drumindex = 0;
		Sequence = new SequenceClass();
		foreach (AllyGroup Ally in Allies) {
			Ally.ReceiveCommand ("Nothing", "Nothing");
		}
		runningcommand = false;
		//TimeDur = 0.0f;
	}
	// Use this for initialization
	void Start () {
		Sequence = new SequenceClass ();
		TheDatabase = GetComponent<SequenceDatabase> ();

		GameObject[] nodes = GameObject.FindGameObjectsWithTag (AllyTag);
		foreach (GameObject Ally in nodes) {
			//if (Ally == nodes[0])
			//	continue;
			Allies.Add (Ally.GetComponent<AllyGroup>() );
		}
		//Allies[0].Init (1, AllyClass.Unit_Type.Type_Melee, 10, 0.75f, 2, 1, 5, 100);
		//Allies[1].Init (6, AllyClass.Unit_Type.Type_Range, 10, 0.75f, 10, 1, 5, 100);

	}

	public void ReceiveSequence (BeatScript nextbeat)
	{ //Function Called when the next beat is received, stacks beats into sequence
		if (nextbeat.GetBeatType () == BeatScript.BeatType.Beat_Rest) {
			if (!runningcommand)//no command, sequence fail
				Reset ();
		} else {

			//Add in checking for if the drum beat follows a pattern
			if (runningcommand)
				Reset();
			else
			{
				Sequence.SetBeat(nextbeat, drumindex);// [drumindex].SetBeatType (nextbeat.GetBeatType() );
				drumindex++;
				//print (drumindex);
				if (drumindex > 3) {
					drumindex = 0; //reset drum sequence
					
					//Four Beats Done, Send it to your units
					//SequenceClass Temp;// = SequenceClass.SetSequence (TheDatabase.CommandCheck(Sequence) );
					Sequence.SetSequence (TheDatabase.CommandCheck(Sequence) );
					AudioClip ResponseSFX;
					if (Sequence.GetMeleeBehaviour() != null)
					{
						ResponseSFX = TheDatabase.GetAudio(Sequence);
						GetComponent<AudioSource>().PlayOneShot(ResponseSFX);
					}
					
					foreach (AllyGroup Ally in Allies)
					{
						Ally.ReceiveCommand(Sequence.GetMeleeBehaviour(), Sequence.GetRangeBehaviour() );
					}
					runningcommand = true;
					print (Sequence.ShowSequence() );
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (Allies[0].GetAIState() != AllyGroup.AI_Ally_State.Ally_Idle) 
		if (runningcommand)
		{ //Check if AI is actually doing an action
			TimeDur += Time.deltaTime;
			//print (TimeDur);
			if (TimeDur > 2.0f) { //Command has lasted long enough
				Reset();
			}
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			GameObject[] nodes = GameObject.FindGameObjectsWithTag("Ally");
			foreach (GameObject Ally in nodes)
			{
				Ally.GetComponent<AllyClass>().TakeDamage(100000);
			}
		}
	}

	//Three programmers, 0 Object Oriented Programming. + 1 

	public void CheckDefeat ()
	{//This function is for checking if the army is dead
		int totalunits = 0;
		foreach (AllyGroup AllyGroup in Allies) {
			totalunits += AllyGroup.GetQuantity();
		}
		if (totalunits < 1) //no more units 
		{// insert defeat condition here
			PlayEnding(false);
		}
	}

	public void PlayEnding(bool win)
	{//true for victory, false for defeat.
		GameObject WinLoseIndicator = GameObject.FindGameObjectWithTag("Result");
		Image TheSprite = WinLoseIndicator.GetComponent<Image> ();
		AudioSource TheSource = WinLoseIndicator.GetComponent<AudioSource> ();
		transform.parent.gameObject.GetComponent<AudioSource> ().Stop ();

		if (win)
		{
			TheSprite.sprite = WinImage;
			TheSource.clip = WinSFX;
		}
		else
		{
			TheSprite.sprite = LoseImage;
			TheSource.clip = LoseSFX;
		}
		WinLoseIndicator.GetComponent<FaderScripte> ().StartFade ();
		TheSource.PlayOneShot (TheSource.clip);
		//WinLoseIndicator.SetActive(true);
		//FaderScripte Fader = WinLoseIndicator.GetComponent<FaderScripte> ();
		//Fader.StartFade ();
	}
}
