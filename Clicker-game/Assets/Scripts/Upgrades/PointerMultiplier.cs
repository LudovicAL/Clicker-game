using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerMultiplier : Upgrade {

	public PointerMultiplier(Button upgradeButton, string name, string description): base (upgradeButton, name, description) {

	}

	public override void ApplyUpgradeEffect() {
		
	}

	public override void CalculateCostOfNextLevel() {
		
	}

	public override bool IsUpgradeAvailable() {
		return true;
	}

}
