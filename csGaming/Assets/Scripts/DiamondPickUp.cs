using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DiamondPickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject diamond;
	ContinueToLevel2 level2;


	// Use this for initialization
	void Start () {

		level2 = GetComponent<ContinueToLevel2> ();
	}

    static void DoBeep()
    {
        EditorApplication.Beep();
    }

	/* Player picks up the key */
    private void OnTriggerEnter(Collider coll)
    {
		coll = GetComponent<Collider> ();

        if(coll.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
			print ("Key has been picked up");
			level2.displayPopUp ();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            DoBeep();
            diamond.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
