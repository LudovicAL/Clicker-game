using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade {
	string name { get; set; }
	string description { get; set; }
	int currentLevel { get; set; }
	double costOfNextLevel { get; }
	public Button upgradeButton { get; set; }

	public Upgrade(Button upgradeButton, string name, string description) {
		this.upgradeButton = upgradeButton;
		this.name = name;
		this.description = description;
		this.currentLevel = 0;
		CalculateCostOfNextLevel ();
	}

	public bool CanAffordUpgrade() {
		return (PersistentData.currentMoney >= costOfNextLevel);
	}

	//Adds N level(s) to the current upgrade's level
	public void AddNLevel(int n) {
		currentLevel += n;
		ApplyUpgradeEffect ();
		CalculateCostOfNextLevel ();
		UpdateButtonAvailability ();
		UpdateButtonAccessibility ();
		UpdateButtonDisplayedCost ();
		UpdateButtonColor ();
	}

	//Buys the upgrade's next level
	public void BuyNextLevel() {
		if (CanAffordUpgrade ()) {
			PersistentData.currentMoney -= costOfNextLevel;
			AddNLevel(1);
		}
	}

	//Updates the enabled status of the button
	public void UpdateButtonAccessibility() {
		upgradeButton.enabled = CanAffordUpgrade ();
	}

	//Updates the active status of the button
	public void UpdateButtonAvailability() {
		upgradeButton.gameObject.SetActive(IsUpgradeAvailable());
	}

	//Updates the displayed cost for the upgrade's next level
	public void UpdateButtonDisplayedCost() {

	}

	//Updates the button's color
	public void UpdateButtonColor() {

	}

	public void OnMouseOver(ToolTip tt) {
		tt.TurnToolTipOn (
			upgradeButton.gameObject,
			name,
			CommonTools.DoubleToString(costOfNextLevel) + " $",
			description
		);
	}

	public abstract bool IsUpgradeAvailable();

	public abstract void CalculateCostOfNextLevel();

	public abstract void ApplyUpgradeEffect();
}
