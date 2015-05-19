using UnityEngine;
using System.Collections;

public class BeatScript {

	public enum BeatType
	{
		Beat_Rest = 0,
		Beat_Fail,
		Beat_Snare,
		Beat_Tom,
		Beat_Hithat,
		Beat_Bass,
		Beat_Number
	}

	BeatType type;

	public void SetBeatType (BeatType type)
	{
		this.type = type;
	}

	public BeatType GetBeatType ()
	{
		return type;
	}
}
