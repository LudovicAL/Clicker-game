using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public Button[] menuButtonsList;
	public GameObject[] innerPanelsList;
	public Button bulkBuyingButton;
	private AvailablePanelStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		updateMenuButtonColors (0);
	}
	
	void Update () {
		
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

	//When the player clicks a menu button from the panel
	public void OnMenuButtonClic(int menuNo) {
		if (panelState == AvailablePanelStates.Playing) {
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

	//When the player clicks the bulk buying button
	public void OnBulkBuyingButtonClic() {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.bulkBuyer.MoveToNextItem ();
			bulkBuyingButton.GetComponentInChildren<Text> ().text = PersistentData.bulkBuyer.Caption;
			foreach (Construction c in PersistentData.listOfConstructions) {
				c.CalculateNumberOfConstructionsToBuild ();
				c.UpdateButtonDisplayedCost ();
			}
		}
	}
}
