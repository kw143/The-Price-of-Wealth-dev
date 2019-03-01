using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class GameAudio : MonoBehaviour {
	
	Queue<string> names;
    Queue<int> delays;
    string next;
    int delay;
    
	void Start () {
	    names = new Queue<string>();
        delays = new Queue<int>();		
	}
	
    void Update () {
        if (delay > 0) {
			delay--;
		} else {
			if (next != null) {
			    gameObject.transform.Find(next).gameObject.GetComponent<AudioSource>().Play();
			    next = null;
			}
		    if (names.Count > 0) {
				delay = delays.Dequeue();
				next = names.Dequeue();
			}
		}
    }	
	
	public void Play(string name) {
		gameObject.transform.Find(name).gameObject.GetComponent<AudioSource>().Play();
	}
	
	public void PlayAfter(string name, int frames) {
		names.Enqueue(name);
		delays.Enqueue(frames);
	}
	
	public void PlayRandom(string[] names) {
		System.Random rng = new System.Random();
		int num = rng.Next(names.Length);
		Play(names[num]);
	}
	
	public void PlayNumbered(string name, int lower, int upper) {
		string[] names = new string[upper - lower + 1];
		int j = 0;
		for (int i = lower; i <= upper; i++) {
			names[j] = name + i.ToString();
			j++;
		}
		PlayRandom(names);
	}
	
	public void PlayAmount(string name, int amount) {
		PlayNumbered(name, 1, amount);
	}
	
	public void InitiateMusic() {
		string track = "BattleTheme1";
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetChampion()) {
				if (c.GetType().Equals(new Villain().GetType())) {
					track = "FinalBoss";
					break;
				}
				track = "MiniBoss";
			}
		}
		Play(track);
	}
}