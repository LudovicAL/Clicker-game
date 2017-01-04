using UnityEngine;
using UnityEngine.UI;

public class EmptyAbility : Ability {
	public EmptyAbility(): base ("Empty", "Empty", 1.0f) {
		//Nothing here yet
	}

	public override bool IsAbilityAvailable() {
		return false;
	}

	public override void UseAbility() {
		//Do nothing.
	}
}
