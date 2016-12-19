using UnityEngine;
using UnityEngine.UI;

public class Construction {
	public int id { get; private set; } //The smallest id must start at 1.
	public string name { get; private set; }
	public int quantity { get; private set; }
	public double constructionCost { get; private set; }
	public bool constructionAvailability { get; set; }
	public double production { get; private set; }
	public float contribution { get; private set; }
	private int numberOfConstructionsToBuild;
	private float constructionCostModifier;
	public Button constructionButton { get; set; }

	public Button upgradeButton { get; set; }
	public int upgradeLevel { get; private set; }
	public double upgradeCost { get; private set; }
	private int upgradesInterval;

	public Construction(string name, int quantity, int id, float constructionCostModifier, Button constructionButton, Button upgradeButton, bool constructionAvailability, int upgradesInterval) {
		this.name = name;
		this.quantity = quantity;
		this.id = id;
		this.constructionButton = constructionButton;
		this.upgradeButton = upgradeButton;
		this.constructionCostModifier = constructionCostModifier;
		this.contribution = 0;
		this.numberOfConstructionsToBuild = 0;
		this.upgradeLevel = 0;
		this.constructionAvailability = constructionAvailability;
		this.upgradesInterval = upgradesInterval;
		CalculateNumberOfConstructionsToBuild ();
		CalculateCostForNCopiesOfThisConstruction();
		CalculateProduction ();
		CalculateNextUpgradeCost ();
	}
		
	//CONSTRUCTION--------------------------------------------------------------

	//Add N constructions to those already possessed
	public void AddNConstructions(int numberOfConstructionsAdded) {
		quantity += numberOfConstructionsAdded;
		//Not all required calculations are performed here, but rather only those that effect this construction alone
		CalculateNumberOfConstructionsToBuild ();
		CalculateCostForNCopiesOfThisConstruction ();
		CalculateProduction ();
		UpdateButtonDisplayedQuantity ();
		UpdateUpgradeButtonAvailability ();
	}

	//Buys a construction
	public void BuyConstruction(DataManager dm) {
		if (CanAffordConstruction()) {
			PersistentData.currentMoney -= constructionCost;
			AddNConstructions(numberOfConstructionsToBuild);
			//Not all calculations are performed here, but rather only those that effect every button due to the change
			dm.CalculateTotalFarmingReward ();
			dm.CalculateCurrentTotalNumberOfConstruction ();
			foreach (Construction c in PersistentData.listOfConstructions) {
				c.CalculateContribution ();
				c.UpdateButtonDisplayedContribution ();
				c.UpdateButtonDisplayedCost ();
			}
		}
	}

	//Returns true if the player can afford the construction
	public bool CanAffordConstruction() {
		if (constructionCost == 0) {
			return false;
		} else {
			return (PersistentData.currentMoney >= constructionCost);
		}
	}

	//Calculates the cost to build one copy of this construction
	//A * C ^ B  ... Where A = id, B = quantity, C = costModifier
	private double CalculateCostForOne() {
		return System.Math.Pow(id + 1, constructionCostModifier + 4) * System.Math.Pow(constructionCostModifier, quantity);
	}

	//Calculates the cost to build N copies of this construction
	//((costForOne * ((C ^ N) - 1)) / (C - 1) ... Where C = costModifier, N = N
	private void CalculateCostForNCopiesOfThisConstruction() {
		constructionCost = (CalculateCostForOne() * ((System.Math.Pow(constructionCostModifier, numberOfConstructionsToBuild)) - 1))/(constructionCostModifier - 1);
	}

	//Returns the maximum number of copies of this construction the player can afford at the moment with his current money
	//Floor(ln((availableMoney / costForOne) * (C - 1) + 1) / ln(c))
	private int CalculateMaxBuyable(double availableMoney) {
		return (int)System.Math.Floor (
			System.Math.Log (
				(
					(
						availableMoney / CalculateCostForOne()
					) * (
						constructionCostModifier - 1
					) + 1
				)
			) / (
				System.Math.Log (
					constructionCostModifier
				)
			)
		);
	}

	//UPGRADE--------------------------------------------------------------

