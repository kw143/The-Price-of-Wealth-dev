using System.Collections.Generic;

public class FinalBossEvent : Event {
	
	public FinalBossEvent() {
		text = "The final boss";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num;
		Character[] enemies = new Character[4];
		enemies[0] = new Villain();
		if (!Areas.defeatedP) {
			enemies[1] = new PoliticianE();
		}
		if (!Areas.defeatedG) {
			enemies[2] = new GeneralE();
		}
		if (!Areas.defeatedC) {
			enemies[3] = new CEOE();
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		options1.AddLast(new TimedMethod(0, "NextEvent", new object[] {new WinGameEvent()}));
	}
}