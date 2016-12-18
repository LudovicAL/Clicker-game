using UnityEngine.UI;

public class PointerMultiplier : Upgrade {

	public PointerMultiplier(Button upgradeButton, string name, string description): base (upgradeButton, name, description) {

	}

	public override void ApplyUpgradeEffect() {
		PersistentData.clickingMultiplier = currentLevel;
	}

	public override void CalculateCostOfNextLevel() {
		
	}

	public override bool IsUpgradeAvailable() {
		return true;
	}

}
