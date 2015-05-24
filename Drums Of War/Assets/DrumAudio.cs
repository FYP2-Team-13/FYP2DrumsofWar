using UnityEngine;
using System.Collections;

public class DrumAudio : MonoBehaviour {

	public AudioClip Snare, Tom, Bass, HiHat;
	AudioSource TheSource;
	// Use this for initialization
	void Start () {
		AudioSource TheSource = GetComponent<AudioSource> ();
	}

	public void Set (BeatScript TheBeat) {
		if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Bass) {
			//TheSource.clip = Bass;
			GetComponent<AudioSource> ().PlayOneShot (Bass);
		} else if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Hithat) {
			//TheSource.clip = HiHat;
			GetComponent<AudioSource> ().PlayOneShot (HiHat);
		} else if (TheBeat.GetBeatType () == BeatScript.BeatType.Beat_Snare) {
			//TheSource.clip = Snare;
			GetComponent<AudioSource> ().PlayOneShot (Snare);
		} else {
			//TheSource.clip = Tom;
			GetComponent<AudioSource> ().PlayOneShot (Tom);
		}
		//TheSource.PlayOneShot ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<AudioSource> ().isPlaying) {
			Destroy(this);
		}
	}
}
