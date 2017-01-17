using UnityEngine;

public class UPointerMultiplier : Upgrade {

	public UPointerMultiplier(string name, string description): base (name, description) {

	}

	//Returns the upgrade description
	public override string getName() {
		return name;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		StaticData.clickingMultiplier = currentLevel;
		scriptsBucket.GetComponent<DataManager> ().CalculateTotalClickingReward ();
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfUpgradesAchievements);
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfWealthAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 3), 3);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (StaticData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}

}
