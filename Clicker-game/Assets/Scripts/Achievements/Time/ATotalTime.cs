using UnityEngine;
using UnityEngine.UI;

public class ATotalTime : Achievement {

	public ATotalTime(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	public override void UpdateAchievement() {
		currentValue = PersistentData.totalTimeSpentPlaying.TotalSeconds;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}