using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.EventSystems;

public class AchievementsPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	private AvailablePanelStates panelState;
	public GameObject achievementPanelPrefab;
	public GameObject panelWealthAchievements;
	public GameObject panelTimeAchievements;
	public GameObject panelConstructionsAchievements;
	public GameObject panelUpgradesAchievements;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		UpdateAchievementPanels (PersistentData.listOfWealthAchievements, panelWealthAchievements);
		UpdateAchievementPanels (PersistentData.listOfTimeAchievements, panelTimeAchievements);
		UpdateAchievementPanels (PersistentData.listOfConstructionsAchievements, panelConstructionsAchievements);
		UpdateAchievementPanels (PersistentData.listOfUpgradesAchievements, panelUpgradesAchievements);
	}

	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			CheckAchievementsInList (PersistentData.listOfTimeAchievements);
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

	//Deletes all previously existing buttons, creates new ones and updates their display
	public void UpdateAchievementPanels<T>(List<T> aList, GameObject aPanel) where T : Achievement {
		for (int i = aPanel.transform.childCount; i > 0; i--) {
			GameObject.Destroy (aPanel.transform.GetChild (i - 1).gameObject);
		}
		foreach (Achievement a in aList) {
			GameObject go = (GameObject)Instantiate (achievementPanelPrefab, aPanel.transform, false);
			a.aPanel = go;
			a.aProgressBar = go.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Image>();
			a.UpdateAchievement (this.gameObject);
			//OnMouseEnter
			EventTrigger trigger = go.GetComponent<EventTrigger> ();
			EventTrigger.Entry entryA = new EventTrigger.Entry();
			entryA.eventID = EventTriggerType.PointerEnter;
			entryA.callback.AddListener ((data) => { a.OnMouseOver(this.GetComponent<ToolTip>()); });
			trigger.triggers.Add (entryA);
			//OnMouseExit
			EventTrigger.Entry entryB = new EventTrigger.Entry();
			entryB.eventID = EventTriggerType.PointerExit;
			entryB.callback.AddListener ((data) => { OnMouseExitAchievement(); });
			trigger.triggers.Add (entryB);
		}
	}

	//Updates every achievements in a given list
	public void CheckAchievementsInList<T>(List<T> achievementsList) where T : Achievement {
		foreach(Achievement a in achievementsList) {
			a.UpdateAchievement (this.gameObject);
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
