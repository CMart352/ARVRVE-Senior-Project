using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class ForgetPasswordController : MonoBehaviour
{



	Toggle forgotPassLink;
	public static bool linkStatus; //to notify myself from other class


	//Component for new panel


	public GameObject outsidePanel; //Big pannel 
	public GameObject innerPanel; //inside panel no filled
	public Text enterEmailMessage; 
	public GameObject emailField;   //input field . fidel needs the string from this
	public GameObject sendButton; //Send Button

	public static string emailstring ;  //if I make this variable static We can access it from that script where he needs it



	void Start()
	{
		//set everything in the panel to false

		outsidePanel.SetActive (false);
		innerPanel.SetActive (false);
		enterEmailMessage.text = " ";
		emailField.SetActive (false);
		sendButton.SetActive (false);



		//Fetch the Toggle GameObject
		forgotPassLink = GetComponent<Toggle>();


		forgotPassLink.isOn = false;  //set it to false first 
		linkStatus = forgotPassLink.isOn;  //takes the current status of the toggle object

	}



	void Update(){

		emailstring = emailField.GetComponent<InputField> ().text; //getting email enter form input field

		/*If toggle is active I make all this appear */

		if (forgotPassLink.isOn == true) {

			outsidePanel.SetActive (true);
			innerPanel.SetActive (true);
			enterEmailMessage.text = "Enter your email here please";
			enterEmailMessage.color = Color.white; 
			emailField.SetActive (true); //input field for email
			sendButton.SetActive (true); // send button 



		}

		linkStatus = forgotPassLink.isOn;  //takes the current status of the toggle object



	}
}