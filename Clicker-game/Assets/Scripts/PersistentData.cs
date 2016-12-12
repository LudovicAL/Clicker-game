using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

public static class PersistentData {
	//OPTIONS
	public static bool shortNumbers = true;
	public static bool promptForPlanetName = true;

	//PLANET
	public static string planetName = "";
	public static float planetScale = 1.0f;
	public static int planetIconId = 0;

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
	public static DateTime timeAtLastsave = System.DateTime.Now;
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
		//---
		//OPTIONS
		storage.shortNumbers = shortNumbers;
		storage.promptForPlanetName = promptForPlanetName;
		//PLANET
		storage.planetName = planetName;
		storage.planetScale = planetScale;
		storage.planetIconId = planetIconId;
		//CLICKING
		storage.baseClickingReward = baseClickingReward;
		storage.clickingMultiplier = clickingMultiplier;
		storage.totalClickingReward = totalClickingReward;
		storage.highestTotalClickingRewardAchieved = highestTotalClickingRewardAchieved;
		storage.currentNumberOfClicks = currentNumberOfClicks;
		storage.highestNumberOfClicsAchived = highestNumberOfClicsAchived;
		storage.totalNumberOfClicks = totalNumberOfClicks;

		//FARMING
		storage.farmingRewardFromConstructions = farmingRewardFromConstructions;
		storage.totalFarmingReward = totalFarmingReward;
		storage.highestTotalFarmingReward = highestTotalFarmingReward;

		//MONEY
		storage.currentMoney = currentMoney;
		storage.highestMoneyAchieved = highestMoneyAchieved;
		storage.totalMoneyCollected = totalMoneyCollected;

		//GEMS
		//Opals
		storage.currentOpals = currentOpals;
		storage.highestOpalsAchieved = highestOpalsAchieved;
		storage.totalOpalsCollected = totalOpalsCollected;
		//Diamond
		storage.currentDiamonds = currentDiamonds;
		storage.highestDiamondsAchieved = highestDiamondsAchieved;
		storage.totalDiamondsCollected = totalDiamondsCollected;
		//Ruby
		storage.currentRubies = currentRubies;
		storage.highestRubiesAchieved = highestRubiesAchieved;
		storage.totalRubiesCollected = totalRubiesCollected;
		//Emerald
		storage.currentEmeralds = currentEmeralds;
		storage.highestEmeraldsAchieved = highestEmeraldsAchieved;
		storage.totalEmeraldsCollected = totalEmeraldsCollected;
		//Silver
		storage.currentSilvers = currentSilvers;
		storage.highestSilversAchieved = highestSilversAchieved;
		storage.totalSilversCollected = totalSilversCollected;
		//Bronze
		storage.currentBronzes = currentBronzes;
		storage.highestBronzesAchieved = highestBronzesAchieved;
		storage.totalBronzesCollected = totalBronzesCollected;

		//GOLD INGOTS
		storage.currentGoldIngots = currentGoldIngots;
		storage.hightGoldIngotsAchieved = hightGoldIngotsAchieved;
		storage.totalGoldIngotsAchieved = totalGoldIngotsAchieved;

		//RESTARTS
		storage.numberOfColonizedPlanets = numberOfColonizedPlanets;
		storage.numberOfInvadedGalaxies = numberOfInvadedGalaxies;
		storage.numberOfCompanyRestarts = numberOfCompanyRestarts;

		//ABILITIES
		storage.currentNumberOfAbilitiesUsed = //In the current session onlycurrentNumberOfAbilitiesUsed;//In the current session only
			storage.totalNumberOfAbilitiesUsed = totalNumberOfAbilitiesUsed;

		//RACES
		storage.numberOfMarsiansAlliance = numberOfMarsiansAlliance;
		storage.numberOfVenusiansAlliance = numberOfVenusiansAlliance;
		storage.numberOfRobotAlliance = numberOfRobotAlliance;

		//CLASSES
		storage.numberOfGamesWithPaidEmployees = numberOfGamesWithPaidEmployees;
		storage.numberOfGamesWithSlaveEmployees = numberOfGamesWithSlaveEmployees;

