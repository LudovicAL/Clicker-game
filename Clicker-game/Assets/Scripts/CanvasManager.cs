using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
	public enum AvailableCanvasStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject toolTipPanel;
	public GameObject[] leftPanelInnerPanelsList;
	public GameObject[] rightPanelInnerPanelsList;
	public GameObject panelLeft;
	public GameObject panelRight;
	public Button bulkBuyingButton;
	private AvailableCanvasStates canvasState;

	// Use this for initialization
	void Start () {
		CommonTools.updateNumbersNotations ();
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetCanvasState (AvailableCanvasStates.Playing);
		foreach (Construction c in PersistentData.listOfConstructions) {
			c.IsUnlocked = c.IsUnlocked; //Activate or deactivate the button. It works because this specific mutator has more to it then only a change of value. Go see the Construction class for yourself, you'll see.
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (canvasState == AvailableCanvasStates.Playing) {
			
		//}
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

	public void ShowAd() {
		this.GetComponent<AdsManager> ().ShowRewardedAd ();
	}

	public void OnSaveButtonClic() {
		PersistentData.SaveData ();
	}

	public void OnLoadButtonClic() {
		PersistentData.LoadData ();
		if (PersistentData.timeSinceLastSave != System.TimeSpan.Zero) {
			this.GetComponent<MessagesPanel> ().ShowRewardAfterAbsence ();
		}
	}
}
