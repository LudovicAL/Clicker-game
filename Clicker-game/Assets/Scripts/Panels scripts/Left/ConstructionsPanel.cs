﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionsPanel : MonoBehaviour {
	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};


	public GameObject thisPanel;
	public Button[] constructionsButtonList;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0; i < PersistentData.listOfConstructions.Length && i < constructionsButtonList.Length; i++) {
			PersistentData.listOfConstructions [i].constructionButton = constructionsButtonList [i];
		}
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.UpdateConstructionButtonAvailability ();
			c.UpdateButtonDisplayedName ();
			c.UpdateButtonDisplayedCost ();
			c.UpdateButtonDisplayedQuantity ();
			c.UpdateButtonDisplayedContribution ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			foreach (Construction c in PersistentData.listOfConstructions) {
				if (c.constructionAvailability) {
					c.CalculateNumberOfConstructionsToBuild ();
					c.UpdateButtonDisplayedCost ();
					c.constructionButton.interactable = c.CanAffordConstruction();
				}
			}
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

	//When the player clicks on a construction button
	public void OnButtonClic(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			if (PersistentData.listOfConstructions[buttonNo].CanAffordConstruction()) {
				PersistentData.listOfConstructions[buttonNo].BuyConstruction (this.GetComponent<DataManager>());
				Update ();
			}
		}
	}
}
