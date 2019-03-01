using System.Collections.Generic;

public class ArtAppreciator : Event {
	
	public ArtAppreciator () {}
	
	public override void Enact () {
		text = "A possessed guest is sitting across from some old sculptures, and turns to stop the party."
		    + "\"One of these is real, but the other is a fake replicated by the American Government. Surely you know which one is genuine?";
		Event right = new Event();
		right.text = "\"Exactly! There is some hope for the younger generation after all!\" The guest heals you for your troubles";
		right.options1 = new LinkedList<TimedMethod>();
		right.options1.AddLast(new TimedMethod(0, "Heal", new object[] {4}));
		right.options1.AddLast(new TimedMethod("Resolve"));
		right.optionText1 = "4 healing for party";
		Event wrong = new BattleEvent(new Character[] {new Tenured()},
    		"\"Wrong. Insolence towards your ancestors has grave consequences.\" The guest prepares for battle");
		options1 = new LinkedList<TimedMethod>();
	    options2 = new LinkedList<TimedMethod>();   	
    	optionText1 = "The bronze sculpture";
		optionText2 = "The stone sculpture";
		if (new System.Random().Next(2) == 0) {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {right}));
    		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {wrong}));
		} else {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {wrong}));
    		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {right}));
		}
		if (Party.PartyContains(new HistoryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {right}));
			optionText3 = "History Major: Well clearly, based on the ancient...";
		}
		if (Party.BagContains(new Smartphone())) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    "You take out the smartphone, but the guest's face turns scary.", wrong)}));
			optionText4 = "Smartphone: Look it up online";
		}
	}
}