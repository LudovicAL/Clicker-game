using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	public float pointerUpgradesCostModifier;

	// Use this for initialization
	void Start () {
		this.GetComponent<CanvasManager> ().OnLoadButtonClic ();
		InvokeRepeating("TimedUpdate", 1.0f, 1.0f);
		if (PersistentData.planetName.Length == 0) {
			this.GetComponent<MainPanel> ().RandomizePlanet ();
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TimedUpdate() {
		AddMoney(PersistentData.totalFarmingReward);
	}

	#region PointerStuff

	public void AddMoney(double moneyToAdd) {
		PersistentData.currentMoney += moneyToAdd;
		if (PersistentData.currentMoney > PersistentData.highestMoneyAchieved) {
			PersistentData.highestMoneyAchieved = PersistentData.currentMoney;
		}
	}


	public void AddClick() {
		PersistentData.currentNumberOfClicks += 1;
		PersistentData.totalNumberOfClicks += 1;
		AddMoney(PersistentData.totalClickingReward);
	}

	public void AddClicks(int numberOfClicks) {
		PersistentData.currentNumberOfClicks += numberOfClicks;
		PersistentData.totalNumberOfClicks += numberOfClicks;
		AddMoney(PersistentData.totalClickingReward * numberOfClicks);
	}

	//Calculates the total clicking reward (and the base clicking reward and clicking multiplier in the process)
	public void CalculateTotalClickingReward() {
		PersistentData.baseClickingReward = Mathf.Exp(PersistentData.listOfPointerUpgrades[0].currentLevel);
		PersistentData.clickingMultiplier = (PersistentData.listOfPointerUpgrades[1].currentLevel + 1);
		PersistentData.totalClickingReward = PersistentData.baseClickingReward * PersistentData.clickingMultiplier;
	}

	#endregion

	#region Construction

	public void CalculateTotalFarmingReward() {
		PersistentData.farmingRewardFromConstructions = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			PersistentData.farmingRewardFromConstructions += c.production; 
		}
		PersistentData.totalFarmingReward = PersistentData.farmingRewardFromConstructions;
		if (PersistentData.totalFarmingReward > PersistentData.highestTotalFarmingReward) {
			PersistentData.highestTotalFarmingReward = PersistentData.totalFarmingReward;
		}
	}

	//Calculates the current total number of construction
	public void CalculateCurrentTotalNumberOfConstruction() {
		int total = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			total += c.quantity;
		}
		PersistentData.currentTotalNumberOfConstruction = total;
		if (PersistentData.highestTotalNumberOfConstructionAchieved < PersistentData.currentTotalNumberOfConstruction) {
			PersistentData.highestTotalNumberOfConstructionAchieved = PersistentData.currentTotalNumberOfConstruction;
		}
	}

	#endregion

	#region OtherStuff

	//Return the reward the player is entitled to after
	public int CalculateRewardAfterAbsence() {
		return (int)(PersistentData.timeSinceLastSave.TotalSeconds * PersistentData.totalFarmingReward);
	}

	#endregion
}
