public class Metronome : Item {
	
	public Metronome () {name = "Metronome"; description = "While in inventory, your basic attack deals set damage"; price = 3; usableOut = true;}
	
	public override TimedMethod[] Use () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			Party.GetPlayer().ToString() + " likes variance. The metronome was discarded"})};
	}
	
	public override void UseOutOfCombat (int i) {}
}