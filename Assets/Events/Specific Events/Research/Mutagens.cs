using System.Collections.Generic;

public class Mutagens : Event {
	
	public Mutagens () {}
	
	public override void Enact () {
		text = "You find this lab is occupied. Its resident holds up a needle. \"Would you like to have your DNA scrambled for science?"
		    + " Of course there's something in it for you, too: this stick of celery\"";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who is the test subject? (will become unstable)",
		    new TimedMethod[] {new TimedMethod(0, "ChangeQuirk", new object[] {new Unstable(null)}), new TimedMethod(0, "Item", new object[] {
			new Item[] {new Celery()}})})}));
		optionText1 = "Accept!";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Refuse!";
		if (Party.PartyContains(new PsychMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			Party.PartyContains(new PsychMajor())].ToString() 
			    + " cites some book of inhumane activities. The researcher shouts to their peers \"IT'S THE FUZZ! RUN!\"",
				new ItemEvent(new Item[] {new Celery(), new MysteryGoo()}, "After they've fled, your party member reveals to not" 
				    + " actually care about use of the DNA scrambler and invites you to take it with you"))}));
			optionText3 = "Psychology Major: Accuse of immoral expirimentation";
		}
		if (Party.BagContains(new MysteryGoo())) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Celery(), new Celery()},
			    "\"Wow! This is a great insight! You deserve 2 sticks of celery!")}));
			optionText4 = "Mystery Goo: Offer new ingrediants";
		}
	}
}