using UnityEngine;
using UnityEngine.UI;

public class ATotalMoney : Achievement {

	public ATotalMoney(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement(GameObject scriptsBucket) {
		currentValue = PersistentData.storedData.highestMoneyAchieved;
		CalculateCurrentLevel (scriptsBucket);
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
