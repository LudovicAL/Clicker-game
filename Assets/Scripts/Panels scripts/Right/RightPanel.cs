using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RightPanel : MonoBehaviour {

	public GameObject thisPanel;
	public Button[] menuButtonsList;
	public GameObject[] innerPanelsList;
	private StaticData.AvailableGameStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
		updateMenuButtonColors (0);
	}

	void Update () {

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

	//When the player clicks a menu button from the panel
	public void OnMenuButtonClic(int menuNo) {
		if (panelState == StaticData.AvailableGameStates.Playing) {
			bool isHidden = thisPanel.GetComponent<Animator> ().GetBool ("isHidden");
			if (isHidden || innerPanelsList[menuNo].activeSelf) {
				thisPanel.GetComponent<Animator> ().SetBool("isHidden", !isHidden);
			}
			for (int i = 0; i < innerPanelsList.Length; i++) {
				innerPanelsList[i].SetActive((i == menuNo) ? true : false);
			}
			updateMenuButtonColors (menuNo);
		}
	}

	//Updates the menu button current color to highligh the currently visited menu
	public void updateMenuButtonColors(int highlightedButton) {
		for (int i = 0; i < menuButtonsList.Length; i++) {
			menuButtonsList[i].GetComponent<Button>().colors = ((i == highlightedButton) ? this.GetComponent<CanvasManager> ().enabledColorBlock : this.GetComponent<CanvasManager> ().disabledColorBlock);
		}
	}
}
