using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	SequenceClass Sequence;
	int drumindex = 0;
	float TimeDur = 0.0f;
	SequenceDatabase TheDatabase;

	void Reset ()
	{
		drumindex = 0;
		Sequence.Empty ();
	}
	// Use this for initialization
	void Start () {
		Sequence = new SequenceClass ();
		TheDatabase = GetComponent<SequenceDatabase> ();
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
				Sequence = TheDatabase.CommandCheck(Sequence);
				if (Sequence.GetMeleeBehaviour() == string.Empty || Sequence.GetRangeBehaviour() == string.Empty)
				{ // No Command Sequence Found for one of the two, reset and redo
				}
				else 
				{ //Command Sequence Found, Send it to your units
					//Send both strings to each AI, AI knows if it itself is melee or range unit
					if (Sequence.GetMeleeBehaviour().CompareTo ("Attack") == 0)
					{
					}
				}

				print (Sequence.ShowSequence() );
				//print (Sequence[0].GetBeatType() + " " + Sequence[1].GetBeatType() + 
				 //      " " + Sequence[2].GetBeatType() + " " + Sequence[3].GetBeatType() );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		TimeDur += Time.deltaTime;
		if (TimeDur > 2.0f) { //Command has lasted long enough
			TimeDur = 0.0f; //Reset Timing
		}
	}
}
