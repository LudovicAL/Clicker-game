using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using System.IO;

public class DataManager : MonoBehaviour {

	public float pointerUpgradesCostModifier;

	void Start () {
		this.GetComponent<CanvasManager> ().OnLoadButtonClick ();
		InvokeRepeating("TimedUpdate", 1.0f, 1.0f);
		if (StaticData.storedData.planetName.Length == 0) {
			this.GetComponent<MainPanel> ().RandomizePlanet ();
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
	}
	
	void Update () {
		
	}

	//Launched every second
	void TimedUpdate() {
		AddMoney(StaticData.storedData.totalFarmingReward);
		AddMana (StaticData.manaRegenRate);
	}

	#region ManaStuff

	//Adds mana to the mana pool
	public void AddMana(float manaToAdd) {
		StaticData.currentMana = System.Math.Min (StaticData.currentMana + manaToAdd, StaticData.maxMana);
	}

	#endregion

	#region PointerStuff

	//Adds money to the player current money
	public void AddMoney(double moneyToAdd) {
		StaticData.storedData.currentMoney += moneyToAdd;
		if (StaticData.storedData.currentMoney > StaticData.storedData.highestMoneyAchieved) {
			StaticData.storedData.highestMoneyAchieved = StaticData.storedData.currentMoney;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfWealthAchievements);
		}
	}

	//Simulates a pointer click
	public void AddClick() {
		StaticData.currentNumberOfClicks += 1;
		StaticData.storedData.totalNumberOfClicks += 1;
		AddMoney(StaticData.storedData.totalClickingReward);
	}

	//Simulates n pointer clicks
	public void AddClicks(int numberOfClicks) {
		StaticData.currentNumberOfClicks += numberOfClicks;
		StaticData.storedData.totalNumberOfClicks += numberOfClicks;
		AddMoney(StaticData.storedData.totalClickingReward * numberOfClicks);
	}

	//Calculates the total clicking reward (and the base clicking reward and clicking multiplier in the process)
	public void CalculateTotalClickingReward() {
		StaticData.baseClickingReward = Mathf.Exp(StaticData.listOfPointerUpgrades[0].currentLevel);
		StaticData.clickingMultiplier = (float)(StaticData.listOfPointerUpgrades[1].currentLevel + (StaticData.storedData.currentInvestors * StaticData.bonusPerInvestor) + 1);
		StaticData.storedData.totalClickingReward = StaticData.baseClickingReward * (double)StaticData.clickingMultiplier;
	}

	#endregion

	#region Construction

	//Calculates the total farming reward
	public void CalculateTotalFarmingReward() {
		StaticData.farmingRewardFromConstructions = 0;
		foreach (Construction c in StaticData.listOfConstructions) {
			StaticData.farmingRewardFromConstructions += c.production; 
		}
		StaticData.storedData.totalFarmingReward = StaticData.farmingRewardFromConstructions * (StaticData.storedData.currentInvestors * (double)StaticData.bonusPerInvestor + 1);
		if (StaticData.storedData.totalFarmingReward > StaticData.storedData.highestTotalFarmingReward) {
			StaticData.storedData.highestTotalFarmingReward = StaticData.storedData.totalFarmingReward;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfWealthAchievements);
		}
	}

	//Calculates the current total number of construction
	public void CalculateCurrentTotalNumberOfConstructions() {
		int total = 0;
		foreach (Construction c in StaticData.listOfConstructions) {
			total += c.quantity;
		}
		StaticData.currentTotalNumberOfConstructions = total;
		if (StaticData.storedData.highestTotalNumberOfConstructionsAchieved < StaticData.currentTotalNumberOfConstructions) {
			StaticData.storedData.highestTotalNumberOfConstructionsAchieved = StaticData.currentTotalNumberOfConstructions;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfConstructionsAchievements);
		}
	}

	public void CalculateCurrentTotalNumberOfAchievements() {
		int total = 0;
		foreach (List<Achievement> la in StaticData.listOfListOfAchievements) {
			foreach (Achievement a in la) {
				total += a.currentLevel;
			}
		}
		StaticData.currentTotalNumberOfAchievements = total;
	}

	//Calculates the current total number of upgrades
	public void CalculateCurrentTotalNumberOfUpgrades() {
		int total = 0;
		foreach (Upgrade u in StaticData.listOfRacesUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in StaticData.listOfConstructionsUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in StaticData.listOfPointerUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in StaticData.listOfManaUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in StaticData.listOfInvestorsUpgrades) {
			total += u.currentLevel;
		}
		StaticData.currentTotalNumberOfUpgrades = total;
		if (StaticData.storedData.highestTotalNumberOfUpgradesAchieved < StaticData.currentTotalNumberOfUpgrades) {
			StaticData.storedData.highestTotalNumberOfUpgradesAchieved = StaticData.currentTotalNumberOfUpgrades;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfUpgradesAchievements);
		}
	}

	#endregion

	#region OtherStuff

	//Return the reward the player is entitled to after
	public double CalculateRewardAfterAbsence() {
		return (StaticData.timeSinceLastSave.TotalSeconds * StaticData.storedData.totalFarmingReward);
	}

	//Return the mana of the player after his absence
	public void UpdateManaAfterAbsence() {
		AddMana((float)(StaticData.timeSinceLastSave.TotalSeconds * StaticData.manaRegenRate));
	}

	//Restart the game
	public void Restart() {
		foreach (Construction c in StaticData.listOfConstructions) {
			c.AddNConstructions (-c.quantity);
		}
		foreach (Upgrade u in StaticData.listOfRacesUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in StaticData.listOfConstructionsUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in StaticData.listOfPointerUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in StaticData.listOfManaUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in StaticData.listOfInvestorsUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		StaticData.bonusPerInvestor = 0.01f;
		StaticData.baseClickingReward = 1;
		StaticData.clickingMultiplier = 1;
		StaticData.currentNumberOfClicks = 0;
		StaticData.currentNumberOfAbilitiesUsed = 0;
		StaticData.listOfAbilities = WordsLists.listOfRacesUpgrades [0].abilities;
		StaticData.currentRace = WordsLists.listOfRacesUpgrades [0];
		StaticData.timeSpentPlayingWithCurrentSession = System.TimeSpan.Zero;
		StaticData.listOfConstructions = WordsLists.listOfRacesUpgrades[0].constructions;
		StaticData.notificationList = new List<Achievement> ();
		StaticData.currentMana = 100;
		StaticData.maxMana = 100;
		StaticData.manaRegenRate = 1;
		StaticData.storedData.currentMoney = 0;
		StaticData.currentTotalNumberOfConstructions = 0;
		StaticData.currentTotalNumberOfUpgrades = 0;
		StaticData.storedData.constructionsQuantities = new int[10];
		StaticData.storedData.constructionsUpgradesLevels = new int[10];
		CalculateTotalClickingReward ();
		CalculateTotalFarmingReward ();
		StaticData.SaveData ();
	}

	#endregion
}
