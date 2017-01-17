using UnityEngine;

public class UManaRegen : Upgrade {

	public UManaRegen(string name, string description): base (name, description) {

	}

	//Returns the upgrade description
	public override string getName() {
		return name;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		StaticData.manaRegenRate = 1.0f + ((float)currentLevel * 0.5f);
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfUpgradesAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 4);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (StaticData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}
}
