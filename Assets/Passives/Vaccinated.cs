public class Vaccinated : Quirk {
	
	public Vaccinated (Character c) {self = c; name = "Vaccinated"; description = "You are immune to poison";}
	
	public override TimedMethod[] Initialize (bool player) {
		self.status.poisonImmune = true;
		self.status.poisoned = 0;
		return new TimedMethod[0];
	}
}