		//WORK FORCE
		storage.currentNumberOfEmployees = currentNumberOfEmployees;
		storage.highestAchievedNumberOfEmployees = highestAchievedNumberOfEmployees;

		//CONSTRUCTIONS
		storage.currentNumberOfConstruction1 = currentNumberOfConstruction1;
		storage.highestNumberOfConstruction1Achieved = highestNumberOfConstruction1Achieved;
		storage.currentNumberOfConstruction2 = currentNumberOfConstruction2;
		storage.highestNumberOfConstruction2Achieved = highestNumberOfConstruction2Achieved;
		storage.currentNumberOfConstruction3 = currentNumberOfConstruction3;
		storage.highestNumberOfConstruction4Achieved = highestNumberOfConstruction4Achieved;

		//TIME
		//Game
		storage.timeAtLastsave = System.DateTime.Now;
		storage.timeSpentPlayingWithCurrentSession = timeSpentPlayingWithCurrentSession;
		storage.longestPlayingSession = longestPlayingSession;
		storage.totalTimeSpentPlaying = totalTimeSpentPlaying;
		storage.totalTimeSpentOffline = totalTimeSpentOffline;

		//Races
		storage.timeSpentPlayingMarsians = timeSpentPlayingMarsians;
		storage.timeSpentPlayingVenusians = timeSpentPlayingVenusians;
		storage.timeSpentPlayingRobots = timeSpentPlayingRobots;

		//Classes
		storage.timeSpentPayingEmployees = timeSpentPayingEmployees;
		storage.timeSpentEnslavingEmployees = timeSpentEnslavingEmployees;

		//Constructions
		storage.constructionsQuantity = new int[listOfConstructions.Length];
		storage.constructionsUpgradeLevel = new int[listOfConstructions.Length];
		for (int i = 0, max = listOfConstructions.Length; i < max; i++) {
			storage.constructionsQuantity[i] = listOfConstructions [i].Quantity;
			storage.constructionsUpgradeLevel[i] = listOfConstructions [i].UpgradeLevel;
		}

