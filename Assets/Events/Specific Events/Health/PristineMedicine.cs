using System.Collections.Generic;

public class PristineMedicine : Event {
	
	public PristineMedicine () {}
	
	public override void Enact () {
		text = "This small room contains only a small table, and on it is a pristine dexterity potion. Another student is at the other entrance"
		    + " and prepares to dash for the flask when they see your party";
		Character[] recruit = new Character[] {new BusinessMajor()};
		recruit[0].GainDexterity(1);
		options1 = new LinkedList<TimedMethod>();
		if (Party.GetPlayer().GetDexterity() > 3) {
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new DexPotion()}, "Ironically it was a "
			    + "test of speed to acquire something to advance it. Your lead party member was faster than the stranger, and so the item is yours")}));
		} else {
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Ironically it was a test of speed to acquire" 
		    	+ " something to advance it. Your lead party member was not fast enough; the stranger nabs the item and dashes off")}));
		}
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {new Character[] {new Doctor()}}));
		optionText1 = "Get there first";
		options2 = new LinkedList<TimedMethod>();	
		if (new System.Random().Next(2) == 0) {
			Event ally = new Event();
			ally.text = "The stranger downs the potion. "
			    + "Noticing that your group wasn't acting completely selfishly, they offer to join you as a business major";
			ally.options1 = new LinkedList<TimedMethod>();
			ally.options1.AddLast(new TimedMethod(0, "Ally", new object[] {recruit}));
			ally.options1.AddLast(new TimedMethod("Resolve"));
			ally.optionText1 = "Accept";
			ally.options2 = new LinkedList<TimedMethod>();
			ally.options2.AddLast(new TimedMethod("Resolve"));
			ally.optionText2 = "Reject";
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {ally}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The stranger grabs the potion and runs off." 
	   		+ " At least you helped someone, however ungrateful")}));
		}
		optionText2 = "Let the stranger take it";
		if (Party.PartyContains(new PoliticalScientist()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "Ally", new object[] {recruit}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.PartyContains(new PoliticalScientist())].ToString() + " speaks to the stranger. The stranger seems to be versed" 
				+ " in diplomacy as well. They reach an agreement: The stranger gets the potion but will join the party.")}));
			optionText3 = "Political Science Major: Use Diplomacy";
		}
		if (Party.PartyContains(new MathMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new DexPotion()},
			    Party.members[Party.PartyContains(new MathMajor())].ToString() + " Tries calculating how to flip the table to " 
			    + " throw the potion into your backpack. However, they are only 90% complete when the stranger grabs the potion. They"
				+ " flip the table anyway and the error is offset by human being attached to the potion. The stranger is unconcious")}));
			optionText4 = "Math Major: Calculate theta";
		}
	}
}