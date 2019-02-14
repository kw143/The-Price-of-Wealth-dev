using System.Collections.Generic;

public static class TowerGetter {
	
	public static List<Event> easy;
	public static List<Event> med;
	public static List<Event> hard;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		easy = new List<Event>();
		med = new List<Event>();
		hard = new List<Event>();
		easy.Add(new TowerEasyBattleR());
		easy.Add(new TowerEasyBattleR());
		easy.Add(new TowerEasyBattleR());
		easy.Add(new TowerEasyBattleR());
		easy.Add(new TowerEasyBattleP());
		easy.Add(new TowerEasyBattleP());
		easy.Add(new TowerEasyBattleP());
		easy.Add(new TowerEasyBattleP());
		easy.Add(new AngryAdmin());
		easy.Add(new Event("2 Instructors are attacking a student", new LinkedList<TimedMethod>(
	        new TimedMethod[] {new TimedMethod(0, "Ally", new object[] {new Character[] {new HistoryMajor()}}),
			new TimedMethod(0, "Battle", new object[] { new Character[] {new Instructor(), new Instructor()}})}),
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Help - Gain an ally", "Move on", null, null));
		med.Add(new TowerMediumBattle());
		med.Add(new TowerMediumBattle());
		med.Add(new TowerMediumBattle());
		med.Add(new TowerMediumBattle());
		med.Add(new TowerMediumBattle());
		med.Add(new Event("You find a fully cooked pizza", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "Heal", new object[] {5}), new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "Item", new object[] {new Item[] {new Pizza()}})}), null, null, "Feast (5 hp to party)", "Take with you", null, null));
		med.Add(new Loudspeaker());
		med.Add(new CampusTour());
		med.Add(new Demonstration());
		hard.Add(new TowerHardBattle());
		hard.Add(new TowerHardBattle());
		hard.Add(new BuzzBot());
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
}
