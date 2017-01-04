using UnityEngine.UI;

public class ManaRegen : Upgrade {

	public ManaRegen(string name, string description): base (name, description) {

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
