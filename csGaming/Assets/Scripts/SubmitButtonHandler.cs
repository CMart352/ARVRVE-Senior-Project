﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SubmitButtonHandler : MonoBehaviour {
	public Transform solutionPanel;
	public GameObject player;
	Vector3 originalPos;
	Quaternion originalRot;

	public Button submit;
	public Button clear;
	//public Button cont;
	public Button repeat;

	public Text attempts; 
	int attempt; 
	private int totalAttempt;

	GameObject[] editBtn;

	bool submitClicked;

	//LoopControlsCoordinator repeat;



	UIPlayCommand1 commandExecution;
	UIButtonClick commandProcessor;
    BlocksRotator bl;

	// Use this for initialization
	void Start () {
		//Mairim
		Button submitBtn = submit.GetComponent<Button>();
		submitBtn.onClick.AddListener (AddCommandsToCommandList);

		//Button continueBtn = cont.GetComponent<Button>();
		//continueBtn.onClick.AddListener (ClearAllC);

		//Record original position of the player 
        originalPos = player.transform.localPosition;
        originalRot = player.transform.localRotation;

		//Create instance of the two player handler classes
		commandProcessor = GetComponent<UIButtonClick> ();
		commandExecution = GetComponent<UIPlayCommand1> ();
        bl = GetComponent<BlocksRotator>();

        attempt = 0; 
		submitClicked = false;
		//DeactivateControls ();

	}

	public void ClearAllC()
	{
		Application.Quit ();
		/* Return player to original position */
		/*
		player.transform.localPosition = originalPos;
		player.transform.localRotation = originalRot;
		commandExecution.indexNode = 0; //to set reset the index node 
		commandExecution.targetAngle = 0; //to reset the angle rotation
		commandProcessor.commandList.Clear();
		//Delete all of the commands in the solution panel
		foreach (Transform child in solutionPanel)
		{
			if (child.name != "Command" && child.name != "RepeatCommandsPanel") //Do not destroy original prefab
			{
				Destroy (child.gameObject);
			}
		}
		attempts.text = "1";
		repeat.gameObject.SetActive (true);*/

	}



	void AddCommandsToCommandList()
	{
		if (solutionPanel.transform.childCount == 1)
			return;
		
		/* Return player to original position */
		player.transform.localPosition = originalPos;
		player.transform.localRotation = originalRot;
		commandExecution.indexNode = 0; //to set reset the index node 
		commandExecution.targetAngle = 0; //to reset the angle rotation

		submitClicked = true;

        /*If user had previously clicked the play Button, return player to original position and 
		 * clear commandList so that when user clicks it again, commands are not duplicated
		 */
        if (commandProcessor.commandList.Count == 0) {  //Solution Panel (commandList) is empty, add commands to the list
			foreach (Transform child in solutionPanel) {
				if (child.name != "Command") { //Original prefab gets ignored
					commandProcessor.commandList.Add (child.name);
				}

				sendCommandsToCharacter ();
			}
		} else { //Solution panel has commands, return to original position, and retry 
			commandProcessor.commandList.Clear();
			//Move player to its original position
			AddCommandsToCommandList();
		}

        /* Disable all controls while character is moving */
//        print("Should be interactable: " + submit.interactable);
//        submit.interactable = false;
//		clear.interactable = false; 

		editBtn = GameObject.FindGameObjectsWithTag ("Edits");

		foreach (GameObject btn in editBtn) {
			print (btn.GetComponent<Button> ().name);
			btn.GetComponent<Button>().interactable = false;
		}
//        print("Should not be interactable: " + submit.interactable);
		/* Increase no of attempts */
		attempt++;
		totalAttempt = attempt;

		attempts.text = attempt.ToString (); 

	}

	public int getAttempts() {

		return int.Parse(attempts.text);
	}

	void sendCommandsToCharacter()
	{
		//submitClicked = false;
		//UIPlayCommand.Execute executes the command list
		commandExecution.TaskOnClick();
		submitClicked = false;


	}

	void ActivateControls(){

		submit.interactable = true;
		clear.interactable = true; 
	}

	void DeactivateControls(){
		submit.interactable = false;
		clear.interactable = false; 
	}
		

	// Update is called once per frame
	void Update () {
		//If there are no commands in the solution panel
		//DIsable the submit and clear button
//		if (solutionPanel.transform.childCount == 1) {
//			submit.interactable = false;
//			clear.interactable = false; 
//		} else if (solutionPanel.transform.childCount > 1 && enableBtns == true) { 
//			//if there are commands in the solution panel, and enableBtns has been activated
//			submit.interactable = true;
//			clear.interactable = true; 
//		} else if (solutionPanel.transform.childCount > 1 && enableBtns == false) {
//			//if there are commands in the solution panel but enableBtns has been deactivated
//			submit.interactable = false;
//			clear.interactable = false; 

//		//if (solutionPanel.transform.childCount > 1 && submitClicked == false) {
//		//	ActivateControls ();
//		//} /*else if (solutionPanel.transform.childCount > 1 && submitClicked == true) {
//			DeactivateControls ();
//		}*/


	}

}

