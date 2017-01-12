using UnityEngine;

public class UBonusPerInvestorUpgrade : Upgrade {

	public UBonusPerInvestorUpgrade(string name, string description): base (name, description) {

	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		PersistentData.bonusPerInvestor = 0.01f + ((float)currentLevel * 0.01f);
		scriptsBucket.GetComponent<InvestorsPanel> ().UpdateInvestorsData ();
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (PersistentData.listOfUpgradesAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 2), 5);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}
}

