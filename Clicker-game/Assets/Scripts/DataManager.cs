using UnityEngine;
using System.Collections;
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
			this.GetComponent<AchievementsPanel> ().CheckWealthAchievements ();
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
		PersistentData.clickingMultiplier = (PersistentData.listOfPointerUpgrades[1].currentLevel + 1);
		PersistentData.storedData.totalClickingReward = PersistentData.baseClickingReward * PersistentData.clickingMultiplier;
	}

	#endregion

	#region Construction

	//Calculates the total farming reward
	public void CalculateTotalFarmingReward() {
		PersistentData.farmingRewardFromConstructions = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			PersistentData.farmingRewardFromConstructions += c.production; 
		}
		PersistentData.storedData.totalFarmingReward = PersistentData.farmingRewardFromConstructions;
		if (PersistentData.storedData.totalFarmingReward > PersistentData.storedData.highestTotalFarmingReward) {
			PersistentData.storedData.highestTotalFarmingReward = PersistentData.storedData.totalFarmingReward;
		}
	}

	//Calculates the current total number of construction
	public void CalculateCurrentTotalNumberOfConstruction() {
		int total = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			total += c.quantity;
		}
		PersistentData.currentTotalNumberOfConstruction = total;
		if (PersistentData.storedData.highestTotalNumberOfConstructionAchieved < PersistentData.currentTotalNumberOfConstruction) {
			PersistentData.storedData.highestTotalNumberOfConstructionAchieved = PersistentData.currentTotalNumberOfConstruction;
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

	#endregion
}
