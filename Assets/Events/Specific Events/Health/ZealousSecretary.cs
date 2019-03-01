using System.Collections.Generic;

public class ZealousSecretary : Event {
	
	public ZealousSecretary () {}
	
	public override void Enact () {
		text = "A secretary is still in the desk. You can barely see the person through flying papers. You hear shouts of \"Patient X's records\"";
		Character[] fight = new Character[] {new SecurityHologram()};
		fight[0].SetPassive(new ForceField(fight[0])); fight[0].GainEvasion(40); fight[0].GainDexterity(2);
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(fight, "The secretary shouts \"BEGONE!\""
		    + " The desk computer's security system activates under the paperwork. You'll have a hard time reaching the machine's core")}));
		optionText1 = "Ask about patient x";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "DamageAll", new object[] {2}));
		options2.AddLast(new TimedMethod(0, "AllStatusChange", new object[] {"Blind", 6}));
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Weather the storm of paper (2 damage and blind to party)";
		if (Party.BagContains(new PaperPlane())) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You throw the paper plane just out of the secretary's reach." 
				+ " Now that paper isn't being thrown everywhere, you get through the checkpoint safely and even catch the plane"
  				+ "as the secretary gives up on it")}));
			optionText3 = "Paper Plane: Cause a distraction";
		}
		if (Party.ContainsQuirk(new Overconfident(null)) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "Heal", new object[] {6}));
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(
			    Party.members[Party.ContainsQuirk(new Overconfident(null))].ToString() + " is very sure of their abilities and begins looking." 
			    + " Moments later, the secretary exclaims AHA! and stops throwing things around. \"All thanks to me,\" says your party member."
				+ " You have your doubts")}));
			optionText4 = "Overconfident: I can find patient X's paperwork";
		}
	}
}