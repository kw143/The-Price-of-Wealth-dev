using System.Collections.Generic;

public class GeneralEvent : Event {
	
	public GeneralEvent() {
		text = "It's the general";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num;
		Character[] enemies = new Character[] {new General()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	    options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new DefeatedGeneral()})); 
	}
}