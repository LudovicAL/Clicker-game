using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public int currentLevel { get; protected  set; }
	public double costOfNextLevel { get; protected set; }
	public double costOfAvailability { get; protected set; }
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
		if (this.icon == null) {
			raceIcons = Resources.LoadAll<Sprite> ("ConstructionsIcons");
			foreach (Sprite s in raceIcons) {
				if (string.Compare(s.name.ToString(), name) == 0) {
					this.icon = s;
					break;
				}
			}
		}
	}

	public bool CanAffordUpgrade() {
		return (StaticData.storedData.currentMoney >= costOfNextLevel);
	}

	//Adds N level(s) to the current upgrade's level
	public void AddNLevel(int n, GameObject scriptsBucket) {
		currentLevel += n;
		scriptsBucket.GetComponent<DataManager> ().CalculateCurrentTotalNumberOfUpgrades ();
		ApplyUpgradeEffect (scriptsBucket);
		CalculateCostOfNextLevel ();
		UpdateButtonAvailability ();
		UpdateButtonInteractivity ();
		UpdateButtonDisplayedCost ();
		UpdateButtonColor ();
	}

	//Buys the upgrade's next level
	public void BuyNextLevel(GameObject scriptsBucket) {
		if (CanAffordUpgrade ()) {
			StaticData.storedData.currentMoney -= costOfNextLevel;
			AddNLevel(1, scriptsBucket);
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
			getName(),
			"Lvl " + (currentLevel + 1).ToString(),
			description,
			"Cost:",
			CommonTools.DoubleToString(costOfNextLevel) + " $"
		);
	}

	//Returns the upgrade name
	public abstract string getName();

	//Is the upgrade available
	public abstract bool IsUpgradeAvailable();

	//Calculates the cost of the next level for this upgrade
	public abstract void CalculateCostOfNextLevel();

	//Applies the upgrade effect
	public abstract void ApplyUpgradeEffect(GameObject scriptsBucket);
}
