using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

public static class PersistentData {
	//OPTIONS
	public static bool shortNumbers = true;
	public static bool promtForPlanetName = true;

	//MISCELLANOUS
	public static string planetName = "";

	//CLICKING
	public static double baseClickingReward = 1;
	public static int clickingMultiplier = 1;
	public static double totalClickingReward = 1;
	public static double highestTotalClickingRewardAchieved = 1;
	public static double currentNumberOfClicks = 0;
	public static double highestNumberOfClicsAchived = 0;
	public static double totalNumberOfClicks = 0;

	//FARMING
	public static double farmingRewardFromConstructions = 0;
	public static double totalFarmingReward = 0;
	public static double highestTotalFarmingReward = 0;

	//MONEY
	public static double currentMoney = 0;
	public static double highestMoneyAchieved = 0;
	public static double totalMoneyCollected = 0;

	//GEMS
		//Opals
	public static double currentOpals = 0;
	public static double highestOpalsAchieved = 0;
	public static double totalOpalsCollected = 0;
		//Diamond
	public static double currentDiamonds = 0;
	public static double highestDiamondsAchieved = 0;
	public static double totalDiamondsCollected = 0;
		//Ruby
	public static double currentRubies = 0;
	public static double highestRubiesAchieved = 0;
	public static double totalRubiesCollected = 0;
		//Emerald
	public static double currentEmeralds = 0;
	public static double highestEmeraldsAchieved = 0;
	public static double totalEmeraldsCollected = 0;
		//Silver
	public static double currentSilvers = 0;
	public static double highestSilversAchieved = 0;
	public static double totalSilversCollected = 0;
		//Bronze
	public static double currentBronzes = 0;
	public static double highestBronzesAchieved = 0;
	public static double totalBronzesCollected = 0;

	//GOLD INGOTS
	public static int currentGoldIngots = 0;
	public static int hightGoldIngotsAchieved = 0;
	public static int totalGoldIngotsAchieved = 0;

	//RESTARTS
	public static int numberOfColonizedPlanets = 0;
	public static int numberOfInvadedGalaxies = 0;
	public static int numberOfCompanyRestarts = 0;

	//ABILITIES
	public static int currentNumberOfAbilitiesUsed = 0;	//In the current session only
	public static int totalNumberOfAbilitiesUsed = 0;

	//RACES
	public static int numberOfMarsiansAlliance = 0;
	public static int numberOfVenusiansAlliance = 0;
	public static int numberOfRobotAlliance = 0;

	//CLASSES
	public static int numberOfGamesWithPaidEmployees = 0;
	public static int numberOfGamesWithSlaveEmployees = 0;

	//WORK FORCE
	public static double currentNumberOfEmployees = 0;
	public static double highestAchievedNumberOfEmployees = 0;

	//CONSTRUCTIONS
	public static int currentNumberOfConstruction1 = 0;
	public static int highestNumberOfConstruction1Achieved = 0;
	public static int currentNumberOfConstruction2 = 0;
	public static int highestNumberOfConstruction2Achieved = 0;
	public static int currentNumberOfConstruction3 = 0;
	public static int highestNumberOfConstruction4Achieved = 0;

	//TIME
		//Game
	public static TimeSpan timeSinceLastSave = System.TimeSpan.Zero;
	public static TimeSpan timeSpentPlayingWithCurrentSession = System.TimeSpan.Zero;
	public static TimeSpan longestPlayingSession = System.TimeSpan.Zero;
	public static TimeSpan totalTimeSpentPlaying = System.TimeSpan.Zero;
	public static TimeSpan totalTimeSpentOffline = System.TimeSpan.Zero;

		//Races
	public static TimeSpan timeSpentPlayingMarsians = System.TimeSpan.Zero;
	public static TimeSpan timeSpentPlayingVenusians = System.TimeSpan.Zero;
	public static TimeSpan timeSpentPlayingRobots = System.TimeSpan.Zero;

		//Classes
	public static TimeSpan timeSpentPayingEmployees = System.TimeSpan.Zero;
	public static TimeSpan timeSpentEnslavingEmployees = System.TimeSpan.Zero;

	//CONSTRUCTIONS
	public static Construction[] listOfConstructions = new Construction[10];

	//BULKBUYER
	public static RouletteButton bulkBuyer = new RouletteButton (new string[]{ "Buy 1", "Buy 10", "Buy 100", "Buy Max" }, new int[]{ 1, 10, 100, 0 });

	//STATIC CONSTRUCTOR
	static PersistentData() {
		string[] names = new string[]{ "Shovels", "Pickaxes", "Jackhammer", "???", "???", "???", "???", "???", "???", "???" };
		bool unlocked;
		for (int i = 0; i < listOfConstructions.Length; i++) {
			unlocked = (i < 3) ? true : false;
			listOfConstructions [i] = new Construction (names[i], 0, i + 1, 1.15f, null, null, unlocked);
		}
	}

	public static void SaveData() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/storedGameData.dat", FileMode.OpenOrCreate);
		Storage storage = new Storage ();
		storage.totalNumberOfClicks = totalNumberOfClicks;
		storage.timeAtLastsave = System.DateTime.Now;
		storage.shortNumbers = shortNumbers;
		storage.promptForPlanetName = promtForPlanetName;
		storage.planetName = planetName;
		bf.Serialize (file, storage);
		file.Close ();
	}

	public static void LoadData() {
		if (!System.IO.File.Exists(Application.persistentDataPath + "/storedGameData.dat")) {
			SaveData ();
		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open(Application.persistentDataPath + "/storedGameData.dat", FileMode.Open);
		Storage storage = (Storage)bf.Deserialize (file);
		file.Close ();
		totalNumberOfClicks = storage.totalNumberOfClicks;
		timeSinceLastSave = System.DateTime.Now - storage.timeAtLastsave;
		shortNumbers = storage.shortNumbers;
		promtForPlanetName = storage.promptForPlanetName;
		planetName = storage.planetName;
		CommonTools.updateNumbersNotations ();
	}
}

//A mockup class used to temporary store the data on load and save events
[Serializable]
class Storage {
	public DateTime timeAtLastsave;
	public double totalNumberOfClicks;
	public bool shortNumbers;
	public bool promptForPlanetName;
	public string planetName;
}