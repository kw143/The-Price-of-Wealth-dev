using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScore : MonoBehaviour {

    public Text total;
	public Text components;
	// Use this for initialization
	void Start () {
		Score.CalculateWin();
		total.text = "Score: " + Score.score.ToString();
		components.text = "Victories Bonus: " + Score.victories.ToString() + " * 10\nDungeon Bonus: " + Score.clears.ToString() + " * 50\nTime Bonus:"
		    + (100 - Time.timeUnit).ToString() + " * 20\n" + "Win Bonus: 1000";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
