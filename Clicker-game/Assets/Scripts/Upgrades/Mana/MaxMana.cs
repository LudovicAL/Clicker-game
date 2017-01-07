using UnityEngine;

public class MaxMana : Upgrade {

	public MaxMana(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.maxMana += 50;
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 5);
		costOfAvailibility = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.storedData.currentMoney >= costOfAvailibility) ? true : false;
	}
}
