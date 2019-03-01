using System.Collections.Generic;

public class FacultyCoven : Event {
	
	public FacultyCoven () {}
	
	public override void Enact () {
		text = "This office reeks of suspicion. Letters between faculty members and the smell of coffee run rampant";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new ItemEvent(new Item[] {new Coffee(), new Sword()},
    		"With the coven taken care of, you can find a little bit of coffee left as well as someone's rapier")}));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new Instructor(), 
	        new Researcher(), new Cop(), new Instructor()}, "You haven't been looking long with a group of faculty walks in on you."
			    + " \"INTRUDERS! THEY KNOW TOO MUCH OF OUR COFFEE COVEN! THEY CANNOT ESCAPE NOW!\"")}));
		optionText1 = "Loot the room";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Leave quietly";
		if (Party.PartyContains(new CJMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Coffee(), new Sword()},
			    Party.members[Party.PartyContains(new CJMajor())].ToString() + " realizes this room is home to a coven of instructors" 
				+ " who steal all of the department's coffee. You find where they stash their coffee and persuasion tools, and take what's left")}));
			optionText3 = "Criminal Justice Major: Uncover the room's secrets";
		}
		if (Party.PartyContains(new CulinaryMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Coffee(), new Sword()},
			    Party.members[Party.PartyContains(new CulinaryMajor())].ToString() + " uncovers a secret stash behind the curtain." 
				+ " There is a rapier alongside the coffee. What sorcery is conducted in this place?")}));
			optionText4 = "Culinary Major: Follow the smell to its source";
		}
	}
}