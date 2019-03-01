using System.Collections.Generic;

public class HallwaySkater : Event {
	
	public HallwaySkater () {}
	
	public override void Enact () {
		text = "You turn the corner to find someone SKATING IN THE HALLS towards you at high speed";
		options1 = new LinkedList<TimedMethod>();
	    if (Party.GetPlayer().GetStrength() > 2) {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Your lead has enough strength to cause the skater"
			    + " to fly over your heads into the wall. Good riddance")}));
		} else {
			Event strBad = new Event();
			strBad.text = "Your lead doesn't have enough strength to stop the skateboard which crashes with its rider into the party";
			strBad.options1 = new LinkedList<TimedMethod>();
			strBad.options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {3}));
			strBad.options1.AddLast(new TimedMethod("Resolve"));
			strBad.optionText1 = "3 damage to party";
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {strBad}));
		}
		optionText1 = "Flip the skateboard";
		options2 = new LinkedList<TimedMethod>();
	    if (Party.GetPlayer().GetDexterity() > 2) {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Your lead's dexterity keeps the team out of the way."
			    + " As karma, the skater crashes into the wall")}));
		} else {
			Event strBad = new Event();
			strBad.text = "Your lead isn't very dextrous, and gets hit by the skater into the rest of the party";
			strBad.options1 = new LinkedList<TimedMethod>();
			strBad.options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {3}));
			strBad.options1.AddLast(new TimedMethod("Resolve"));
			strBad.optionText1 = "3 damage to party";
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {strBad}));
		}
		optionText2 = "Dodge the skater";
		if (Party.PartyContains(new HistoryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new HistoryMajor())].ToString() + " nails the skater with their shield, keeping the party safe.")}));
			optionText3 = "History Major: Throw your shield";
		}
		if (Party.PartyContains(new DanceMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(
			    new DanceMajor())].ToString() + " pulls the entire party around the criminal. The skater is distracted and crashes")}));
			optionText4 = "Dance Major: Perform a party-wide flip";
		}
	}
}