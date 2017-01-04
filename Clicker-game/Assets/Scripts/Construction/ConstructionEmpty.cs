using UnityEngine;
using UnityEngine.UI;

public class ConstructionEmpty : Construction {

	#region Constructor

	public ConstructionEmpty(int id) : base ("Empty", 0, id, 1.0f, false, 1) {
		//Do nothing
	}

	#endregion

	#region Construction Button

	public override void UpdateConstructionButtonAvailability() {
		if (constructionButton != null) {
			constructionButton.gameObject.SetActive (false);
		}
	}

	//Updates the button displaying the cost of the next copies of this construction
	public override void UpdateButtonDisplayedCost() {
		//Do nothing
	}

	//Updates the displayed name for this construction
	public override void UpdateButtonDisplayedName() {
		//Do nothing 
	}

	//Updates the displayed contribution for this construction
	public override void UpdateButtonDisplayedContribution() {
		//Do nothing 
	}

	//Updates the button displaying the number of copies of this construction currently possessed
	public override void UpdateButtonDisplayedQuantity() {
		//Do nothing
	}

	//Updates the construction button's image
	public override void UpdateConstructionButtonsImage() {
		//Do nothing
	}

	#endregion

	#region Upgrade Button

	//Updates the upgrade button availability
	public override void UpdateUpgradeButtonAvailability() {
		if (upgradeButton != null) {
			upgradeButton.gameObject.SetActive (false);
		}
	}

	//Updates the upgrade button image color
	protected override void UpdateUpgradeButtonColor() {
		//Do nothing
	}

	//Updates the upgrade button's image
	protected override void UpdateUpgradeButtonsImage() {
		//Do nothing
	}

	//When the mouse hover over the upgrade button
	public override void OnMouseOverUpgradeButton(ToolTip tt) {
		//Do nothing
	}

	#endregion

	#region OtherCalulations

	//Calculates the amount of money produced by this construction per second
	public override void CalculateProduction() {
		//Do nothing
	}

	//Calculates the contribution of this specific constructions among all constructions
	protected override void CalculateContribution() {
		//Do nothing
	}

	//Calculates the number of constructions to build according to the bulk buying roulette button
	public override void CalculateNumberOfConstructionsToBuild() {
		//Do nothing
	}

	#endregion
}
