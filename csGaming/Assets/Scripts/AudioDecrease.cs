using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDecrease : MonoBehaviour {

	public static IEnumerator Decrease (AudioSource audioTrack, float FadeTime) {
		
		float startVolume = audioTrack.volume;

		while (audioTrack.volume > 0) {
			audioTrack.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}

		audioTrack.Stop ();
		audioTrack.volume = startVolume;
		//print ("The volume sttoped completely");
	}


}

