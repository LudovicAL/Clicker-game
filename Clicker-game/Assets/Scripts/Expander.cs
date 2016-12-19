using UnityEngine;
using UnityEngine.UI;

public class Expander : MonoBehaviour {
	
	public GameObject expanderPanel;
	public Text expanderButtonText;

	private bool isOn;
	private string bName;

	void Start () {
		this.isOn = true;
		this.bName = expanderButtonText.text;
		updateDisplay ();
	}

	/*
	void Update () {

	}
	*/

	public void onClick() {
		isOn = !isOn;
		updateDisplay ();
	}

	private void updateDisplay() {
		expanderButtonText.text = (isOn) ? bName + " ▼" : bName + " ▲";
		expanderPanel.SetActive (isOn);
	}
}