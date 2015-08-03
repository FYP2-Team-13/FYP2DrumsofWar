using UnityEngine;
using System.Collections;

public class DrumAudio : MonoBehaviour {

	public AudioClip Snare, Tom, Bass, HiHat, Miss;
	//AudioSource TheSource;
	// Use this for initialization
	void Start () {
		//AudioSource TheSource = GetComponent<AudioSource> ();
	}

	public void Set (BeatScript TheBeat) {
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Bass) {
			//TheSource.clip = Bass;
			GetComponent<AudioSource> ().PlayOneShot (Bass);
		} 
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Hithat) {
			//TheSource.clip = HiHat;
			GetComponent<AudioSource> ().PlayOneShot (HiHat);
		} 
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Snare) {
			//TheSource.clip = Snare;
			GetComponent<AudioSource> ().PlayOneShot (Snare);
		} 
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Tom) {
			//TheSource.clip = Tom;
			GetComponent<AudioSource> ().PlayOneShot (Tom);
		}
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Miss) {
			GetComponent<AudioSource> ().PlayOneShot (Tom);
		}
		//Destroy (this, 1.0f);
		//TheSource.PlayOneShot ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
