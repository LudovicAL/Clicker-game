using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	public GameObject ttSmallPanel;
	public Text ttSmallTopLeft;
	public Text ttSmallTopRight;
	public Text ttSmallDescription;

	public GameObject ttLongPanel;
	public Text ttLongTopLeft;
	public Text ttLongTopRight;
	public Text ttLongDescription;
	public Text ttLongBottomLeft;
	public Text ttLongBottomRight;

	private AvailablePanelStates panelState;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		TurnToolTipOff ();
	}
	
	/*
	void Update () {
	
	}
	*/

	protected void OnPlaying() {
		SetPanelState (AvailablePanelStates.Playing);
	}

	protected void OnPausing() {
		SetPanelState (AvailablePanelStates.Paused);
	}

	public void SetPanelState(AvailablePanelStates state) {
		panelState = state;
	}

	//Turns on the small tooltip
	public void TurnToolTipOn(GameObject go, string topLeft, string topRight, string description) {
		if (panelState == AvailablePanelStates.Playing) {
			ttSmallTopLeft.text = topLeft;
			ttSmallTopRight.text = topRight;
			ttSmallDescription.text = description;
			if (Camera.main.ScreenToViewportPoint(go.GetComponent<RectTransform> ().position).x > 0.5f) {
				ttSmallPanel.GetComponent<RectTransform> ().pivot = new Vector2(1.01f, 0.5f);
			} else {
				ttSmallPanel.GetComponent<RectTransform> ().pivot = new Vector2(-0.01f, 0.5f);
			}
			ttSmallPanel.GetComponent<RectTransform> ().position = go.GetComponent<RectTransform> ().position;
			ttSmallPanel.gameObject.SetActive (true);
		}
	}

	//Turns on the long tooltip
	public void TurnToolTipOn(GameObject go, string topLeft, string topRight, string description, string bottomLeft, string bottomRight) {
		if (panelState == AvailablePanelStates.Playing) {
			ttLongTopLeft.text = topLeft;
			ttLongTopRight.text = topRight;
			ttLongDescription.text = description;
			ttLongBottomLeft.text = bottomLeft;
			ttLongBottomRight.text = bottomRight;
			if (Camera.main.ScreenToViewportPoint(go.GetComponent<RectTransform> ().position).x > 0.5f) {
				ttLongPanel.GetComponent<RectTransform> ().pivot = new Vector2(1.01f, 0.5f);
			} else {
				ttLongPanel.GetComponent<RectTransform> ().pivot = new Vector2(-0.01f, 0.5f);
			}
			ttLongPanel.GetComponent<RectTransform> ().position = go.GetComponent<RectTransform> ().position;
			ttLongPanel.gameObject.SetActive (true);
		}
	}

	//Turns off both tooltips
	public void TurnToolTipOff() {
		ttSmallPanel.gameObject.SetActive (false);
		ttLongPanel.gameObject.SetActive (false);
	}
}
