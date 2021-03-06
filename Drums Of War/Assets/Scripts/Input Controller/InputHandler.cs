﻿using UnityEngine;
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
	public GameObject DrumSFX;

	public List<AllyGroup> Allies = new List<AllyGroup>();
	public string AllyTag;

	GameObject Database;
	ConsistentArmy theArmy;

	void Reset ()
	{
		TimeDur = 0.0f;
		drumindex = 0;
		Sequence = new SequenceClass();
		foreach (AllyGroup Ally in Allies) {
			Ally.ReceiveCommand ("Nothing", "Nothing", Vector3.up);
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

		Database = GameObject.FindGameObjectWithTag ("Database");
		theArmy = Database.GetComponent<ConsistentArmy> ();

		foreach (AllyGroup Ally in Allies)
		{
			if (Allies.IndexOf(Ally) < theArmy.TheArmy.Length)
			{
				int index = Allies.IndexOf (Ally);
				ArmyStats ThisArmy = theArmy.TheArmy[index];
				Ally.Init (ThisArmy.Quantity);
				ThisArmy.ApplyStats (Ally);

				foreach (AllyClass Unit in Ally.Allies)
				{
					Unit.transform.FindChild("Body_BackHand/Body_Weapon").gameObject.GetComponent<SpriteRenderer>().sprite = ThisArmy.Weapon.SpriteItem;
					Unit.transform.FindChild("Body_Origin/Mask").gameObject.GetComponent<SpriteRenderer>().sprite = ThisArmy.Helmet.SpriteItem;
				}
				Ally.SetAnimation (ThisArmy.Weapon.type);
			}
			else
			{
				Ally.Init (Ally.Quantity);
			}
		}
		//Allies[0].Init (1, AllyClass.Unit_Type.Type_Melee, 10, 0.75f, 2, 1, 5, 100);
		//Allies[1].Init (6, AllyClass.Unit_Type.Type_Range, 10, 0.75f, 10, 1, 5, 100);

	}

	public void ReceiveSequence (BeatScript nextbeat)
	{ //Function Called when the next beat is received, stacks beats into sequence
		if (nextbeat.GetBeatType () == BeatScript.BeatType.Beat_Rest) {
			if (drumindex != 0)
			{
				CreateMissSFX();
				Reset();
			} else if (!runningcommand)//no command, sequence fail
			{
				Reset ();
			} 
		} else {

			//Add in checking for if the drum beat follows a pattern
			if (runningcommand)
			{
				CreateMissSFX();
				Reset();
			}
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
					else 
					{
						CreateMissSFX();
					}
					
					Vector3 FrontMostAlly = new Vector3();

					GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Ally");
					float furthestdistance = 0;
					if (nodes.Length > 0) {
						foreach (GameObject TheAlly in nodes) {
							if (TheAlly.transform.position.x > furthestdistance) {
								furthestdistance = TheAlly.transform.position.x;
								FrontMostAlly.Set (TheAlly.transform.position.x, TheAlly.transform.position.y, TheAlly.transform.position.z);
							}
						}
					}

					foreach (AllyGroup Ally in Allies)
					{
						Ally.ReceiveCommand(Sequence.GetMeleeBehaviour(), Sequence.GetRangeBehaviour(), FrontMostAlly + Vector3.right * 3.5f * Allies.IndexOf (Ally));
					}

					runningcommand = true;
					print (Sequence.ShowSequence() );
				} else {
					foreach (AllyGroup Ally in Allies)
					{
						Ally.DanceBeat (nextbeat);
					}
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

		if (Input.GetKeyDown (KeyCode.H)) { // kill all units
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
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraFollowScript> ().Following = false;
		GameObject WinLoseIndicator = GameObject.FindGameObjectWithTag("Result");
		Image TheSprite = WinLoseIndicator.GetComponent<Image> ();
		AudioSource TheSource = WinLoseIndicator.GetComponent<AudioSource> ();
		transform.parent.gameObject.GetComponent<AudioSource> ().Stop ();

		if (win)
		{
			TheSprite.sprite = WinImage;
			TheSource.clip = WinSFX;

			foreach (AllyGroup Ally in Allies)
			{
				if (Allies.IndexOf(Ally) < theArmy.TheArmy.Length)
				{
					int index = Allies.IndexOf (Ally);
					ArmyStats ThisArmy = theArmy.TheArmy[index];

					ThisArmy.Quantity = Ally.Quantity;
				}
			}

			//int level = GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().nextlevel;
			int lastlevel = GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().nextlevel;
			int thislevel = GameObject.FindGameObjectWithTag("Level").GetComponent<DropSystem>().Level;
			if (thislevel >= lastlevel)
			{
				GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>().nextlevel = thislevel + 1;
			}
		}
		else
		{
			TheSprite.sprite = LoseImage;
			TheSource.clip = LoseSFX;
		}
		WinLoseIndicator.GetComponent<FaderScripte> ().StartFade ();
		TheSource.PlayOneShot (TheSource.clip);

		Invoke ("BacktoCamp", 8);
	}

	void BacktoCamp ()
	{
		Application.LoadLevel ("Camp Menu");
	}

	void CreateMissSFX()
	{
		GameObject TempSFX = (GameObject) Instantiate(DrumSFX);
		TempSFX.gameObject.transform.parent = gameObject.transform;
		BeatScript tempbeat  = new BeatScript();
		tempbeat.SetBeatType (BeatScript.BeatType.Beat_Miss);
		TempSFX.GetComponent<DrumAudio>().Set(tempbeat);
		Destroy (TempSFX, 1.0f);
		//GUI.Label (new Rect (Screen.width / 2 - 15, Screen.height / 2 - 15, 30, 30), "Hit");
	}
}
