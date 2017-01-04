using UnityEngine;
using UnityEngine.UI;

public class AMoneyPerSecond : Achievement {

	public AMoneyPerSecond(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	public override void UpdateAchievement() {
		currentValue = PersistentData.highestTotalFarmingReward;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
