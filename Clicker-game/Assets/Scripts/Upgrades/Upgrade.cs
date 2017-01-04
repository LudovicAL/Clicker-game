using UnityEngine.UI;

public abstract class Upgrade {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public int currentLevel { get; protected  set; }
	public double costOfNextLevel { get; protected set; }
	public Button uButton { get; set; }

	public Upgrade(string name, string description) {
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
		UpdateButtonInteractivity ();
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
	public void UpdateButtonInteractivity() {
		uButton.enabled = CanAffordUpgrade ();
	}

	//Updates the active status of the button
	public void UpdateButtonAvailability() {
		uButton.gameObject.SetActive(IsUpgradeAvailable());
	}

	//Updates the displayed cost for the upgrade's next level
	public void UpdateButtonDisplayedCost() {

	}

	//Updates the button's color
	public void UpdateButtonColor() {

	}

	public void OnMouseOver(ToolTip tt) {
		tt.TurnToolTipOn (
			uButton.gameObject,
			name,
			"Lvl " + (currentLevel + 1).ToString(),
			description,
			"Cost:",
			CommonTools.DoubleToString(costOfNextLevel) + " $"
		);
	}

	public abstract bool IsUpgradeAvailable();

	public abstract void CalculateCostOfNextLevel();

	public abstract void ApplyUpgradeEffect();
}
