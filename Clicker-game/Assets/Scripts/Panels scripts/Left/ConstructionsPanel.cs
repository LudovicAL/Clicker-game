using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionsPanel : MonoBehaviour {

	public GameObject constructionButtonPrefab;
	public GameObject thisPanel;
	private StaticData.AvailableGameStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
		UpdateConstructionButtons ();
	}
	
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			foreach (Construction c in StaticData.listOfConstructions) {
				c.CalculateNumberOfConstructionsToBuild ();
				c.UpdateButtonDisplayedCost ();
				c.constructionButton.interactable = c.CanAffordConstruction();
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

	//Deletes all previously existing construction buttons, creates new ones and updates their display
	public void UpdateConstructionButtons() {
		for (int i = thisPanel.transform.childCount; i > 0; i--) {
			GameObject.Destroy (thisPanel.transform.GetChild (i - 1).gameObject);
		}
		foreach (Construction c in StaticData.listOfConstructions) {
			GameObject go = (GameObject)Instantiate (constructionButtonPrefab, thisPanel.transform, false);
			Button b = go.GetComponent<Button> ();
			b.onClick.AddListener(delegate() { c.BuyConstruction(this.GetComponent<DataManager>()); });
			b.onClick.AddListener(delegate() { Update(); });
			c.constructionButton = b;
			c.UpdateButtonDisplayedName ();
			c.UpdateButtonDisplayedCost ();
			c.UpdateButtonDisplayedQuantity ();
			c.UpdateButtonDisplayedContribution ();
			c.UpdateConstructionButtonImage ();
		}
	}
}
