using System.Collections.Generic;

public static class HealthGetter {
	
	public static List<Event> hall;
	public static List<Event> room;
	public static List<Event> desk;
	public static List<Event> store;
	public static List<Event> hard;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		hall = new List<Event>();
	    room = new List<Event>();
		desk = new List<Event>();
	    hard = new List<Event>();
		store = new List<Event>();
		final = new List<Event>();
		hall.Add(new HealthEasyBattleP());
	    hall.Add(new HealthEasyBattleR());
		hall.Add(new HealthEasyBattleP());
		hall.Add(new HealthEasyBattleR());
		hall.Add(new HealthEasyBattleP());
		hall.Add(new HealthEasyBattleR());
		room.Add(new HealthMediumBattle());
		room.Add(new HealthMediumBattle());
		room.Add(new HealthEasyBattleP());
		room.Add(new HealthEasyBattleR());
		room.Add(new HealthMediumBattle());
		room.Add(new Event("A room marked as contaminated appears to contain some useful supplies", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "Poison", new object[] {3}), new TimedMethod(0, "Item", new object[] {new Item[] {new Defibrilator(),
		    new ToxicSolution(), new Wire(), new MysterySolution()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}),
			null, null, "Gather supplies (become poisoned next fight)", "Move on", null, null));
		room.Add(new Event("A standard treatment room is here. There is enough supplies for one person", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be treated?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"Heal", 15}), new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("15 hp restored")})
			})})}), null, null, null, "Heal", null, null, null));
		room.Add(new Event("A standard treatment room is here. There is enough supplies for one person", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be treated?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"Heal", 15}), new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("15 hp restored")})
			})})}), null, null, null, "Heal", null, null, null));
		room.Add(new HealthHardBattle());
		room.Add(new TheDentist());
		room.Add(new PristineMedicine());
		room.Add(new MedicalSlime());
		room.Add(new ReviveChoice());
		room.Add(new HealthEasyBattleR());
		room.Add(new HealthMediumBattle());
		desk.Add(new HealthMediumBattle());
		desk.Add(new HealthMediumBattle());
		desk.Add(new ItemEvent(new Item[] {new Pencil(), new PinkSlip(), new Sanitizer()}, "This is an empty front desk, unlooted"));
		desk.Add(new ZealousSecretary());
		hard.Add(new HealthHardBattle());
		store.Add(new ItemEvent(new Item[] {new Pencil(), new PinkSlip(), new Sanitizer()}, "This is an empty front desk, unlooted"));
		store.Add(new Event("A room marked as contaminated appears to contain some useful supplies", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "Poison", new object[] {3}), new TimedMethod(0, "Item", new object[] {new Item[] {new Defibrilator(),
		    new ToxicSolution(), new Wire(), new MysterySolution()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}),
			null, null, "Gather supplies (become poisoned next fight)", "Move on", null, null));
		store.Add(new HealthEasyBattleR());
		final.Add(new ItemEvent(new Item[] {new Defibrilator(), new Defibrilator(), new HealthPotion(), new HealthPotion()},
		    "A collection of unlooted, very useful survival tools"));
	}
	
	public static Event Hall() {
		int index = rng.Next(hall.Count);
		Event e = hall[index];
		hall.RemoveAt(index);
		return e;
	}
	
	public static Event Room() {
		int index = rng.Next(room.Count);
		Event e = room[index];
		room.RemoveAt(index);
		return e;
	}
	
	public static Event Desk() {
		int index = rng.Next(desk.Count);
		Event e = desk[index];
		desk.RemoveAt(index);
		return e;
	}
	
	public static Event Hard() {
		int index = rng.Next(hard.Count);
		Event e = hard[index];
		hard.RemoveAt(index);
		return e;
	}
	
	public static Event Store() {
		int index = rng.Next(store.Count);
		Event e = store[index];
		store.RemoveAt(index);
		return e;
	}
	
	public static Event Final() {
		int index = rng.Next(final.Count);
		Event e = final[index];
		final.RemoveAt(index);
		return e;
	}
}
