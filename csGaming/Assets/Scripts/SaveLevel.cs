using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour {

	public void saveLevel() {
		string level = SceneManager.GetActiveScene().name;
		Debug.Log (level);

		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("SAVE_LEVEL")
			.SetEventAttribute ("PATH", level)
			.Send ((response) => {
				if (!response.HasErrors) {
					Debug.Log("Level saved successfully");
				}
				else {
					Debug.Log("Error " + response.Errors.JSON.ToString());
				}
		});

	}
}
