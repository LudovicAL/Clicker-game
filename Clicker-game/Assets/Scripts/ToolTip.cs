﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject ttPanel;
	public Text ttTitle;
	public Text ttProgress;
	public Text ttDescription;
	private AvailablePanelStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		TurnToolTipOff ();
	}
	
	/*
	void Update () {
	
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

	public void TurnToolTipOn(GameObject go, string title, string progress, string description) {
		if (panelState == AvailablePanelStates.Playing) {
			ttTitle.text = title;
			ttProgress.text = progress;
			ttDescription.text = description;
			if (Camera.main.ScreenToViewportPoint(go.GetComponent<RectTransform> ().position).x > 0.5f) {
				ttPanel.GetComponent<RectTransform> ().pivot = new Vector2(1.01f, 0.5f);
			} else {
				ttPanel.GetComponent<RectTransform> ().pivot = new Vector2(-0.01f, 0.5f);
			}
			ttPanel.GetComponent<RectTransform> ().position = go.GetComponent<RectTransform> ().position;
			ttPanel.gameObject.SetActive (true);
		}
	}

	public void TurnToolTipOff() {
		ttPanel.gameObject.SetActive (false);
	}
}
