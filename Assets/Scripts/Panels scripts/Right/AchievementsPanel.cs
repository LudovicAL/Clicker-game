using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.EventSystems;

public class AchievementsPanel : MonoBehaviour {

	public GameObject thisPanel;
	private StaticData.AvailableGameStates panelState;
	public GameObject achievementPanelPrefab;
	public GameObject panelWealthAchievements;
	public GameObject panelTimeAchievements;
	public GameObject panelConstructionsAchievements;
	public GameObject panelUpgradesAchievements;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
		UpdateAchievementPanels (StaticData.listOfWealthAchievements, panelWealthAchievements);
		UpdateAchievementPanels (StaticData.listOfTimeAchievements, panelTimeAchievements);
		UpdateAchievementPanels (StaticData.listOfConstructionsAchievements, panelConstructionsAchievements);
		UpdateAchievementPanels (StaticData.listOfUpgradesAchievements, panelUpgradesAchievements);
	}

	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			CheckAchievementsInList (StaticData.listOfTimeAchievements);
		}
	}

	protected void OnPlaying() {
		SetPanelState (StaticData.AvailableGameStates.Playing);
	}

	protected void OnPausing() {
		SetPanelState (StaticData.AvailableGameStates.Paused);
	}

	public void SetPanelState(StaticData.AvailableGameStates state) {
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
		if (panelState == StaticData.AvailableGameStates.Playing) {
			StaticData.listOfWealthAchievements [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	//When the mouse hover over an achieveent
	public void OnMouseOverTimeAchievement(int buttonNo) {
		if (panelState == StaticData.AvailableGameStates.Playing) {			
			StaticData.listOfTimeAchievements [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	//On mouse exit an achievement panel
	public void OnMouseExitAchievement() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
