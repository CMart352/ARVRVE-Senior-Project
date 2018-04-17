using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPlayerSound : MonoBehaviour {

	public AudioSource AudioTrack; 


	// Use this for initialization
	void Start () {
		AudioTrack = GetComponent<AudioSource>();
	}



	// Update is called once per frame
	void Update () {

		if (UIPlayCommand1.isPlayerWalking == true) {

			print ("Method working ");
			AudioTrack.Play();

			UIPlayCommand1.isPlayerWalking = false;

		}

	}
}
