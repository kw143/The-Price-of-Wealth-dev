using System.Collections.Generic;

public static class LectureGetter {
	
	public static List<Event> hall;
	public static List<Event> room;
	public static List<Event> office;
	public static List<Event> lh;
	public static List<Event> hard;
	public static List<Event> final;
	public static System.Random rng = new System.Random();
	
	public static void Refresh () {
		hall = new List<Event>();
	    room = new List<Event>();
		office = new List<Event>();
	    hard = new List<Event>();
		lh = new List<Event>();
		final = new List<Event>();
		hall.Add(new LectureEasyBattleP());
	    hall.Add(new LectureEasyBattleR());
		hall.Add(new LectureEasyBattleP());
		hall.Add(new LectureEasyBattleR());
		hall.Add(new LectureEasyBattleR());
		hall.Add(new LectureEasyBattleR());
		room.Add(new LectureMediumBattle());
		room.Add(new LectureMediumBattle());
		room.Add(new LectureEasyBattleP());
		room.Add(new LectureEasyBattleP());
		room.Add(new LectureMediumBattle());
		office.Add(new LectureEasyBattleP());
		office.Add(new ItemEvent(new Item[] {new Coffee()}, "While snooping around, you find a legendary cup of coffee"));
		hard.Add(new LectureHardBattle());
		lh.Add(new Event("2 groups of students are arguing about stem vs liberal arts. They immediatly demand you take a side",
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Heal", new object[] {5}), 
			new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {
			new ChemistryMajor(), new CSMajor(), new AerospaceEngineer(), new MathMajor()}, "The STEM majors are enranged and attack")})}),
			new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "GainSP", new object[] {15}), new TimedMethod(
			0, "CauseEvent", new object[] {new BattleEvent( new Character[] {
			new EnglishMajor(), new CulinaryMajor(), new DanceMajor(), new MusicMajor()},
			"The liberal arts majors are enranged and attack")})}), null, null, "Side with the arts (Party heals)", "Side with stem (Gain SP)",
			null, null));
		lh.Add(new LectureHardBattle());
		lh.Add(new LectureHardBattle());
		lh.Add(new LectureHardBattle());
		final.Add(new ItemEvent(new Item[] {new Exam()}, "Wow! it's a graded exam that got a 105"));
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
	
	public static Event Office() {
		int index = rng.Next(office.Count);
		Event e = office[index];
		office.RemoveAt(index);
		return e;
	}
	
	public static Event Hard() {
		int index = rng.Next(hard.Count);
		Event e = hard[index];
		hard.RemoveAt(index);
		return e;
	}
	
	public static Event LH() {
		int index = rng.Next(lh.Count);
		Event e = lh[index];
		lh.RemoveAt(index);
		return e;
	}
	
	public static Event Final() {
		int index = rng.Next(final.Count);
		Event e = final[index];
		final.RemoveAt(index);
		return e;
	}
}
