public class Handcuffs : Special {
	
	public Handcuffs() {name = "Handcuffs"; description = "Switch in and goop the enemy"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int i) {
		TimedMethod[] goopPart;
		if (Attacks.EvasionCycle(Party.members[i], Party.GetEnemy())) {
		    goopPart = Party.GetEnemy().status.Goop();
		} else {
			goopPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Miss"}), new TimedMethod("Null")};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Big Swing"}),
    		new TimedMethod(0, "SwitchTo", new object[] {i + 1}), goopPart[0], goopPart[1]};
	}
}