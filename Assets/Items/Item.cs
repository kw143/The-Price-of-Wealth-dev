using System.Collections;
using System.Collections.Generic;

public class Item {
	protected string name;
	protected string description;
	//Does the player choose someone to use the item on?
	public bool selects;
	//Number of items you must trade for this in the shop
	public int price;
	public bool usableOut;
	
	public Item() {
		usableOut = false;
		//price = 2;
	}
	
	//Called upon use of the item in combat, without selecting a character
	public virtual TimedMethod[] Use () {
		return new TimedMethod[0];
	}
	
	public string GetName () {
		return name;
	}
	
	public string GetDescription () {
	    return description;	
	}
	
	//Called upon use of the item outside of combat. If it can't be used, ignore this
	public virtual void UseOutOfCombat(int i){Party.AddItem(this);}
	
	//Called upon if the item selects a party member, and i is the index in Party.members
	public virtual TimedMethod[] UseSelected (int i) {return new TimedMethod[0];}
	
}