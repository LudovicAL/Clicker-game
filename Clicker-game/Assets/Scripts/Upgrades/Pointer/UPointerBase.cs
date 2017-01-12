using UnityEngine;

public class UPointerBase : Upgrade {

	public UPointerBase(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.baseClickingReward = currentLevel;
		scriptsBucket.GetComponent<DataManager> ().CalculateTotalClickingReward ();
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfUpgradesAchievements);
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfWealthAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 2);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}
}
