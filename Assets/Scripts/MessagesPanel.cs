﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessagesPanel : MonoBehaviour {

	public GameObject panelMessage;

	public GameObject panelRewardAfterAbsence;
	public Text textOfRewardAfterAbsence;

	public GameObject panelInputDialogForPlanetName;
	public InputField inputFieldOfInputDialog;

	/*
	void Start () {
		
	}

	void Update () {
	
	}
	*/

	//Prompts the player with a message stating how much money he has gained during his absence
	public void ShowRewardAfterAbsence() {
		panelMessage.SetActive (true);
		panelRewardAfterAbsence.SetActive (true);
		textOfRewardAfterAbsence.text = "You were absent for " + StaticData.timeSinceLastSave.Days.ToString() + "d, " + StaticData.timeSinceLastSave.Hours + "h and " + StaticData.timeSinceLastSave.Minutes + "m. Your workers produced " + this.GetComponent<DataManager> ().CalculateRewardAfterAbsence () + " $ in that time.";
	}

	//When the player clicks the claim reward after absence button
	public void OnClaimRewardAfterAbsenceButtonClic() {
		this.GetComponent<DataManager>().AddMoney(this.GetComponent<DataManager> ().CalculateRewardAfterAbsence ());
		panelRewardAfterAbsence.SetActive (false);
		panelMessage.SetActive (false);
	}

	//Prompts the player for a planet name
	public void PromptForPlanetName() {
		panelMessage.SetActive (true);
		panelInputDialogForPlanetName.SetActive (true);
		inputFieldOfInputDialog.Select ();
		inputFieldOfInputDialog.ActivateInputField ();
	}

	//When the player submits his desired planet name (or no name at all)
	public void OnPlanetNameSubmit() {
		if (inputFieldOfInputDialog.text.Length == 0) {
			StaticData.storedData.planetName = CommonTools.GeneratePlanetName ();
		} else {
			StaticData.storedData.planetName = inputFieldOfInputDialog.text;
			inputFieldOfInputDialog.text = "";
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
		panelInputDialogForPlanetName.SetActive (false);
		panelMessage.SetActive (false);
		StaticData.SaveData ();
	}
}
