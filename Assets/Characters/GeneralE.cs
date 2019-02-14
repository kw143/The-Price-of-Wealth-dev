public class GeneralE : General {
	
	public GeneralE () {passive = new Passive(); champion = false;}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 5) {
			return Charge();
		} else if (num < 7) {
			return Melee();
		} else {
			return Automatic();
		}
	}
}