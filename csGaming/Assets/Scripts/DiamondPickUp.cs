using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DiamondPickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject diamond;
	ContinueToLevel2 level2;
	Timer clock;


	// Use this for initialization
	void Start () {

		level2 = GetComponent<ContinueToLevel2> ();

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
			if (clock == null && GetComponent<Timer> () != null) {
				clock = GetComponent<Timer> ();
			}
				
			print (clock.getTotalSeconds ());
            DoBeep();
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
			print ("On trigger stay");
            DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up 2");
			level2.displayPopUp ();
        }
    }
    
	private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
			print ("On trigger exit");
            DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up 3");
			level2.displayPopUp ();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
