using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentData {

	#region Variables

	//STORAGE
	public static Storage storedData = new Storage();

	//INVESTORS
	public static double potentialInvestors = 0;
	public static float bonusPerInvestor = 0.01f;
	public static List<Upgrade> listOfInvestorsUpgrades = WordsLists.listOfInvestorsUpgrades;

	//PLANET

	//CLICKING
	public static double baseClickingReward = 1;
	public static float clickingMultiplier = 1;
	public static double currentNumberOfClicks = 0;

	//FARMING
	public static double farmingRewardFromConstructions = 0;

	//MONEY

	//RESTARTS

	//ABILITIES
	public static int currentNumberOfAbilitiesUsed = 0;	//In the current session only
	public static List<Ability> listOfAbilities = WordsLists.listOfRacesUpgrades [0].abilities;

	//RACES
	public static Race currentRace = WordsLists.listOfRacesUpgrades [0];

	//TIME
		//Game
	public static TimeSpan timeSinceLastSave = System.TimeSpan.Zero;
	public static TimeSpan timeSpentPlayingWithCurrentSession = System.TimeSpan.Zero;

		//Races

	//CONSTRUCTIONS
	public static int currentTotalNumberOfConstruction = 0;
	public static List<Construction> listOfConstructions = WordsLists.listOfRacesUpgrades[0].constructions;

	//UPGRADES
	public static List<Race> listOfRacesUpgrades = WordsLists.listOfRacesUpgrades;
	public static List<Upgrade> listOfPointerUpgrades = WordsLists.listOfPointerUpgrades;
	public static List<Upgrade> listOfManaUpgrades = WordsLists.listOfManaUpgrades;

	//ACHIEVEMENTS
	public static Achievement[] listOfWealthAchievements = WordsLists.listOfWealthAchievements;
	public static Achievement[] listOfTimeAchievements = WordsLists.listOfTimeAchievements;

	//NOTIFICATIONS
	public static List<Achievement> notificationList = new List<Achievement> ();

	//BULKBUYER
	public static RouletteButton bulkBuyer = new RouletteButton (new string[]{ "Buy 1", "Buy 10", "Buy 100", "Buy Max" }, new int[]{ 1, 10, 100, 0 });

	//MANA
	public static float currentMana = 100;
	public static float maxMana = 100;
	public static float manaRegenRate = 1;

	//STATIC CONSTRUCTOR
	static PersistentData() {
		//Nothing here yet...
	}

	#endregion

	#region SaveData

	public static void SaveData() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + Path.PathSeparator + "storedGameData.dat", FileMode.OpenOrCreate);
		storedData.timeAtLastSave = System.DateTime.Now;
		for (int i = 0, max = listOfConstructions.Count; i < max; i++) {
			storedData.constructionsQuantities[i] = listOfConstructions [i].quantity;
			storedData.constructionsUpgradesLevels[i] = listOfConstructions [i].upgradeLevel;
		}
		bf.Serialize (file, storedData);
		file.Close ();
	}

	#endregion

	#region LoadData

	public static void LoadData() {
		if (!System.IO.File.Exists(Application.persistentDataPath + "/storedGameData.dat")) {
			SaveData ();
		} else {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/storedGameData.dat", FileMode.Open);
			storedData = (Storage)bf.Deserialize (file);
			file.Close ();
			timeSinceLastSave = System.DateTime.Now - storedData.timeAtLastSave;
			for (int i = 0, max = listOfConstructions.Count; i < max; i++) {
				if (listOfConstructions[i] != null) {
					listOfConstructions [i].AddNConstructions(storedData.constructionsQuantities [i] - listOfConstructions [i].quantity);
					listOfConstructions [i].AddNUpgrades(storedData.constructionsUpgradesLevels [i] - listOfConstructions [i].upgradeLevel);
				}
			}
			CommonTools.UpdateNumbersNotations ();
		}
	}

	#endregion
}