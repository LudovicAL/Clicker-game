using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestorsPanel : MonoBehaviour {

	public GameObject thisPanel;
	public Text currentInvestors;
	public Text bonusPerInvestor;
	public Text potentialInvestors;
	private StaticData.AvailableGameStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);	
	}
	
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			UpdateInvestorsData();
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

	//Updates the number of potential investors
	public void UpdateInvestorsData() {
		StaticData.potentialInvestors = System.Math.Max(0, System.Math.Floor((-1 + System.Math.Pow(1 + 8 * (StaticData.storedData.currentMoney / 1000000000000), 0.5)) / 2));//geometric progression
		potentialInvestors.text = CommonTools.DoubleToString(StaticData.potentialInvestors);
		bonusPerInvestor.text = StaticData.bonusPerInvestor.ToString ("p0");
	}

	//When the user clicks expand
	public void OnExpandButtonClic() {
		StaticData.storedData.currentInvestors += StaticData.potentialInvestors;
		this.GetComponent<DataManager>().Restart ();
	}
}
