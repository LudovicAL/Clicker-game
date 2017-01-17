using UnityEngine;

public class UBonusPerInvestorUpgrade : Upgrade {

	public UBonusPerInvestorUpgrade(string name, string description): base (name, description) {

	}

	//Returns the upgrade description
	public override string getName() {
		return name;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		StaticData.bonusPerInvestor = 0.01f + ((float)currentLevel * 0.01f);
		scriptsBucket.GetComponent<InvestorsPanel> ().UpdateInvestorsData ();
		scriptsBucket.GetComponent<AchievementsPanel> ().CheckAchievementsInList (StaticData.listOfUpgradesAchievements);
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = System.Math.Pow ((currentLevel + 2), 5);
		costOfAvailability = costOfNextLevel / 3;
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (StaticData.storedData.currentMoney >= costOfAvailability) ? true : false;
	}
}

