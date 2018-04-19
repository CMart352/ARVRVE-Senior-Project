using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopControlsCoordinator : MonoBehaviour {

	public Dropdown dropdown1;
	public Dropdown dropdown2;
	public Dropdown dropdown3;
	public Dropdown dropdown4;
	public Dropdown dropdown5;
	public Dropdown dropdown6;
	public Button confirm;
	public Button exit;
	public int MoveForwardAmount;
	public int MoveForwardOrder;
	public int TurnRightAmount;
	public int TurnRightOrder;
	public int TurnLeftAmount;
	public int TurnLeftOrder;

	public GameObject commandPrefab; 

	public GameObject loopPanel;
	//public GameObject solutionPanel;

	SpawnInstructions spawner = null;


	public string[] loopInstructionSet;

	// Use this for initialization
	void Start () {

		spawner = gameObject.AddComponent<SpawnInstructions> ();

		Button confirmBtn = confirm.GetComponent<Button> ();
		confirmBtn.onClick.AddListener (HandleConfirm);

		Button exitBtn = exit.GetComponent<Button> ();
		exitBtn.onClick.AddListener (Exit);

		spawner.commandPrefab = commandPrefab;
		
	}

	void HandleConfirm()
	{
		
		ClearAllValues ();

		MoveForwardAmount = int.Parse(dropdown1.captionText.text);
		MoveForwardOrder = int.Parse(dropdown4.captionText.text);

		TurnRightAmount = int.Parse(dropdown3.captionText.text);
		TurnRightOrder = int.Parse(dropdown6.captionText.text);

		TurnLeftAmount = int.Parse(dropdown2.captionText.text);
		TurnLeftOrder = int.Parse(dropdown5.captionText.text);

		int j = 0;
		int temp = 0;

		//Order of 1
		if (MoveForwardOrder == 1) 
			{
			while(temp < MoveForwardAmount) 
				{
					loopInstructionSet [j] = "MoveForward";
				j++;
				temp++;
				}
			}
		else if (TurnRightOrder == 1) 
			{
			while(temp < TurnRightAmount)
				{
					loopInstructionSet [j] = "TurnRight";
				j++;
				temp++;
				}
			}
		else if (TurnLeftOrder == 1) 
			{
			while( temp < TurnLeftAmount) 
				{
				loopInstructionSet [j] = "TurnLeft";
				j++;
				temp++;
				}
			}
		temp = 0;

		//Order of 2
		if (MoveForwardOrder == 2) 
		{
			while(temp < MoveForwardAmount) 
			{
				loopInstructionSet [j] = "MoveForward";
				j++;
				temp++;
			}
		}
		else if (TurnLeftOrder == 2) 
		{
			while(temp < TurnLeftAmount)
			{
				loopInstructionSet [j] = "TurnLeft";
				j++;
				temp++;
			}
		}
		else if (TurnRightOrder == 2) 
		{
			while( temp < TurnRightAmount) 
			{
				loopInstructionSet [j] = "TurnRight";
				j++;
				temp++;
			}
		}
		temp = 0;

		//Order of 3
		if (MoveForwardOrder == 3) 
		{
			while(temp < MoveForwardAmount) 
			{
				loopInstructionSet [j] = "MoveForward";
				j++;
				temp++;
			}
		}
		else if (TurnLeftOrder == 3) 
		{
			while(temp < TurnLeftAmount)
			{
				loopInstructionSet [j] = "TurnLeft";
				j++;
				temp++;
			}
		}
		else if (TurnRightOrder == 3) 
		{
			while( temp < TurnRightAmount) 
			{
				loopInstructionSet [j] = "TurnRight";
				j++;
				temp++;
			}
		}
		temp = 0;

		loopPanel.SetActive (false);

		AddToSolutionPanel ();

	}

	void AddToSolutionPanel()
	{
		int i = 0;
		string temp = "";
		while ( i < loopInstructionSet.Length)
		{
			temp = loopInstructionSet [i];

			if (temp.Equals ("MoveForward")) 
			{
				spawner.MoveUp ();
			}
			if (temp.Equals ("TurnLeft")) 
			{
				spawner.MoveLeft ();
			}
			if (temp.Equals ("TurnRight")) 
			{
				spawner.MoveRight ();
			}

			i++;
		}
	}

	void ClearAllValues()
	{
		MoveForwardAmount = 0;
		MoveForwardOrder= 0;
		TurnRightAmount=0;
		TurnRightOrder=0;
		TurnLeftAmount=0;
		TurnLeftOrder=0;

		for (int i = 0; i < loopInstructionSet.Length; i++) {
			loopInstructionSet [i] = "";
		}


	}

	void Exit()
	{
		loopPanel.SetActive (false);
	}
	// Update is called once per frame
	void Update () {


	}
}

