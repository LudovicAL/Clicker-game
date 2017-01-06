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
	public GameObject panelRaces;
	public GameObject panelConstructionUpgrades;
	public GameObject panelPointerUpgrades;
	public GameObject panelManaUpgrades;
	public GameObject upgradeButtonPrefab;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		UpdateUpgradeButtons (PersistentData.listOfRaces, panelRaces);
		UpdateConstructionsUpgradesButtons ();
		UpdateUpgradeButtons (PersistentData.listOfPointerUpgrades, panelPointerUpgrades);
		UpdateUpgradeButtons (PersistentData.listOfManaUpgrades, panelManaUpgrades);
	}

	void fooA(Upgrade u) {

	}

	void fooB<T>(List<T> u) where T : Upgrade {

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
			b.onClick.AddListener(delegate() { u.BuyNextLevel(); });
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

	#region ConstructionUpgradesButtons

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
			entryA.callback.AddListener ((data) => { c.OnMouseOverUpgradeButton(this.GetComponent<ToolTip> ()); });
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
