using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public GameObject toolTipPanel;
	public ColorBlock enabledColorBlock;
	public ColorBlock disabledColorBlock;
	private StaticData.AvailableGameStates gameState;

	void Start () {
		CommonTools.UpdateNumbersNotations ();
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetCanvasState (this.GetComponent<GameStatesManager> ().gameState);
	}

	void Update () {
		if (gameState == StaticData.AvailableGameStates.Playing) {

		}
	}

	protected void OnPlaying() {
		SetCanvasState (StaticData.AvailableGameStates.Playing);
	}

	protected void OnPausing() {
		SetCanvasState (StaticData.AvailableGameStates.Paused);
	}

	public void SetCanvasState(StaticData.AvailableGameStates state) {
		gameState = state;
	}

	//Shows a video ad
	public void ShowAd() {
		this.GetComponent<AdsManager> ().ShowRewardedAd ();
	}

	//Saves the game
	public void OnSaveButtonClick() {
		StaticData.SaveData ();
	}

	//Load the saved game
	public void OnLoadButtonClick() {
		StaticData.LoadData (this.gameObject);
		this.GetComponent<MainPanel> ().UpdatePlanet ();
		this.GetComponent<OptionPanel> ().UpdateAllOptionButtons ();
		this.GetComponent<DataManager> ().CalculateTotalClickingReward ();
		this.GetComponent<DataManager> ().CalculateTotalFarmingReward ();
		this.GetComponent<DataManager> ().CalculateCurrentTotalNumberOfConstructions ();
		if (StaticData.timeSinceLastSave != System.TimeSpan.Zero) {
			this.GetComponent<MessagesPanel> ().ShowRewardAfterAbsence ();
			this.GetComponent<DataManager> ().UpdateManaAfterAbsence ();
		}
	}
}
