using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

/*This class adds fuctionality to CONFIRM button when Users want to reset their password*/

public class NewPasswordController : MonoBehaviour {

	public AudioSource AudioTrack;  
	public AudioClip clip;


	//text object to print error message on token and confpass
	public Text confpassmessageError;

	//after password was succefully reset
	public GameObject notificationPanel;
	public Text notification;
	public GameObject goBackToLogin; 



	void Start () {  
		
		//final notification pannel objects
		notificationPanel.SetActive (false);
		notification.text = " ";
		goBackToLogin.SetActive (false);

		AudioTrack = GetComponent<AudioSource>();

	}


	/*implementation of CONFIRM BUTTON */
	public void resetPassword(){  

		if( Validation.validatePassword(PasswordRecoveryRequest.stringPassword) && PasswordRecoveryRequest.stringToken != "" ){ 
			
			//confirmation panel appears
			notificationPanel.SetActive (true);
			notification.text = "Password has been succefully reset";
			notification.color = Color.white;
			goBackToLogin.SetActive (true);

		}else{
			print ("not matching credentials");
			//else : warnings
			confpassmessageError.text = "WRONG INFORMATION ENTERED"; 
			confpassmessageError.color = Color.red; 

			AudioTrack.PlayOneShot (clip, 1.9F); 
			print ("Effect no.2 done well ");
		}

	}

}


