﻿using UnityEngine;
using UnityEngine.UI;

public class DefaultAbility : Ability {
	public DefaultAbility(string name, string description, float manaCost): base (name, description, manaCost) {
		//Nothing here yet
	}

	//Is the ability available
	public override bool IsAbilityAvailable() {
		return true;
	}

	//Uses the ability
	public override void UseAbility() {
		if (PersistentData.currentMana >= manaCost) {
			PersistentData.currentMana -= manaCost;
			UpdateButtonInteractivity ();
		}
	}
}