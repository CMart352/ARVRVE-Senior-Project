using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksRotator : MonoBehaviour
{
    private bool rotateClockWise = false;

    public GameObject rotatingBlocks;

	// Use this for initialization
	void Start () {
        rotatingBlocks = GetComponent<GameObject>();
	}

	public void Rotate() {
        rotateClockWise = true;
	}


	// Update is called once per frame
	public void Update () {
		if (rotateClockWise && (transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0))
		{
			transform.Rotate(0, 0, -1);
		}
	}
}
