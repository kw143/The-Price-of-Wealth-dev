using System.Collections.Generic;

public class MedicalSlime : Event {
	
	public MedicalSlime () {}
	
	public override void Enact () {
		text = "This room is a storage place for a...abnormal expiriment. In the center is a large tank with a different sort of slime in it";
		Character[] recruit = new Character[] {new BusinessMajor()};
		recruit[0].GainDexterity(1);
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Item", new object[] {new Item[] {new MysterySolution(), new ToxicSolution(), new Sanitizer()}}));
		optionText1 = "Search the room for materials used in the expiriment";
		options2 = new LinkedList<TimedMethod>();
		Character[] slime = new Character[] {new Slime()};
		slime[0].drops = new Item[] {new SlimeGoo(), new MysteryGoo(), new MysteryGoo()};
		slime[0].GainPower(-4); slime[0].GainDefense(4); slime[0].SetQuirk(new Ill(slime[0]));
		options2.AddLast(new TimedMethod(0, "Battle", new object[] {slime}));
		optionText2 = "All slimes are inherently evil. Destroy it";
		if (Party.PartyContains(new ChemistryMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "Ally", new object[] {recruit}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new StrengthPotion()},
			    Party.members[Party.PartyContains(new ChemistryMajor())].ToString() + " uses the slime's storage tank as a cauldron" 
				+ " and pours a bunch of chemicals into it. Several explosions later, you are assured the slime is both dead and nutritious")}));
			optionText3 = "Chemistry Major: Convert the slime into a powerful potion";
		}
		if (Party.PartyContains(new PreMed()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "Heal", new object[] {6}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.PartyContains(new PreMed())].ToString() + " electrocutes the slime with a bunch of loose wires" 
			    + " and then dumps the tank (and it) onto the party (6 healing). The party leaves with the slime stunned on the floor")}));
			optionText4 = "Pre med Student: Heal the party with the slime's tank";
		}
	}
}