using UnityEngine;
using System.Collections;

public class SequenceClass {

	BeatScript[] Beat = new BeatScript[4];
	string RangeBeh, MeleeBeh;

	// Use this for initialization
	public SequenceClass () {
		for (int i = 0; i < 4; i++) {
			Beat[i] = new BeatScript();
		}
		RangeBeh = string.Empty;
		MeleeBeh = string.Empty;
	}

	public SequenceClass (BeatScript[] beat) {
		for (int i = 0; i < 4; i++) {
			Beat[i] = new BeatScript();
			Beat[i].SetBeatType(beat[i].GetBeatType() );
		}
		RangeBeh = string.Empty;
		MeleeBeh = string.Empty;
	}
	
	public SequenceClass GetSequence ()
	{
		return this;
	}
		
	public BeatScript GetBeat (int index)
	{
		return Beat [index];
	}

	public string GetRangeBehaviour ()
	{
		return RangeBeh;
	}

	public string GetMeleeBehaviour ()
	{
		return MeleeBeh;
	}

	public void SetSequence (SequenceClass theSequence, string RangeBeh, string MeleeBeh)
	{
		for (int i = 0; i < 4; i++) {
			Beat [i].SetBeatType (theSequence.Beat [i].GetBeatType ());
		}
		this.RangeBeh = RangeBeh;
		this.MeleeBeh = MeleeBeh;
	}

	public void SetSequence (SequenceClass theSequence)
	{
		for (int i = 0; i < 4; i++) {
			Beat [i].SetBeatType (theSequence.Beat [i].GetBeatType ());
		}
		this.RangeBeh = theSequence.GetRangeBehaviour();
		this.MeleeBeh = theSequence.GetMeleeBehaviour();
	}

	public void SetSequence (BeatScript first, BeatScript second, BeatScript third, BeatScript fourth, string RangeBeh, string MeleeBeh)
	{
		Beat [0].SetBeatType (first.GetBeatType ());
		Beat [1].SetBeatType (second.GetBeatType ());
		Beat [2].SetBeatType (third.GetBeatType ());
		Beat [3].SetBeatType (fourth.GetBeatType ());
		this.RangeBeh = RangeBeh;
		this.MeleeBeh = MeleeBeh;
	}

	public void SetBeat (BeatScript beat, int index)
	{
		Beat [index].SetBeatType (beat.GetBeatType ());
	}

	public void SetRangeBehaviour (string Beh)
	{
		this.RangeBeh = Beh;
	}

	public void SetMeleeBehaviour (string Beh)
	{
		this.MeleeBeh = Beh;
	}

	public string ShowSequence ()
	{
		string temp = ("Range: " + RangeBeh + ", Melee: " + MeleeBeh + ". Beat: " + Beat [0].GetBeatType ().ToString ()
			+ " " + Beat [1].GetBeatType ().ToString () + " " + Beat [2].GetBeatType ().ToString () + " " +
			Beat [3].GetBeatType ().ToString ());
		return temp;
	}

	public bool isSame (SequenceClass other)
	{
		for (int i = 0; i < 4; i++)
		{
			if (Beat[i].GetBeatType() != other.Beat[i].GetBeatType() )
				return false;
		}
		return true;
	}

	public void Empty ()
	{
		for (int i = 0; i < 4; i++) {
			Beat[i] = new BeatScript();
			Beat[i].SetBeatType(BeatScript.BeatType.Beat_Rest );
		}
		RangeBeh = string.Empty;
		MeleeBeh = string.Empty;
	}
}
