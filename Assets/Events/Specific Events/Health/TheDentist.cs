using System.Collections.Generic;

public class TheDentist : Event {
	
	public TheDentist () {}
	
	public override void Enact () {
		text = "This room's layout is a little different than the rest. Before you can put your finger on it, somone blocks the door behind you."
		    + " \"I AM A DENTIST. AND YOU DON'T LOOK LIKE YOU'VE FLOSSED!";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {new Character[] {new Doctor()}}));
		optionText1 = "Fight the dentist";
		options2 = new LinkedList<TimedMethod>();
		Event dentistry = new Event();
			dentistry.text = "The dentist takes out all of the dentistry tools, and then just yanks " +
    			Party.members[Party.playerSlot - 1].ToString() + "'s tooth out. You are given a goody bag";
			dentistry.options1 = new LinkedList<TimedMethod>();
			dentistry.options1.AddLast(new TimedMethod(0, "Damage", new object[] {9}));
			dentistry.options1.AddLast(new TimedMethod(0, "Item", new object[] {new Item[] {new Sanitizer(), new Celery()}}));
			dentistry.optionText1 = "9 damage";
			options2.AddLast(new TimedMethod(0, "ChooseMember", new object[] {Party.playerSlot - 1}));
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {dentistry}));
		optionText2 = "Submit to dentistry";
		if (Party.PartyContains(new PreMed()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Antibiotics(), new Wire(), new Celery()},
			    Party.members[Party.PartyContains(new PreMed())].ToString() + " smiles at the dentist." 
				+ " \"But...the...my...plan...NOOOOOOOOO!\" The dentist runs away screaming. The room can now be looted")}));
			optionText3 = "Pre-med Student: I floss every day";
		}
		if (Party.ContainsQuirk(new Ill(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Antibiotics(), new Wire(), new Celery()},
			    Party.members[Party.ContainsQuirk(new Ill(null))].ToString() + "'s breath seems to cause a reaction in the enigmatic dentist" 
				+ " \"MY ONE WEAKNESS, FOUL MOUTHS! WAIT HERE WHILE I GET MY PARTICLE BEAM!\" You loot the room and leave")}));
			optionText4 = "Ill: Breathe";
		}
	}
}