	//Buys an upgrade
	public void BuyUpgrade(DataManager dm) {
		if (CanAffordUpgrade()) {
			PersistentData.currentMoney -= upgradeCost;
			AddNUpgrades(1);
			//Not all calculations are performed here, but rather only those that effect every button due to the change
			dm.CalculateTotalFarmingReward ();
			foreach (Construction c in PersistentData.listOfConstructions) {
				c.CalculateContribution ();
				c.UpdateButtonDisplayedContribution ();
				c.UpdateButtonDisplayedCost ();
			}
		}
	}

	//Add N upgrades to those already possessed
	public void AddNUpgrades(int numberOfUpgradesToAdd) {
		upgradeLevel += numberOfUpgradesToAdd;
		//Not all required calculations are performed here, but rather only those that effect this construction alone
		CalculateNextUpgradeCost ();
		CalculateProduction ();
		UpdateUpgradeButtonColor ();
	}
		
	//Calculates the cost of the next upgrade
	private void CalculateNextUpgradeCost() {
		upgradeCost = (double)((upgradeLevel + 1) * id);
	}

	//Returns true if the player can afford the construction upgrade
	public bool CanAffordUpgrade() {
		return (PersistentData.currentMoney >= upgradeCost);
	}

	//CONSTRUCTION BUTTON--------------------------------------------------------------

	public void UpdateConstructionButtonAvailability() {
		if (upgradeButton != null) {
			constructionButton.gameObject.SetActive (constructionAvailability);
		}
	}

	//Updates the button displaying the cost of the next copies of this construction
	public void UpdateButtonDisplayedCost() {
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
	public void UpdateButtonDisplayedName() {
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
	public void UpdateButtonDisplayedContribution() {
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
	public void UpdateButtonDisplayedQuantity() {
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
	public void UpdateConstructionButtonsImage(Sprite s) {
		if (constructionButton != null) {
			Component[] imageComponentsArray = constructionButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Image")) {
					i.GetComponent<Image> ().sprite = s;
					break;
				}
			}
		}
	}

	//UPGRADE BUTTON--------------------------------------------------------------

	//Updates the upgrade button availability
	public void UpdateUpgradeButtonAvailability() {
		if (upgradeButton != null) {
			if (constructionAvailability) {
				upgradeButton.gameObject.SetActive(quantity >= ((upgradeLevel + 1) * upgradesInterval));
			} else {
				upgradeButton.gameObject.SetActive(false);
			}
		}
	}

	//Updates the upgrade button image color
	private void UpdateUpgradeButtonColor() {
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
	private void UpdateUpgradeButtonsImage(Sprite s) {
		if (upgradeButton != null) {
			Component[] imageComponentsArray = upgradeButton.GetComponentsInChildren<Image> ();
			foreach (Image i in imageComponentsArray) {
				if (i.gameObject.CompareTag("Image")) {
					i.GetComponent<Image> ().sprite = s;
					break;
				}
			}
		}
	}

	//When the mouse hover over the upgrade button
	public void OnMouseOverUpgradeButton(ToolTip tt) {
		tt.TurnToolTipOn (
			upgradeButton.gameObject,
			WordsLists.upgradesAdjectives[upgradeLevel] + name,
			CommonTools.DoubleToString(upgradeCost) + " $",
			name + " production is doubled."
		);
	}

	//OTHER CALCULATIONS--------------------------------------------------------------

	//Calculates the amount of money produced by this construction per second
	private void CalculateProduction() {
		production = System.Math.Pow (id + 1, 2.0f) * quantity * System.Math.Pow(2, (double)(upgradeLevel));
	}

	//Calculates the contribution of this specific constructions among all constructions
	private void CalculateContribution() {
		if (PersistentData.farmingRewardFromConstructions != 0) {
			contribution = (float)(production / PersistentData.farmingRewardFromConstructions);
		}
	}

	//Calculates the number of constructions to build according to the bulk buying roulette button
	public void CalculateNumberOfConstructionsToBuild() {
		if (PersistentData.bulkBuyer.Quantity == 0) {
			numberOfConstructionsToBuild = CalculateMaxBuyable(PersistentData.currentMoney);
		} else {
			numberOfConstructionsToBuild = PersistentData.bulkBuyer.Quantity;
		}
	}
}