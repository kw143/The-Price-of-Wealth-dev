using System.Collections.Generic;

public class FoodStand : Event {
	
	public FoodStand () {}
	
	public override void Enact () {
		text = "Someone has left a note at a hot-dog stand that reads \"Free food :). Please take only 1\" There's quite a bit of food here";
		Character[] enemies = new Character[] {new BusinessMajor(), new FootballPlayer(), new MathMajor(), new MusicMajor()};
		enemies[0].SetRecruitable(false); enemies[1].SetRecruitable(false); enemies[2].SetRecruitable(false); enemies[3].SetRecruitable(false);
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Item", new object[] {new Item[] {new Pizza()}}));
		optionText1 = "Take a piece (obviously a pizza)";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		Event trap = new Event();
		trap.text = "As you greedily take food, you trigger a trap and a large boulder rolls down the stands. Your party tires themselves out"
		    + " escaping the boulder (-2 power), AND the food stand was destroyed. Greed is bad";
		trap.options1 = new LinkedList<TimedMethod>();
		trap.options1.AddLast(new TimedMethod(0, "AllStatChange", new object[] {"GainPower", -2}));
		trap.optionText1 = "Lame";
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {trap}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(
			    new Item[] {new Pizza(), new ProteinBar(), new Pizza(), new Donut(), new Pizza()}, "The ends justify the means?")}));
		}
		optionText2 = "Take it all";
		if (Party.PartyContains(new MechanicalEngineer()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Wire(), new Oil(), new USB()},
			    Party.members[Party.PartyContains(new MechanicalEngineer())].ToString() + " breaks apart the broken hot-dog creation device."
				+ " Incidentally someone had wired a trap to a large boulder, but your bag wouldn't fit it")}));
			optionText3 = "Mechanical Engineer: Reverse engineer the food stand";
		}
		if (Party.ContainsQuirk(new Ill(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.ContainsQuirk(new Ill(null))}));
			options4.AddLast(new TimedMethod(0, "ChangeQuirk", new object[] {new Vaccinated(null)}));
			options4.AddLast(new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", 3}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.ContainsQuirk(new Ill(null))].ToString() + " is now vaccinated, gaining 3 max HP")}));
			optionText4 = "Ill: Take the cure to their sickness";
		}
	}
}