using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class removeCommand : MonoBehaviour {

	public Button removeSign;
	public GameObject commandPrefab;

	// Use this for initialization
	void Start () {
		
		Button deteleButton = removeSign.GetComponent<Button>();
		removeSign.onClick.AddListener(Remove);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Remove()
	{
		Destroy (commandPrefab);
	}
}
