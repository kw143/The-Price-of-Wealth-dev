using System.Collections.Generic;

public static class DungeonMapData {
	
	public static Dictionary<string, DungeonMap> data;
	
	public static void Initialize () {
		Dictionary<string, AdjacencyList> towContents = new Dictionary<string, AdjacencyList>();
		towContents.Add("TowStart1", new AdjacencyList("TowStart1", new string[] {"TowStart2", "TowEasy1"}));
		towContents.Add("TowStart2", new AdjacencyList("TowStart2", new string[] {"TowStart1", "TowEasy2"}));
		towContents.Add("TowEasy1", new AdjacencyList("TowEasy1", new string[] {"TowStart1", "TowEasy3"}));
		towContents.Add("TowEasy2", new AdjacencyList("TowEasy2", new string[] {"TowStart2", "TowEasy4"}));
		towContents.Add("TowEasy3", new AdjacencyList("TowEasy3", new string[] {"TowEasy1", "TowMed1", "TowEasy4"}));
		towContents.Add("TowEasy4", new AdjacencyList("TowEasy4", new string[] {"TowEasy2", "TowMed2", "TowEasy3"}));
		towContents.Add("TowMed1", new AdjacencyList("TowMed1", new string[] {"TowEasy3", "TowMed3"}));
		towContents.Add("TowMed2", new AdjacencyList("TowMed2", new string[] {"TowEasy4", "TowMed4"}));
		towContents.Add("TowMed3", new AdjacencyList("TowMed3", new string[] {"TowMed1", "TowMed5"}));
		towContents.Add("TowMed4", new AdjacencyList("TowMed4", new string[] {"TowMed2", "TowMed6"}));
		towContents.Add("TowMed5", new AdjacencyList("TowMed5", new string[] {"TowMed3", "TowDiff1", "TowMed6"}));
		towContents.Add("TowMed6", new AdjacencyList("TowMed6", new string[] {"TowMed4", "TowDiff2", "TowMed5"}));
		towContents.Add("TowDiff1", new AdjacencyList("TowDiff1", new string[] {"TowMed5", "TowBoss"}));
		towContents.Add("TowDiff2", new AdjacencyList("TowDiff2", new string[] {"TowMed6", "TowBoss"}));
		towContents.Add("TowBoss", new AdjacencyList("TowBoss", new string[] {"TowDiff1", "TowDiff2", "TowFinal"}));
		towContents.Add("TowFinal", new AdjacencyList("TowFinal", new string[] {"TowBoss"}));
		Dictionary<string, Event> towEvents = new Dictionary<string, Event>();
		TowerGetter.Refresh();
		towEvents.Add("TowStart1", TowerGetter.Easy());
		towEvents.Add("TowStart2", TowerGetter.Easy());
		towEvents.Add("TowEasy1", TowerGetter.Easy());
		towEvents.Add("TowEasy2", TowerGetter.Easy());
		towEvents.Add("TowEasy3", TowerGetter.Easy());
		towEvents.Add("TowEasy4", TowerGetter.Easy());
		towEvents.Add("TowMed1", TowerGetter.Medium());
		towEvents.Add("TowMed2", TowerGetter.Medium());
		towEvents.Add("TowMed3", TowerGetter.Medium());
		towEvents.Add("TowMed4", TowerGetter.Medium());
		towEvents.Add("TowMed5", TowerGetter.Medium());
		towEvents.Add("TowMed6", TowerGetter.Medium());
		towEvents.Add("TowDiff1", TowerGetter.Hard());
		towEvents.Add("TowDiff2", TowerGetter.Hard());
		towEvents.Add("TowBoss", new CentralAIEvent());
		towEvents.Add("TowFinal", new Event("A desk with huge stacks of admission letters is before you. Someone is very inspired by this",
    		new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who is inspired?",
			new TimedMethod[] {new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 2}), new TimedMethod(0, "StatChange", new object[] {
			"GainStrength", 2}), new TimedMethod(0, "CauseEvent", new object[] {
			new TextEvent("Strength +2, Dex +2")})})})}), null, null, null, "Wow!", null, null, null));
		DungeonMap tower = new DungeonMap("TowStart1", towContents, towEvents);
		
		Dictionary<string, AdjacencyList> dinContents = new Dictionary<string, AdjacencyList>();
		dinContents.Add("DinStart", new AdjacencyList("DinStart", new string[] {"DinEat1", "DinLine1"}));
		dinContents.Add("DinEat1", new AdjacencyList("DinEat1", new string[] {"DinStart", "DinLine1", "DinEat2", "DinEat3", "DinEat4"}));
		dinContents.Add("DinEat2", new AdjacencyList("DinEat2", new string[] {"DinEat1", "DinEat3", "DinEat4"}));
		dinContents.Add("DinEat3", new AdjacencyList("DinEat3", new string[] {"DinHall2", "DinLine2", "DinEat1", "DinEat2", "DinEat4"}));
		dinContents.Add("DinEat4", new AdjacencyList("DinEat4", new string[] {"DinHall2", "DinEat1", "DinEat2", "DinEat3"}));
		dinContents.Add("DinLine1", new AdjacencyList("DinLine1", new string[] {"DinStart", "DinEat1", "DinLine2"}));
		dinContents.Add("DinLine2", new AdjacencyList("DinLine2", new string[] {"DinLine1", "DinEat3", "DinHall1"}));
		dinContents.Add("DinHall1", new AdjacencyList("DinHall1", new string[] {"DinLine2", "DinKitchen1"}));
		dinContents.Add("DinHall2", new AdjacencyList("DinHall2", new string[] {"DinEat3", "DinEat4", "DinEat5"}));
		dinContents.Add("DinEat5", new AdjacencyList("DinEat5", new string[] {"DinHall2", "DinEat6", "DinCut"}));
		dinContents.Add("DinEat6", new AdjacencyList("DinEat6", new string[] {"DinEat5", "DinCut"}));
		dinContents.Add("DinKitchen1", new AdjacencyList("DinKitchen1", new string[] {"DinHall1", "DinKitchen2", "DinClean"}));
		dinContents.Add("DinKitchen2", new AdjacencyList("DinKitchen2", new string[] {"DinKitchen1", "DinClean"}));
		dinContents.Add("DinClean", new AdjacencyList("DinClean", new string[] {"DinKitchen1", "DinKitchen2", "DinDiff1", "DinDiff2"}));
		dinContents.Add("DinDiff1", new AdjacencyList("DinDiff1", new string[] {"DinClean", "DinBoss"}));
		dinContents.Add("DinDiff2", new AdjacencyList("DinDiff2", new string[] {"DinClean", "DinCut", "DinBoss"}));
		dinContents.Add("DinCut", new AdjacencyList("DinCut", new string[] {"DinEat5", "DinEat6", "DinDiff2"}));
		dinContents.Add("DinBoss", new AdjacencyList("DinBoss", new string[] {"DinDiff1", "DinDiff2", "DinFinal"}));
		dinContents.Add("DinFinal", new AdjacencyList("DinFinal", new string[] {"DinBoss"}));
		Dictionary<string, Event> dinEvents = new Dictionary<string, Event>();
		DiningGetter.Refresh();
		dinEvents.Add("DinStart", DiningGetter.Hall());
		dinEvents.Add("DinEat1", DiningGetter.Eat());
		dinEvents.Add("DinEat2", DiningGetter.Eat());
		dinEvents.Add("DinEat3", DiningGetter.Eat());
		dinEvents.Add("DinEat4", DiningGetter.Eat());
		dinEvents.Add("DinLine1", DiningGetter.Line());
		dinEvents.Add("DinLine2", DiningGetter.Line());
		dinEvents.Add("DinHall1", DiningGetter.Hall());
		dinEvents.Add("DinHall2", DiningGetter.Hall());
		dinEvents.Add("DinEat5", DiningGetter.Eat());
		dinEvents.Add("DinEat6", DiningGetter.Eat());
		dinEvents.Add("DinKitchen1", DiningGetter.Kitchen());
		dinEvents.Add("DinKitchen2", DiningGetter.Kitchen());
		dinEvents.Add("DinClean", DiningGetter.Clean());
		dinEvents.Add("DinDiff1", DiningGetter.Hard());
		dinEvents.Add("DinDiff2", DiningGetter.Hard());
		dinEvents.Add("DinCut", DiningGetter.Cut());
		dinEvents.Add("DinBoss", new CultLeaderEvent());
		dinEvents.Add("DinFinal", DiningGetter.Final());
		DungeonMap dining = new DungeonMap("DinStart", dinContents, dinEvents);
		
		Dictionary<string, AdjacencyList> resContents = new Dictionary<string, AdjacencyList>();
		resContents.Add("ResStart", new AdjacencyList("ResStart", new string[] {"ResHall1", "ResHall3"}));
		resContents.Add("ResHall1", new AdjacencyList("ResHall1", new string[] {"ResStart", "ResCut1"}));
		resContents.Add("ResCut1", new AdjacencyList("ResCut1", new string[] {"ResHall1", "ResHall2"}));
		resContents.Add("ResHall2", new AdjacencyList("ResHall2", new string[] {"ResCut1", "ResHall7", "ResLab1"}));
		resContents.Add("ResLab1", new AdjacencyList("ResLab1", new string[] {"ResHall2"}));
		resContents.Add("ResHall3", new AdjacencyList("ResHall3", new string[] {"ResStart", "ResHall4", "ResHall8"}));
		resContents.Add("ResHall4", new AdjacencyList("ResHall4", new string[] {"ResHall3", "ResHall5"}));
		resContents.Add("ResHall5", new AdjacencyList("ResHall5", new string[] {"ResHall4", "ResRew"}));
		resContents.Add("ResRew", new AdjacencyList("ResRew", new string[] {"ResHall5", "ResHall6"}));
		resContents.Add("ResHall6", new AdjacencyList("ResHall6", new string[] {"ResRew", "ResHall7"}));
		resContents.Add("ResHall7", new AdjacencyList("ResHall7", new string[] {"ResHall6", "ResHall2", "ResBoss", "ResLab2"}));
		resContents.Add("ResLab2", new AdjacencyList("ResLab2", new string[] {"ResHall7"}));
		resContents.Add("ResHall8", new AdjacencyList("ResHall8", new string[] {"ResHall3", "ResCut2"}));
		resContents.Add("ResCut2", new AdjacencyList("ResCut2", new string[] {"ResHall8", "ResHall9"}));
		resContents.Add("ResHall9", new AdjacencyList("ResHall9", new string[] {"ResCut2", "ResBoss"}));
		resContents.Add("ResBoss", new AdjacencyList("ResBoss", new string[] {"ResHall9", "ResHall7", "ResFinal"}));
		resContents.Add("ResFinal", new AdjacencyList("ResFinal", new string[] {"ResBoss"}));
		Dictionary<string, Event> resEvents = new Dictionary<string, Event>();
		ResearchGetter.Refresh();
		resEvents.Add("ResStart", ResearchGetter.Easy());
	    resEvents.Add("ResHall1", ResearchGetter.Easy());
		resEvents.Add("ResCut1", ResearchGetter.Cut());
		resEvents.Add("ResHall2", ResearchGetter.Medium());
		resEvents.Add("ResLab1", ResearchGetter.Lab());
		resEvents.Add("ResHall3", ResearchGetter.Easy());
		resEvents.Add("ResHall4", ResearchGetter.Easy());
		resEvents.Add("ResHall5", ResearchGetter.Medium());
		resEvents.Add("ResRew", ResearchGetter.Reward());
		resEvents.Add("ResHall6", ResearchGetter.Medium());
		resEvents.Add("ResHall7", ResearchGetter.Hard());
		resEvents.Add("ResLab2", ResearchGetter.Lab());
		resEvents.Add("ResHall8", ResearchGetter.Easy());
		resEvents.Add("ResCut2", ResearchGetter.Cut());
		resEvents.Add("ResHall9", ResearchGetter.Hard());
		resEvents.Add("ResBoss", new ExpirimentorEvent());
		resEvents.Add("ResFinal", ResearchGetter.Final());
		DungeonMap research = new DungeonMap("ResStart", resContents, resEvents);
		
		Dictionary<string, AdjacencyList> spoContents = new Dictionary<string, AdjacencyList>();
		spoContents.Add("SpoStart", new AdjacencyList("SpoStart", new string[] {"SpoHall1", "SpoHall3"}));
		spoContents.Add("SpoHall1", new AdjacencyList("SpoHall1", new string[] {"SpoStart", "SpoHall2"}));
		spoContents.Add("SpoHall2", new AdjacencyList("SpoHall2", new string[] {"SpoHall1", "SpoRoom1"}));
		spoContents.Add("SpoRoom1", new AdjacencyList("SpoRoom1", new string[] {"SpoHall2", "SpoRoom2", "SpoStand1"}));
		spoContents.Add("SpoRoom2", new AdjacencyList("SpoRoom2", new string[] {"SpoRoom1", "SpoGate1"}));
		spoContents.Add("SpoGate1", new AdjacencyList("SpoGate1", new string[] {"SpoRoom2", "SpoField1"}));
		spoContents.Add("SpoField1", new AdjacencyList("SpoField1", new string[] {"SpoGate1", "SpoStand2", "SpoBoss"}));
		spoContents.Add("SpoStand1", new AdjacencyList("SpoStand1", new string[] {"SpoRoom1", "SpoStand2"}));
		spoContents.Add("SpoStand2", new AdjacencyList("SpoStand2", new string[] {"SpoStand1", "SpoStand4", "SpoField1"}));
		spoContents.Add("SpoHall3", new AdjacencyList("SpoHall3", new string[] {"SpoStart", "SpoHall4"}));
		spoContents.Add("SpoHall4", new AdjacencyList("SpoHall4", new string[] {"SpoHall3", "SpoRoom3"}));
		spoContents.Add("SpoRoom3", new AdjacencyList("SpoRoom3", new string[] {"SpoHall4", "SpoRoom4", "SpoStand3"}));
		spoContents.Add("SpoRoom4", new AdjacencyList("SpoRoom4", new string[] {"SpoRoom3", "SpoGate2"}));
		spoContents.Add("SpoGate2", new AdjacencyList("SpoGate2", new string[] {"SpoRoom4", "SpoField2"}));
		spoContents.Add("SpoField2", new AdjacencyList("SpoField2", new string[] {"SpoGate2", "SpoStand4", "SpoBoss"}));
		spoContents.Add("SpoStand3", new AdjacencyList("SpoStand3", new string[] {"SpoRoom3", "SpoStand4"}));
		spoContents.Add("SpoStand4", new AdjacencyList("SpoStand4", new string[] {"SpoStand3", "SpoStand2", "SpoField2"}));
		spoContents.Add("SpoBoss", new AdjacencyList("SpoBoss", new string[] {"SpoField1", "SpoField2", "SpoFinal"}));
		spoContents.Add("SpoFinal", new AdjacencyList("SpoFinal", new string[] {"SpoBoss"}));
		Dictionary<string, Event> spoEvents = new Dictionary<string, Event>();
		SportsGetter.Refresh();
		spoEvents.Add("SpoStart", SportsGetter.Hall());
	    spoEvents.Add("SpoHall1", SportsGetter.Hall());
		spoEvents.Add("SpoHall2", SportsGetter.Hall());
		spoEvents.Add("SpoRoom1", SportsGetter.Room());
		spoEvents.Add("SpoRoom2", SportsGetter.Room());
		spoEvents.Add("SpoGate1", SportsGetter.Gate());
		spoEvents.Add("SpoField1", SportsGetter.Field());
		spoEvents.Add("SpoStand1", SportsGetter.Stand());
		spoEvents.Add("SpoStand2", SportsGetter.Stand());
		spoEvents.Add("SpoHall3", SportsGetter.Hall());
		spoEvents.Add("SpoHall4", SportsGetter.Hall());
		spoEvents.Add("SpoRoom3", SportsGetter.Room());
		spoEvents.Add("SpoRoom4", SportsGetter.Room());
		spoEvents.Add("SpoGate2", SportsGetter.Gate());
		spoEvents.Add("SpoField2", SportsGetter.Field());
		spoEvents.Add("SpoStand3", SportsGetter.Stand());
		spoEvents.Add("SpoStand4", SportsGetter.Stand());
		spoEvents.Add("SpoBoss", new QuarterbackEvent());
		spoEvents.Add("SpoFinal", SportsGetter.Final());
		DungeonMap sports = new DungeonMap("SpoStart", spoContents, spoEvents);
		
		Dictionary<string, AdjacencyList> artContents = new Dictionary<string, AdjacencyList>();
		artContents.Add("ArtStart1", new AdjacencyList("ArtStart1", new string[] {"ArtRoom1"}));
		artContents.Add("ArtStart2", new AdjacencyList("ArtStart2", new string[] {"ArtRoom2"}));
		artContents.Add("ArtRoom1", new AdjacencyList("ArtRoom1", new string[] {"ArtStart1", "ArtHall1", "ArtHall3"}));
		artContents.Add("ArtRoom2", new AdjacencyList("ArtRoom2", new string[] {"ArtStart2", "ArtHall1", "ArtHall4"}));
		artContents.Add("ArtHall1", new AdjacencyList("ArtHall1", new string[] {"ArtRoom1", "ArtRoom2", "ArtHall2"}));
		artContents.Add("ArtHall2", new AdjacencyList("ArtHall2", new string[] {"ArtHall1", "ArtGallery1"}));
		artContents.Add("ArtHall3", new AdjacencyList("ArtHall3", new string[] {"ArtRoom1", "ArtStage1"}));
		artContents.Add("ArtHall4", new AdjacencyList("ArtHall4", new string[] {"ArtRoom2", "ArtStage2"}));
		artContents.Add("ArtGallery1", new AdjacencyList("ArtGallery1", new string[] {"ArtHall2", "ArtHall5"}));
		artContents.Add("ArtHall5", new AdjacencyList("ArtHall5", new string[] {"ArtGallery1", "ArtGallery2", "ArtGallery3"}));
		artContents.Add("ArtStage1", new AdjacencyList("ArtStage1", new string[] {"ArtHall3", "ArtStore1"}));
		artContents.Add("ArtStage2", new AdjacencyList("ArtStage2", new string[] {"ArtHall4", "ArtStore2"}));
		artContents.Add("ArtStore1", new AdjacencyList("ArtStore1", new string[] {"ArtStage1", "ArtGallery2"}));
		artContents.Add("ArtStore2", new AdjacencyList("ArtStore2", new string[] {"ArtStage2", "ArtGallery3"}));
		artContents.Add("ArtGallery2", new AdjacencyList("ArtGallery2", new string[] {"ArtStore1", "ArtHall5", "ArtRecep"}));
		artContents.Add("ArtGallery3", new AdjacencyList("ArtGallery3", new string[] {"ArtStore2", "ArtHall5", "ArtRecep"}));
		artContents.Add("ArtRecep", new AdjacencyList("ArtRecep", new string[] {"ArtGallery2", "ArtGallery3", "ArtBoss"}));
		artContents.Add("ArtBoss", new AdjacencyList("ArtBoss", new string[] {"ArtRecep", "ArtFinal"}));
		artContents.Add("ArtFinal", new AdjacencyList("ArtFinal", new string[] {"ArtBoss"}));
		Dictionary<string, Event> artEvents = new Dictionary<string, Event>();
		ArtGetter.Refresh();
		artEvents.Add("ArtStart1", ArtGetter.Hall());
	    artEvents.Add("ArtStart2", ArtGetter.Hall());
		artEvents.Add("ArtRoom1", ArtGetter.Room());
		artEvents.Add("ArtRoom2", ArtGetter.Room());
		artEvents.Add("ArtHall1", ArtGetter.Hall());
		artEvents.Add("ArtHall2", ArtGetter.Hall());
		artEvents.Add("ArtHall3", ArtGetter.Hall());
		artEvents.Add("ArtHall4", ArtGetter.Hall());
		artEvents.Add("ArtGallery1", ArtGetter.Gallery());
		artEvents.Add("ArtHall5", ArtGetter.Hall());
		artEvents.Add("ArtStage1", ArtGetter.Stage());
		artEvents.Add("ArtStage2", ArtGetter.Stage());
		artEvents.Add("ArtStore1", ArtGetter.Store());
		artEvents.Add("ArtStore2", ArtGetter.Store());
		artEvents.Add("ArtGallery2", ArtGetter.Gallery());
		artEvents.Add("ArtGallery3", ArtGetter.Gallery());
		artEvents.Add("ArtRecep", ArtGetter.Recep());
		artEvents.Add("ArtBoss", new SymphonyEvent());
		artEvents.Add("ArtFinal", ArtGetter.Final());
		DungeonMap art = new DungeonMap("ArtStart1", artContents, artEvents);
		
		Dictionary<string, AdjacencyList> helContents = new Dictionary<string, AdjacencyList>();
		helContents.Add("HelStart", new AdjacencyList("HelStart", new string[] {"HelHall1"}));
		helContents.Add("HelRoom1", new AdjacencyList("HelRoom1", new string[] {"HelHall1"}));
		helContents.Add("HelRoom2", new AdjacencyList("HelRoom2", new string[] {"HelHall1"}));
		helContents.Add("HelRoom3", new AdjacencyList("HelRoom3", new string[] {"HelHall1"}));
		helContents.Add("HelRoom4", new AdjacencyList("HelRoom4", new string[] {"HelHall2"}));
		helContents.Add("HelRoom5", new AdjacencyList("HelRoom5", new string[] {"HelHall2"}));
		helContents.Add("HelRoom6", new AdjacencyList("HelRoom6", new string[] {"HelHall2"}));
		helContents.Add("HelRoom7", new AdjacencyList("HelRoom7", new string[] {"HelHall3"}));
		helContents.Add("HelRoom8", new AdjacencyList("HelRoom8", new string[] {"HelHall3"}));
		helContents.Add("HelRoom9", new AdjacencyList("HelRoom9", new string[] {"HelHall3"}));
		helContents.Add("HelHall1", new AdjacencyList("HelHall1", new string[] {"HelStart", "HelDesk1", "HelRoom1", "HelRoom2", "HelRoom3"}));
		helContents.Add("HelHall2", new AdjacencyList("HelHall2", new string[] {"HelDesk1", "HelDesk2", "HelRoom4", "HelRoom5", "HelRoom6"}));
		helContents.Add("HelHall3", new AdjacencyList("HelHall3", new string[] {"HelDesk2", "HelBoss", "HelRoom7", "HelRoom8", "HelRoom9"}));
		helContents.Add("HelDesk1", new AdjacencyList("HelDesk1", new string[] {"HelHall1", "HelHall2"}));
		helContents.Add("HelDesk2", new AdjacencyList("HelDesk2", new string[] {"HelHall2", "HelHall3", "HelStore"}));
		helContents.Add("HelStore", new AdjacencyList("HelStore", new string[] {"HelDesk2"}));
		helContents.Add("HelBoss", new AdjacencyList("HelBoss", new string[] {"HelHall3", "HelFinal"}));
		helContents.Add("HelFinal", new AdjacencyList("HelFinal", new string[] {"HelBoss"}));
		Dictionary<string, Event> helEvents = new Dictionary<string, Event>();
		HealthGetter.Refresh();
		helEvents.Add("HelStart", HealthGetter.Hall());
	    helEvents.Add("HelRoom1", HealthGetter.Room());
		helEvents.Add("HelRoom2", HealthGetter.Room());
		helEvents.Add("HelRoom3", HealthGetter.Room());
		helEvents.Add("HelRoom4", HealthGetter.Room());
		helEvents.Add("HelRoom5", HealthGetter.Room());
		helEvents.Add("HelRoom6", HealthGetter.Room());
		helEvents.Add("HelRoom7", HealthGetter.Room());
		helEvents.Add("HelRoom8", HealthGetter.Room());
		helEvents.Add("HelRoom9", HealthGetter.Room());
		helEvents.Add("HelHall1", HealthGetter.Hall());
		helEvents.Add("HelHall2", HealthGetter.Hall());
		helEvents.Add("HelHall3", HealthGetter.Hard());
		helEvents.Add("HelDesk1", HealthGetter.Desk());
		helEvents.Add("HelDesk2", HealthGetter.Desk());
		helEvents.Add("HelStore", HealthGetter.Store());
		helEvents.Add("HelBoss", new SurgeonEvent());
		helEvents.Add("HelFinal", HealthGetter.Final());
		DungeonMap health = new DungeonMap("HelStart", helContents, helEvents);
		
		Dictionary<string, AdjacencyList> lecContents = new Dictionary<string, AdjacencyList>();
		lecContents.Add("LecStart", new AdjacencyList("LecStart", new string[] {"LecHall1"}));
		lecContents.Add("LecHall1", new AdjacencyList("LecHall1", new string[] {"LecStart", "LecHall2", "LecLH1"}));
		lecContents.Add("LecHall2", new AdjacencyList("LecHall2", new string[] {"LecHall1", "LecRoom1"}));
		lecContents.Add("LecHall3", new AdjacencyList("LecHall3", new string[] {"LecRoom1", "LecRoom2", "LecRoom3"}));
		lecContents.Add("LecHall4", new AdjacencyList("LecHall4", new string[] {"LecRoom3", "LecRoom4", "LecRoom5"}));
		lecContents.Add("LecHall5", new AdjacencyList("LecHall5", new string[] {"LecLH1", "LecLH2"}));
		lecContents.Add("LecRoom1", new AdjacencyList("LecRoom1", new string[] {"LecHall2", "LecHall3", "LecOff1"}));
		lecContents.Add("LecRoom2", new AdjacencyList("LecRoom2", new string[] {"LecHall3", "LecOff1"}));
		lecContents.Add("LecRoom3", new AdjacencyList("LecRoom3", new string[] {"LecHall3", "LecHall4"}));
		lecContents.Add("LecRoom4", new AdjacencyList("LecRoom4", new string[] {"LecHall4", "LecOff2"}));
		lecContents.Add("LecRoom5", new AdjacencyList("LecRoom5", new string[] {"LecHall4", "LecOff2", "LecBoss"}));
		lecContents.Add("LecOff1", new AdjacencyList("LecOff1", new string[] {"LecRoom1", "LecRoom2"}));
		lecContents.Add("LecOff2", new AdjacencyList("LecOff2", new string[] {"LecRoom4", "LecRoom5"}));
		lecContents.Add("LecLH1", new AdjacencyList("LecLH1", new string[] {"LecHall1", "LecHall5"}));
		lecContents.Add("LecLH2", new AdjacencyList("LecLH2", new string[] {"LecHall5", "LecBoss"}));
		lecContents.Add("LecBoss", new AdjacencyList("LecBoss", new string[] {"LecRoom5", "LecLH2", "LecFinal"}));
		lecContents.Add("LecFinal", new AdjacencyList("LecFinal", new string[] {"LecBoss"}));
		Dictionary<string, Event> lecEvents = new Dictionary<string, Event>();
		LectureGetter.Refresh();
		lecEvents.Add("LecStart", LectureGetter.Hall());
	    lecEvents.Add("LecHall1", LectureGetter.Hall());
		lecEvents.Add("LecHall2", LectureGetter.Hall());
		lecEvents.Add("LecHall3", LectureGetter.Hall());
		lecEvents.Add("LecHall4", LectureGetter.Hall());
		lecEvents.Add("LecHall5", LectureGetter.Hall());
		lecEvents.Add("LecRoom1", LectureGetter.Room());
		lecEvents.Add("LecRoom2", LectureGetter.Room());
		lecEvents.Add("LecRoom3", LectureGetter.Room());
		lecEvents.Add("LecRoom4", LectureGetter.Room());
		lecEvents.Add("LecRoom5", LectureGetter.Hard());
		lecEvents.Add("LecOff1", LectureGetter.Office());
		lecEvents.Add("LecOff2", LectureGetter.Office());
		lecEvents.Add("LecLH1", LectureGetter.LH());
		lecEvents.Add("LecLH2", LectureGetter.LH());
		lecEvents.Add("LecBoss", new TenuredEvent());
		lecEvents.Add("LecFinal", LectureGetter.Final());
		DungeonMap lecture = new DungeonMap("LecStart", lecContents, lecEvents);
		
		
		data = new Dictionary<string, DungeonMap>();
		data.Add("tower", tower);
		data.Add("dining", dining);
		data.Add("research", research);
		data.Add("sports", sports);
		data.Add("art", art);
		data.Add("health", health);
		data.Add("lecture", lecture);
		
		Event ceo = new CEOEvent();
		Event politician = new PoliticianEvent();
		Event general = new GeneralEvent();
		Event final = new FinalBossEvent();
		HashSet<int> available = new HashSet<int>(new int[] {0, 1, 2, 3, 4, 5, 6});
		System.Random rng = new System.Random();
		int index;
		int[] mappedIndexes = new int[] {0, 1, 2, 3, 4, 5, 6};
		index = rng.Next(7);
		available.Remove(index);
		SetBoss(index, politician);
		Areas.bossLocations.Add(index);
		mappedIndexes[index] = 6;
		index = rng.Next(6);
		available.Remove(mappedIndexes[index]);
		SetBoss(mappedIndexes[index], ceo);
		Areas.bossLocations.Add(mappedIndexes[index]);
		mappedIndexes[index] = mappedIndexes[5];
		index = rng.Next(5);
		available.Remove(mappedIndexes[index]);
		SetBoss(mappedIndexes[index], general);
		Areas.bossLocations.Add(mappedIndexes[index]);
		mappedIndexes[index] = mappedIndexes[4];
		index = rng.Next(4);
		available.Remove(mappedIndexes[index]);
		SetBoss(mappedIndexes[index], final);
		Areas.bossLocations.Add(mappedIndexes[index]);
		int[] availableArray = new int[3];
		available.CopyTo(availableArray);
		foreach (int i in availableArray) {
			Areas.bossLocations.Add(i);
		}
		int starting = availableArray[rng.Next(3)];
		SetFirst(starting);
		Areas.SetLocation(starting);
	}
	
	public static void SetBoss(int index, Event boss) {
		switch (index) {
			case 0:
			    data["tower"].eventMap["TowBoss"] = boss;
				break;
			case 1:
			    data["dining"].eventMap["DinBoss"] = boss;
				break;
			case 2:
			    data["research"].eventMap["ResBoss"] = boss;
				break;
			case 3:
			    data["sports"].eventMap["SpoBoss"] = boss;
				break;
			case 4:
			    data["art"].eventMap["ArtBoss"] = boss;
				break;
			case 5:
			    data["health"].eventMap["HelBoss"] = boss;
				break;
			case 6:
			    data["lecture"].eventMap["LecBoss"] = boss;
				break;
		}
	}
	
	public static void SetFirst(int index) {
		DungeonMap graph = data["tower"];
		switch (index) {
			case 0:
			    graph = data["tower"];
				break;
			case 1:
			    graph = data["dining"];
				break;
			case 2:
			    graph = data["research"];
				break;
			case 3:
			    graph = data["sports"];
				break;
			case 4:
			    graph = data["art"];
				break;
			case 5:
			    graph = data["health"];
				break;
			case 6:
			    graph = data["lecture"];
				break;
		}
		graph.eventMap[graph.position] = new InitialRecruit();
	}
	
}