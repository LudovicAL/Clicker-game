using UnityEngine.UI;

public class MaxMana : Upgrade {

	public MaxMana(Button upgradeButton, string name, string description): base (upgradeButton, name, description) {

	}

	public override void ApplyUpgradeEffect() {
		PersistentData.maxMana += 50;
	}

	public override void CalculateCostOfNextLevel() {

	}

	public override bool IsUpgradeAvailable() {
		return true;
	}
}
