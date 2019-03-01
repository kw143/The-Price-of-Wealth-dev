using System.Collections.Generic;

public class OfficeHours : Event {
	
	public OfficeHours () {}
	
	public override void Enact () {
		text = "A student is in a classroom with an asleep and possessed professor. The professor must have been about to write"
		    + " the answer to something before she fell asleep, and the student won't leave the room without it";
		Event ally = new Event();
		ally.text = "With the situation resolved, the student offers to join you";
		ally.options1 = new LinkedList<TimedMethod>();
		ally.options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {new MathMajor()}}));
		ally.optionText1 = "Recruit the math major";
		ally.options2 = new LinkedList<TimedMethod>();
		ally.options2.AddLast(new TimedMethod("Resolve"));
		ally.optionText2 = "Refuse";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {ally}));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new Instructor()},
			"You wake up the professor, who finishes writing the answer. But because she's possessed she attacks you right after")}));
		optionText1 = "Wake up the instructor";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		    options2.AddLast(new TimedMethod(0, "Apathize", new object[] {2}));
		    options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("\"How can you spend tax-money on college if you"
		    	+ " won't discover the secrets of the universe?...\" Your party feels apathetic")}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The student listens to you and claims they know"
		    	+ " the answer anyway", ally)}));
		}
		optionText2 = "Reason with the student";
		if (Party.BagContains(new Pencil())) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {ally}));
			optionText3 = "Pencil: Let the student work the problem while they travel with you";
		}
		if (Party.PartyContains(new EnglishMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {ally}));
			optionText4 = "English Major: Read the textbook to reach the answer";
		}
	}
}