		//---
		bf.Serialize (file, storage);
		file.Close ();
	}

	public static void LoadData() {
		if (!System.IO.File.Exists(Application.persistentDataPath + "/storedGameData.dat")) {
			SaveData ();
		} else {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/storedGameData.dat", FileMode.Open);
			Storage storage = (Storage)bf.Deserialize (file);
			file.Close ();
			//---
			//OPTIONS
			shortNumbers = storage.shortNumbers;
			promptForPlanetName = storage.promptForPlanetName;

			//PLANET
			planetName = storage.planetName;
			planetScale = storage.planetScale;
			planetIconId = storage.planetIconId;

			//CLICKING
			baseClickingReward = storage.baseClickingReward;
			clickingMultiplier = storage.clickingMultiplier;
			totalClickingReward = storage.totalClickingReward;
			highestTotalClickingRewardAchieved = storage.highestTotalClickingRewardAchieved;
			currentNumberOfClicks = storage.currentNumberOfClicks;
			highestNumberOfClicsAchived = storage.highestNumberOfClicsAchived;
			totalNumberOfClicks = storage.totalNumberOfClicks;

			//FARMING
			farmingRewardFromConstructions = storage.farmingRewardFromConstructions;
			totalFarmingReward = storage.totalFarmingReward;
			highestTotalFarmingReward = storage.highestTotalFarmingReward;

			//MONEY
			currentMoney = storage.currentMoney;
			highestMoneyAchieved = storage.highestMoneyAchieved;
			totalMoneyCollected = storage.totalMoneyCollected;

			//GEMS
			//Opals
			currentOpals = storage.currentOpals;
			highestOpalsAchieved = storage.highestOpalsAchieved;
			totalOpalsCollected = storage.totalOpalsCollected;
			//Diamond
			currentDiamonds = storage.currentDiamonds;
			highestDiamondsAchieved = storage.highestDiamondsAchieved;
			totalDiamondsCollected = storage.totalDiamondsCollected;
			//Ruby
			currentRubies = storage.currentRubies;
			highestRubiesAchieved = storage.highestRubiesAchieved;
			totalRubiesCollected = storage.totalRubiesCollected;
			//Emerald
			currentEmeralds = storage.currentEmeralds;
			highestEmeraldsAchieved = storage.highestEmeraldsAchieved;
			totalEmeraldsCollected = storage.totalEmeraldsCollected;
			//Silver
			currentSilvers = storage.currentSilvers;
			highestSilversAchieved = storage.highestSilversAchieved;
			totalSilversCollected = storage.totalSilversCollected;
			//Bronze
			currentBronzes = storage.currentBronzes;
			highestBronzesAchieved = storage.highestBronzesAchieved;
			totalBronzesCollected = storage.totalBronzesCollected;

			//GOLD INGOTS
			currentGoldIngots = storage.currentGoldIngots;
			hightGoldIngotsAchieved = storage.hightGoldIngotsAchieved;
			totalGoldIngotsAchieved = storage.totalGoldIngotsAchieved;

			//RESTARTS
			numberOfColonizedPlanets = storage.numberOfColonizedPlanets;
			numberOfInvadedGalaxies = storage.numberOfInvadedGalaxies;
			numberOfCompanyRestarts = storage.numberOfCompanyRestarts;

			//ABILITIES
			currentNumberOfAbilitiesUsed = storage.currentNumberOfAbilitiesUsed;	//In the current session only
			totalNumberOfAbilitiesUsed = storage.totalNumberOfAbilitiesUsed;

			//RACES
			numberOfMarsiansAlliance = storage.numberOfMarsiansAlliance;
			numberOfVenusiansAlliance = storage.numberOfVenusiansAlliance;
			numberOfRobotAlliance = storage.numberOfRobotAlliance;

			//CLASSES
			numberOfGamesWithPaidEmployees = storage.numberOfGamesWithPaidEmployees;
			numberOfGamesWithSlaveEmployees = storage.numberOfGamesWithSlaveEmployees;

			//WORK FORCE
			currentNumberOfEmployees = storage.currentNumberOfEmployees;
			highestAchievedNumberOfEmployees = storage.highestAchievedNumberOfEmployees;

			//CONSTRUCTIONS
			currentNumberOfConstruction1 = storage.currentNumberOfConstruction1;
			highestNumberOfConstruction1Achieved = storage.highestNumberOfConstruction1Achieved;
			currentNumberOfConstruction2 = storage.currentNumberOfConstruction2;
			highestNumberOfConstruction2Achieved = storage.highestNumberOfConstruction2Achieved;
			currentNumberOfConstruction3 = storage.currentNumberOfConstruction3;
			highestNumberOfConstruction4Achieved = storage.highestNumberOfConstruction4Achieved;

			//TIME
			//Game
			timeAtLastsave = storage.timeAtLastsave;
			timeSinceLastSave = System.DateTime.Now - storage.timeAtLastsave;
			timeSpentPlayingWithCurrentSession = storage.timeSpentPlayingWithCurrentSession;
			longestPlayingSession = storage.longestPlayingSession;
			totalTimeSpentPlaying = storage.totalTimeSpentPlaying;
			totalTimeSpentOffline = storage.totalTimeSpentOffline;

			//Races
			timeSpentPlayingMarsians = storage.timeSpentPlayingMarsians;
			timeSpentPlayingVenusians = storage.timeSpentPlayingVenusians;
			timeSpentPlayingRobots = storage.timeSpentPlayingRobots;

			//Classes
			timeSpentPayingEmployees = storage.timeSpentPayingEmployees;
			timeSpentEnslavingEmployees = storage.timeSpentEnslavingEmployees;

			//Constructions
			for (int i = 0, max = listOfConstructions.Length; i < max; i++) {
				listOfConstructions [i].AddNConstructions(storage.constructionsQuantity [i] - listOfConstructions [i].Quantity);
				listOfConstructions [i].AddNUpgrades(storage.constructionsUpgradeLevel [i] - listOfConstructions [i].UpgradeLevel);
			}

			//---
			CommonTools.updateNumbersNotations ();
		}
	}
}