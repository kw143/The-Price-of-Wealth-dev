public class Joust : Special {
	
	public Joust() {name = "Joust"; description = "Attack for high power, get attacked for low power"; baseCost = 4; modifier = 0;}

    public override TimedMethod[] Use() {
		Attacks.SetAudio("Sword", 15);
		Party.GetPlayer().SetGuard(Party.GetPlayer().GetGuard() + Party.GetEnemy().GetCharge() / 2);
		return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3 ,4}),
    		new TimedMethod(0, "Audio", new object[] {"Big Swing"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength() + 6, Party.GetPlayer().GetStrength() + 6,
			Party.GetPlayer().GetAccuracy(), true, true, false}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 1, 1, Party.GetEnemy().GetAccuracy(), true, true, false})};
    }
}