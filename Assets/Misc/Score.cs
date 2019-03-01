public static class Score {
	
	public static int score;
	public static int victories;
	public static int clears;
	
	public static void Reset () {
		score = 0;
		victories = 0;
		clears = 0;
	}
	
	public static void CalculateWin () {
	    GetClears();
		score = victories * 10 + clears * 50 + (100 - Time.timeUnit) * 20 + 1000;
	}
	
	public static void CalculateLoss () {
		GetClears();
		score = victories * 10 + clears * 50;
	}
	
	public static void GetClears () {
		foreach (bool b in Areas.cleared.Values) {
			if (b) {
				clears++;
			}
		}
	}
}