using System.Collections.Generic;

public class ReviveChoice : Event {
	
	public ReviveChoice () {}
	
	public override void Enact () {
		text = "This barren room's speaker lets an unknown voice reach you \"Honorable adventurers, doth thou wish the power of lame electric device"
    		+ " or the power of PIZZA?\" You know this person's alignment";
		Character[] fight = new Character[] {new SecurityHologram()};
		fight[0].SetPassive(new ForceField(fight[0])); fight[0].GainEvasion(40); fight[0].GainDexterity(2);
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Defibrilator()}, "A defibrilator drops"
		    + " through the loudspeaker. You hear faint chuckling, but it might just be internal")}));
		optionText1 = "Choose the lame electric device";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Pizza()}, "A pizza drops "
		    + "through the loudspeaker. You don't feel any more powerful")}));
		optionText2 = "Choose the pizza";
		if (Party.BagContains(new Pizza())) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Defibrilator(), new Automatic(), new Sword()},
			    "\"WHAAAAT?\" For some reason, the person on the other side dumps the lame electric device and their weapons down the loudspeaker" 
				+ " \"Use the power welllllll.\"")}));
			optionText3 = "Pizza: I already have the power";
		}
		if (Party.ContainsQuirk(new Berserk(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "Item", new object[] {new Item[] {new Defibrilator(), new Pizza()}}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new PizzaCultist()}, 
			    Party.members[Party.ContainsQuirk(new Berserk(null))].ToString() + " throws the operating table at the loudspeaker." 
			    + " The resident cultist falls to the floor.")}));
			optionText4 = "Berserk: Attack the cultist";
		}
	}
}