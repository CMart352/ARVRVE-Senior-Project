using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueToLevel2 : MonoBehaviour {

	GameObject[] nextLevelObjects;
	//public Button nextLevelBtn;
	//SubmitButtonHandler controller;
	public GameObject messagePanel;
	public Button cont;

	// Use this for initialization
	void Start () {

		/* Find all objects that will be displayed in the "Next Level" pop up */
		nextLevelObjects = GameObject.FindGameObjectsWithTag("LevelCompleted");
		hidePopUp ();

		//controller = gameObject.AddComponent<SubmitButtonHandler> ();

		Button btn = cont.GetComponent<Button>();
		btn.onClick.AddListener (CloseMessage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void CloseMessage()
	{
		Application.Quit ();
	}

	/* Deactivate them for now */
	public void hidePopUp()
	{
		foreach(GameObject g in nextLevelObjects)
		{
			g.SetActive(false);
		}
	}

	public void displayPopUp()
	{
		print ("Congratulations message");
		foreach(GameObject g in nextLevelObjects)
		{
			g.SetActive(true);
		}
	}
}
