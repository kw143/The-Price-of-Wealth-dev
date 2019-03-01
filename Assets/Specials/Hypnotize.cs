public class Hypnotize : Special {
	
	public Hypnotize() {name = "Hypnotize"; description = "Put the enemy to sleep"; baseCost = 4; modifier = 0;}
	
	public override TimedMethod[] Use () {
		TimedMethod[] sleepPart = Party.GetEnemy().status.Sleep();
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}), new TimedMethod(0, "Audio", new object[] {"Hypnotize"}),
		    sleepPart[0], sleepPart[1]};
	}
}