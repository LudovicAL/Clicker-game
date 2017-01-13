﻿using UnityEngine;
using UnityEngine.UI;

public class ATotalTime : Achievement {

	public ATotalTime(string name, string description, bool revealed, double[] valuesTable): base (name, description, revealed, valuesTable) {
		//Nothing to do here... yet
	}

	//Updates the achievement progress and display
	public override void UpdateAchievement(GameObject scriptsBucket) {
		currentValue = PersistentData.storedData.totalTimeSpentPlaying.TotalSeconds;
		CalculateCurrentLevel (scriptsBucket);
		CalculateProgress ();
		UpdateProgressBar ();
	}
}