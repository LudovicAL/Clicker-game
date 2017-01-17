using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionPanel : MonoBehaviour {

	public GameObject thisPanel;
	//private StaticData.AvailableGameStates panelState;
	public Toggle buttonOptionShortNumberNotation;
	public Toggle buttonOptionPlanetNamePromt;
	public Toggle buttonOptionAchievementNotification;

	// Use this for initialization
	void Start () {
		//this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		//this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		//SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
	}
	
	/*
	void Update () {
		//if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			
		//}
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
	*/

	//When the player clicks the short number notation option button
	public void OnDisplayShortNumberNotationButtonClic(Toggle tButton) {
		StaticData.storedData.shortNumbers = tButton.isOn;
		CommonTools.UpdateNumbersNotations();

	}

	//When the player clicks the prompt for planet name option button
	public void OnPromptForPlanetNameButtonClic(Toggle tButton) {
		StaticData.storedData.promptForPlanetName = tButton.isOn;		
	}

	//When the player clicks the prompt for planet name option button
	public void OnAchievementNotificationButtonClic(Toggle tButton) {
		StaticData.storedData.achievementsNotifications = tButton.isOn;		
	}

	//Updates all the options buttons so they correspond the values in PersistentData
	public void UpdateAllOptionButtons() {
		UpdateButtonShortNumberNotation ();
		UpdateButtonPlanetNamePrompt ();
		UpdateButtonAchievementsNotifications ();
	}

	//Updates the number notation option button so it corresponds the value in PersistentData
	public void UpdateButtonShortNumberNotation() {
		buttonOptionShortNumberNotation.isOn = StaticData.storedData.shortNumbers;
		CommonTools.UpdateNumbersNotations();
	}

	//Updates the planet name prompt option button so it corresponds the value in PersistentData
	public void UpdateButtonPlanetNamePrompt() {
		buttonOptionPlanetNamePromt.isOn = StaticData.storedData.promptForPlanetName;
	}

	//Updates the achievement notification option button so it corresponds the value in PersistentData
	public void UpdateButtonAchievementsNotifications() {
		buttonOptionAchievementNotification.isOn = StaticData.storedData.achievementsNotifications;
	}
}
