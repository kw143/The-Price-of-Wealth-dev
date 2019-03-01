using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    
	public GameObject start;
	public GameObject credits;
	public GameObject settings;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OpenCredits () {
		credits.SetActive(true);
		start.SetActive(false);
	}
	 
	public void OpenSettings () {
		settings.SetActive(true);
		start.SetActive(false);
	}
	
	public void ToMain () {
		settings.SetActive(false);
		credits.SetActive(false);
		start.SetActive(true);
	}
}
