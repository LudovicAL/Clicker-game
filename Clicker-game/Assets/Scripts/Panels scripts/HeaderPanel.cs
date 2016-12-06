using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	private AvailablePanelStates panelState;
	public Text currentMoneyText;
	public Text currentFarmingText;


	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing) {
			currentMoneyText.text = CommonTools.DoubleToString(PersistentData.currentMoney) + " $";
			currentFarmingText.text = CommonTools.DoubleToString(PersistentData.totalFarmingReward) + " $ / sec.";
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
}
