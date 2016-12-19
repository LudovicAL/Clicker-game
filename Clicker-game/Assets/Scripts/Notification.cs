using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {

	public enum AvailablePanelStates {
		Paused,	//Player is paused
		Playing,	//Game is playing
	};

	private AvailablePanelStates panelState;
	public GameObject thisPanel;
	public Text thisText;
	private bool showing;
	private Task tTask;



	// Use this for initialization
	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (AvailablePanelStates.Playing);
		showing = false;
		tTask = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (panelState == AvailablePanelStates.Playing) {
			if (!showing) {
				if (PersistentData.notificationList.Count > 0) {
					showing = true;
					tTask = new Task(showNextNotification ());
				}
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

	private IEnumerator showNextNotification() {
		thisText.text = "New achievement completed: " + PersistentData.notificationList[0].name + " lvl " + PersistentData.notificationList[0].currentLevel + ".";
		PersistentData.notificationList.RemoveAt(0);
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", false);
		yield return new WaitForSeconds(5);
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", true);
		yield return new WaitForSeconds(1);
		showing = false;
	}

	private IEnumerator hideNotification() {
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", true);
		yield return new WaitForSeconds(1);
		showing = false;
	}

	public void OnButtonClick() {
		if (panelState == AvailablePanelStates.Playing) {
			if (tTask != null) {
				if (tTask.Running) {
					tTask.Stop ();
					StartCoroutine (hideNotification ());
				}
			}
		}
	}
}
