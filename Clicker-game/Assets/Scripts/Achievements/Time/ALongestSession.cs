using UnityEngine;
using UnityEngine.UI;

public class ALongestSession : Achievement {

	public ALongestSession(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement() {
		currentValue = PersistentData.storedData.longestPlayingSession.TotalSeconds;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
