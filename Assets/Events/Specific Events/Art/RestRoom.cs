using System.Collections.Generic;

public class RestRoom : Event {
	
	public RestRoom () {}
	
	public override void Enact () {
		text = "This is a storage room, but it's been looted already. It could make a good place to rest, if you have the time";
		options1 = new LinkedList<TimedMethod>();
	    optionText1 = "Take a long break (pass time, 10 healing to party)";
	    options1.AddLast(new TimedMethod(0, "SpendTime", new object[] {5}));
    	options1.AddLast(new TimedMethod(0, "Heal", new object[] {10}));
		options1.AddLast(new TimedMethod("Resolve"));
		options2 = new LinkedList<TimedMethod>();   	
		optionText2 = "Take just a short break (3 healing to party)";
    	options2.AddLast(new TimedMethod(0, "Heal", new object[] {3}));
		options2.AddLast(new TimedMethod("Resolve"));
		if (Party.PartyContains(new MusicMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "AllStatChange", new object[] {"GainPower", 3}));
			options3.AddLast(new TimedMethod(0, "AllStatChange", new object[] {"GainAccuracy", 3}));
			options3.AddLast(new TimedMethod(0, "Heal", new object[] {3}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(new MusicMajor())].ToString()
			    + " performs during the break, raising morale (party power and accuracy +3 next fight, and +3 HP")}));
			optionText3 = "Music Major: put on a show";
		}
		if (Party.PartyContains(new DanceMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.PartyContains(new DanceMajor())}));
			options4.AddLast(new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 1}));
			options4.AddLast(new TimedMethod(0, "Heal", new object[] {3}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(new DanceMajor())].ToString()
			    + " gains 1 dexterity during the rest, and the party got 3 healing")}));
			optionText4 = "Dance Major: Practice dodging even more";
		}
	}
}