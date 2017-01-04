using UnityEngine;
using UnityEngine.UI;

public class ATotalMoney : Achievement {

	public ATotalMoney(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	public override void UpdateAchievement() {
		currentValue = PersistentData.highestMoneyAchieved;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
