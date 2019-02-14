public class CEOE : CEO {
    
	public CEOE () {
		champion = false;
	}
	
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		if (cycle == 0) {
			cycle++;
			if (rng.Next(2) == 0) {
				return Contraband();
			} else {
				return Monopoly();
			}
		} else if (cycle == 1) {
			cycle++;
			return Attack();
		} else if (cycle == 2) {
			cycle++;
			return Integration(rng);
		} else if (cycle == 4) {
			cycle++;
			return Attack();
		} else {
			cycle = 1;
			return Stack();
		}
	}
	
}