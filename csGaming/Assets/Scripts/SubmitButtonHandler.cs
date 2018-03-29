using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SubmitButtonHandler : MonoBehaviour {
	public Transform solutionPanel;
	public GameObject player;
	Vector3 originalPos;
	public Button submit;
	UIPlayCommand commandExecution;
	UIButtonClick commandProcessor;

	// Use this for initialization
	void Start () {
		//Mairim
		Button submitBtn = submit.GetComponent<Button>();
		submitBtn.onClick.AddListener (AddCommandsToCommandList);

		//Record original position of the player 
		originalPos = player.transform.position;

		//Create instance of the two player handler classes
		commandProcessor = GetComponent<UIButtonClick>();
		commandExecution = GetComponent<UIPlayCommand> ();
		//commandProcessor = new UIButtonClick();
		//commandExecution = new UIPlayCommand ();
	}

	void AddCommandsToCommandList()
	{
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
			player.transform.position = originalPos;
			AddCommandsToCommandList();
		}
	}

	void sendCommandsToCharacter()
	{
		//UIPlayCommand.Execute executes the command list
		commandExecution.TaskOnClick();

	}






	// Update is called once per frame
	void Update () {
		
	}
}
