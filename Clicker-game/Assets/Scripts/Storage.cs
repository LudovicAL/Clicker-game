using System;

//A mockup class used to temporary store the data on load and save events
[Serializable]
public class Storage {
	//INVESTORS
	public double currentInvestors = 0;

	//OPTIONS
	public bool shortNumbers = true;
	public bool promptForPlanetName = true;
	public bool achievementsNotifications = true;

	//PLANET
	public string planetName = "";
	public float planetScale = 1.0f;
	public int planetIconId = 0;

	//CLICKING
	public double totalClickingReward = 1;
	public double highestTotalClickingRewardAchieved = 1;
	public double highestNumberOfClicsAchieved = 0;
	public double totalNumberOfClicks = 0;

	//FARMING
	public double totalFarmingReward = 0;
	public double highestTotalFarmingReward = 0;

	//MONEY
	public double currentMoney = 0;
	public double highestMoneyAchieved = 0;
	public double totalMoneyCollected = 0;

	//RESTARTS
	public int numberOfColonizedPlanets = 0;
	public int numberOfInvadedGalaxies = 0;
	public int numberOfCompanyRestarts = 0;

	//ABILITIES
	public int totalNumberOfAbilitiesUsed = 0;

	//RACES
	public int numberOfMarsiansAlliance = 0;
	public int numberOfVenusiansAlliance = 0;
	public int numberOfRobotAlliance = 0;

	//TIME
		//Game
	public DateTime timeAtLastSave = System.DateTime.Now;
	public TimeSpan longestPlayingSession = System.TimeSpan.Zero;
	public TimeSpan totalTimeSpentPlaying = System.TimeSpan.Zero;
	public TimeSpan totalTimeSpentOffline = System.TimeSpan.Zero;

		//Races
	public TimeSpan timeSpentPlayingMarsians = System.TimeSpan.Zero;
	public TimeSpan timeSpentPlayingVenusians = System.TimeSpan.Zero;
	public TimeSpan timeSpentPlayingRobots = System.TimeSpan.Zero;

	//CONSTRUCTION
	public int highestTotalNumberOfConstructionsAchieved = 0;
	public int[] constructionsQuantities = new int[10];
	public int[] constructionsUpgradesLevels = new int[10];

	//UPGRADES
	public int highestTotalNumberOfUpgradesAchieved = 0;

	//ACHIEVEMENTS

	//BULKBUYER

	//MANA
	public float highestMaxManaAchieved = 100.0f;
	public float highestManaRegenRateAchieved = 1.0f;
}