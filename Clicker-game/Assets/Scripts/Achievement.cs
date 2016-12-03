using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievement : MonoBehaviour {

	public GameObject toolTipPanel;
	public Image progressBar;

	private string aName;
	private string aDescription;
	private int currentLevel;
	private int maxLevel;
	private bool revealed;
	private float currentProgress;

	void Start () {
		aName = "";
		aDescription = "";
		currentLevel = 0;
		maxLevel = 1;
		revealed = false;
		CalculateProgress ();
		UpdateProgressBar ();
	}

	/*
	void Update () {

	}
	*/

	public void OnMouseOver() {
		toolTipPanel.GetComponent<ToolTip> ().TurnToolTipOn (this.gameObject, aName, currentProgress.ToString("P0"), aDescription);
	}

	public void OnMouseExit() {
		toolTipPanel.SetActive (false);
	}

	public void AddNLevels(int numberOfLevelsToAdd) {
		currentLevel += numberOfLevelsToAdd;
		CalculateProgress ();
	}

	public void CalculateProgress() {
		currentProgress = ((float)currentLevel) / ((float)maxLevel);
	}

	public void UpdateProgressBar() {
		progressBar.fillAmount = currentProgress;
	}

	//Getters and setters
	public string AName {
		get {
			return aName;
		}
		set {
			aName = value;
		}
	}

	public string ADescription {
		get {
			return aDescription;
		}
		set {
			aDescription = value;
		}
	}

	public int MaxLevel {
		get {
			return maxLevel;
		}
		set {
			maxLevel = value;
		}
	}

	public bool Revealed {
		get {
			return revealed;
		}
		set {
			revealed = value;
		}
	}
}
