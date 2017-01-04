using UnityEngine;
using UnityEngine.UI;

public class ALongestSession : Achievement {

	public ALongestSession(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	public override void UpdateAchievement() {
		currentValue = PersistentData.longestPlayingSession.TotalSeconds;
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
