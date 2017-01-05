using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradesPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public GameObject panelConstructionUpgrades;
	public GameObject panelPointerUpgrades;
	public Button[] pointersUpgradesButtonList;
	public Button[] manaUpgradesButtonList;
	public GameObject upgradeButtonPrefab;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		UpdateConstructionsUpgradesButtons ();
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

	//Deletes all previously existing buttons, creates new ones and updates their display
	public void UpdateConstructionsUpgradesButtons() {
		for (int i = panelConstructionUpgrades.transform.childCount; i > 0; i--) {
			GameObject.Destroy (panelConstructionUpgrades.transform.GetChild (i - 1).gameObject);
		}
		foreach (Construction c in PersistentData.listOfConstructions) {
			GameObject go = (GameObject)Instantiate (upgradeButtonPrefab, panelConstructionUpgrades.transform, false);
			Button b = go.GetComponent<Button> ();
			c.upgradeButton = b;
			c.UpdateUpgradeButtonAvailability ();
			c.UpdateUpgradeButtonImage ();
			//OnClick
			b.onClick.AddListener(delegate() { c.BuyUpgrade(this.GetComponent<DataManager>()); });
			b.onClick.AddListener(delegate() { OnMouseExitUpgradeButton (); });
			b.onClick.AddListener(delegate() { Update (); });
			//OnMouseEnter
			EventTrigger trigger = go.GetComponent<EventTrigger> ();
			EventTrigger.Entry entryA = new EventTrigger.Entry();
			entryA.eventID = EventTriggerType.PointerEnter;
			entryA.callback.AddListener ((data) => { OnMouseOverConstructionUpgradeButton (c.id - 1); });
			trigger.triggers.Add (entryA);
			//OnMouseExit
			EventTrigger.Entry entryB = new EventTrigger.Entry();
			entryB.eventID = EventTriggerType.PointerExit;
			entryB.callback.AddListener ((data) => { OnMouseExitUpgradeButton(); });
			trigger.triggers.Add (entryB);
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

	//On mouse exit the upgrade button
	public void OnMouseExitUpgradeButton() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
