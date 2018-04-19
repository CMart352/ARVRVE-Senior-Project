using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNexLevel : MonoBehaviour {

	public Button next;
	public GameObject messagePanel;
	SubmitButtonHandler controller;

	// Use this for initialization
	void Start () {
		
		Button btn = next.GetComponent<Button>();
		btn.onClick.AddListener (NextLevel);

		controller = gameObject.AddComponent<SubmitButtonHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void NextLevel()
	{
		messagePanel.SetActive (false);
	//	controller.ClearAll ();
	}

}
