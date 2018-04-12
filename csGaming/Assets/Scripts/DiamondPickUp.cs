using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DiamondPickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject diamond;
	ContinueToLevel2 level2;
	Timer clock;
	SubmitButtonHandler handler;

	private string currentLevel;
	private int attempts;
	private double timeToComplete;

	public static bool playClip; //flag to play success audio clip 

	// Use this for initialization
	void Start () {

		level2 = GetComponent<ContinueToLevel2> ();
		handler = GetComponent<SubmitButtonHandler> ();

		print ("Diamond start");

	}

    static void DoBeep()
    {
        EditorApplication.Beep();
    }

	/* Player picks up the key */
    private void OnTriggerEnter(Collider coll)
    {
		//coll = GetComponent<Collider> ();

        if(coll.gameObject == player)
        {
			playClip = true;

			if (clock == null && GetComponent<Timer> () != null) {
				clock = GetComponent<Timer> ();
			}
				
			currentLevel = SceneManager.GetActiveScene().name;
			attempts = handler.getAttempts ();
			timeToComplete = clock.getTotalSeconds();

			string path = currentLevel + ".Attempts.KeysCollected.Time";

			UpdateProgress.ProgressUpdate (path, attempts, timeToComplete);

           // DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up 1");
			level2.displayPopUp ();
        }
    }

    private void OnTriggerStay(Collider coll)
    {
		//coll = GetComponent<Collider> ();
        if (coll.gameObject == player)
        {
			playClip = true;

			print ("On trigger stay");
            //DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up 2");
			level2.displayPopUp ();
        }
    }
    
	private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
			playClip = true;

			print ("On trigger exit");
            //DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up 3");
			level2.displayPopUp ();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
