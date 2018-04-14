using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpaceSound : MonoBehaviour {

	public AudioSource AudioTrack;  


	public AudioClip hoverClip;

	//sound for gameButtons
	public AudioClip clickClip;

	//sound for PanelSolutionButtons
	public AudioClip submitButtonClip;


	public AudioClip clearButtonClip;

	public AudioClip clickonPause; 
	public AudioClip clickonquit;



	// Use this for initialization
	void Start () {
		AudioTrack = GetComponent<AudioSource>();
	}


	public void clickEffect(){

		if (QuitGame.isPauseMenuInactive == true) {
			AudioTrack.PlayOneShot (clickClip, 0F);
		} else {
			AudioTrack.PlayOneShot (clickClip, 1.9F);
		}
	}

	public void clickSubmitEffect(){
		if(QuitGame.isPauseMenuInactive == true){
		   AudioTrack.PlayOneShot (submitButtonClip,0F);
		} else{
			AudioTrack.PlayOneShot (submitButtonClip,1.9F);
		}
	}

	public void clickClearEffect(){
		if (QuitGame.isPauseMenuInactive == true) {

			AudioTrack.PlayOneShot (clearButtonClip, 0F);
		} else {
			AudioTrack.PlayOneShot (clearButtonClip, 1.9F);
		}
	}

	public void hoverEffect(){

		if (QuitGame.isPauseMenuInactive == true) {
			AudioTrack.PlayOneShot (hoverClip, 0F);
		} else {
			AudioTrack.PlayOneShot (hoverClip, 1.9F);
		}
	}



	/*Function on Pause Menu*/

	public void hoverOnPause(){

		if (QuitGame.isPauseMenuInactive == true) {
			AudioTrack.PlayOneShot (hoverClip, 1.9F);
		} else {
			AudioTrack.PlayOneShot (hoverClip, 0F);
		}
	}


	public void clickOnPause(){
		
		if (QuitGame.isPauseMenuInactive == true) {
			AudioTrack.PlayOneShot (clickonPause, 1.9F);
		} else {
			AudioTrack.PlayOneShot (clickonPause, 0F);
		}
	}


	public void clickOnQuit(){

		if (QuitGame.isPauseMenuInactive == true) {
			AudioTrack.PlayOneShot (clickonquit, 1.9F);
		} else {
			AudioTrack.PlayOneShot (clickonquit, 0F);
		}
	}

}
