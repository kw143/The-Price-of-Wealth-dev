public class Automatic : Item {
	
	public Automatic () {name = "Automatic"; description = "attack four times"; price = 6;}
	
	public override TimedMethod[] Use () {
		Attacks.SetAudio("Blunt Hit", 6);
		int dmg = Party.GetPlayer().GetStrength();
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Automatic"}),
		new TimedMethod(0, "StagnantAttack", new object[] {true, dmg, dmg, Party.GetPlayer().GetAccuracy(), true, false, false}),
		new TimedMethod(0, "StagnantAttack", new object[] {true, dmg, dmg, Party.GetPlayer().GetAccuracy(), true, false, false}),
		new TimedMethod(0, "StagnantAttack", new object[] {true, dmg, dmg, Party.GetPlayer().GetAccuracy(), true, false, false}),
		new TimedMethod(0, "StagnantAttack", new object[] {true, dmg, dmg, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}