using System.Collections.Generic;

public class AngryAdmin : Event {
	
	public AngryAdmin () {}
	
	public override void Enact () {
		text = "A door by you seems to visibly bulge with the force of shouting within. The voice is saying \"WORTHLESS INCOMPETENT WORM!\"";
		Character[] enemies = new Character[] {new Administrator(), new Instructor()};
		enemies[0].SetQuirk(new Temperamental(enemies[0]));
		options1 = new LinkedList<TimedMethod>();
    	options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Kick open the door!";
		options2 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(3) == 0) {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {
			    new TextEvent("As soon as you clear the door, someone is thrown threw it. Best to keep moving")}));
		} else {
			Event badEvent = new Event();
			badEvent.text = "You try to sneak past, but a desktop computer crashes through the window and hits " +
    			Party.members[Party.playerSlot - 1].ToString();
			badEvent.options1 = new LinkedList<TimedMethod>();
			badEvent.options1.AddLast(new TimedMethod(0, "Damage", new object[] {5}));
			badEvent.options1.AddLast(new TimedMethod("Resolve"));
			badEvent.optionText1 = "Oh no";
			options2.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.playerSlot - 1}));
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {badEvent}));
		}
		optionText2 = "Quickly walk past";
		if (Party.PartyContains(new PoliticalScientist()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new PoliticalScientist())].ToString() + " goes up to the door and whispers something. Moments later, a fully"
			    + " possessed administrator walks out the door and hands them a briefcase", new ItemEvent(new Item[] {new Briefcase(),
			    new Pizza()}, "You see the contents"))}));
			optionText3 = "Political Science Major: Use hidden knowledge of politics";
		}
		if (Party.ContainsQuirk(new Temperamental(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.ContainsQuirk(new Temperamental(null))}));
			options4.AddLast(new TimedMethod(0, "StatChange", new object[] {"GainStrength", 1}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.ContainsQuirk(new Temperamental(null))]
			    + " shouts YOOOOUUUUU ARE THE WORM! The voice behind the door is silenced. "
				+ "This person feels very smug about themself, gaining a point in strength")}));
			optionText4 = "Temperamental: Shout back";
		}
	}
	
}