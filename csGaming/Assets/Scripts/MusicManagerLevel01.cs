using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerLevel01 : MonoBehaviour {

	public AudioSource bgTrack01;  //backgroundTrack

	static MusicManagerLevel01 instance = null;

	void Start () {

		if (instance != null) {
			Destroy (gameObject, 0.5F);
			print ("Destroyed ");
		} else {
			instance = this;
			print ("created "); }



		GameObject.DontDestroyOnLoad (gameObject);  /*THE TRACK WILL STILL BE PLAYING ONCE WE CHANGE THE SCENE*/
		StartCoroutine (AudioDecrease.Increase (bgTrack01, 10.0f)); 


	}


	void Update () {




		if (QuitGame.decreaseSound == true) {   //when quit is pressed 

			bgTrack01.Stop ();

		}


		if (DiamondPickUp.playClip == true) {   //if player wins the level decrease background music 

			StartCoroutine (AudioDecrease.Decrease (bgTrack01, 20.0f)); 
		}


	}


}
