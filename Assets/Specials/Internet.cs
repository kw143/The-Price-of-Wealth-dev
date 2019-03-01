public class Internet : Special {
	
	public Internet() {name = "Internet"; description = "Learn about the opponent and gain evasion"; baseCost = 1; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		Party.GetPlayer().SetEvasion(Party.GetPlayer().GetEvasion() + 8);
		string[] lines = Party.GetEnemy().CSDescription();
		TimedMethod[] returned = new TimedMethod[lines.Length + 1];
		returned[0] = new TimedMethod(0, "Audio", new object[] {"Wikipedia"});
		int index = 1;
		foreach (string s in lines) {
			returned[index] = new TimedMethod(120, "Log", new object[] {s});
			index++;
		}
		return returned;
    }
}