using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNexLevel : MonoBehaviour {

	public Button next;

	// Use this for initialization
	void Start () {
		
		Button btn = next.GetComponent<Button>();
		btn.onClick.AddListener (NextLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NextLevel()
	{
		SceneManager.LoadScene ("Level_02");
	}

}
