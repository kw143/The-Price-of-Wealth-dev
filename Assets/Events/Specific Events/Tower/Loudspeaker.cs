using System.Collections.Generic;

public class Loudspeaker : Event {
	
	public Loudspeaker () {}
	
	public override void Enact () {
		text = "A voice is heard over the loudspeakers \"Today we are endorsing Our Bucks Coffee. Get yer free samples now.\""
		    + " You're not sure where the voice originates";
		Event fight = new Event();
		fight.text = "You find the room with a barrel of coffee sitting in the corner. The crowd inside is ready to defend it";
		Character[] enemies = new Character[] {new Representative(), new CSMajor(), new MusicMajor()};
		enemies[0].status.Coffee(); enemies[1].status.Coffee(); enemies[2].status.Coffee();
		fight.options1 = new LinkedList<TimedMethod>();
		fight.options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		fight.options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new ItemEvent(new Item[] {new Coffee(), new Coffee(), new Sword()},
	    	"You collect what coffee remains")}));
		fight.optionText1 = "Fight";
		options1 = new LinkedList<TimedMethod>();
		if (new System.Random().Next(3) == 0) {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {fight}));
		} else {
			options1.AddLast(new TimedMethod(0, "SpendTime", new object[] {3}));
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You can't find the room, but plenty of time is wasted")}));
		}
		optionText1 = "Try to find the source";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Ignore this lier";
		if (Party.PartyContains(new BusinessMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {fight}));
			optionText3 = "Business Major: I've participated in this before";
		}
		if (Party.PartyContains(new CulinaryMajor()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {fight}));
			optionText4 = "Culinary Major: Follow the smell";
		}
	}
}