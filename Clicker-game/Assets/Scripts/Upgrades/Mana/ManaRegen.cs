using UnityEngine.UI;

public class ManaRegen : Upgrade {

	public ManaRegen(Button upgradeButton, string name, string description): base (upgradeButton, name, description) {

	}

	public override void ApplyUpgradeEffect() {
		PersistentData.manaRegenRate += 0.5f;
	}

	public override void CalculateCostOfNextLevel() {

	}

	public override bool IsUpgradeAvailable() {
		return true;
	}
}
