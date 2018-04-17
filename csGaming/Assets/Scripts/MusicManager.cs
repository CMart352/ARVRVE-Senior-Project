using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script handling the MUSIC BACKGROUND.
 * It has the loop option on the inspector active for when the track stops. 
 * It is also able to go through all scenes before start in LEVEL_01*/






public class MusicManager : MonoBehaviour {


	public AudioSource bgTrack;  //backgroundTrack
	private float myStartVolume ;

	static MusicManager instance = null;


	/*** The volume that starts on 1F ***/

	void Start () {

		/*      if (instance != null) {
			Destroy (gameObject);
			print ("Destroyed ");
		} else {
			instance = this;
			print ("created ");
		}                           
		*/

		GameObject.DontDestroyOnLoad (gameObject);  /*THE TRACK WILL STILL BE PLAYING ONCE WE CHANGE THE SCENE*/


		//bgTrack.Play();  //play from once scene is loaded 
	}



	void Update () {

		/*Audio on SignUp form*/

		if (RegisterPlayer.stopMusic == true) { //IF user hits SINGUP button 



			StartCoroutine (AudioDecrease.Decrease (bgTrack, 70.0f));  //it decreases slowly by NEW FACTOR



			if (SignUp.restartMusic == true) { /*If goBacktoMainMenu selected : music set back to a high volume */
				StartCoroutine (AudioDecrease.Increase (bgTrack, 15.0f)); 
				RegisterPlayer.stopMusic = false;



				if (instance != null) {
					Destroy (gameObject, 0.5F);
					print ("Destroyed ");
				} else {
					instance = this;
					print ("created "); }


			}

		} 
		//in any case if STARTS button is hit, the music will start decreasing
		if (SignUp.firstLevelbegins == true) {
			StartCoroutine (AudioDecrease.Decrease (bgTrack, 70.0f));

		}


		/*Audio on Login form*/

		/*when user hits LOGIN (login scene) the first music background stops*/
		if (AuthenticatePlayer.changeAudio == true) {

			StartCoroutine (AudioDecrease.Decrease (bgTrack, 70.0f));

		}

	}



}
