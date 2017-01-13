using UnityEngine;
using UnityEngine.UI;

public class AConstructionsNumber : Achievement {

	public AConstructionsNumber(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement(GameObject scriptsBucket) {
		currentValue = PersistentData.storedData.highestTotalNumberOfConstructionsAchieved;
		CalculateCurrentLevel (scriptsBucket);
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
