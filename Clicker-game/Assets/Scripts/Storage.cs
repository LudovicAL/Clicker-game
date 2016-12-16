using System;

//A mockup class used to temporary store the data on load and save events
[Serializable]
class Storage {
	//OPTIONS
	public bool shortNumbers;
	public bool promptForPlanetName;

	//PLANET
	public string planetName;
	public float planetScale;
	public int planetIconId;

	//CLICKING
	public int baseClickingRewardUpgradeLevel;
	public int clickingMultiplierUpgradeLevel;
	public double totalClickingReward;
	public double highestTotalClickingRewardAchieved;
	public double highestNumberOfClicsAchived;
	public double totalNumberOfClicks;

	//FARMING
	public double farmingRewardFromConstructions;
	public double totalFarmingReward;
	public double highestTotalFarmingReward;

	//MONEY
	public double currentMoney;
	public double highestMoneyAchieved;
	public double totalMoneyCollected;

	//GEMS
	//Opals
	public double currentOpals;
	public double highestOpalsAchieved;
	public double totalOpalsCollected;
	//Diamond
	public double currentDiamonds;
	public double highestDiamondsAchieved;
	public double totalDiamondsCollected;
	//Ruby
	public double currentRubies;
	public double highestRubiesAchieved;
	public double totalRubiesCollected;
	//Emerald
	public double currentEmeralds;
	public double highestEmeraldsAchieved;
	public double totalEmeraldsCollected;
	//Silver
	public double currentSilvers;
	public double highestSilversAchieved;
	public double totalSilversCollected;
	//Bronze
	public double currentBronzes;
	public double highestBronzesAchieved;
	public double totalBronzesCollected;

	//GOLD INGOTS
	public int currentGoldIngots;
	public int hightGoldIngotsAchieved;
	public int totalGoldIngotsAchieved;

	//RESTARTS
	public int numberOfColonizedPlanets;
	public int numberOfInvadedGalaxies;
	public int numberOfCompanyRestarts;

	//ABILITIES
	public int currentNumberOfAbilitiesUsed;//In the current session only
	public int totalNumberOfAbilitiesUsed;

	//RACES
	public int numberOfMarsiansAlliance;
	public int numberOfVenusiansAlliance;
	public int numberOfRobotAlliance;

	//CLASSES
	public int numberOfGamesWithPaidEmployees;
	public int numberOfGamesWithSlaveEmployees;

	//WORK FORCE
	public double currentNumberOfEmployees;
	public double highestAchievedNumberOfEmployees;

	//TIME
	//Game
	public DateTime timeAtLastsave;
	public TimeSpan timeSinceLastSave;
	public TimeSpan timeSpentPlayingWithCurrentSession;
	public TimeSpan longestPlayingSession;
	public TimeSpan totalTimeSpentPlaying;
	public TimeSpan totalTimeSpentOffline;

	//Races
	public TimeSpan timeSpentPlayingMarsians;
	public TimeSpan timeSpentPlayingVenusians;
	public TimeSpan timeSpentPlayingRobots;

	//Classes
	public TimeSpan timeSpentPayingEmployees;
	public TimeSpan timeSpentEnslavingEmployees;

	//CONSTRUCTION
	public int highestTotalNumberOfConstructionAchieved;
	public int[] highestNumberOfConstructionAchieved;
	public int[] constructionsQuantity;
	public int[] constructionsUpgradeLevel;
}