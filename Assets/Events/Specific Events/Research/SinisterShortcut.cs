using System.Collections.Generic;

public class SinisterShortcut : Event {
	
	public SinisterShortcut () {}
	
	public override void Enact () {
		text = "You wander into a long, dark corridor that looks like it hasn't been kept in years. Papers of unintelligeble scrawl "
		    + " are on the walls. You get a glimpse of a more legible one that has the names of people, listed as test subjects";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new Expirimentor()},
	    	"An old disheveled figure walks out of a door in front of you. \"New rats. Just what I needed\"")}));
		optionText1 = "Go forward";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Escape"));
		optionText2 = "Turn Back";
	}
}