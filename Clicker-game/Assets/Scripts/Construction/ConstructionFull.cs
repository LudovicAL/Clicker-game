using UnityEngine;
using UnityEngine.UI;

public class ConstructionFull : Construction {

	#region Constructor

	public ConstructionFull(string name, int quantity, int id, float constructionCostModifier, bool constructionAvailability, int upgradesInterval)
		: base (name, quantity, id, constructionCostModifier, constructionAvailability, upgradesInterval) {
		Sprite[] constructionIcons = Resources.LoadAll<Sprite> ("ConstructionIcons");
		foreach (Sprite s in constructionIcons) {
			if (string.Compare(s.name.ToString(), name) == 0) {
				this.icon = s;
				break;
			}
		}
	}

	#endregion

	#region Construction Button

	public override void UpdateConstructionButtonAvailability() {
		if (constructionButton != null) {
			constructionButton.gameObject.SetActive (constructionAvailability);
		}
	}

	//Updates the button displaying the cost of the next copies of this construction
	public override void UpdateButtonDisplayedCost() {
		if (constructionButton != null) {
			Component[] textComponentsArray = constructionButton.GetComponentsInChildren<Text> ();
			foreach (Text t in textComponentsArray) {
				if (t.gameObject.CompareTag("Cost")) {
					CalculateNumberOfConstructionsToBuild ();
					CalculateCostForNCopiesOfThisConstruction();
					if (PersistentData.bulkBuyer.Quantity == 0) {
						t.text = "(" + numberOfConstructionsToBuild.ToString() + "x) " + CommonTools.DoubleToString(constructionCost) + " $";
					} else {
						t.text = CommonTools.DoubleToString(constructionCost) + " $";
					}
					break;
				}
			}
		}
	}

	//Updates the displayed name for this construction
	public override void UpdateButtonDisplayedName() {
		if (constructionButton != null) {
			Component[] textComponentsArray = constructionButton.GetComponentsInChildren<Text> ();
			foreach (Text t in textComponentsArray) {
				if (t.gameObject.CompareTag("Name")) {
					t.text = name;
					break;
				}
			}
		} 
	}

	//Updates the displayed contribution for this construction
	public override void UpdateButtonDisplayedContribution() {
		if (constructionButton != null) {
			Component[] textComponentsArray = constructionButton.GetComponentsInChildren<Text> ();
			foreach (Text t in textComponentsArray) {
				if (t.gameObject.CompareTag("Contribution")) {
					t.text = contribution.ToString("p2");
					break;
				}
			}
		} 
	}

	//Updates the button displaying the number of copies of this construction currently possessed
	public override void UpdateButtonDisplayedQuantity() {
		if (constructionButton != null) {
			Component[] textComponentsArray = constructionButton.GetComponentsInChildren<Text> ();
			foreach (Text t in textComponentsArray) {
				if (t.gameObject.CompareTag("Quantity")) {
					t.text = quantity.ToString ();
					break;
				}
			}
		}
	}

	//Updates the construction button's image
	public override void UpdateConstructionButtonsImage() {
		if (constructionButton != null) {
			Component[] imageComponentsArray = constructionButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Image")) {
					i.GetComponent<Image> ().sprite = icon;
					break;
				}
			}
		}
	}

	#endregion

	#region Upgrade Button

	//Updates the upgrade button availability
	public override void UpdateUpgradeButtonAvailability() {
		if (upgradeButton != null) {
			if (constructionAvailability) {
				upgradeButton.gameObject.SetActive(quantity >= ((upgradeLevel + 1) * upgradesInterval));
			} else {
				upgradeButton.gameObject.SetActive(false);
			}
		}
	}

	//Updates the upgrade button image color
	protected override void UpdateUpgradeButtonColor() {
		if (upgradeButton != null) {
			Component[] imageComponentsArray = upgradeButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Plus")) {
					i.GetComponent<Image> ().color = WordsLists.upgradesColors [upgradeLevel];
					break;
				}
			}
		}
	}

	//Updates the upgrade button's image
	protected override void UpdateUpgradeButtonsImage() {
		if (upgradeButton != null) {
			Component[] imageComponentsArray = upgradeButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Image")) {
					i.GetComponent<Image> ().sprite = icon;
					break;
				}
			}
		}
	}

	//When the mouse hover over the upgrade button
	public override void OnMouseOverUpgradeButton(ToolTip tt) {
		tt.TurnToolTipOn (
			upgradeButton.gameObject,
			WordsLists.upgradesAdjectives[upgradeLevel] + name,
			CommonTools.DoubleToString(upgradeCost) + " $",
			name + " production is doubled."
		);
	}

	#endregion

	#region OtherCalulations

	//Calculates the amount of money produced by this construction per second
	public override void CalculateProduction() {
		production = System.Math.Pow (id + 1, 2.0f) * quantity * System.Math.Pow(2, (double)(upgradeLevel));
	}

	//Calculates the contribution of this specific constructions among all constructions
	protected override void CalculateContribution() {
		if (PersistentData.farmingRewardFromConstructions != 0) {
			contribution = (float)(production / PersistentData.farmingRewardFromConstructions);
		}
	}

	//Calculates the number of constructions to build according to the bulk buying roulette button
	public override void CalculateNumberOfConstructionsToBuild() {
		if (PersistentData.bulkBuyer.Quantity == 0) {
			numberOfConstructionsToBuild = CalculateMaxBuyable(PersistentData.currentMoney);
		} else {
			numberOfConstructionsToBuild = PersistentData.bulkBuyer.Quantity;
		}
	}

	#endregion
}