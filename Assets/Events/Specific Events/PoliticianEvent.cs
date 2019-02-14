using System.Collections.Generic;

public class PoliticianEvent : Event {
	
	public PoliticianEvent() {
		text = "It's the politician";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num;
		Character[] enemies = new Character[] {new Politician()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	    options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new DefeatedPolitician()})); 
	}
}