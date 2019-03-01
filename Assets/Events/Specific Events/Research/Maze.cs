using System.Collections.Generic;

public class Maze : Event {
	
	public Maze () {}
	
	public override void Enact () {
		text = "Everything looks the same here. For all you know you're walking in circles. You've seen Dr. Maze's office 4 times now";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new Criminal(), new Janitor(),
		new LabRobot(), new Researcher()}, "In a few minutes you step on a trip wire, slamming the door shut behind you."
		    + " An armed group blocks your way. You hear from the researcher \"I am Dr. Maze. You are now victim #385 of my eeeeevil trap\"")}));
		optionText1 = "Follow the left wall";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "Apathize", new object[] {3}));
		options2.AddLast(new TimedMethod(0, "SpendTime", new object[] {5}));
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Your heart did not help with directions. You spend upwards"
            + " of an hour in these hallways, and by the end of it morale is beginning to drop")}));
		optionText2 = "Follow your heart";
		if (Party.PartyContains(new ChemistryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "SpendTime", new object[] {2}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			Party.PartyContains(new ChemistryMajor())].ToString() 
			    + " reveals a map of the area. It's completely unintelligable, but they seem to know where they're going")}));
			optionText3 = "Chemistry Major: Follow the map you still have";
		}
		if (Party.PartyContains(new CJMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new Researcher()},
			    Party.members[Party.PartyContains(new CJMajor())].ToString() + " has uncovered an evil plan by Dr. Maze and stages an ambush!")}));
			optionText4 = "Criminal Justice Major: Follow a string of evidence against villany!";
		}
	}
}