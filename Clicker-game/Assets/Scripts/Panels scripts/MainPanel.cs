using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour {

	public GameObject thisPanel;
	private StaticData.AvailableGameStates panelState;
	public Image planetImage;
	public Text planetName;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
	}
	
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing && thisPanel.activeSelf) {
			
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

	//Generates a random planet
	public void RandomizePlanet() {
		StaticData.storedData.planetScale = Random.Range (1.0f, 2.0f);
		Sprite[] planetIcons = Resources.LoadAll<Sprite> ("PlanetIcons");
		if (planetIcons.Length > 0) {
			StaticData.storedData.planetIconId = Random.Range (0, planetIcons.Length - 1);
		}
		if (StaticData.storedData.promptForPlanetName) {
			this.GetComponent<MessagesPanel>().PromptForPlanetName ();
		} else {
			StaticData.storedData.planetName = CommonTools.GeneratePlanetName ();
		}
		UpdatePlanet ();
	}

	//Updates the planet display
	public void UpdatePlanet() {
		planetName.text = StaticData.storedData.planetName;
		planetImage.GetComponent<RectTransform> ().localScale = new Vector3(StaticData.storedData.planetScale, StaticData.storedData.planetScale, 1.0f);
		Sprite[] planetIcons = Resources.LoadAll<Sprite> ("PlanetIcons");
		planetImage.GetComponent<Image> ().sprite = planetIcons[StaticData.storedData.planetIconId];
	}

	//Whenever the player clics the main button
	public void OnMainButtonClic() {
		if (panelState == StaticData.AvailableGameStates.Playing) {
			this.GetComponent<DataManager> ().AddClick ();
		}
	}
}
