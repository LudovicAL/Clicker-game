using UnityEngine;

public class ManaRegen : Upgrade {

	public ManaRegen(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.manaRegenRate += 0.5f;
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 4);
		costOfAvailibility = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.currentMoney >= costOfAvailibility) ? true : false;
	}
}
