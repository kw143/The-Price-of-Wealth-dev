public class Taze : Special {
	
	public Taze() {name = "Taze"; description = "A piercing attack that stuns"; baseCost = 6; modifier = 0;}
	
	public override TimedMethod[] Use () {
		Attacks.SetAudio("Tazer", 6);
		TimedMethod[] stunPart = new TimedMethod[] {new TimedMethod("Null"), new TimedMethod("Null")};
		if (Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
		    stunPart = Party.GetEnemy().status.Stun(2);
		}
		return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1 ,2}),
    		new TimedMethod(0, "Audio", new object[] {"Button"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {true, 6, 6, Party.GetPlayer().GetAccuracy(), true, true, true}), stunPart[0], stunPart[1]};
	}
	
}