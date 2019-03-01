public class PowerStrike : Special {
	
	public PowerStrike() {name = "Power Strike"; description = "Attack for your basic attack's max damage"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] Use() {
		Attacks.SetAudio("Blunt Hit", 15);
		if (Party.BagContains(new Metronome())) {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Big Swing"}), new TimedMethod(0, "StagnantAttack", new object[] {
			    true, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetAccuracy(), true, true, false})};
		} else {
	    	return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Big Swing"}), new TimedMethod(0, "StagnantAttack", new object[] {
			    true, Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetAccuracy(), true, true, false})};
		}
	}
}