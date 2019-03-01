using System.Collections.Generic;

public class PossessedOrchestra : Event {
	
	public PossessedOrchestra () {}
	
	public override void Enact () {
		text = "This auditorium is host to a possessed orchestra echoing dissonantly";
		options1 = new LinkedList<TimedMethod>();
	    optionText1 = "Walk through normally";
	    options1.AddLast(new TimedMethod(0, "GainSP", new object[] {-5}));
    	options1.AddLast(new TimedMethod(0, "AllStatChange", new object[] {"GainDefense", -2}));
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The orchestra notices you and plays a particularly "
		    + "unnerving and haunting tune the entire way through, speeding up as you start running (SP -5, Party defense -2)")}));
		options2 = new LinkedList<TimedMethod>();   	
		optionText2 = "FIGHT THE ORCHESTRA";
		Character[] enemies = new Character[] {new Conductor(), new MusicMajor(), new MusicMajor(), new MusicMajor()};
		enemies[1].SetRecruitable(false); enemies[2].SetRecruitable(false); enemies[3].SetRecruitable(false);
    	options2.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		if (Party.PartyContains(new MusicMajor()) >= 0) {
			options3 = new LinkedList<TimedMethod>();
			options3.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent(Party.members[Party.PartyContains(new MusicMajor())].ToString()
			    + " starts playing with the orchestra, distracting them from the rest of the party long enough to escape the room")}));
			optionText3 = "Music Major: play along";
		}
		if (Party.BagContains(new Tuba())) {
			options4 = new LinkedList<TimedMethod>();
			options4.AddLast(new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("The poorly played tuba bounced off the walls."
			    + " Everyone feels a little deafer, but they didn't have to hear the screeching violins")}));
			optionText4 = "Tuba: Drown out their sound";
		}
	}
}