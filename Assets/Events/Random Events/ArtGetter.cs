using System.Collections.Generic;

public static class ArtGetter {
	
	public static List<Event> hall;
	public static List<Event> room;
	public static List<Event> gallery;
	public static List<Event> stage;
	public static List<Event> recep;
	public static List<Event> store;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		hall = new List<Event>();
	    room = new List<Event>();
		gallery = new List<Event>();
	    stage = new List<Event>();
	    recep = new List<Event>();
		store = new List<Event>();
		final = new List<Event>();
		hall.Add(new ArtEasyBattleR());
	    hall.Add(new ArtEasyBattleR());
		hall.Add(new ArtEasyBattleP());
		hall.Add(new ArtEasyBattleR());
		hall.Add(new ArtEasyBattleR());
	    hall.Add(new ArtEasyBattleR());
		hall.Add(new ArtEasyBattleP());
		hall.Add(new ArtEasyBattleR());
		hall.Add(new BeggerEvent());
		room.Add(new ArtMediumBattle());
		room.Add(new ArtMediumBattle());
		room.Add(new ArtEasyBattleP());
		room.Add(new ArtEasyBattleP());
		gallery.Add(new ArtMediumBattle());
		gallery.Add(new ArtMediumBattle());
		gallery.Add(new ArtMediumBattle());
		stage.Add(new ArtHardBattle());
	    stage.Add(new Event("Students are attempting to put together a show to take mind off the times", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "GainSP", new object[] {3}), new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "GainSP", new object[] {-5}), new TimedMethod(0, "Item", new object[] {new Item[] {new VotedBadge(), new Donut()}}),
			new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Battle", new object[] {
			new Character[] {new DanceMajor(), new MusicMajor(), new HistoryMajor(), new EnglishMajor()}}),
			new TimedMethod(0, "Item", new object[] {new Item[] {new Tuba(), new Heels(), new Donut(), new Textbook()}})}),
			null, "Watch the show. Gain 3 SP", "Assist the group. Lose 5 SP and gain 2 items", "Mug them for all the items", null));
		recep.Add(new ArtHardBattle());
		store.Add(new ArtEasyBattleR());
		store.Add(new ItemEvent(new Item[] {new Tuba(), new Tuba(), new Metronome(), new Baton()},
    		"You found the storage room for the music building"));
		final.Add(new Event("The art gallery is so peaceful", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "GainSP", new object[] {25}), new TimedMethod(0, "Heal", new object[] {10}),
			new TimedMethod("Resolve")}), null, null, null, "Relax (+25 sp and 10 hp per member)", null, null, null));
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
	
	public static Event Gallery() {
		int index = rng.Next(gallery.Count);
		Event e = gallery[index];
		gallery.RemoveAt(index);
		return e;
	}
	
	public static Event Stage() {
		int index = rng.Next(stage.Count);
		Event e = stage[index];
		stage.RemoveAt(index);
		return e;
	}
	
	public static Event Recep() {
		int index = rng.Next(recep.Count);
		Event e = recep[index];
		recep.RemoveAt(index);
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
