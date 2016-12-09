using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public Button[] upgradesButtonList;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0; i < PersistentData.listOfConstructions.Length && i < upgradesButtonList.Length; i++) {
			PersistentData.listOfConstructions [i].UpgradeButton = upgradesButtonList [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			foreach (Construction c in PersistentData.listOfConstructions) {
				if (c.IsUnlocked) {
					c.UpgradeButtonIsActive = this.GetComponent<DataManager> ().IsUpgradeAvailable (c);
					c.UpgradeButtonIsInterractable = this.GetComponent<DataManager> ().CanAffordUpgrade (c);
				}
			}
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

	//When the player clicks on a construction upgrade button
	public void OnButtonClic(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			if (this.GetComponent<DataManager> ().CanAffordUpgrade (PersistentData.listOfConstructions[buttonNo])) {
				this.GetComponent<DataManager> ().BuyUpgrade (PersistentData.listOfConstructions[buttonNo]);
				Update ();
				this.GetComponent<CanvasManager> ().toolTipPanel.GetComponent<ToolTip> ().TurnToolTipOff ();
			}
		}
	}

	public void OnMouseOverUpgradeButton(int buttonNo) {
		this.GetComponent<CanvasManager> ().toolTipPanel.GetComponent<ToolTip> ().TurnToolTipOn (
			PersistentData.listOfConstructions[buttonNo].UpgradeButton.gameObject,
			WordsLists.upgradesAdjectives[PersistentData.listOfConstructions[buttonNo].UpgradeLevel] + PersistentData.listOfConstructions[buttonNo].Name,
			"",
			PersistentData.listOfConstructions[buttonNo].Name + " production is doubled."
		);
	}

	public void OnMouseExitUpgradeButton(int buttonNo) {
		this.GetComponent<CanvasManager> ().toolTipPanel.SetActive (false);
	}
}
