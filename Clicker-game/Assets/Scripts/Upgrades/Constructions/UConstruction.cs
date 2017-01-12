using UnityEngine;

public class UConstruction : Upgrade {

	public int id { get; private set; }

	public UConstruction(string name, string description, int id): base (name, description) {
		this.id = id;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect(GameObject scriptsBucket) {
		scriptsBucket.GetComponent<DataManager>().CalculateTotalFarmingReward ();
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.CalculateContribution ();
			c.UpdateButtonDisplayedContribution ();
		}
		scriptsBucket.GetComponent<DataManager> ().CalculateCurrentTotalNumberOfUpgrades ();
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {
		costOfNextLevel = (double)((currentLevel + 1) * id);
	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return (PersistentData.listOfConstructions[id - 1].quantity >= ((currentLevel + 1) * PersistentData.listOfConstructions[id - 1].upgradesInterval));
	}
}
