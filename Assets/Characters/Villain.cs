public class Villain : Character {
	
	int cycleSwitch;
	int cycleMain;
	
	public Villain () {
		health = 100; maxHP = 100; strength = 5; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 5; evasion = 0; type = "Villain"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = true; recruitable = false;
		CreateDrops(); cycleSwitch = 2; cycleMain = 0;
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (Party.enemyCount > 1) {
			if (cycleSwitch == 0) {
				cycleSwitch++;
				return Attack(num);
			} else if (cycleSwitch == 1) {
				cycleSwitch++;
				return Buff(num);
			} else {
				return Switch();
			}
		} else {
			if (cycleMain == 0) {
				cycleMain++;
				return Hypnotize();
			} else if (cycleMain == 1) {
				cycleMain++;
				return Attack(num);
			} else {
				cycleMain--;
				return Buff(num);
			}
		}
	}
	
	public TimedMethod[] Attack(int num) {
		if (num < 4) {
			return Knife();
		} else if (num < 8) {
			return Pistol();
		} else {
			return Acid();
		}
	}
	
	public TimedMethod[] Buff(int num) {
		if (num < 2) {
			return Steroid();
		} else if (num < 4) {
			return Poison();
		} else if (num < 6) {
			return Smoke();
		} else if (num < 8) {
			return Duel();
		} else {
			return Drug();
		}
	}
	
	public TimedMethod[] Knife () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain used the knife"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 5, 5, GetAccuracy(), true, true, true})};
	}
	
	public TimedMethod[] Pistol () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain shot the pistol"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 10, 10, GetAccuracy() / 2, true, true, false})};
	}
	
	public TimedMethod[] Acid () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain threw an acid bomb"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
	    	new TimedMethod(0, "AttackAll", new object[] {false, 2, 2, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Steroid () {
		GainPower(3);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain applied steroids"})};
	}
	
	public TimedMethod[] Poison() {
	    TimedMethod poisonPart = new TimedMethod(60, "Log", new object[] {"miss"});
	    if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    poisonPart = Party.GetPlayer().status.Poison(2)[0];
	    }
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain sprayed poison fumes"}), poisonPart};
	}
	
	public TimedMethod[] Smoke() {
		evasion += 10;
		TimedMethod blindPart = new TimedMethod(60, "Log", new object[] {"miss"});
	    if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    blindPart = Party.GetPlayer().status.Blind(7)[0];
	    }
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain threw a smoke bomb"}), blindPart};
	}
	
	public TimedMethod[] Duel() {
		Party.GetPlayer().GainEvasion(Party.GetPlayer().GetEvasion() / 2);
		GainGuard(10);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain gave an insulting taunt. Evasion halved"})};
	}
	
	public TimedMethod[] Drug() {
		if (Attacks.EvasionCycle(this, Party.GetEnemy())) {
			Status.NullifyAttack(Party.GetPlayer());
			Status.NullifyDefense(Party.GetPlayer());
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
				"The Villain injected an unstable formula"}), Party.GetPlayer().status.CauseApathy(2)[0]};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain missed with an unstable formula"})};
		}
	}
	
	public TimedMethod[] Hypnotize() {
	    if (Attacks.EvasionCycle(GetAccuracy() * 2, Party.GetPlayer())) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain activated the evil device"}), 
			Party.GetPlayer().status.Possess()[0], new TimedMethod(0, "SwitchTo", new object[] {1})};
	    }
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain activated the evil device and you dodged its nature"})};
	}
	
	public TimedMethod[] Switch() {
		if (GetGooped()) {
			status.gooped = false;
			GainEvasion(10);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain escaped the goop with a smoke bomb"})};
		}
		for (int i = 1; i < 4; i++) {
			if (Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemySlot = i + 1;
				cycleSwitch = 0;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Villain called upon his loyal cabinet"}),
				    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, 1})};
			}
		}
		return Knife();
	}
	
	public override void CreateDrops() {
		drops = new Item[0];
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 10 + rnd.Next(6);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription() {
		return new string[] {"This is it. The final battle",
		"He seems to carry a full bag of tricks. Be ready for anything, and win"};
	}
}