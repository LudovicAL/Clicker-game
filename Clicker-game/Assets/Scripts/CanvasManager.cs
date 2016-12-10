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

	// Use this for initialization
	void Start () {
		CommonTools.updateNumbersNotations ();
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetCanvasState (AvailableCanvasStates.Playing);
	}
	
	// Update is called once per frame
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

	public void ShowAd() {
		this.GetComponent<AdsManager> ().ShowRewardedAd ();
	}

	public void OnSaveButtonClic() {
		PersistentData.SaveData ();
	}

	public void OnLoadButtonClic() {
		PersistentData.LoadData ();
		if (PersistentData.timeSinceLastSave != System.TimeSpan.Zero) {
			this.GetComponent<MessagesPanel> ().ShowRewardAfterAbsence ();
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
	}
}
