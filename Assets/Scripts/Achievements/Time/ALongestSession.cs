﻿using UnityEngine;
using UnityEngine.UI;

public class ALongestSession : Achievement {

	public ALongestSession(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement(GameObject scriptsBucket) {
		currentValue = StaticData.storedData.longestPlayingSession.TotalSeconds;
		CalculateCurrentLevel (scriptsBucket);
		CalculateProgress ();
		UpdateProgressBar ();
	}
}
