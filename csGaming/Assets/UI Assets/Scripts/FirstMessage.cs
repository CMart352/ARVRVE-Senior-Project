using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMessage : MonoBehaviour {

	public Button exitBtn;
	public Button exitBtn1;
	public Button exitBtn2;
	public Button exitBtn3;
	public Button exitBtn4;
	public Button exitBtn5;
	public Button exitBtn6;
	public GameObject welcomeImage;
	public GameObject tipsNo1;
	public GameObject tipsNo2;
	public GameObject tipsNo3;
	public GameObject tipsNo4;
	public GameObject tipsNo5;
	public GameObject tipsNo6;

	// Use this for initialization
	void Start () {
		Button exit = exitBtn.GetComponent<Button>();
		exit.onClick.AddListener(ExitMessage);

		Button exit1 = exitBtn1.GetComponent<Button>();
		exit1.onClick.AddListener(ExitMessage1);

		Button exit2 = exitBtn2.GetComponent<Button>();
		exit2.onClick.AddListener(ExitMessage2);

		Button exit3 = exitBtn3.GetComponent<Button>();
		exit3.onClick.AddListener(ExitMessage3);

		Button exit4 = exitBtn4.GetComponent<Button>();
		exit4.onClick.AddListener(ExitMessage4);

		Button exit5 = exitBtn5.GetComponent<Button>();
		exit5.onClick.AddListener(ExitMessage5);

		Button exit6 = exitBtn6.GetComponent<Button>();
		exit6.onClick.AddListener(ExitMessage6);


		welcomeImage.SetActive(true); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ExitMessage()
	{
		welcomeImage.gameObject.SetActive(false); 
		tipsNo1.gameObject.SetActive(true); 
	}

	void ExitMessage1()
	{
		tipsNo1.gameObject.SetActive(false); 
		tipsNo2.gameObject.SetActive(true); 
	}

	void ExitMessage2()
	{
		tipsNo2.gameObject.SetActive(false); 
		tipsNo3.gameObject.SetActive(true); 
	}

	void ExitMessage3()
	{
		tipsNo3.gameObject.SetActive(false); 
		tipsNo4.gameObject.SetActive(true); 
	}

	void ExitMessage4()
	{
		tipsNo4.gameObject.SetActive(false); 
		tipsNo5.gameObject.SetActive(true); 
	}

	void ExitMessage5()
	{
		tipsNo5.gameObject.SetActive(false); 
		tipsNo6.gameObject.SetActive(true); 
	}

	void ExitMessage6()
	{
		tipsNo6.gameObject.SetActive(false); 
	}

}
