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
	public Button[] constructionsUpgradesButtonList;
	public Button[] pointersUpgradesButtonList;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0; i < PersistentData.listOfConstructions.Length && i < constructionsUpgradesButtonList.Length; i++) {
			PersistentData.listOfConstructions [i].UpgradeButton = constructionsUpgradesButtonList [i];
		}
		for (int i = 0; i < PersistentData.listOfPointerUpgrades.Length && i < pointersUpgradesButtonList.Length; i++) {
			PersistentData.listOfPointerUpgrades [i].upgradeButton = pointersUpgradesButtonList[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			foreach (Construction c in PersistentData.listOfConstructions) {
				if (c.IsUnlocked) {
					c.UpgradeButtonIsActive = this.GetComponent<DataManager> ().IsUpgradeAvailable (c);
					c.UpgradeButtonIsInterractable = this.GetComponent<DataManager> ().CanAffordConstructionUpgrade (c);
				}
			}
			foreach (Upgrade u in PersistentData.listOfPointerUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonAccessibility ();
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
	public void OnButtonClicConstructionUpgrade(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			if (this.GetComponent<DataManager> ().CanAffordConstructionUpgrade (PersistentData.listOfConstructions[buttonNo])) {
				this.GetComponent<DataManager> ().BuyConstructionUpgrade (PersistentData.listOfConstructions[buttonNo]);
				Update ();
				this.GetComponent<ToolTip> ().TurnToolTipOff ();
			}
		}
	}

	//When the mouse hover over a construction upgrade button
	public void OnMouseOverConstructionUpgradeButton(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfConstructions [buttonNo].OnMouseOverUpgradeButton (this.GetComponent<ToolTip> ());
		}
	}


	//When the player clicks on a pointer upgrade button
	public void OnButtonClicPointerUpgrade(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfPointerUpgrades [buttonNo].BuyNextLevel ();
		}
	}

	//When the mouse hover over a pointer upgrade button
	public void OnMouseOverPointerUpgradeButton(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {			
			PersistentData.listOfPointerUpgrades [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	public void OnMouseExitUpgradeButton() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
