using System.Collections.Generic;

public class MysteryMeat : Event {
	
	public MysteryMeat () {}
	
	public override void Enact () {
		text = "You are about to gather more rations from this buffet line when you remember in the past this was famous for..."
		    + "mystery meat";
		Event meatloaf = new Event();
		meatloaf.text = "Tastes like chicken. You take the rest with you";
		meatloaf.options1 = new LinkedList<TimedMethod>();
		meatloaf.options1.AddLast(new TimedMethod(0, "Item", new object[] {new Item[] {new Meatloaf()}}));
		meatloaf.optionText1 = "Neat";
		Event poison = new Event();
		poison.text = "This was not the best idea";
		poison.options1 = new LinkedList<TimedMethod>();
		poison.options1.AddLast(new TimedMethod(0, "StatusChange", new object[] {"Poison", 4}));
		poison.options1.AddLast(new TimedMethod("Resolve"));
		poison.optionText1 = "Become poisoned";
		options1 = new LinkedList<TimedMethod>();
		optionText1 = "Take it with you";
		options1.AddLast(new TimedMethod(0, "Item", new object[] {new Item[]{new MysteryGoo()}}));
		options2 = new LinkedList<TimedMethod>();
		optionText2 = "Sample the meat to see if it's edible";
		TimedMethod[] meatResults = new TimedMethod[1];
		if (new System.Random().Next(2) == 0) {
			meatResults[0] = new TimedMethod(0, "CauseEvent", new object[] {meatloaf});
		} else {
			meatResults[0] = new TimedMethod(0, "CauseEvent", new object[] {poison});
		}
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will eat the meat?", meatResults)}));
		if (Party.PartyContains(new CulinaryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
		    optionText3 = "Culinary Major: Purify the food";
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new CulinaryMajor())].ToString() + " cooks the food very thouroughly", meatloaf)}));
		}
		if (Party.PartyContains(new ChemistryMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
    		optionText4 = "Chemistry Major: Use the diseased meat to create poisons";
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new ToxicSolution(), new ToxicSolution()},
			    Party.members[Party.PartyContains(new ChemistryMajor())].ToString() + " put all the meat in a blender, and said they're done")}));
		}
	}
}