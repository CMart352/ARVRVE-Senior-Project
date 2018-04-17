using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

	//this track works toguether with the music manager track 
	public AudioSource bgTrack;  //backgroundTrack

	// Use this for initialization
	void Start () {

	}

	/*Change volume on pauseButton Click*/
	public void testMethod (){
		if (QuitGame.slowMusic == false) {
			bgTrack.volume = bgTrack.volume / 2 - 0.045F; 
			//QuitGame.slowMusic = false;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
