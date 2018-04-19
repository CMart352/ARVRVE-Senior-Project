using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLoopPanel : MonoBehaviour {

	public GameObject loopPanel;
	public Button repeat;

	// Use this for initialization
	void Start () {
		loopPanel.SetActive (false);

		Button repeatInstance = repeat.GetComponent<Button> ();
		repeatInstance.onClick.AddListener (Display);

	}

	void Display()
	{
		loopPanel.SetActive (true);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
