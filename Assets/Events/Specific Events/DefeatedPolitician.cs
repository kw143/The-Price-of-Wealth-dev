using System.Collections.Generic;

public class DefeatedPolitician : Event {
	
	public DefeatedPolitician() {
		
	}
	
	public override void Enact() {
		Areas.defeatedP = true;
		text = "You have defeated one of the 3 underlings and are 1 step closer to victory";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Resolve"));
		optionText1 = "Great";
	}
	
}