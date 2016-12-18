using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	private AvailablePanelStates panelState;
	private List<Achievement> achievementList;
	public GameObject thisPanel;
	public bool showing;



	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		achievementList = new List<Achievement> ();
		showing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing) {
			if (!showing) {
				if (achievementList.Count > 0) {
					//TODO
				}
			} else {
				//TODO
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

	public void AddNotification(Achievement a) {
		achievementList.Add (a);
	}

	public void OnButtonClick() {
		if (panelState == AvailablePanelStates.Playing) {
			thisPanel.GetComponent<Animator> ().SetBool("isHidden", true);
		}
	}
}
