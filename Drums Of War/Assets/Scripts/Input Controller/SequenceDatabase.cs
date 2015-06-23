using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SequenceDatabase : MonoBehaviour {
	
	public TextAsset Database;
	public static List <SequenceClass> SequenceList = new List<SequenceClass>();
	public List<AudioClip> ResponseList = new List<AudioClip>();
	
	// Use this for initialization
	void Start () {
		//Create a String Reader that has loaded the Text Asset
		StringReader Data = new StringReader (Database.text); 
		//Store all the Text into a string
		string Contents = Data.ReadToEnd ();
		//Split Contents of Text Asset by lines
		string[] Lines = Contents.Split ("\n"[0]);
		
		foreach (string line in Lines) {
			//Split each line into variables by comma (,)
			string[] values = line.Split(","[0]);
			
			//Create temporal variables to Load all Sequence in
			SequenceClass Temp = new SequenceClass();
			BeatScript TempBeat = new BeatScript();
			
			Temp.SetRangeBehaviour(values[0] );
			Temp.SetMeleeBehaviour(values[1] );
			
			//Compare each string with the corresponding Beat
			for (int i = 2; i < 6; i++)
			{
				if (values[i].CompareTo ("Snare") == 0 )
				{
					TempBeat.SetBeatType(BeatScript.BeatType.Beat_Snare);
				} else if (values[i].CompareTo ("Tom") == 0 )
				{
					TempBeat.SetBeatType(BeatScript.BeatType.Beat_Tom);
				} else if (values[i].CompareTo ("Bass") == 0)
				{
					TempBeat.SetBeatType(BeatScript.BeatType.Beat_Bass);
				} else if (values[i].CompareTo ("HiHat") == 0)
				{
					TempBeat.SetBeatType(BeatScript.BeatType.Beat_Hithat);
				}
				Temp.SetBeat (TempBeat, i - 2);
			}
			
			//Load the Temp Sequence into to List
			//print (Temp.ShowSequence() );
			SequenceList.Add(Temp);
		}
		//foreach (SequenceClass Sequence in SequenceList) {
		//	print (Sequence.ShowSequence() );
		//}
	}
	
	public SequenceClass CommandCheck(SequenceClass theSequence)
	{
		foreach (SequenceClass Sequence in SequenceList) {
			if (Sequence.isSame(theSequence) )
			{
				return Sequence;
			}
		}
		return theSequence;
	}

	public AudioClip GetAudio(SequenceClass theSequence)
	{
		foreach (SequenceClass Sequence in SequenceList) {
			if (Sequence.isSame(theSequence) )
			{
				return ResponseList [SequenceList.IndexOf(Sequence)];
			}
		}
		return null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}