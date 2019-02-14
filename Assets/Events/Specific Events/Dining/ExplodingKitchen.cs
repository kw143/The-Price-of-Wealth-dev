using System.Collections.Generic;

public class ExplodingKitchen : Event {
	
	public ExplodingKitchen () {}
	
	public override void Enact () {
		text = "A lone student is in this kitchen as smoke billows out from several contraptions \"THE STOVE IS ON FIRE, "
		    + " THE SINK IS FLOODING THE DISHWASHER AND THE COFFEE MACHINE IS ABOUT TO EXPLODE!\"";
		Event recruit = new Event();
		recruit.text = "Accept the Culinary Major?";
		recruit.options1 = new LinkedList<TimedMethod>();
		recruit.options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {new CulinaryMajor()}}));
		recruit.optionText1 = "Yes";
		recruit.options2 = new LinkedList<TimedMethod>();
		recruit.options2.AddLast(new TimedMethod("Resolve"));
		recruit.optionText2 = "No";
		Event damage = new Event();
		damage.text = "-3 hp to party";
		damage.options1 = new LinkedList<TimedMethod>();
		damage.options1.AddLast(new TimedMethod(0, "DamageAll", new object[] {3}));
		damage.optionText1 = "Oh no";
		options1 = new LinkedList<TimedMethod>();
		optionText1 = "Save the stove!";
		if (new System.Random().Next(3) == 0) {
		    options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You only succeed in burning yourself", damage)}));
		} else {
			options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {new CulinaryMajor()}}));
			options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You direct the flow of the sink towards the stove, "
		    	+ "Extinguishing the fire. The student manages to handle the other emergencies and offers to join your team", recruit)}));
		}
		options2 = new LinkedList<TimedMethod>();
		optionText2 = "Save the dishes!";
		if (new System.Random().Next(3) == 0) {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("As you approach the dishwasher, the contents flood"
			    + " out in a sharp tide, catching the party", damage)}));
		} else {
			options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Sword(), new Sword()},
			    "You discover the dishwasher held swords...You turn to ask the student, but they've vanished")}));
		}
		options3 = new LinkedList<TimedMethod>();
		optionText3 = "Save the Coffee!";
		if (Party.PartyContains(new AerospaceEngineer()) >= 0 || Party.PartyContains(new MechanicalEngineer()) >= 0) {
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Your engineer prevents the machine from exploding."
			    + " Its contents seem to have been fried into quite the potent solution", new ItemEvent(new Item[] {
				    new StrengthPotion()}, "The other student has disappeared, but hey, free coffee?"))}));
		} else {
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Without an engineer to fix the extremely intricate"
			    + " device, it explode in your face, just like you were warned", damage)}));
		}
		options4 = new LinkedList<TimedMethod>();
		optionText4 = "Save Yourself!";
		if (new System.Random().Next(3) == 0) {
			Character[] c = new Character[] {new CulinaryMajor()};
			c[0].SetHealth(1); c[0].SetRecruitable(false); c[0].SetQuirk(new Berserk(c[0])); c[0].drops = new Item[0];
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(c , 
			    "Your party quickly dashes from the room as an explosion echos from within it. Moments later, the student walks out covered in"
				+ " soot (or coffee?), pointing an accusing finger")}));
		} else {
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Your party quickly dashes from the room as an"
			    + " explosion echos from within it. Moments later, the student walk out covered in soot (or coffee?)."
		    	+ " It will take longer than you have time for this one to mentally recover")}));
		}
	}
}