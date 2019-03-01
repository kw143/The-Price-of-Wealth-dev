public class SpicyEscape : Special {
	
	public SpicyEscape () {
		name = "Spicy Escape";
	    description = "Switch out and give the newcomer 3 power"; baseCost = 3;
	    modifier = 0;
		selects = true;
	}
	
	public override TimedMethod[] UseSelects (int i) {
		if (Party.GetPlayer().GetGooped()) {
			Party.GetPlayer().GainPower(3);
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Powder"}), new TimedMethod(60, "Log", new object[] {
		    	Party.GetPlayer().ToString() + " is gooped. The switch failed"})};
		}
		Party.members[i].GainPower(3);
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Powder"}),
		    new TimedMethod(60, "Log", new object[] {Party.GetPlayer().ToString() + " left a cloud of spice"}),
    		new TimedMethod(0, "SwitchTo", new object[] {i + 1})};
	}
}