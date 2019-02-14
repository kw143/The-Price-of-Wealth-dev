using System.Collections.Generic;

public class InitialRecruit : Event {
	
    public InitialRecruit () {
		text = "As you begin your journey, you'll want to form a team to help survive. Choose one of these two to add to your party";
	}
	
	public override void Enact () {
		Character[] choices = GetChoices();
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {choices[0]}}));
		optionText1 = choices[0].type;
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "Ally", new object[] {new Character[] {choices[1]}}));
		optionText2 = choices[1].type;
		options3 = new LinkedList<TimedMethod>();
		options3.AddLast(new TimedMethod(0, "Resolve", null));
		optionText3 = "Go alone";
	}
	
	public Character[] GetChoices() {
		Character[] choices = new Character[2];
		switch (Map.currentPosition) {
			case "tower":
			    choices[0] = new CJMajor();
				choices[1] = new PoliticalScientist();
				break;
			case "dining":
			    choices[0] = new CulinaryMajor();
				choices[1] = new EnglishMajor();
				break;
			case "research":
			    choices[0] = new ChemistryMajor();
				choices[1] = new MathMajor();
				break;
			case "sports":
			    choices[0] = new FootballPlayer();
				choices[1] = new AerospaceEngineer();
				break;
			case "art":
			    choices[0] = new DanceMajor();
				choices[1] = new MusicMajor();
				break;
			case "health":
			    choices[0] = new PreMed();
				choices[1] = new PsychMajor();
				break;
			case "lecture":
			    choices[0] = new HistoryMajor();
				choices[1] = new BusinessMajor();
				break;
		}
		return choices;
	}
}