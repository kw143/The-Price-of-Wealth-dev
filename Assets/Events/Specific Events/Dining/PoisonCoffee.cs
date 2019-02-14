using System.Collections.Generic;

public class PoisonCoffee : Event {
	
	public PoisonCoffee () {}
	
	public override void Enact () {
		text = "There are 2 mugs of coffee sitting on a table, but one chair is occupied by an incredibly suspicious man. "
		    + "Someone feels compelled to sit across from him";
		Event success = new Event();
		success.text = "The coffee is perfectly fine. The suspicious person drank from his cup and immediately keeled over";
		success.options1 = new LinkedList<TimedMethod>();
		success.options1.AddLast(new TimedMethod(0, "StatusChange", new object[] {"Coffee", null}));
		success.optionText1 = "...";
		Event failure = new Event();
		failure.text = "The coffee was poisoned! The suspicious person drinks from their mug and readies pizzas";
		failure.options1 = new LinkedList<TimedMethod>();
		failure.options1.AddLast(new TimedMethod(0, "StatusChange", new object[] {"Poison", 4}));
		Character[] cultist = new Character[] {new PizzaCultist()};
		cultist[0].status.Coffee();
		failure.options1.AddLast(new TimedMethod(0, "Battle", new object[] {cultist}));
		failure.optionText1 = "...fight...";
		Event e = new Event();
		e.text = "The man points to each mug, and then makes a drinking gesture. This reminds you of something";
		e.options1 = new LinkedList<TimedMethod>();
		e.optionText1 = "The left mug";
		e.options2 = new LinkedList<TimedMethod>();
		e.optionText2 = "The right mug";
		if (new System.Random().Next(2) == 0) {
			e.options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {success}));
			e.options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {failure}));
		} else {
			e.options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {failure}));
			e.options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {success}));
		}
		e.options3 = new LinkedList<TimedMethod>();
		e.options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new PizzaCultist()},
		    "While avoiding the flying table, the suspicious person's disguise is ruined, and he prepares his pizzas. "
			+ "The content of the mugs are lost forever")}));
		e.optionText3 = "Flip the table";
		if (Party.PartyContains(new ChemistryMajor()) >= 0) {
			e.options4 = new LinkedList<TimedMethod>();
			e.options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {success}));
			e.optionText4 = "Chemistry Major: point out the poisoned mug";
		}
		
		options1 = new LinkedList<TimedMethod>();
		options1.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {0}));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {e}));
		optionText1 = Party.members[0].ToString();
		if (Party.members[1] != null) {
		    options2 = new LinkedList<TimedMethod>();
		    options2.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {1}));
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {e}));
		    optionText2 = Party.members[1].ToString();
		}
		if (Party.members[2] != null) {
		    options3 = new LinkedList<TimedMethod>();
		    options3.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {2}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {e}));
		    optionText3 = Party.members[2].ToString();
		}
		if (Party.members[3] != null) {
		    options4 = new LinkedList<TimedMethod>();
		    options4.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {3}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {e}));
		    optionText4 = Party.members[3].ToString();
	    }
	}
}