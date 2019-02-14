using System.Collections.Generic;

public class SurgeonEvent : Event {
	
	public SurgeonEvent() {
		text = "Surgeon";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies = new Character[] {new Surgeon()};
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}