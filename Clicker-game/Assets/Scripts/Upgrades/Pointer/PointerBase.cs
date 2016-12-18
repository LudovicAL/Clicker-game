using UnityEngine.UI;

public class PointerBase : Upgrade {

	public PointerBase(Button upgradeButton, string name, string description): base (upgradeButton, name, description) {

	}

	public override void ApplyUpgradeEffect() {
		PersistentData.baseClickingReward = currentLevel;
	}

	public override void CalculateCostOfNextLevel() {

	}

	public override bool IsUpgradeAvailable() {
		return true;
	}

}
