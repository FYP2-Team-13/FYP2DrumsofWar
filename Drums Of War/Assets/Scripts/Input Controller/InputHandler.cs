using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

	SequenceClass Sequence;
	int drumindex = 0;
	float TimeDur = 0.0f;
	SequenceDatabase TheDatabase;

	public List<AllyClass> Allies = new List<AllyClass>();
	public string AllyTag;

	void Reset ()
	{
		drumindex = 0;
		Sequence.Empty ();
		//TimeDur = 0.0f;
	}
	// Use this for initialization
	void Start () {
		Sequence = new SequenceClass ();
		TheDatabase = GetComponent<SequenceDatabase> ();

		GameObject[] nodes = GameObject.FindGameObjectsWithTag (AllyTag);
		foreach (GameObject Ally in nodes) {
			Allies.Add (Ally.GetComponent<AllyClass>() );
		}

	}

	public void ReceiveSequence (BeatScript nextbeat)
	{ //Function Called when the next beat is received, stacks beats into sequence
		if (nextbeat.GetBeatType () == BeatScript.BeatType.Beat_Rest) { //no beat, sequence fail
			Reset ();
		} else {

			//Add in checking for if the drum beat follows a pattern

			Sequence.SetBeat(nextbeat, drumindex);// [drumindex].SetBeatType (nextbeat.GetBeatType() );
			drumindex++;
			//print (drumindex);
			if (drumindex > 3) {
				drumindex = 0; //reset drum sequence

				//Four Beats Done, Send it to your units
				//SequenceClass Temp;// = SequenceClass.SetSequence (TheDatabase.CommandCheck(Sequence) );
				Sequence.SetSequence (TheDatabase.CommandCheck(Sequence) );
					
				foreach (AllyClass Ally in Allies)
				{
					Ally.ReceiveCommand(Sequence.GetMeleeBehaviour(), Sequence.GetRangeBehaviour() );
				}

				print (Sequence.ShowSequence() );
				//print (Sequence[0].GetBeatType() + " " + Sequence[1].GetBeatType() + 
				 //      " " + Sequence[2].GetBeatType() + " " + Sequence[3].GetBeatType() );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Allies [0].GetAIState () != AllyClass.AI_Ally_State.Ally_Idle) {
			TimeDur += Time.deltaTime;
			if (TimeDur > 2.0f) { //Command has lasted long enough
				TimeDur = 0.0f; //Reset Timing

				foreach (AllyClass Ally in Allies) {
					Ally.ReceiveCommand ("Nothing", "Nothing");
				}
			}
		}
	}
}
