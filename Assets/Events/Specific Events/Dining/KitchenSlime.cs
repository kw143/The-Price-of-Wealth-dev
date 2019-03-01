using System.Collections.Generic;

public class KitchenSlime : Event {
	
	public KitchenSlime () {}
	
	public override void Enact () {
		text = "This used to be the dishwashing room, but something's... not right. The lights are off, broken glass is on the floor, and a..."
		    + "bubbling is heard from the center";
		options1 = new LinkedList<TimedMethod>();
		Character[] slime = new Character[] {new Slime()};
		slime[0].SetMaxHP(50); slime[0].SetHealth(50); slime[0].SetPower(8); slime[0].SetDefense(-8); slime[0].SetQuirk(new Catalyst(slime[0]));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(slime, "As you near the center of the room, a towering"
		    + " slime looms in front of you. Prepare yourself")}));
		optionText1 = "There is no other way forward";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod("Escape"));
		optionText2 = "Time to go";
		if (Party.BagContains(new SlimeGoo())) {
			options3 = new LinkedList<TimedMethod>();
			Character[] slimes = new Character[] {new Slime(), new Slime(), new Slime(), new Slime()};
			foreach (Character c in slimes) {
				c.SetMaxHP(15); c.SetHealth(15); c.SetPower(8); c.SetDefense(-8); c.SetQuirk(new Regeneration(c));
			}
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(slimes, 
			    "The slime goo shoots towards the center of the room into a much larger slime. "
				+ "It has an unstable reaction as the large slime splits into four. Will this be easier than its combined shape?")}));
			optionText3 = "Slime Goo: It calls for its kind";
		}
	}
}