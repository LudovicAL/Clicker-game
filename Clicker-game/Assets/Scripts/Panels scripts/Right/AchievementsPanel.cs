using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class AchievementsPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	private AvailablePanelStates panelState;
	public GameObject[] wealthAchievementsPanelList;
	public Image[] wealthAchievementsProgressBarList;
	public GameObject[] timeAchievementsPanelList;
	public Image[] timeAchievementsProgressBarList;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0; i < PersistentData.listOfWealthAchievements.Length && i < wealthAchievementsPanelList.Length; i++) {
			PersistentData.listOfWealthAchievements [i].aPanel = wealthAchievementsPanelList[i];
			PersistentData.listOfWealthAchievements [i].aProgressBar = wealthAchievementsProgressBarList[i];
		}
		for (int i = 0; i < PersistentData.listOfTimeAchievements.Length && i < timeAchievementsPanelList.Length; i++) {
			PersistentData.listOfTimeAchievements [i].aPanel = timeAchievementsPanelList[i];
			PersistentData.listOfTimeAchievements [i].aProgressBar = timeAchievementsProgressBarList[i];
		}
	}

	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			CheckTimeAchievements ();
		}
	}

	protected void OnPlaying() {
		SetPanelState (AvailablePanelStates.Playing);
	}

	protected void OnPausing() {
		SetPanelState (AvailablePanelStates.Paused);
	}

	public void SetPanelState(AvailablePanelStates state) {
		panelState = state;
	}

	//Updates every wealth related achievement
	public void CheckWealthAchievements() {
		foreach(Achievement a in PersistentData.listOfWealthAchievements) {
			a.UpdateAchievement ();
		}
	}

	//Updates every time related achievement
	public void CheckTimeAchievements() {
		foreach(Achievement a in PersistentData.listOfTimeAchievements) {
			a.UpdateAchievement ();
		}
	}

	//When the mouse hover over a Wealth achieveent
	public void OnMouseOverWealthAchievement(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfWealthAchievements [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	//When the mouse hover over an achieveent
	public void OnMouseOverTimeAchievement(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {			
			PersistentData.listOfTimeAchievements [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	//On mouse exit an achievement panel
	public void OnMouseExitAchievement() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
