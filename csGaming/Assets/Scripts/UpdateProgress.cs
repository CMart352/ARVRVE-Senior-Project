using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProgress : MonoBehaviour {

	public static void ProgressUpdate(string path, int attempts, double time){
		new GameSparks.Api.Requests.LogEventRequest()
			.SetEventKey("PROG_UPDATE")
			.SetEventAttribute("PATH", path)
			.SetEventAttribute("ATTEMPTS", attempts)
			.SetEventAttribute("NUM_KEYS", 1)
			.SetEventAttribute("TIME", (long)time)
			.Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Progress updated successfully");
				} else {
					Debug.Log("Error " + response.Errors.JSON.ToString());
				}
			});
	}
}
