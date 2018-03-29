using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthenticatePlayer : MonoBehaviour {

	public static void AunthenticatePlayerBttn(string username, string password, string scene, Text playerTextError) {
		new GameSparks.Api.Requests.AuthenticationRequest().
			SetUserName(username).
			SetPassword(password).
			Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
					SceneManager.LoadScene(scene);

			    	playerTextError.text = " ";
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
