using System.Collections.Generic;

public class BuzzBot : Event {
	
	public BuzzBot () {}
	
	public override void Enact () {
		text = "The heating of circuits is heard at the far corner of this dark room as you see a robotic version of your school's mascot."
		    + " ID cards are strewn about the place. The bot powers up its LASER GUN";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {8}));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {reward}));
		optionText1 = "What is behind it? (8 damage to party)";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "DamageAll", new object[] {2}));
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Scatter and run! (2 damage to party)";
		if (Party.PartyContains(new CJMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(new CJMajor())].ToString() 
			    + " electrocutes the robot with the tazer before it can fire", reward)}));
			optionText3 = "Criminal Justice Major: fire first";
		}
		if (Party.BagContains(new Exam())) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You present the exam to the robot. Seeing the perfect score,"
		    	+ " it powers down, allowing access to the room behind it", reward)}));
			optionText4 = "Exam: present the exam as proof of intelligence";
		}
	}
}