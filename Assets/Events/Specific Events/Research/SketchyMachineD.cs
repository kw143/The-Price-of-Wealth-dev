using System.Collections.Generic;

public class SketchyMachineD : Event {
	
	public SketchyMachineD () {}
	
	public override void Enact () {
		text = "You enter a room with a huge device that apparently enhances vitality. There is enough electricity for 1 person";
		TimedMethod[] contents = new TimedMethod[3];
		TimedMethod strength = new TimedMethod(0, "StatChange", new object[] {"GainStrength", -1});
		TimedMethod accuracy = new TimedMethod(0, "StatChange", new object[] {"GainAccuracy", -2});
		TimedMethod health = new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", 5});
		TimedMethod dexterity = new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 2});
		options1 = new LinkedList<TimedMethod>();
		string result = "The machine increased ";
		if (new System.Random().Next(2) == 0) {
			contents[0] = health;
			result = result + "max HP by 5 but reduced ";
		} else {
			contents[0] = dexterity;
			result = result + "dexterity by 2 but reduced ";
		}
		if (new System.Random().Next(2) == 0) {
			contents[1] = strength;
			result = result + "strength by 1";
		} else {
			contents[1] = accuracy;
			result = result + "accuracy by 2";
		}
		contents[2] = new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(result)});
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be altered?", contents)}));
		optionText1 = "Send someone to the machine";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "No unethical science";
	}
}