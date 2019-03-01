public class ToxicSolution : Item {
	
    public ToxicSolution () {name = "Toxic Solution"; description = "Poisons the enemy"; price = 2;}

    public override TimedMethod[] Use () {
	    Party.AddItem(new Flask());
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
			TimedMethod[] poisonPart = Party.GetEnemy().status.Poison(2);
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Clean"}), new TimedMethod(0, "AudioAfter", new object[] {"Acid", 10}),
			    poisonPart[0], poisonPart[1]};
		} else {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Clean"}), new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	}	
}