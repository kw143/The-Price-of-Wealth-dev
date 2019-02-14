using System.Collections.Generic;

public static class ResearchGetter {
	
	public static List<Event> easy;
	public static List<Event> med;
	public static List<Event> hard;
	public static List<Event> reward;
	public static List<Event> cut;
	public static List<Event> lab;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		easy = new List<Event>();
		med = new List<Event>();
		hard = new List<Event>();
		reward = new List<Event>();
		cut = new List<Event>();
	    lab = new List<Event>();
		final = new List<Event>();
		easy.Add(new ResearchEasyBattleR());
		easy.Add(new ResearchEasyBattleR());
		easy.Add(new ResearchEasyBattleR());
		easy.Add(new ResearchEasyBattleR());
		easy.Add(new ResearchEasyBattleP());
		easy.Add(new ResearchEasyBattleP());
		easy.Add(new ResearchEasyBattleP());
		easy.Add(new ResearchEasyBattleP());
		med.Add(new ResearchMediumBattle());
		med.Add(new ResearchMediumBattle());
		med.Add(new ResearchMediumBattle());
		hard.Add(new ResearchHardBattle());
		hard.Add(new ResearchHardBattle());
		reward.Add(new ItemEvent(new Item[] {new Flask(), new Flask(), new Flask()}, "Some chemistry supplies are left untouched"));
		reward.Add(new Event("A working machine has a sign saying complex thing about strength", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be altered?", new TimedMethod[] {new TimedMethod(
		    0, "StatChange", new object[] {"GainStrength", 1}), new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", -1}), 
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strengh + 1, maxHP - 1")})})})}), new LinkedList<TimedMethod>(
			new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Send someone to the machine", "No unethical science", null, null));
		cut.Add(new ResearchHardBattle());
		cut.Add(new Event("You find a shortcut guarded by 2 Lab Robots", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "Battle", new object[] {new Character[] {new LabRobot(), new LabRobot()}})}),
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Escape")}),
		    null, null, "Go through the shortcut", "Go the normal way", null, null));
		lab.Add(new ItemEvent(new Item[] {new Flask(), new Flask(), new Flask()}, "Some chemistry supplies are left untouched"));
		lab.Add(new Event("A working machine has a sign saying complex thing about strength", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be altered?", new TimedMethod[] {new TimedMethod(
		    0, "StatChange", new object[] {"GainStrength", 1}), new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", -1}), 
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strengh + 1, maxHP - 1")})})})}), new LinkedList<TimedMethod>(
			new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Send someone to the machine", "No unethical science", null, null));
		lab.Add(new Event("You find a room fludded with slime goop", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("LoseItems"), new TimedMethod(0, "Item", new object[] {new Item[] {new MysteryGoo(), new MysteryGoo(),
			new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(),
	        new MysteryGoo(),}})}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Battle", new object[] {new Character[] {
    		new Slime(), new Slime(), new Slime(), new Slime()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("Resolve")}), null, "Sacrifice your items to the slime", "insult the slime", "ignore the slime", null));
		lab.Add(new ResearchMediumBattle());
		lab.Add(new ResearchHardBattle());
		final.Add(new ItemEvent(new Item[] {new StrengthPotion(), new DexPotion(), new AccuracyPotion(), new HealthPotion()},
		    "Finally, where they keep the good stuff"));
	}
	
	public static Event Easy() {
		int index = rng.Next(easy.Count);
		Event e = easy[index];
		easy.RemoveAt(index);
		return e;
	}
	
	public static Event Medium() {
		int index = rng.Next(med.Count);
		Event e = med[index];
		med.RemoveAt(index);
		return e;
	}
	
	public static Event Hard() {
		int index = rng.Next(hard.Count);
		Event e = hard[index];
		hard.RemoveAt(index);
		return e;
	}
	
	public static Event Reward() {
		int index = rng.Next(reward.Count);
		Event e = reward[index];
		reward.RemoveAt(index);
		return e;
	}
	
	public static Event Cut() {
		int index = rng.Next(cut.Count);
		Event e = cut[index];
		cut.RemoveAt(index);
		return e;
	}
	
	public static Event Lab() {
		int index = rng.Next(lab.Count);
		Event e = lab[index];
		lab.RemoveAt(index);
		return e;
	}
	
	public static Event Final() {
		int index = rng.Next(final.Count);
		Event e = final[index];
		final.RemoveAt(index);
		return e;
	}
}
