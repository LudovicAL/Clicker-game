﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradesPanel : MonoBehaviour {

	public GameObject thisPanel;
	public GameObject panelRaces;
	public GameObject panelConstructionsUpgrades;
	public GameObject panelPointerUpgrades;
	public GameObject panelManaUpgrades;
	public GameObject panelInvestorsUpgrades;
	public GameObject upgradeButtonPrefab;
	private StaticData.AvailableGameStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
		UpdateUpgradeButtons (StaticData.listOfRacesUpgrades, panelRaces);
		UpdateUpgradeButtons (StaticData.listOfConstructionsUpgrades, panelConstructionsUpgrades);
		UpdateUpgradeButtons (StaticData.listOfPointerUpgrades, panelPointerUpgrades);
		UpdateUpgradeButtons (StaticData.listOfManaUpgrades, panelManaUpgrades);
		UpdateUpgradeButtons (StaticData.listOfInvestorsUpgrades, panelInvestorsUpgrades);
	}

	// Update is called once per frame
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			foreach (Upgrade u in StaticData.listOfRacesUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
			}
			foreach (Upgrade u in StaticData.listOfConstructionsUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
			}
			foreach (Upgrade u in StaticData.listOfPointerUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
			}
			foreach (Upgrade u in StaticData.listOfManaUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
			}
			foreach (Upgrade u in StaticData.listOfInvestorsUpgrades) {
				u.UpdateButtonAvailability ();
				u.UpdateButtonInteractivity ();
			}
		}
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

	#region UpgradesButtons

	//Deletes all previously existing buttons, creates new ones and updates their display
	public void UpdateUpgradeButtons<T>(List<T> uList, GameObject uPanel) where T : Upgrade {
		for (int i = uPanel.transform.childCount; i > 0; i--) {
			GameObject.Destroy (uPanel.transform.GetChild (i - 1).gameObject);
		}
		foreach (Upgrade u in uList) {
			GameObject go = (GameObject)Instantiate (upgradeButtonPrefab, uPanel.transform, false);
			Button b = go.GetComponent<Button> ();
			u.uButton = b;
			u.UpdateButtonAvailability ();
			u.UpdateButtonImage ();
			//OnClick
			b.onClick.AddListener(delegate() { u.BuyNextLevel(this.gameObject); });
			b.onClick.AddListener(delegate() { OnMouseExitUpgradeButton (); });
			b.onClick.AddListener(delegate() { Update (); });
			//OnMouseEnter
			EventTrigger trigger = go.GetComponent<EventTrigger> ();
			EventTrigger.Entry entryA = new EventTrigger.Entry();
			entryA.eventID = EventTriggerType.PointerEnter;
			entryA.callback.AddListener ((data) => { u.OnMouseOver(this.GetComponent<ToolTip>()); });
			trigger.triggers.Add (entryA);
			//OnMouseExit
			EventTrigger.Entry entryB = new EventTrigger.Entry();
			entryB.eventID = EventTriggerType.PointerExit;
			entryB.callback.AddListener ((data) => { OnMouseExitUpgradeButton(); });
			trigger.triggers.Add (entryB);
		}
	}

	#endregion

	//On mouse exit the upgrade button
	public void OnMouseExitUpgradeButton() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
