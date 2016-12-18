﻿using UnityEngine;
using UnityEngine.UI;

public class ATotalTime : Achievement {

	public ATotalTime(int id, string name, string description, bool revealed, GameObject aPanel, Image aProgressBar): base (id, name, description, revealed, aPanel, aProgressBar) {
		valuesTable = new double[WordsLists.wealthAchievementsValuesTable.GetLength(1)];
		for (int i = 0; i < valuesTable.Length; i++) {
			valuesTable [i] = WordsLists.wealthAchievementsValuesTable [id, i];
		}
	}

	public override void UpdateAchievement() {
		currentValue = PersistentData.totalTimeSpentPlaying.TotalSeconds;
		CalculateCurrentLevel ();
		CalculateProgress ();
		UpdateProgressBar ();
	}
}