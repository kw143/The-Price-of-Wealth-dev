using System.Collections.Generic;

public static class DiningGetter {
	
	public static List<Event> hall;
	public static List<Event> line;
	public static List<Event> eat;
	public static List<Event> cut;
	public static List<Event> clean;
	public static List<Event> kitchen;
	public static List<Event> hard;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		cut = new List<Event>();
	    clean = new List<Event>();
		eat = new List<Event>();
	    hall = new List<Event>();
	    line = new List<Event>();
		hard = new List<Event>();
		final = new List<Event>();
		kitchen = new List<Event>();
		hall.Add(new DiningEasyBattleR());
	    hall.Add(new DiningEasyBattleR());
		hall.Add(new DiningEasyBattleP());
		hall.Add(new DiningEasyBattleP());
		line.Add(new DiningEasyBattleP());
		line.Add(new DiningEasyBattleP());
		line.Add(new MysteryMeat());
		line.Add(new DiningEasyBattleR());
		eat.Add(new DiningEasyBattleP());
		eat.Add(new DiningEasyBattleR());
		eat.Add(new DiningEasyBattleP());
		eat.Add(new DiningEasyBattleR());
		eat.Add(new DiningMediumBattle());
		eat.Add(new DiningMediumBattle());
		eat.Add(new DiningMediumBattle());
		eat.Add(new DiningHardBattle());
		eat.Add(new ItemEvent(new Item[] {new Pizza(), new Celery(), new Curry(), new ProteinBar()}, "Tons of food is here untouched"));
		eat.Add(new Event("TA's are guarding some donuts", new LinkedList<TimedMethod>(
	        new TimedMethod[] {new TimedMethod(0, "NextEvent", new object[] {new ItemEvent(new Item[] {new Donut(), new Donut(), new Donut()},
			"The donuts are yours")}), new TimedMethod(0, "Battle", new object[] {new Character[] {new TeachingAssistant(), new TeachingAssistant(),
			new TeachingAssistant(), new TeachingAssistant()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("Resolve")}), null, null, "It's for the donuts", "Don't bother", null, null));
		eat.Add(new PoisonCoffee());
		kitchen.Add(new DiningMediumBattle());
		kitchen.Add(new DiningMediumBattle());
		kitchen.Add(new ExplodingKitchen());
		kitchen.Add(new CultHideout());
		kitchen.Add(new DiningMediumBattle());
		kitchen.Add(new DiningMediumBattle());
		clean.Add(new BattleEvent(new Character[] {new Janitor(), new Janitor()}, "No dishes are being washed anymore"));
		clean.Add(new DiningMediumBattle());
		clean.Add(new DiningHardBattle());
		clean.Add(new KitchenSlime());
		cut.Add(new DiningHardBattle());
		hard.Add(new DiningHardBattle());
		hard.Add(new DiningHardBattle());
		final.Add(new ItemEvent(new Item[] {new GoldenPizza(), new MegaCurry(), new Meatloaf(), new IronSpinach(), new Coffee()},
		    "You have fought your way to the untouched food supplies fed only to grant winners"));
	}
	
	public static Event Hall() {
		int index = rng.Next(hall.Count);
		Event e = hall[index];
		hall.RemoveAt(index);
		return e;
	}
	
	public static Event Line() {
		int index = rng.Next(line.Count);
		Event e = line[index];
		line.RemoveAt(index);
		return e;
	}
	
	public static Event Eat() {
		int index = rng.Next(eat.Count);
		Event e = eat[index];
		eat.RemoveAt(index);
		return e;
	}
	
	public static Event Kitchen() {
		int index = rng.Next(kitchen.Count);
		Event e =kitchen[index];
		kitchen.RemoveAt(index);
		return e;
	}
	
	public static Event Clean() {
		int index = rng.Next(clean.Count);
		Event e = clean[index];
		clean.RemoveAt(index);
		return e;
	}
	
	public static Event Cut() {
		int index = rng.Next(cut.Count);
		Event e = cut[index];
		cut.RemoveAt(index);
		return e;
	}
	
	public static Event Hard() {
		int index = rng.Next(hard.Count);
		Event e = hard[index];
		hard.RemoveAt(index);
		return e;
	}
	
	public static Event Final() {
		int index = rng.Next(final.Count);
		Event e = final[index];
		final.RemoveAt(index);
		return e;
	}
}
