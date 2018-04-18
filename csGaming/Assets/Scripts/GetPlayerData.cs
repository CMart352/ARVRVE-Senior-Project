using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;

public class GetPlayerData : MonoBehaviour
{
    public static void GetData(int attempts, int time, int numKeys)
    {

        new GameSparks.Api.Requests.LogEventRequest()
        .SetEventKey("UPDATE_PLAYER_DATA")
        .SetEventAttribute("ATTEMPTS", attempts)
        .SetEventAttribute("TIME", time)
        .SetEventAttribute("KEYS", numKeys)
        .Send((response) => {
            if (!response.HasErrors)
            {
                Debug.Log("player updated successfully");
            }
            else
            {
                Debug.Log("res: " + response.Errors.JSON.ToString());
            }
        });
    }

}