using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour {
	public enum AvailableCanvasStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject toolTipPanel;
	public Button[] constructionsButtonList;
	public Button[] upgradesButtonList;
	public GameObject[] leftPanelInnerPanelsList;
	public GameObject[] rightPanelInnerPanelsList;
	public GameObject panelLeft;
	public GameObject panelRight;
	public Image planetImage;
	public Text planetName;
	public Text currentMoneyText;
	public Text currentFarmingText;
	public Button bulkBuyingButton;
	private AvailableCanvasStates canvasState;

	// Use this for initialization
	void Start () {
		CommonTools.updateNumbersNotations ();
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetCanvasState (AvailableCanvasStates.Playing);
		for (int i = 0; i < PersistentData.listOfConstructions.Length && i < constructionsButtonList.Length && i < upgradesButtonList.Length; i++) {
			PersistentData.listOfConstructions [i].ConstructionButton = constructionsButtonList [i];
			PersistentData.listOfConstructions [i].UpgradeButton = upgradesButtonList [i];
			PersistentData.listOfConstructions [i].IsUnlocked = PersistentData.listOfConstructions [i].IsUnlocked;
		}
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.UpdateButtonDisplayedName ();
			c.UpdateButtonDisplayedCost ();
			c.UpdateButtonDisplayedQuantity ();
			c.UpdateButtonDisplayedContribution ();
		}
		RandomizePlanet ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canvasState == AvailableCanvasStates.Playing) {
			UpdateTopPanel();
			UpdateRightPanel ();
			UpdateLeftPanel();
		}
	}

	protected void OnPlaying() {
		SetCanvasState (AvailableCanvasStates.Playing);
	}

	protected void OnPausing() {
		SetCanvasState (AvailableCanvasStates.Paused);
	}

	public void SetCanvasState(AvailableCanvasStates state) {
		canvasState = state;
	}

	//Updates the top panel
	public void UpdateTopPanel() {
		currentMoneyText.text = CommonTools.DoubleToString(PersistentData.currentMoney) + " $";
		currentFarmingText.text = CommonTools.DoubleToString(PersistentData.totalFarmingReward) + " $ / sec.";
	}

	//Updates the left panel
	public void UpdateLeftPanel() {
		if (!panelRight.GetComponent<Animator> ().GetBool ("isHidden")) {
			foreach (Construction c in PersistentData.listOfConstructions) {
				if (c.IsUnlocked) {
					c.CalculateNumberOfConstructionsToBuild ();
					c.UpdateButtonDisplayedCost ();
					c.ConstructionButtonIsInterractable = this.GetComponent<DataManager> ().CanAffordConstruction(c);
					c.UpgradeButtonIsActive = this.GetComponent<DataManager> ().IsUpgradeAvailable (c);
					c.UpgradeButtonIsInterractable = this.GetComponent<DataManager> ().CanAffordUpgrade (c);
				}
			}
		}
	}

	//Updates the right panel
	public void UpdateRightPanel() {
		if (!panelRight.GetComponent<Animator> ().GetBool ("isHidden")) {
			
		}
	}

	//Whenever the player clics the main button
	public void OnMainButtonClic() {
		if (canvasState == AvailableCanvasStates.Playing) {
			this.GetComponent<DataManager> ().AddClick ();
		}
	}

	//When the player clicks a menu button from the left panel
	public void OnLeftPanelMenuButtonClic(int menuNo) {
		if (canvasState == AvailableCanvasStates.Playing) {
			bool isHidden = panelLeft.GetComponent<Animator> ().GetBool ("isHidden");
			if (isHidden || leftPanelInnerPanelsList[menuNo].activeSelf) {
				panelLeft.GetComponent<Animator> ().SetBool("isHidden", !isHidden);	
			}
			for (int i = 0; i < leftPanelInnerPanelsList.Length; i++) {
				leftPanelInnerPanelsList[i].SetActive((i == menuNo) ? true : false);
			}
		}
	}

	//When the player clicks a menu button from the right panel
	public void OnRightPanelMenuButtonClic(int menuNo) {
		if (canvasState == AvailableCanvasStates.Playing) {
			bool isHidden = panelRight.GetComponent<Animator> ().GetBool ("isHidden");
			if (isHidden || rightPanelInnerPanelsList[menuNo].activeSelf) {
				panelRight.GetComponent<Animator> ().SetBool("isHidden", !isHidden);
			}
			for (int i = 0; i < rightPanelInnerPanelsList.Length; i++) {
				rightPanelInnerPanelsList[i].SetActive((i == menuNo) ? true : false);
			}
		}
	}

	//When the player clicks the bulk buying button
	public void OnBulkBuyingButtonClic() {
		PersistentData.bulkBuyer.MoveToNextItem ();
		bulkBuyingButton.GetComponentInChildren<Text> ().text = PersistentData.bulkBuyer.Caption;
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.CalculateNumberOfConstructionsToBuild ();
			c.UpdateButtonDisplayedCost ();
		}
	}

	//When the player clicks on a construction button
	public void OnLeftPanelConstructionButtonClic(int buttonNo) {
		if (canvasState == AvailableCanvasStates.Playing) {
			if (this.GetComponent<DataManager> ().CanAffordConstruction (PersistentData.listOfConstructions[buttonNo])) {
				this.GetComponent<DataManager> ().BuyConstruction (PersistentData.listOfConstructions[buttonNo]);
				UpdateLeftPanel ();
			}
		}
	}

	//When the player clicks on a construction upgrade button
	public void OnLeftPanelConstructionUpgradeButtonClic(int buttonNo) {
		if (canvasState == AvailableCanvasStates.Playing) {
			if (this.GetComponent<DataManager> ().CanAffordUpgrade (PersistentData.listOfConstructions[buttonNo])) {
				this.GetComponent<DataManager> ().BuyUpgrade (PersistentData.listOfConstructions[buttonNo]);
				UpdateLeftPanel ();
				toolTipPanel.GetComponent<ToolTip> ().TurnToolTipOff ();
			}
		}
	}

	public void ShowAd() {
		this.GetComponent<AdsManager> ().ShowRewardedAd ();
	}

	public void OnSaveButtonClic() {
		PersistentData.SaveData ();
	}

	public void OnLoadButtonClic() {
		PersistentData.LoadData ();
		if (PersistentData.timeSinceLastSave != System.TimeSpan.Zero) {
			this.GetComponent<MessagesPanelManager> ().ShowRewardAfterAbsence ();
		}
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
			this.GetComponent<MessagesPanelManager>().PromptForPlanetName ();
		} else {
			planetName.text = CommonTools.GeneratePlanetName ();
			PersistentData.planetName = planetName.text;
		}
	}

	public void UpdatePlanetName() {
		planetName.text = PersistentData.planetName;
	}

	public void OnMouseOverUpgradeButton(int buttonNo) {
		toolTipPanel.GetComponent<ToolTip> ().TurnToolTipOn (
			PersistentData.listOfConstructions[buttonNo].UpgradeButton.gameObject,
			WordsLists.upgradesAdjectives[PersistentData.listOfConstructions[buttonNo].UpgradeLevel] + PersistentData.listOfConstructions[buttonNo].Name,
			"",
			PersistentData.listOfConstructions[buttonNo].Name + " production is doubled."
		);
	}

	public void OnMouseExitUpgradeButton(int buttonNo) {
		toolTipPanel.SetActive (false);
	}
}
