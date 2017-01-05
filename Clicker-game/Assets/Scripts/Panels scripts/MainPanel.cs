using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject thisPanel;
	private AvailablePanelStates panelState;
	public Image planetImage;
	public Text planetName;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
	}
	
	void Update () {
		if (panelState == AvailablePanelStates.Playing && thisPanel.activeSelf) {
			
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

	//Generates a random planet
	public void RandomizePlanet() {
		PersistentData.planetScale = Random.Range (1.0f, 2.0f);
		Sprite[] planetIcons = Resources.LoadAll<Sprite> ("PlanetIcons");
		if (planetIcons.Length > 0) {
			PersistentData.planetIconId = Random.Range (0, planetIcons.Length - 1);
		}
		if (PersistentData.promptForPlanetName) {
			this.GetComponent<MessagesPanel>().PromptForPlanetName ();
		} else {
			PersistentData.planetName = CommonTools.GeneratePlanetName ();
		}
		UpdatePlanet ();
	}

	//Updates the planet display
	public void UpdatePlanet() {
		planetName.text = PersistentData.planetName;
		planetImage.GetComponent<RectTransform> ().localScale = new Vector3(PersistentData.planetScale, PersistentData.planetScale, 1.0f);
		Sprite[] planetIcons = Resources.LoadAll<Sprite> ("PlanetIcons");
		planetImage.GetComponent<Image> ().sprite = planetIcons[PersistentData.planetIconId];
	}

	//Whenever the player clics the main button
	public void OnMainButtonClic() {
		if (panelState == AvailablePanelStates.Playing) {
			this.GetComponent<DataManager> ().AddClick ();
		}
	}
}
