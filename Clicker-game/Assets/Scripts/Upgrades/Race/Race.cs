using UnityEngine;
using System.Collections.Generic;

public class Race : Upgrade {
	public List<Construction> constructions { get; protected set; }
	public List<Ability> abilities { get; protected set; }

	public Race(string name, string description, List<Construction> constructions, List<Ability> abilities, double cost) : base (name, description) {
		this.constructions = constructions;
		this.abilities = abilities;
		this.costOfNextLevel = cost;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.currentRace = this;
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfAvailibility = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		if ((this != PersistentData.listOfRacesUpgrades [0]) &&	//Checks that it is not upgrade 0
		    (PersistentData.currentRace == PersistentData.listOfRacesUpgrades [0]) &&	//Checks that 'currentUpgrade' is upgrade 0
		    (PersistentData.currentMoney >= costOfAvailibility)) {	//Checks that the costOfAvailibility requirement is met
			return true;
		} else {
			return false;
		}
	}
}