using System.Collections.Generic;

public class CEOEvent : Event {
	
	public CEOEvent() {
		text = "It's the CEO";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num;
		Character[] enemies = new Character[] {new CEO()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	    options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new DefeatedCEO()})); 
	}
}