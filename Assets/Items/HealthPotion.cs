public class HealthPotion : Item {
	
	public HealthPotion() {
    	name = "Carbon"; description = "+3 MaxHP. Organic people are healthier";
	    selects = true; price = 11; usableOut = true;
	}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.AddItem(new Flask());
		Party.members[i].GainMaxHP(3);
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Drink"}),
		    new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " Got healthier!"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}