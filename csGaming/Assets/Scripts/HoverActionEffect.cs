using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverActionEffect : MonoBehaviour {


	public AudioSource AudioTrack;  
	public AudioClip hoverClip;

//	public Texture2D cursor;



	// Use this for initialization
	void Start () {
		AudioTrack = GetComponent<AudioSource>();
			//	cursor.Resize (15, 15);
	}




	public void hoverEffect(){

		AudioTrack.PlayOneShot (hoverClip ,1.9F);
	}

	/*public void handOnHover(){


		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);

	}


	public void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}*/
}