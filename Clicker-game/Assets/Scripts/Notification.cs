using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {

	private StaticData.AvailableGameStates panelState;
	public GameObject thisPanel;
	public Text thisText;
	private bool showing;
	private Task tTask;

	void Start () {
		this.GetComponent<GameStatesManager> ().PlayingGameState.AddListener(OnPlaying);
		this.GetComponent<GameStatesManager> ().PausedGameState.AddListener(OnPausing);
		SetPanelState (this.GetComponent<GameStatesManager> ().gameState);
		showing = false;
		tTask = null;
	}
	
	void Update () {
		if (panelState == StaticData.AvailableGameStates.Playing) {
			if (!showing) {
				if (StaticData.notificationList.Count > 0) {
					showing = true;
					tTask = new Task(showNextNotification ());
				}
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

	//Shows the next notification in the queue
	private IEnumerator showNextNotification() {
		thisText.text = "New achievement completed: " + StaticData.notificationList[0].name + " lvl " + StaticData.notificationList[0].currentLevel + ".";
		StaticData.notificationList.RemoveAt(0);
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", false);
		yield return new WaitForSeconds(5);
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", true);
		yield return new WaitForSeconds(1);
		showing = false;
	}

	//Hides the currently shown notification
	private IEnumerator hideNotification() {
		thisPanel.GetComponent<Animator> ().SetBool("isHidden", true);
		yield return new WaitForSeconds(1);
		showing = false;
	}

	//When the played clicks the notification
	public void OnButtonClick() {
		if (panelState == StaticData.AvailableGameStates.Playing) {
			if (tTask != null) {
				if (tTask.Running) {
					tTask.Stop ();
					StartCoroutine (hideNotification ());
				}
			}
		}
	}
}
