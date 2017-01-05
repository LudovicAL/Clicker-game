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

	//On a click on the expander
	public void onClick() {
		isOn = !isOn;
		updateDisplay ();
	}

	//Updates the expander display
	private void updateDisplay() {
		expanderButtonText.text = (isOn) ? bName + " ▼" : bName + " ▲";
		expanderPanel.SetActive (isOn);
	}
}