using System.Collections.Generic;

public class CultHideout : Event {
	
	public CultHideout () {}
	
	public override void Enact () {
		text = "Chants are heard from within the kitchen. They are in a strange langua-, nope, just saying pizza over and over again."
		    + " You feel a tap on your shoulder and smell burnt crust";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new PizzaCultist(), new PizzaCultist(),
		    new PizzaCultist(), new PizzaCultist()}, "The loud fighting attracts the others!")}));
		optionText1 = "Attack the cultist";
		if (Party.PartyContains(new PsychMajor()) >= 0) {
			options2 = new LinkedList<TimedMethod>();
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.PartyContains(new PsychMajor())].ToString() 
			    + " chants azziP 3 times. The cultist is very confused by this. He goes to ask his other members for help, leaving time for"
	    		+ " a quick escape", new ItemEvent(new Item[] {new Pizza(), new Pizza()}, "You even swipe a few pizzas"))}));
			optionText2 = "Psychology Major: Mind trick the cultist";
		}
		if (Party.PartyContains(new CulinaryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "SpendTime", new object[] {2}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			Party.PartyContains(new CulinaryMajor())].ToString() 
			    + " converts a pizza into a golden pizza for the cult and the party is let go. Unfortunately this takes some time")}));
			optionText3 = "Culinary Major: Bribe the cult";
		}
		if (Party.PartyContains(new FootballPlayer()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {new PizzaCultist()}, 
			    Party.members[Party.PartyContains(new FootballPlayer())].ToString() + " Tackles the room full of cultists, knocking them all out. "
				    + "Only the one behind you remains")}));
			optionText4 = "Football Player: Plow through the room with surprise";
		}
	}
}