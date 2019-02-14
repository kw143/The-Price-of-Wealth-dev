using System.Collections.Generic;

public class CentralAIEvent : Event {
	
	public CentralAIEvent() {
		text = "The Central AI";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies = new Character[] {new CentralAI()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}