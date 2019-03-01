public class Passive {
    
	protected string description;
	protected string name;
	protected Character self;
	
	//Always pass in "this" to the constructor
	public Passive(Character c) {self = c;}
	public Passive(){}
	
	//Is called at the start of the round when the character is NOT in the lead
	public virtual TimedMethod[] Check (bool player) {
		return new TimedMethod[0];
	}
	
	//Is called at the start of the round when the charcter is in the lead
	public virtual TimedMethod[] CheckLead (bool player) {
	    return new TimedMethod[0];	
	}
	
	//Currently not used anywhere, but if some external source needs to call the passive with a new method, here it is
	public virtual TimedMethod[] Use (bool player) {
		return new TimedMethod[0];
	}
	
	//Is called at the beginning of the battle or on summon (Check/Checklead is still called on turn 1)
	public virtual TimedMethod[] Initialize (bool player) {
		return new TimedMethod[0];
	}
	
	//Is called when the character reaches 0 hp
	public virtual TimedMethod[] Deactivate (bool player) {
		return new TimedMethod[0];
	}
	
	public string GetName() {return name;}
	public string GetDescription() {return description;}
	public Passive Clone () {return (Passive)this.MemberwiseClone();}
	public void SetSelf(Character c) {self = c;}
	
}