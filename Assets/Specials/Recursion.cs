using UnityEngine;

public class Recursion : Special {
	
	public Recursion () {name = "Recursion"; description = "Attack once for every basic attack this character used this combat";
	    baseCost = 2; modifier = 0;
	}
	
	public override TimedMethod[] Use () {
		CSMajor self = (CSMajor) Party.GetPlayer();
		int attacks = self.attacks;
		if (attacks == 0) {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skip Turn"})};
		}
		Attacks.SetAudio("Blunt Hit", 10);
	    TimedMethod[] moves = new TimedMethod[attacks + 2];
		moves[0] = new TimedMethod(0, "Audio", new object[] {"Skill1"});
		moves[1] = new TimedMethod(0, "Audio", new object[] {"Recursion"});
		for (int i = 1; i < attacks; i++) {
			moves[i + 1] = new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 1,
    			Party.GetPlayer().GetAccuracy(), true, false, false});
		}
		moves[attacks + 1] = new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 1,
    		Party.GetPlayer().GetAccuracy(), true, true, false});
		return moves;
	}
}