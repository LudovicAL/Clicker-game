﻿using UnityEngine;

public class UConstruction : Upgrade {

	public int id { get; private set; }
	public int upgradeInterval { get; private set; }

	public UConstruction(string name, string description, int id, int upgradeInterval): base (name, description) {
		this.id = id;
		this.upgradeInterval = upgradeInterval;
	}

	//Returns the upgrade description
	public override string getName() {
		return WordsLists.upgradesAdjectives[currentLevel] + " " + name;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		scriptsBucket.GetComponent<DataManager>().CalculateTotalFarmingReward ();
		foreach (Construction c in StaticData.listOfConstructions) {
			c.CalculateContribution ();
			c.UpdateButtonDisplayedContribution ();
		}
		scriptsBucket.GetComponent<DataManager> ().CalculateCurrentTotalNumberOfUpgrades ();
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = (double)((currentLevel + 1) * id);
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (StaticData.listOfConstructions[id - 1].quantity >= ((currentLevel + 1) * upgradeInterval));
	}
}
