using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameStatesManager : MonoBehaviour {

	public enum AvailableGameStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public UnityEvent PausedGameState;
	public UnityEvent PlayingGameState;

	private AvailableGameStates gameState;

	// Use this for initialization
	void Start () {
		if (PlayingGameState == null) {
			PlayingGameState = new UnityEvent();
		}
		if (PausedGameState == null) {
			PausedGameState = new UnityEvent();
		}
		ChangeGameState(AvailableGameStates.Playing);
	}

	// Update is called once per frame
	void Update () {
		if (gameState == AvailableGameStates.Playing) {
			
		}
	}

	//Call this to change the game state
	public void ChangeGameState(AvailableGameStates desiredState) {
		gameState = desiredState;
		switch(desiredState) {
			case AvailableGameStates.Playing:
				PlayingGameState.Invoke ();
				break;
			case AvailableGameStates.Paused:
				PausedGameState.Invoke ();
				break;
		}
	}

	//Called when users presses the escape key
	public void OnEscapeKeyPressed() {
		if (gameState == AvailableGameStates.Playing) {
			ChangeGameState (AvailableGameStates.Paused);
		} else if (gameState == AvailableGameStates.Paused) {
			ChangeGameState (AvailableGameStates.Playing);
		}
	}

	//Properties
	public AvailableGameStates GameState {
		get {
			return gameState;
		}
		set {
			gameState = value;
		}
	}
}