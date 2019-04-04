using System.Collections.Generic;

public class LaserGallery : Event {
	
	public LaserGallery () {}
	
	public override void Enact () {
		text = "You need to get through an art gallery to progress deeper into the art building. Just like in the movies, you can see a"
		    + " network of lasers scattered across the room, prepared for any intruders";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Escape"));
		optionText1 = "Find another way around";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		    Event fail = new Event();
		    fail.text = "You are right in the middle of the room, when someone slips on an old piece of pizza and falls into multiple lasers."
	    	    + " The paintings spin around revealing flamethrowers. The party is burned multiple times as they dash to the other side";
    		fail.options1 = new LinkedList<TimedMethod>();
		    fail.options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {6}));
			fail.options1.AddLast(new TimedMethod("Resolve"));
	    	fail.optionText1 = "6 damage to party";
    		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {fail}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Everyone is very careful, and you cross the room without "
		    	+ "triggering the trap")}));
		}
		optionText2 = "Sneak through the web";
		if (Party.PartyContains(new AerospaceEngineer()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new USB()}, Party.members[
			    Party.PartyContains(new AerospaceEngineer())].ToString() + " shoots out all the cameras in the room." 
				+ " For some reason this doesn't trigger the trap, and one of them dropped a USB drive")}));
			optionText3 = "Aerospace Engineer: Use the drone to disable the lasers";
		}
		if (Party.ContainsQuirk(new Ninja(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.ContainsQuirk(new Ninja(null))}));
			options4.AddLast(new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 1}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.ContainsQuirk(new Ninja(null))].ToString() + " shows the party how to get through the room by example, "
				+ " and feels like flipping around the room multiple times made them more dextrous (dexterity + 1)")}));
			optionText4 = "Ninja: Teach the party parkour";
		}
	}
}