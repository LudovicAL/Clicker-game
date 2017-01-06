﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject ttSmallPanel;
	public Text ttSmallTopLeft;
	public Text ttSmallTopRight;
	public Text ttSmallDescription;

	public GameObject ttLongPanel;
	public Text ttLongTopLeft;
	public Text ttLongTopRight;
	public Text ttLongDescription;
	public Text ttLongBottomLeft;
	public Text ttLongBottomRight;

	public GameObject ttCustomPanel;

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

	//Turns on the small tooltip
	public void TurnToolTipOn(GameObject go, string topLeft, string topRight, string description) {
		if (panelState == AvailablePanelStates.Playing) {
			ttSmallTopLeft.text = topLeft;
			ttSmallTopRight.text = topRight;
			ttSmallDescription.text = description;
			positionToolTip (go, ttSmallPanel);
			ttSmallPanel.gameObject.SetActive (true);
		}
	}

	//Turns on the long tooltip
	public void TurnToolTipOn(GameObject go, string topLeft, string topRight, string description, string bottomLeft, string bottomRight) {
		if (panelState == AvailablePanelStates.Playing) {
			ttLongTopLeft.text = topLeft;
			ttLongTopRight.text = topRight;
			ttLongDescription.text = description;
			ttLongBottomLeft.text = bottomLeft;
			ttLongBottomRight.text = bottomRight;
			positionToolTip (go, ttLongPanel);
			ttLongPanel.gameObject.SetActive (true);
		}
	}

	//Turns on the custom tooltip
	public void TurnToolTipOn(GameObject go, string[] texts) {
		if (panelState == AvailablePanelStates.Playing) {
			for (int i = 0, maxA = ttCustomPanel.transform.childCount, maxB = texts.Length; i < maxA; i++) {
				if (i < maxB) {
					ttCustomPanel.transform.GetChild (i).GetComponent<Text> ().text = texts [i];
					ttCustomPanel.transform.GetChild (i).gameObject.SetActive (true);
				} else {
					ttCustomPanel.transform.GetChild (i).gameObject.SetActive (false);
				}
			}
			positionToolTip (go, ttCustomPanel);
			ttCustomPanel.gameObject.SetActive (true);
		}
	}

	public void positionToolTip(GameObject go, GameObject ttPanel) {
		if (Camera.main.ScreenToViewportPoint(go.GetComponent<RectTransform> ().position).x > 0.5f) {
			ttPanel.GetComponent<RectTransform> ().pivot = new Vector2(1.01f, 0.5f);
		} else {
			ttPanel.GetComponent<RectTransform> ().pivot = new Vector2(-0.01f, 0.5f);
		}
		ttPanel.GetComponent<RectTransform> ().position = go.GetComponent<RectTransform> ().position;
	}

	//Turns off all tooltips
	public void TurnToolTipOff() {
		ttSmallPanel.gameObject.SetActive (false);
		ttLongPanel.gameObject.SetActive (false);
		ttCustomPanel.gameObject.SetActive (false);
	}
}
