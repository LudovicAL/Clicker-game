using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionPanel : MonoBehaviour {

	/*
	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};
	*/

	public GameObject thisPanel;
	//private AvailablePanelStates panelState;
	public Toggle buttonOptionShortNumberNotation;
	public Toggle buttonOptionPlanetNamePromt;
	public Toggle buttonOptionAchievementNotification;

	// Use this for initialization
	void Start () {
		//this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		//this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		//SetPanelState (AvailablePanelStates.Playing);
	}
	
	/*
	void Update () {
		//if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			
		//}
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
	*/

	//When the player clicks the short number notation option button
	public void OnDisplayShortNumberNotationButtonClic(Toggle tButton) {
		PersistentData.storedData.shortNumbers = tButton.isOn;
		CommonTools.UpdateNumbersNotations();

	}

	//When the player clicks the prompt for planet name option button
	public void OnPromptForPlanetNameButtonClic(Toggle tButton) {
		PersistentData.storedData.promptForPlanetName = tButton.isOn;		
	}

	//When the player clicks the prompt for planet name option button
	public void OnAchievementNotificationButtonClic(Toggle tButton) {
		PersistentData.storedData.achievementsNotifications = tButton.isOn;		
	}

	//Updates all the options buttons so they correspond the values in PersistentData
	public void UpdateAllOptionButtons() {
		UpdateButtonShortNumberNotation ();
		UpdateButtonPlanetNamePrompt ();
		UpdateButtonAchievementsNotifications ();
	}

	//Updates the number notation option button so it corresponds the value in PersistentData
	public void UpdateButtonShortNumberNotation() {
		buttonOptionShortNumberNotation.isOn = PersistentData.storedData.shortNumbers;
		CommonTools.UpdateNumbersNotations();
	}

	//Updates the planet name prompt option button so it corresponds the value in PersistentData
	public void UpdateButtonPlanetNamePrompt() {
		buttonOptionPlanetNamePromt.isOn = PersistentData.storedData.promptForPlanetName;
	}

	//Updates the achievement notification option button so it corresponds the value in PersistentData
	public void UpdateButtonAchievementsNotifications() {
		buttonOptionAchievementNotification.isOn = PersistentData.storedData.achievementsNotifications;
	}
}
