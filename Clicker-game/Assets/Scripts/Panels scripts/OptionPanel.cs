using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	private AvailablePanelStates panelState;
	public Text currentMoneyText;
	public Text currentFarmingText;
	public Toggle buttonOptionShortNumberNotation;
	public Toggle buttonOptionPlanetNamePromt;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
	}
	
	/*
	void Update () {
		//if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			
		//}
	}
	*/

	protected void OnPlaying() {
		SetPanelState (AvailablePanelStates.Playing);
	}

	protected void OnPausing() {
		SetPanelState (AvailablePanelStates.Paused);
	}

	public void SetPanelState(AvailablePanelStates state) {
		panelState = state;
	}

	//When the player clicks the short number notation option button
	public void OnDisplayShortNumberNotationButtonClic(Toggle tButton) {
		PersistentData.shortNumbers = tButton.isOn;
		CommonTools.updateNumbersNotations();

	}

	//When the player clicks the prompt for planet name option button
	public void OnPromptForPlanetNameButtonClic(Toggle tButton) {
		PersistentData.promtForPlanetName = tButton.isOn;		
	}

	public void UpdateAllOptionButtons() {
		UpdateButtonShortNumberNotation ();
		UpdateButtonPlanetNamePrompt ();
	}

	public void UpdateButtonShortNumberNotation() {
		buttonOptionShortNumberNotation.isOn = PersistentData.shortNumbers;
		CommonTools.updateNumbersNotations();
	}

	public void UpdateButtonPlanetNamePrompt() {
		buttonOptionPlanetNamePromt.isOn = PersistentData.promtForPlanetName;
	}
}
