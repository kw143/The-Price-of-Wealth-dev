using System.Collections.Generic;

public class Demonstration : Event {
	
	public Demonstration () {}
	
	public override void Enact () {
		text = "You are ambushed! A group of like-dressed people behind you speak in unison: \"We represent the googoo party."
		    + " We must stop the meepmeep party from gaining any political power. To get support, we bar any from passing unless they read"
			+ " This manifest\n. One waves a 300 page book around";
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {new Character[] {new PoliticalScientist(), new PoliticalScientist(),
		new PoliticalScientist(), new PoliticalScientist()}}));
		optionText1 = "They're cultists? (fight)";
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "SpendTime", new object[] {2}));
		options2.AddLast(new TimedMethod(0, "Apathize", new object[] {3}));
		options2.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("You read the book. It is boring and takes forever."
		    + " Everyone feels less hope for humanity")}));
		optionText2 = "Read the manifest!";
		if (Party.PartyContains(new PoliticalScientist()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new ItemEvent(new Item[] {new Textbook()},
			    Party.members[Party.PartyContains(new PoliticalScientist())].ToString() + " speaks a string of gibberish."
				+ " The group says \"googoo forever, comrade.\" You receive a copy of the manifest")}));
			optionText3 = "Political Scientist: I know a secret message";
		}
		if (Party.BagContains(new VotedBadge())) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("\"Oh. Buzz off. Who votes early like that? Lame.\""
			    + " The group walks off to bother someone else")}));
			optionText4 = "VotedBadge: We voted already";
		}
	}
}