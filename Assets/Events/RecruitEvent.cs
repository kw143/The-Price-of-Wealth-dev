using System.Collections.Generic;

public class RecruitEvent : Event {
	
	public RecruitEvent(Character member, string text) {
		this.text = text;
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {member}}));
		optionText1 = "Recruit " + member.type;
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Ignore";
	}
}