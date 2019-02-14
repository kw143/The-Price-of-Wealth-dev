public class PoliticianE : Politician {
	
	public PoliticianE () {champion = false;}
	
	public override TimedMethod[] AI () {
		if (broken) {
			if (cycle < 2) {
				cycle++;
				return Weak();
			} else {
				cycle = 0;
				return SaveFace();
		    }
		} else {
		    if (cycle == 0) {
		    	cycle++;
	    		return CampaignDefense();
    		} else if (cycle == 1) {
		    	cycle++;
	    		return Filibuster();
     		} else if (cycle == 2) {
		    	cycle++;
	    	    return CampaignBalance();			
    		} else if (cycle == 3) {
		    	cycle++;
	    		return Veto();
    		} else if (cycle == 4) {
		    	cycle++;
	    		return CampaignOffense();
    		} else {
			    cycle = 0;
			    return Attack();
		    }
		}
	}
}