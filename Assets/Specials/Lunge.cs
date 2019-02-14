public class Lunge : Special {
	
	public Lunge() {name = "Lunge"; description = "Switch in and attack"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int i) {
		return new TimedMethod[] {new TimedMethod(0, "SwitchTo", new object[] {i + 1}), new TimedMethod(60, "StagnantAttack", new object[] {
			true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}