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
	public Button[] manaUpgradesButtonList;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0, maxA = PersistentData.listOfConstructions.Length, maxB = constructionsUpgradesButtonList.Length; i < maxA && i < maxB; i++) {
			if (PersistentData.listOfConstructions[i] != null) {
				PersistentData.listOfConstructions [i].upgradeButton = constructionsUpgradesButtonList [i];
				PersistentData.listOfConstructions [i].UpdateUpgradeButtonAvailability ();
			} else {
				constructionsUpgradesButtonList [i].gameObject.SetActive(false);
			}
		}
		for (int i = 0; i < PersistentData.listOfPointerUpgrades.Length && i < pointersUpgradesButtonList.Length; i++) {
			PersistentData.listOfPointerUpgrades [i].uButton = pointersUpgradesButtonList[i];
		}
		for (int i = 0; i < PersistentData.listOfManaUpgrades.Length && i < manaUpgradesButtonList.Length; i++) {
			PersistentData.listOfManaUpgrades [i].uButton = manaUpgradesButtonList[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			foreach (Construction c in PersistentData.listOfConstructions) {
				if (c.constructionAvailability) {
					c.upgradeButton.interactable = c.CanAffordUpgrade ();
				}
			}
			foreach (Upgrade u in PersistentData.listOfPointerUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
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

	#region ConstructionUpgrades

	//When the player clicks on a construction upgrade button
	public void OnButtonClicConstructionUpgrade(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			if (PersistentData.listOfConstructions[buttonNo].CanAffordUpgrade()) {
				PersistentData.listOfConstructions[buttonNo].BuyUpgrade(this.GetComponent<DataManager>());
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

	#endregion

	#region PointerUpgrades

	//When the player clicks on a pointer upgrade button
	public void OnButtonClicPointerUpgrade(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfPointerUpgrades [buttonNo].BuyNextLevel ();
			this.GetComponent<DataManager> ().CalculateTotalClickingReward ();
		}
	}

	//When the mouse hover over a pointer upgrade button
	public void OnMouseOverPointerUpgradeButton(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {			
			PersistentData.listOfPointerUpgrades [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	#endregion

	#region ManaUpgrades

	//When the player clicks on a pointer upgrade button
	public void OnButtonClicManaUpgrade(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfManaUpgrades [buttonNo].BuyNextLevel ();
		}
	}

	//When the mouse hover over a pointer upgrade button
	public void OnMouseOverManaUpgradeButton(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {			
			PersistentData.listOfManaUpgrades [buttonNo].OnMouseOver (this.GetComponent<ToolTip> ());
		}
	}

	#endregion

	public void OnMouseExitUpgradeButton() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
