using UnityEngine.UI;

public class PointerBase : Upgrade {

	public PointerBase(string name, string description): base (name, description) {

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
