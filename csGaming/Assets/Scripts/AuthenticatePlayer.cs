using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*see if we can add another method here that maps the email to a user already in the database*/

public class AuthenticatePlayer : MonoBehaviour {

	public static bool changeAudio; 
	public Text playerTextError;

	public AudioSource AudioTrack;  
	public AudioClip clip;



	void Start () {  
		
		AudioTrack = GetComponent<AudioSource>();
	}



	public void AunthenticatePlayerBttn() {

		new GameSparks.Api.Requests.AuthenticationRequest().
		SetUserName(Login.username).
			SetPassword(Login.password).
			Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
			    	playerTextError.text = " ";
					GetLevel.getLevel ();
				   
				    
				   changeAudio = true;

				} else {
					/**Samira, add error messages similar to the ones you created**/
			

					/**Your code goes here**/


					Debug.Log("Error Authenticating Player...");

			     	AudioTrack.PlayOneShot (clip, 1.9F); 
			    	print ("Effect no.2 done well ");

				    playerTextError.text = "Not valid user ";
				    playerTextError.color = Color.red;

				}
			});


	}

	void Update () {

		/*When user hits enters on Login Form*/
		if( Input.GetKeyDown(KeyCode.Return) ) { 
			
			AunthenticatePlayerBttn ();
		}

	}
}
