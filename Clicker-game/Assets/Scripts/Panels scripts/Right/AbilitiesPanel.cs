using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	public Image manaBar;
	public Text manaText;
	public Button[] abilitiesButtons;
	private AvailablePanelStates panelState;

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		for (int i = 0; i < PersistentData.listOfAbilities.Length; i++) {
			PersistentData.listOfAbilities [i].aButton = abilitiesButtons[i];
		}
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

	//When the mouse hover over an ability button
	public void OnMouseOverAbility(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfAbilities [buttonNo].OnMouseOver(this.GetComponent<ToolTip> ());
		}
	}

	//When the player clicks on an ability button
	public void OnButtonClicAbility(int buttonNo) {
		if (panelState == AvailablePanelStates.Playing) {
			PersistentData.listOfAbilities [buttonNo].UseAbility ();
		}
	}

	public void OnMouseExitAbility() {
		this.GetComponent<ToolTip> ().TurnToolTipOff ();
	}
}
