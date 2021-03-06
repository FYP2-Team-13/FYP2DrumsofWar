﻿using UnityEngine;
using System.Collections;

public class BeatScript {

	public enum BeatType
	{
		Beat_Rest = 0,
		Beat_Snare,
		Beat_Tom,
		Beat_Hithat,
		Beat_Bass,
		Beat_Miss,
		Beat_Number
	}

	BeatType type;

	public BeatScript ()
	{
		type = BeatType.Beat_Rest;
	}

	public void SetBeatType (BeatType type)
	{
		this.type = type;
	}

	public BeatType GetBeatType ()
	{
		return type;
	}
}
