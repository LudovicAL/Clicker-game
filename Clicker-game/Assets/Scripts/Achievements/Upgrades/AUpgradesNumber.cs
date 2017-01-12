using UnityEngine;
using UnityEngine.UI;

public class AUpgradesNumber : Achievement {
	
	public AUpgradesNumber(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement() {
		currentValue = PersistentData.currentTotalNumberOfUpgrades;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
