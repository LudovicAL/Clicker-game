﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestorsPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public Text currentInvestors;
	public Text potentialInvestors;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);	
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			UpdatePotentialInvestors();
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

	public void UpdatePotentialInvestors() {
		PersistentData.potentialInvestors = System.Math.Max(0, System.Math.Floor((-1 + System.Math.Pow(1 + 8 * (PersistentData.currentMoney / 1000000000000), 0.5)) / 2));//geometric progression
		potentialInvestors.text = CommonTools.DoubleToString(PersistentData.potentialInvestors);
	}

	public void OnExpandButtonClic() {

	}
}