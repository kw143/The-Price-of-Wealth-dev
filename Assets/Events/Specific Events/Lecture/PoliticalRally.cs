using System.Collections.Generic;

public class PoliticalRally: Event {
	
	public PoliticalRally () {}
	
	public override void Enact () {
		text = "This lecture hall is occupied by an extremist faction of the meepmeep political party. The room is filled with screams"
		    + " wishing the destructive fall of the googoo party";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new PoliticalScientist(), 
	        new MathMajor(), new PizzaCultist(), new BusinessMajor()}, "They ask you for the password. You don't know the password")}));
		optionText1 = "Fake support for the meepmeep";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "Battle", new object[] {new Character[] {new PoliticalScientist(), 
    		new MathMajor(), new PizzaCultist(), new BusinessMajor()}}));
		optionText2 = "Condemn the extremists";
		if (Party.PartyContains(new PoliticalScientist()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new VotedBadge()},
			    Party.members[Party.PartyContains(new PoliticalScientist())].ToString() + " points vaguely at the hoard accusing" 
				+ " no one in particular of chanting incorrectly. As the meepmeep extremists turn on each other, one walks up and gives you a "
				+ "badge")}));
			optionText3 = "Political Science Major: Expose a sleeper agent";
		}
		if (Party.PartyContains(new CSMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "GainSP", new object[] {8}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.PartyContains(new CSMajor())].ToString() + " messes with the lights a little." 
			    + " The meepmeep bow to you, revering you as their chosen leader. Don't ask why (SP + 8)")}));
			optionText4 = "CS Major: Cause the lights to flicker";
		}
	}
}