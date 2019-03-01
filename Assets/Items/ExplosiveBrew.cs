public class ExplosiveBrew : Item {
	
	public ExplosiveBrew () {name = "Explosive Brew"; description = "attack the enemy party. If their lead dodges, their whole team will"; price = 2;}
	
	public override TimedMethod[] Use () {
		//Party.AddItem(new Flask());
		Attacks.SetAudio("Slap", 6);
		return new TimedMethod[] {new TimedMethod(0, "AudioAfter", new object[] {"S Explosion", 10}),
		    new TimedMethod(60, "AttackAll", new object[] {true, 2, 2, Party.GetPlayer().GetAccuracy(), true})};
	}
}