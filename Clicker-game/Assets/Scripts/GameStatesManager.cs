using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameStatesManager : MonoBehaviour {

	public UnityEvent PausedGameState;
	public UnityEvent PlayingGameState;
	public StaticData.AvailableGameStates gameState { get; private set;}

	void Awake () {
		if (PlayingGameState == null) {
			PlayingGameState = new UnityEvent();
		}
		if (PausedGameState == null) {
			PausedGameState = new UnityEvent();
		}
		ChangeGameState(StaticData.AvailableGameStates.Playing);
	}

	void start() {

	}

	void Update () {
		if (Input.GetKeyDown("escape")) {
			OnEscapeKeyPressed ();
		}
	}

	//Call this to change the game state
	public void ChangeGameState(StaticData.AvailableGameStates desiredState) {
		gameState = desiredState;
		switch(desiredState) {
			case StaticData.AvailableGameStates.Playing:
				PlayingGameState.Invoke ();
				break;
			case StaticData.AvailableGameStates.Paused:
				PausedGameState.Invoke ();
				break;
		}
	}

	//Called when users presses the escape key
	public void OnEscapeKeyPressed() {
		if (gameState == StaticData.AvailableGameStates.Playing) {
			ChangeGameState (StaticData.AvailableGameStates.Paused);
		} else if (gameState == StaticData.AvailableGameStates.Paused) {
			ChangeGameState (StaticData.AvailableGameStates.Playing);
		}
	}
}