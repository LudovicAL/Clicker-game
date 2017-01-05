using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilitiesPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public GameObject abilityButtonPanel;
	public Image manaBar;
	public Text manaText;
	public GameObject abilityButtonPrefab;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		UpdateAbilityButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			manaText.text = PersistentData.currentMana.ToString() + " / " + PersistentData.maxMana.ToString();
			manaBar.fillAmount = (PersistentData.currentMana / PersistentData.maxMana);
			foreach (Ability a in PersistentData.listOfAbilities) {
				a.UpdateButtonInteractivity ();
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

	public void UpdateAbilityButtons() {
		foreach (Ability a in PersistentData.listOfAbilities) {
			GameObject go = (GameObject)Instantiate (abilityButtonPrefab, abilityButtonPanel.transform, false);
			Button b = go.GetComponent<Button> ();
			a.aButton = b;
			a.UpdateButtonAvailability ();
			a.UpdateButtonDisplayedName ();
			//OnClick
			b.onClick.AddListener(delegate() { a.UseAbility(); });
			//OnMouseEnter
			EventTrigger trigger = go.GetComponent<EventTrigger> ();
			EventTrigger.Entry entryA = new EventTrigger.Entry();
			entryA.eventID = EventTriggerType.PointerEnter;
			entryA.callback.AddListener ((data) => { a.OnMouseOver(this.GetComponent<ToolTip> ()); });
			trigger.triggers.Add (entryA);
			//OnMouseExit
			EventTrigger.Entry entryB = new EventTrigger.Entry();
			entryB.eventID = EventTriggerType.PointerExit;
			entryB.callback.AddListener ((data) => { OnMouseExitAbility(); });
			trigger.triggers.Add (entryB);
		}
	}

	public void OnMouseExitAbility() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
