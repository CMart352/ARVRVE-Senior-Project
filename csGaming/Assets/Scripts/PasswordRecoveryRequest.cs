using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.UI;


public class PasswordRecoveryRequest : MonoBehaviour {

	public AudioSource AudioTrack;  
	public AudioClip clip;


	//new panel objects
	public GameObject panel;  //bigger panel 
	public GameObject Innerpanel; 
	public Text enterToken;
	public GameObject token; //token
	public Text enterConfpass;
	public GameObject confPass;
	public GameObject confirmButton ; 


	public Text emailWarning;

	public static string stringToken;
	public static string stringPassword;

	//go back to login panel
	public GameObject notificationPanel;
	public Text notification;
	public GameObject goBackToLogin;

	public Text errorMessage; 

	void Start () {  

		panel.SetActive (false);
		Innerpanel.SetActive (false);
		enterToken.text = "";
		token.SetActive (false);
		enterConfpass.text = "";
		confPass.SetActive (false);
		confirmButton.SetActive (false);


		notificationPanel.SetActive (false);
		notification.text = " " ;
		goBackToLogin.SetActive (false);

		AudioTrack = GetComponent<AudioSource>();
	}



	public void retrievePassword() {



		GSRequestData scriptData = new GSRequestData().
			AddString("action", "passwordRecoveryRequest").
			AddString("email", ForgetPasswordController.emailstring);
	    	



		new GameSparks.Api.Requests.AuthenticationRequest().
		SetUserName("").
		SetPassword("").
		SetScriptData (scriptData).
			Send ((response) => {
		if (response.Errors.JSON.Contains("complete"))
				{
					Debug.Log("Password retrieval request sent");

				   //SHOW NEXT PANEL
			    	panel.SetActive (true);
			    	Innerpanel.SetActive (true);
			    	enterToken.text = "Please enter token received:";
			    	enterToken.color = Color.white;
				    token.SetActive (true);
				    enterConfpass.text = "Confirm new password:";
				    enterConfpass.color = Color.white;
				    confPass.SetActive (true);
				    confirmButton.SetActive (true);
		        
				    
				    emailWarning.text = " ";
			   
				    
				}
				else
				{

			    	AudioTrack.PlayOneShot (clip, 1.9F); 
			    	print ("Effect no.2 done well ");
				    emailWarning.text = "Email is invalid. Please try again";
				    emailWarning.color = Color.red;

					Debug.Log("Password Reset Error" + response.Errors.JSON.ToString());
				 

				}
				
		});


	}

	public void resetPassword() {
		GSRequestData scriptData = new GSRequestData().
			AddString("action", "resetPassword").
			AddString("token", stringToken).
			AddString("password", stringPassword);




		new GameSparks.Api.Requests.AuthenticationRequest().
		SetUserName("").
		SetPassword("").
		SetScriptData (scriptData).
		Send ((response) => {
			if (response.Errors.JSON.Contains("complete"))
			{
				Debug.Log("Password reset request sent");

				//SHOW NEXT PANEL
				notificationPanel.SetActive(true);
				notification.text = "Password has been successfully reset";
				notification.color = Color.white;
				goBackToLogin.SetActive(true);





			}
			else
			{
				print("Invalid credentials");

				AudioTrack.PlayOneShot (clip, 1.9F); 
				print ("Effect no.2 done well ");

				//error message shown
				errorMessage.text = "WRONG INFORMATION ENTERED";
				errorMessage.color = Color.red;

				Debug.Log("Password Reset Error" + response.Errors.JSON.ToString());


			}

		});


	}



	void Update(){
		//Fidel will need these strings back 

		stringPassword = confPass.GetComponent<InputField> ().text;
		stringToken = token.GetComponent<InputField> ().text; 


	}


}
