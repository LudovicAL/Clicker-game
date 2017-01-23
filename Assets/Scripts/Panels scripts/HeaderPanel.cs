using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel : MonoBehaviour {

	public GameObject thisPanel;
	private StaticData.AvailableGameStates panelState;
	public Text currentMoneyText;
	public Text currentFarmingText;


	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
	}
	
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing) {
			currentMoneyText.text = CommonTools.DoubleToString(StaticData.storedData.currentMoney) + " $";
			currentFarmingText.text = CommonTools.DoubleToString(StaticData.storedData.totalFarmingReward) + " $ / sec.";
		}
	}

	protected void OnPlaying() {
		SetPanelState (StaticData.AvailableGameStates.Playing);
	}

	protected void OnPausing() {
		SetPanelState (StaticData.AvailableGameStates.Paused);
	}

	public void SetPanelState(StaticData.AvailableGameStates state) {
		panelState = state;
	}
}
