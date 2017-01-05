using UnityEngine.UI;

public class ManaRegen : Upgrade {

	public ManaRegen(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect() {
		PersistentData.manaRegenRate += 0.5f;
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {

	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return true;
	}
}
