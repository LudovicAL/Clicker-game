using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public int currentLevel { get; protected  set; }
	public double costOfNextLevel { get; protected set; }
	public Button uButton { get; set; }
	public Sprite icon { get; set; }

	public Upgrade(string name, string description) {
		this.name = name;
		this.description = description;
		this.currentLevel = 0;
		CalculateCostOfNextLevel ();
		Sprite[] raceIcons = Resources.LoadAll<Sprite> ("Upgrades");
		foreach (Sprite s in raceIcons) {
			if (string.Compare(s.name.ToString(), name) == 0) {
				this.icon = s;
				break;
			}
		}
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

	//Updates the button's image
	public void UpdateButtonImage() {
		if (uButton != null) {
			Component[] imageComponentsArray = uButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Image")) {
					i.GetComponent<Image> ().sprite = icon;
					break;
				}
			}
		}
	}

	//On mouse over the upgrade button
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

	//Is the upgrade available
	public abstract bool IsUpgradeAvailable();

	//Calculates the cost of the next level for this upgrade
	public abstract void CalculateCostOfNextLevel();

	//Applies the upgrade effect
	public abstract void ApplyUpgradeEffect();
}
