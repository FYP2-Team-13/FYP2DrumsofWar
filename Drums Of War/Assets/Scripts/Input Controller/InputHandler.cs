using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	BeatScript[] Sequence = new BeatScript[4];
	int drumindex = 0;
	float TimeDur = 0.0f;

	void Reset ()
	{
		drumindex = 0;
		foreach (BeatScript Beat in Sequence)
		{
			Beat.SetBeatType(BeatScript.BeatType.Beat_Rest);
		}
	}
	// Use this for initialization
	void Start () {
		Sequence [0] = new BeatScript ();
		Sequence [1] = new BeatScript ();
		Sequence [2] = new BeatScript ();
		Sequence [3] = new BeatScript ();
	}

	public void ReceiveSequence (BeatScript nextbeat)
	{
		if (nextbeat.GetBeatType () == BeatScript.BeatType.Beat_Rest) { //no beat, sequence fail
			Reset ();
		} else {

			//Add in checking for if the drum beat follows a pattern

			Sequence [drumindex].SetBeatType (nextbeat.GetBeatType() );
			drumindex++;
			if (drumindex > 3) {
				drumindex = 0; //reset drum sequence

				//Four Beats Done, Send it to your units

				print (Sequence[0].GetBeatType() + " " + Sequence[1].GetBeatType() + 
				       " " + Sequence[2].GetBeatType() + " " + Sequence[3].GetBeatType() );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		TimeDur += Time.deltaTime;
		if (TimeDur > 4.0f) { //Command has lasted long enough
			TimeDur = 0.0f; //Reset Timing
		}
	}
}
