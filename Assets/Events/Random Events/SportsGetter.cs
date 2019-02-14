using System.Collections.Generic;

public static class SportsGetter {
	
	public static List<Event> hall;
	public static List<Event> room;
	public static List<Event> gate;
	public static List<Event> field;
	public static List<Event> stand;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		hall = new List<Event>();
	    room = new List<Event>();
		gate = new List<Event>();
	    field = new List<Event>();
	    stand = new List<Event>();
		final = new List<Event>();
		hall.Add(new SportsEasyBattleR());
	    hall.Add(new SportsEasyBattleR());
		hall.Add(new SportsEasyBattleP());
		hall.Add(new SportsEasyBattleR());
		hall.Add(new SportsEasyBattleR());
		room.Add(new SportsMediumBattle());
		room.Add(new SportsMediumBattle());
		room.Add(new SportsMediumBattle());
		room.Add(new SportsMediumBattle());
		room.Add(new Event("You find the weight room, but it is occupied", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "NextEvent", new object[] {new SelectMember("Who will lift?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"GainStrength", 1}),
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strength + 1")})})}),
			new TimedMethod(0, "Battle", new object[] {new Character[] {new PreMed(), new MathMajor()}})}),
			new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Fight for the weights", "Skip", null, null));
		room.Add(new Event("You find the cardio room", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will run?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 1}), new TimedMethod(0, "StatChange", new object[] {"SetPower", -5}),
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Dexterity + 1. Power down next fight")})})})}), new LinkedList<TimedMethod>(
			new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Have somebody run. It's very tiring", "Skip", null, null));
		gate.Add(new SportsMediumBattle());
	    gate.Add(new SportsMediumBattle());
		field.Add(new SportsHardBattle());
		field.Add(new SportsHardBattle());
		stand.Add(new SportsEasyBattleR());
		stand.Add(new SportsEasyBattleP());
		stand.Add(new SportsMediumBattle());
		stand.Add(new SportsHardBattle());
		final.Add(new Event("The championship winnings are here. Who will don the title?", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Choose (+4 strength)", new TimedMethod[] {
			new TimedMethod(0, "StatChange", new object[] {"GainStrength", 4}),
			new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strength + 4")})})})}), null, null, null,"Decide", null, null, null));
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
	
	public static Event Gate() {
		int index = rng.Next(gate.Count);
		Event e = gate[index];
		gate.RemoveAt(index);
		return e;
	}
	
	public static Event Field() {
		int index = rng.Next(field.Count);
		Event e = field[index];
		field.RemoveAt(index);
		return e;
	}
	
	public static Event Stand() {
		int index = rng.Next(stand.Count);
		Event e = stand[index];
		stand.RemoveAt(index);
		return e;
	}
	
	public static Event Final() {
		int index = rng.Next(final.Count);
		Event e = final[index];
		final.RemoveAt(index);
		return e;
	}
}
