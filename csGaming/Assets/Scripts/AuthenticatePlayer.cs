using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*see if we can add another method here that maps the email to a user already in the database*/

public class AuthenticatePlayer : MonoBehaviour {

	public static bool changeAudio; 




	public static void AunthenticatePlayerBttn(string username, string password, Text playerTextError) {
		new GameSparks.Api.Requests.AuthenticationRequest().
			SetUserName(username).
			SetPassword(password).
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

				    playerTextError.text = "Not valid user ";
				    playerTextError.color = Color.red;

				}
			});


	}
}
