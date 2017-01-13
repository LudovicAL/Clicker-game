﻿using UnityEngine;

public class UMaxMana : Upgrade {

	public UMaxMana(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.maxMana = 100 + ((float)currentLevel * 50);
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfUpgradesAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 5);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}
}