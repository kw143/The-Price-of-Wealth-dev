using System.Collections.Generic;

public class PotionMaking : Event {
	
	public PotionMaking () {}
	
	public override void Enact () {
		text = "A chemistry major is waiting in front of a setup with vials of multicolered chemicals."
		    + "\"Can you help me create these Dexterity Potions? All you need to do is pour exactly 6.1423797 millilleters of"
			+ " explodium catostroxide at the same time I add the cataclystic salt. Easy :)\"";
		ItemEvent reward = new ItemEvent(new Item[] {new AccuracyPotion(), new Antibiotics(), new Sword(), new Pizza()}, "It seems " 
		    + "the robot was guarding something important");
		Event success = new Event();
		success.text = "It works! And by that meaning nothing exploded. The chemistry major gives you 1 of the completed solutions and takes"
     		+ " the other one. \"Well, that was my entire purpose in life. Uh, should I just go along with you all?";
		TimedMethod item = new TimedMethod(0, "Item", new object[] {new Item[] {new DexPotion()}});
		Character[] chem = new Character[] {new ChemistryMajor()};
		chem[0].GainDexterity(1);
		success.options1 = new LinkedList<TimedMethod>();
		success.options1.AddLast(new TimedMethod(0, "Ally", new object[] {chem}));
		success.options1.AddLast(item);
		success.optionText1 = "Add them to the team";
		success.options2 = new LinkedList<TimedMethod>();
		success.options2.AddLast(item);
		success.optionText2 = "They seem like a liability";
		Event failure = new Event();
		failure.text = "You add the explodium catostroxide without a hitch. But when you are putting the vial back in place, the solution"
		    + " suddenly explodes, catching the whole party. The chemist is not very happy with this...\"IMBECILES! ALL OF YOU WILL PAY "
			+ " FOR YOUR RIDICULOUS CLUMSINESS!";
		Character[] chemE = new Character[] {new ChemistryMajor()};
		chemE[0].Damage(3); chemE[0].SetQuirk(new Berserk(chemE[0])); chemE[0].SetRecruitable(false);
		failure.options1 = new LinkedList<TimedMethod>();
		failure.options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {4}));
		failure.options1.AddLast(new TimedMethod(0, "Battle", new object[] {chemE}));
		failure.optionText1 = "Oh no";
		options1 = new LinkedList<TimedMethod>();
		if (Party.PartyContains(new MathMajor()) >= 0) {
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(new MathMajor())].ToString()
		    + " Tells the rest of you to stand back. They had to calculate much worse during Pi-theory", success)}));
		} else if (new System.Random().Next(3) == 0) {
            options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You look at the tiny markings on vial. "
			    + "The smallest given measurement is millilleters. \"Here we go! 3...2...1.5...pi/2...1!\"", success)}));
		} else {
            options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You look at the tiny markings on vial. "
			    + "The smallest given measurement is millilleters. \"Here we go! 3...2...1.5...pi/2...1!\"", failure)}));
		}		
		optionText1 = "Attempt to pour a very precise amount";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "SpendTime", new object[] {3}));
		if (Party.PartyContains(new MathMajor()) >= 0) {
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You spend many practice attempts with water. "
    		+ "When you are finally ready, you look up to see" + Party.members[Party.PartyContains(new MathMajor())].ToString()
		    + " already completed the task. You feel like you had your time wasted, but it turned out fine in the end", success)}));
		} else if (new System.Random().Next(3) < 2) {
            options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You spend many practice attempts with water. "
			    + "When you are finally ready, you pour the solution", success)}));
		} else {
            options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You spend many practice attempts with water. "
			    + "When you are finally ready, you pour the solution", failure)}));
		}		
		optionText2 = "Take time to practice first";
		options3 = new LinkedList<TimedMethod>();
		if (Party.ContainsQuirk(new Paranoid(null)) >= 0) {
		    options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The chemists shouts \"HEY!\" and throws a special"
			    + " flask at the party. Expecting that, " + Party.members[Party.ContainsQuirk(new Paranoid(null))].ToString()
				+ " holds up a mirror, reflecting the flask into the mixture on the table. You hear a geyser erupt as you hastily move on")}));
		} else {
			options3.AddLast(new TimedMethod(0, "Poison", new object[] {2}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The chemist shouts \"HEY!\" and throws a special"
	    		+ " flask at the party. When it breaks, poisonous gas fills the hallway. You are all poisoned")}));
		}
		optionText3 = "Politely refuse";
	}
}