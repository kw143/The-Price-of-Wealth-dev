using System.Collections.Generic;

public class TestEnvironment : Event {
	
	public TestEnvironment () {}
	
	public override void Enact () {
		text = "This lecture hall seems empty...no, it is in a testing environment. If you are seen, it will count as cheating.";
		options1 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		    options1.AddLast(new TimedMethod(0, "GainSP", new object[] {-10}));
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new TeachingAssistant()},
		        " You are discovered by a teaching assistant! You lose 10 sp from nagging and now you have to fight")}));
		} else {
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You sneak out of the testing environment safely")}));
		}
		optionText1 = "Sneak through";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		    options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new LabRobot(),
			    new TeachingAssistant(), new TeachingAssistant(), new Instructor()}, "You make a break for it but the automated doors close as "
		        + "the instructor speaks the magic words. The lecture hall also comes with an anti-cheat robot")}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The TA's walking the room weren't nearly as fast as you")}));
		}
		optionText2 = "Run through very fast";
		if (Party.PartyContains(new PsychMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Pencil(), new Textbook()},
			    Party.members[Party.PartyContains(new PsychMajor())].ToString() + " speaks the forbidden words \"open note.\"" 
				+ " Everyone scrambles to leave and get their notes. In the confusion, you escape and can even take some loot")}));
			optionText3 = "Psychology Major: Incite chaos";
		}
		if (Party.ContainsQuirk(new Procrastinator(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.ContainsQuirk(new Procrastinator(null))].ToString() + " Walks up to the instructor." 
			    + " \"You are too late. You get a zero. Goodbye.\" Your party is escorted from the room")}));
			optionText4 = "Procrastinator: The instructor knows me";
		}
	}
}