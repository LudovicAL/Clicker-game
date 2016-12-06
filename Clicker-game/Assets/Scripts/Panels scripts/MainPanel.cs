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

	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		RandomizePlanet ();
	}
	
	// Update is called once per frame
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
		float scale = Random.Range (1.0f, 2.0f);
		planetImage.GetComponent<RectTransform> ().localScale = new Vector3(scale, scale, 1.0f);
		Sprite[] planetIcons = Resources.LoadAll<Sprite> ("PlanetIcons");
		if (planetIcons.Length > 0) {
			int iconId = Random.Range (0, planetIcons.Length - 1);
			planetImage.GetComponent<Image> ().sprite = planetIcons[iconId];
		}
		if (PersistentData.promtForPlanetName) {
			this.GetComponent<MessagesPanel>().PromptForPlanetName ();
		} else {
			planetName.text = CommonTools.GeneratePlanetName ();
			PersistentData.planetName = planetName.text;
		}
	}

	public void UpdatePlanetName() {
		planetName.text = PersistentData.planetName;
	}

	//Whenever the player clics the main button
	public void OnMainButtonClic() {
		if (panelState == AvailablePanelStates.Playing) {
			this.GetComponent<DataManager> ().AddClick ();
		}
	}
}
