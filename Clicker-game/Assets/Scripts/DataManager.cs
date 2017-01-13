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
		if (PersistentData.storedData.planetName.Length == 0) {
			this.GetComponent<MainPanel> ().RandomizePlanet ();
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
	}
	
	void Update () {
		
	}

	//Launched every second
	void TimedUpdate() {
		AddMoney(PersistentData.storedData.totalFarmingReward);
		AddMana (PersistentData.manaRegenRate);
	}

	#region ManaStuff

	//Adds mana to the mana pool
	public void AddMana(float manaToAdd) {
		PersistentData.currentMana = System.Math.Min (PersistentData.currentMana + manaToAdd, PersistentData.maxMana);
	}

	#endregion

	#region PointerStuff

	//Adds money to the player current money
	public void AddMoney(double moneyToAdd) {
		PersistentData.storedData.currentMoney += moneyToAdd;
		if (PersistentData.storedData.currentMoney > PersistentData.storedData.highestMoneyAchieved) {
			PersistentData.storedData.highestMoneyAchieved = PersistentData.storedData.currentMoney;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfWealthAchievements);
		}
	}

	//Simulates a pointer click
	public void AddClick() {
		PersistentData.currentNumberOfClicks += 1;
		PersistentData.storedData.totalNumberOfClicks += 1;
		AddMoney(PersistentData.storedData.totalClickingReward);
	}

	//Simulates n pointer clicks
	public void AddClicks(int numberOfClicks) {
		PersistentData.currentNumberOfClicks += numberOfClicks;
		PersistentData.storedData.totalNumberOfClicks += numberOfClicks;
		AddMoney(PersistentData.storedData.totalClickingReward * numberOfClicks);
	}

	//Calculates the total clicking reward (and the base clicking reward and clicking multiplier in the process)
	public void CalculateTotalClickingReward() {
		PersistentData.baseClickingReward = Mathf.Exp(PersistentData.listOfPointerUpgrades[0].currentLevel);
		PersistentData.clickingMultiplier = (float)(PersistentData.listOfPointerUpgrades[1].currentLevel + (PersistentData.storedData.currentInvestors * PersistentData.bonusPerInvestor) + 1);
		PersistentData.storedData.totalClickingReward = PersistentData.baseClickingReward * (double)PersistentData.clickingMultiplier;
	}

	#endregion

	#region Construction

	//Calculates the total farming reward
	public void CalculateTotalFarmingReward() {
		PersistentData.farmingRewardFromConstructions = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			PersistentData.farmingRewardFromConstructions += c.production; 
		}
		PersistentData.storedData.totalFarmingReward = PersistentData.farmingRewardFromConstructions * (PersistentData.storedData.currentInvestors * (double)PersistentData.bonusPerInvestor + 1);
		if (PersistentData.storedData.totalFarmingReward > PersistentData.storedData.highestTotalFarmingReward) {
			PersistentData.storedData.highestTotalFarmingReward = PersistentData.storedData.totalFarmingReward;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfWealthAchievements);
		}
	}

	//Calculates the current total number of construction
	public void CalculateCurrentTotalNumberOfConstructions() {
		int total = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			total += c.quantity;
		}
		PersistentData.currentTotalNumberOfConstructions = total;
		if (PersistentData.storedData.highestTotalNumberOfConstructionsAchieved < PersistentData.currentTotalNumberOfConstructions) {
			PersistentData.storedData.highestTotalNumberOfConstructionsAchieved = PersistentData.currentTotalNumberOfConstructions;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfConstructionsAchievements);
		}
	}

	//Calculates the current total number of upgrades
	public void CalculateCurrentTotalNumberOfUpgrades() {
		int total = 0;
		foreach (Upgrade u in PersistentData.listOfRacesUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in PersistentData.listOfConstructionsUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in PersistentData.listOfPointerUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in PersistentData.listOfManaUpgrades) {
			total += u.currentLevel;
		}
		foreach (Upgrade u in PersistentData.listOfInvestorsUpgrades) {
			total += u.currentLevel;
		}
		PersistentData.currentTotalNumberOfUpgrades = total;
		if (PersistentData.storedData.highestTotalNumberOfUpgradesAchieved < PersistentData.currentTotalNumberOfUpgrades) {
			PersistentData.storedData.highestTotalNumberOfUpgradesAchieved = PersistentData.currentTotalNumberOfUpgrades;
			this.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfUpgradesAchievements);
		}
	}

	#endregion

	#region OtherStuff

	//Return the reward the player is entitled to after
	public double CalculateRewardAfterAbsence() {
		return (PersistentData.timeSinceLastSave.TotalSeconds * PersistentData.storedData.totalFarmingReward);
	}

	//Return the mana of the player after his absence
	public void UpdateManaAfterAbsence() {
		AddMana((float)(PersistentData.timeSinceLastSave.TotalSeconds * PersistentData.manaRegenRate));
	}

	//Restart the game
	public void Restart() {
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.AddNConstructions (-c.quantity);
		}
		foreach (Upgrade u in PersistentData.listOfRacesUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in PersistentData.listOfConstructionsUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in PersistentData.listOfPointerUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in PersistentData.listOfManaUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		foreach (Upgrade u in PersistentData.listOfInvestorsUpgrades) {
			u.AddNLevel (-u.currentLevel, this.gameObject);
		}
		PersistentData.bonusPerInvestor = 0.01f;
		PersistentData.baseClickingReward = 1;
		PersistentData.clickingMultiplier = 1;
		PersistentData.currentNumberOfClicks = 0;
		PersistentData.currentNumberOfAbilitiesUsed = 0;
		PersistentData.listOfAbilities = WordsLists.listOfRacesUpgrades [0].abilities;
		PersistentData.currentRace = WordsLists.listOfRacesUpgrades [0];
		PersistentData.timeSpentPlayingWithCurrentSession = System.TimeSpan.Zero;
		PersistentData.listOfConstructions = WordsLists.listOfRacesUpgrades[0].constructions;
		PersistentData.notificationList = new List<Achievement> ();
		PersistentData.currentMana = 100;
		PersistentData.maxMana = 100;
		PersistentData.manaRegenRate = 1;
		PersistentData.storedData.currentMoney = 0;
		PersistentData.currentTotalNumberOfConstructions = 0;
		PersistentData.currentTotalNumberOfUpgrades = 0;
		PersistentData.storedData.constructionsQuantities = new int[10];
		PersistentData.storedData.constructionsUpgradesLevels = new int[10];
		CalculateTotalClickingReward ();
		CalculateTotalFarmingReward ();
		PersistentData.SaveData ();
	}

	#endregion
}
