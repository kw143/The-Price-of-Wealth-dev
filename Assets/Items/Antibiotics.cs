public class Antibiotics : Item {
	
	public Antibiotics () {name = "Antibiotics"; description = "Cures poison and makes you immune for the rest of the fight";
	    price = 3; usableOut = true; selects = true;}
	
	public override TimedMethod[] UseSelected (int i) {
		Party.members[i].status.poisoned = 0;
		Party.members[i].status.poisonImmune = true;
		return new TimedMethod[0];
	}
	
	public override void UseOutOfCombat(int i) {
		Party.GetCharacter(i).status.poisonImmune = true;
	}
}