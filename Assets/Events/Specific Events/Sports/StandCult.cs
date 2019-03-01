using System.Collections.Generic;

public class StandCult : Event {
	
	public StandCult () {}
	
	public override void Enact () {
		text = "About a dozen individuals are just sitting in the stands, uttering RAH RAH RAH. There is nothing on the field";
		Character[] enemies = new Character[] {new PizzaCultist(), new PizzaCultist(), new PizzaCultist(), new PizzaCultist()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(enemies, "They notice you and change their tune to"
		    + " JOOOIIIIN USSSS EAAAT THE PIIIZZAAA")}));
		optionText1 = "Talk to them";
		if (Party.PartyContains(new BusinessMajor()) >= 0) {
			options2 = new LinkedList<TimedMethod>();
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Pizza(), new Pizza(), new Pizza()}, 
			    Party.members[Party.PartyContains(new BusinessMajor())].ToString() 
				+ " \"borrows\" the supplies around the group. They're all pizzas for some reason")}));
			optionText2 = "Business Major: Take all their stuff";
		}
		if (Party.PartyContains(new MathMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "GainSP", new object[] {10}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new MathMajor())].ToString() + " has plenty of time to prepare calculations."
				+ " They then walk over to the group and pushes one, making them all fall down the stands."
				+ " Your SP increased by 10, but any pizzas the group was holding got crushed. Apparently they were cultists")}));
			optionText3 = "Math Major: Plan a domino effect";
		}
		if (Party.ContainsQuirk(new SleepDeprived(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.ContainsQuirk(new SleepDeprived(null))}));
			options4.AddLast(new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", 5}));
			options4.AddLast(new TimedMethod(0, "SpendTime", new object[] {3}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.ContainsQuirk(new SleepDeprived(null))].ToString() + " is lulled by the chanting and joins, falling into a trance."
				+ " After a long time, they wake up feeling healthier (max hp + 5)")}));
			optionText4 = "Sleep Deprived: Join the chant";
		}
	}
}