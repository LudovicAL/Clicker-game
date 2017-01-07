using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Ability {

	public string name { get; protected set; }
	public string description { get; protected set; }
	public float manaCost { get; protected set; }
	public Button aButton { get; set; }

	public Ability(string name, string description, float manaCost) {
		this.name = name;
		this.description = description;
		this.manaCost = manaCost;
	}


	//Updates the enabled status of the button
	public void UpdateButtonInteractivity() {
		aButton.enabled = PersistentData.currentMana >= manaCost;
	}

	//Updates the active status of the button
	public void UpdateButtonAvailability() {
		aButton.gameObject.SetActive(IsAbilityAvailable());
	}

	//Updates the active status of the button
	public void UpdateButtonDisplayedName() {
		if (aButton != null) {
			Component[] textComponentsArray = aButton.GetComponentsInChildren<Text> ();
			foreach (Text t in textComponentsArray) {
				if (t.gameObject.CompareTag("Name")) {
					t.text = name;
					break;
				}
			}
		} 
	}

	//OnMouseOver the ability button
	public void OnMouseOver(ToolTip tt) {
		tt.TurnToolTipOn (
			aButton.gameObject,
			name,
			manaCost.ToString(),
			description
		);
	}

	//Is the ability available
	public abstract bool IsAbilityAvailable();

	//Uses the ability
	public abstract void UseAbility();
}
