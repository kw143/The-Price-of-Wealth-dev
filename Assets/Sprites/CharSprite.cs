﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSprite : MonoBehaviour {
    
	public Vector3 moveTo;
	public int defaultX;
	public int defaultY;
	public Image healthBar;
	public Text charText;
	public int slot;
	public bool player;
	static CharSprite displaced;
	static bool leadFirst;
	static int storedX;
	static int storedY;
	Queue<string> backlog;
	int delay;
	
	// Use this for initialization
	void Start () {
		if (player && slot == Party.playerSlot - 1) {
			gameObject.transform.localPosition = new Vector3(-350, 60, 1);
			if (displaced != null) {
				displaced.gameObject.transform.localPosition = new Vector3(defaultX, defaultY, 1);
				displaced.moveTo = displaced.gameObject.transform.localPosition;
				displaced = null;
			} else {
				leadFirst = true;
				storedX = defaultX;
				storedY = defaultY;
			}
		} else if (slot == 0) {
			if (leadFirst) {
				gameObject.transform.localPosition = new Vector3(storedX, storedY, 1);
				leadFirst = false;
			} else {
			    displaced = this;
			}
		}
		gameObject.transform.localPosition = new Vector3(defaultX, defaultY, 1);
		moveTo = gameObject.transform.localPosition;
		backlog = new Queue<string>();
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveTo != gameObject.transform.localPosition) {
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 
			    System.Math.Max(System.Math.Min(5, moveTo.x - gameObject.transform.localPosition.x), -5),
				gameObject.transform.localPosition.y + System.Math.Max(System.Math.Min(5, moveTo.y - gameObject.transform.localPosition.y), -5),
				gameObject.transform.localPosition.z + System.Math.Max(System.Math.Min(5, moveTo.z - gameObject.transform.localPosition.z), -5));
		}
		if (delay == 20) {
			charText.text = "";
		} else if (delay == 0 && backlog.Count > 0) {
			charText.text = backlog.Dequeue();
			delay = 80;
		}
		if (delay > 0) {
			delay--;
		}
		if (player && Party.members[slot] != null) {
		    healthBar.transform.localScale = new Vector3((float)Party.members[slot].GetHealth() / (float)Party.members[slot].GetMaxHP(), 1, 1);
			healthBar.transform.localPosition = new Vector3(-30 + (30 * (float)Party.members[slot].GetHealth() / (float)Party.members[slot].GetMaxHP()),
			    healthBar.transform.localPosition.y, 0);
		} else if (Party.enemies[slot] != null) {
			healthBar.transform.localScale = new Vector3((float)Party.enemies[slot].GetHealth() / (float)Party.enemies[slot].GetMaxHP(), 1, 1);
			healthBar.transform.localPosition = new Vector3(-30 + (30 * (float)Party.enemies[slot].GetHealth() / (float)Party.enemies[slot].GetMaxHP()),
			    healthBar.transform.localPosition.y, 0);
		}
	}
	
	public void Log (string s) {
		backlog.Enqueue(s);
	}
}
