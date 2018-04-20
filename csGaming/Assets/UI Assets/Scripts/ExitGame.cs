using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {

	public Button exit;
	// Use this for initialization
	void Start () {
		Button exitBtn = exit.GetComponent<Button> ();
		exitBtn.onClick.AddListener (Exit);
	}
	void Exit()
	{
		Application.Quit ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
