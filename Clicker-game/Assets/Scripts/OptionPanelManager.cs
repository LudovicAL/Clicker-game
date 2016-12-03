using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionPanelManager : MonoBehaviour {

	public Toggle buttonOptionShortNumberNotation;
	public Toggle buttonOptionPlanetNamePromt;

	// Use this for initialization
	void Start () {
	
	}
	
	/*
	void Update () {
	
	}
	*/

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
