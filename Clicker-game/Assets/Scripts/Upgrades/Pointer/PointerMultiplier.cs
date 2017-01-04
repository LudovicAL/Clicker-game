using UnityEngine.UI;

public class PointerMultiplier : Upgrade {

	public PointerMultiplier(string name, string description): base (name, description) {

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
