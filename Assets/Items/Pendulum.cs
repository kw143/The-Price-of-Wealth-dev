public class Pendulum : Item {
	
	public Pendulum () {name = "Pendulum"; description = "Put the enemy to sleep. It's very accurate"; price = 2;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCycle(Party.GetPlayer().GetAccuracy() * 2, Party.GetEnemy())) {
			TimedMethod[] sleepPart = Party.GetEnemy().status.Sleep();
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Hypnotize"}), sleepPart[0], sleepPart[1]};
		} else {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Hypnotize"}), new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	}
}