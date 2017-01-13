using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
	public enum AvailableCanvasStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject toolTipPanel;
	public ColorBlock enabledColorBlock;
	public ColorBlock disabledColorBlock;
	private AvailableCanvasStates canvasState;

	void Start () {
		CommonTools.UpdateNumbersNotations ();
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetCanvasState (AvailableCanvasStates.Playing);
	}

	void Update () {
		if (canvasState == AvailableCanvasStates.Playing) {

		}
	}

	protected void OnPlaying() {
		SetCanvasState (AvailableCanvasStates.Playing);
	}

	protected void OnPausing() {
		SetCanvasState (AvailableCanvasStates.Paused);
	}

	public void SetCanvasState(AvailableCanvasStates state) {
		canvasState = state;
	}

	//Shows a video ad
	public void ShowAd() {
		this.GetComponent<AdsManager> ().ShowRewardedAd ();
	}

	//Saves the game
	public void OnSaveButtonClick() {
		PersistentData.SaveData ();
	}

	//Load the saved game
	public void OnLoadButtonClick() {
		PersistentData.LoadData (this.gameObject);
		this.GetComponent<MainPanel> ().UpdatePlanet ();
		this.GetComponent<OptionPanel> ().UpdateAllOptionButtons ();
		this.GetComponent<DataManager> ().CalculateTotalClickingReward ();
		this.GetComponent<DataManager> ().CalculateTotalFarmingReward ();
		this.GetComponent<DataManager> ().CalculateCurrentTotalNumberOfConstructions ();
		if (PersistentData.timeSinceLastSave != System.TimeSpan.Zero) {
			this.GetComponent<MessagesPanel> ().ShowRewardAfterAbsence ();
			this.GetComponent<DataManager> ().UpdateManaAfterAbsence ();
		}
	}
}
