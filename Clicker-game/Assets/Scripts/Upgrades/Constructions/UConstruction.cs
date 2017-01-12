using UnityEngine;

public class UConstruction : Upgrade {

	public UConstruction(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		//...
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		//...
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return true;
	}
}
