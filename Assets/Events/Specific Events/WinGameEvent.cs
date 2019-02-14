using System.Collections.Generic;

public class WinGameEvent : Event {
	
	public WinGameEvent() {
		
	}
	
	public override void Enact() {
		text = "You Win! But there's no win screen so the game will keep playing";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Resolve"));
		optionText1 = "Yay";
	}
	
}