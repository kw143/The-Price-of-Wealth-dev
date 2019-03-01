public class Unstable : Quirk {
	public Unstable (Character c) {self = c; name = "Unstable"; description = "Regenerate or become poisoned at the start of the battle";}
	
	public override TimedMethod[] CheckLead (bool player) {
		Character target;
		if (player) {
			target = Party.GetEnemy();
		} else {
			target = Party.GetPlayer();
		}
		return target.status.Poison(2);
	}
	
	public override TimedMethod[] Initialize (bool player) {
		if (new System.Random().Next(2) == 0) {
			self.status.Poison(2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is poisoned"})};
		} else {
		    self.status.Regenerate(2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is regenerating"})};
		}
	}
}