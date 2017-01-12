using UnityEngine;
using System.Collections.Generic;

public class URace : Upgrade {
	public List<Construction> constructions { get; protected set; }
	public List<Upgrade> upgrades { get; protected set; }
	public List<Ability> abilities { get; protected set; }

	public URace(string name, string description, List<Construction> constructions, List<Upgrade> upgrades, List<Ability> abilities, double cost, double costOfAvailability) : base (name, description) {
		this.constructions = constructions;
		this.upgrades = upgrades;
		this.abilities = abilities;
		this.costOfNextLevel = cost;
		this.costOfAvailability = costOfAvailability;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.currentRace = this;
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfUpgradesAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		//Nothing here
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		if ((this != PersistentData.listOfRacesUpgrades [0]) &&	//Checks that it is not upgrade 0
		    (PersistentData.currentRace == PersistentData.listOfRacesUpgrades [0]) &&	//Checks that 'currentUpgrade' is upgrade 0
		    (PersistentData.storedData.currentInvestors >= costOfAvailability)) {	//Checks that the costOfAvailibility requirement is met
			return true;
		} else {
			return false;
		}
	}
}