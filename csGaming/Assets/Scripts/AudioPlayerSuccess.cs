using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script that adds a sound wjen player wins*/

public class AudioPlayerSuccess : MonoBehaviour {

	public AudioSource audioTrack;  
	public AudioClip shot;

	private int count = 0 ;

	// Use this for initialization
	void Start () {

		audioTrack = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {

		if (DiamondPickUp.playClip == true) {

			audioTrack.PlayOneShot (shot, 1.9F); 
			print ("Effect no.2 done well ");

			if (count == 17) { //handling clip time on pick up key action


				StartCoroutine (AudioDecrease.Decrease(audioTrack, 70.0f));  //it decreases slowly from 1 to that NEW FACTOR
				print ("Current Volume: " + audioTrack.volume);
				DiamondPickUp.playClip = false;

			}

			count++; 
		}  

	}



}
