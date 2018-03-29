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
		/*Only delete those buttons that were instantiating in order to avoid deleting
		 * the original prefab */
		if (commandPrefab.name == "Command(Clone)") {
			Debug.Log ("You have clicked the delete button");
			Destroy (this.gameObject);
		}/*If it is a prefab then make */
		else {
			GameObject commandPref = Instantiate (commandPrefab) as GameObject;
			Destroy (this.gameObject);
		}
	}
}
