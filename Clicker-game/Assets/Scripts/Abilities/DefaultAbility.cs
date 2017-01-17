using UnityEngine;
using UnityEngine.UI;
using System;

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
		if (StaticData.currentMana >= manaCost) {
			StaticData.currentMana -= manaCost;
			UpdateButtonInteractivity ();
		}
	}
}