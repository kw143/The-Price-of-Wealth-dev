using System.Collections.Generic;

public class CampusTour : Event {
	
	public CampusTour () {}
	
	public override void Enact () {
		text = "A student-led campus tour starts walking by your group, paying no heed";
		Event recruit = new Event();
		recruit.text = "It quickly becomes obvious the student is just acting, and isn't possessed. They could probably use some help";
		recruit.options1 = new LinkedList<TimedMethod>();
		recruit.options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {new EnglishMajor()}}));
		recruit.options1.AddLast(new TimedMethod("Resolve"));
		recruit.optionText1 = "Call for the student";
		recruit.options2 = new LinkedList<TimedMethod>();
		recruit.options2.AddLast(new TimedMethod("Resolve"));
		recruit.optionText2 = "No. Actors are suspicious";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Resolve"));
		optionText1 = "Let the group go";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(2) == 0) {
		    options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {recruit}));
		} else {
			Character[] enemies = new Character[] {new Chef(), new Janitor(), new EnglishMajor()};
			enemies[2].SetRecruitable(false);
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(enemies, "Despite trying to be stealthy,"
			    + " the tour guide slowly turns towards you, saying \"Here lie embarrassments of the institution, taking up your spots."
	        	+   " Whoever is rid of them gets a free scholarship for their child")}));
		}
		optionText2 = "Eavesdrop";
		if (Party.ContainsQuirk(new Average(null)) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {recruit}));
			optionText3 = "Average: blend in to the crowd";
		}
		if (Party.PartyContains(new BusinessMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {
				new ItemEvent(new Item[] {new Smartphone(), new Donut(), new PaperPlane(), new Sanitizer()} ,
				Party.members[Party.PartyContains(new BusinessMajor())].ToString() + " is back before you know it."
		    	+ " The tour guide was ironically talking about the cost of tuition")}));
			optionText4 = "Business Major: Sick, free loot";
		}
	}
}