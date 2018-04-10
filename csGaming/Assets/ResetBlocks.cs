using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBlocks : MonoBehaviour {

	public GameObject blocks;


	public void resetBlocks() {
		blocks.transform.rotation = Quaternion.Euler (0, 0, 0);
		print ("blocks " + blocks.transform.rotation);
	}
}
