using System.Collections.Generic;

public class BrokenGate : Event {
	
	public BrokenGate () {}
	
	public override void Enact () {
		text = "This gate has been broken, blocking the way to the field. If you can't get through it you'll have to go the long way around";
		Character[] enemies = new Character[] {new PizzaCultist(), new PizzaCultist(), new PizzaCultist(), new PizzaCultist()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Escape"));
		optionText1 = "Leave for now";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "SpendTime", new object[] {4}));
		options2.AddLast(new TimedMethod(0, "Apathize", new object[] {3}));
		options2.AddLast(new TimedMethod(0, "AllStatChange", new object[] {"GainPower", -2}));
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("It goes very slowly, and everyone feels more apathetic "
		   + " and powered down. But, the path is clear")}));
		optionText2 = "Hit the gate until it breaks";
		if (Party.PartyContains(new MechanicalEngineer()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "GainSP", new object[] {-3}));
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new MechanicalEngineer())].ToString() + " spends some resources to fix the gate, but it doensn't take much time (-3 sp)")}));
			optionText3 = "Mechanical Engineer: Fix the gate";
		}
		if (Party.PartyContains(new FootballPlayer()) >= 0) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[
			    Party.PartyContains(new FootballPlayer())].ToString() + " apparently was given permission to pass through the gate and will"
				+ " present it for the party. You are told to stand back before your ally charges straight through the gate")}));
			optionText4 = "Football Player: Present proof of worthiness";
		}
	}
}