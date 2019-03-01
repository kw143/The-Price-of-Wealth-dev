using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    
	public GameObject screen;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void PauseGame () {
		screen.SetActive(false);
		gameObject.SetActive(true);
	}
	
	public void Play () {
		screen.SetActive(true);
		gameObject.SetActive(false);
	}
	
	public void Quit () {
		SceneManager.LoadScene("GameOver");
	}
}
