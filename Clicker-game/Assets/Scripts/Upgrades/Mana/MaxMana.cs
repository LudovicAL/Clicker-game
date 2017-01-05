using UnityEngine.UI;

public class MaxMana : Upgrade {

	public MaxMana(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect() {
		PersistentData.maxMana += 50;
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {

	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return true;
	}
}
