public class Sanitizer : Item {
	
	public Sanitizer() {name = "Sanitizer"; description = "Recover from poisoned, gooped, and blinded"; price = 2; usableOut = true; selects = true;}

	public override TimedMethod[] UseSelected (int i) {
		Party.members[i].status.poisoned = 0;
		Party.members[i].status.gooped = false;
		Party.members[i].status.blinded = 0;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Clean"}),
    		new TimedMethod(60, "Log", new object[] {"Negative effects were removed"})};
	}
	
	public override void UseOutOfCombat (int i) {
		UseSelected(i);
	}
	
}