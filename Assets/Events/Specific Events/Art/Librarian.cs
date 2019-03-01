using System.Collections.Generic;

public class Librarian : Event {
	
	public Librarian () {}
	
	public override void Enact () {
		text = "You enter the building's library, and are immediately told to shush by the student librarian. The path forward is littered with"
		    + "creaky wooden floorboards";
		Event right = new Event();
		right.text = "\"Exactly! There is some hope for the younger generation after all!\" The guest heals you for your troubles";
		right.options1 = new LinkedList<TimedMethod>();
		right.options1.AddLast(new TimedMethod(0, "Heal", new object[] {4}));
		right.options1.AddLast(new TimedMethod("Resolve"));
		right.optionText1 = "4 healing for party";
		Event wrong = new BattleEvent(new Character[] {new Tenured()},
    		"\"Wrong. Insolence towards your ancestors has grave consequences.\" The guest prepares for battle");
		options1 = new LinkedList<TimedMethod>();
	    optionText1 = "Walk carefully";
        if (new System.Random().Next(2) == 0) {
		    options1.AddLast(new TimedMethod(0, "SpendTime", new object[] {3}));
    		options1.AddLast(new TimedMethod(0, "Apathize", new object[] {1}));
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You are very close to the exit but you step on the wrong"
			    + " piece of the floor and a resounding creak echos throughout the room. The librarion seems to teleport in front of you and gives"
			    + " a very long and silent lecture (Time passed + party gains apathy)")}));
		} else {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You make it through the library,"
    			+ " but feel the librarian's distrustful gaze the entire time")}));
		}
		options2 = new LinkedList<TimedMethod>();   	
		optionText2 = "Try to recruit";
		options2.AddLast(new TimedMethod(0, "SpendTime", new object[] {3}));
    	options2.AddLast(new TimedMethod(0, "Apathize", new object[] {1}));
		options2.AddLast(new TimedMethod(0, "Ally", new object[] {new EnglishMajor()}));
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The librarian walks over to your group and spends quite some"
			    + " time silently gesturing to books and looking angry. Suddenly they just start walking towards the exit. It worked?"
			    + " (Time passed + party gains apathy + new recruit)")}));
		if (Party.BagContains(new Textbook())) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The librarian seems to relax when seeing a giant book"
			    + " and you cross the room without any trouble")}));
			optionText3 = "Textbook: act like you're reading it";
		}
	}
}