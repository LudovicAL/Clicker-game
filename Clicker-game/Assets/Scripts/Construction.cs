using UnityEngine;
using UnityEngine.UI;

public class Construction {
	string name;
	int quantity;
	int id; //The smallest id must start at 1.
	double cost;
	double production;
	float contribution;
	int numberOfConstructionsToBuild;
	float costModifier;
	Button constructionButton;
	Button upgradeButton;
	int upgradeLevel;
	double nextUpgradeCost;
	bool unlocked;

	public Construction(string name, int quantity, int id, float costModifier, Button constructionButton, Button upgradeButton, bool unlocked) {
		this.name = name;
		this.quantity = quantity;
		this.id = id;
		this.constructionButton = constructionButton;
		this.upgradeButton = upgradeButton;
		this.costModifier = costModifier;
		this.contribution = 0;
		this.numberOfConstructionsToBuild = 0;
		this.upgradeLevel = 0;
		this.unlocked = unlocked;
		CalculateNumberOfConstructionsToBuild ();
		CalculateCostForNCopiesOfThisConstruction();
		CalculateProduction ();
		CalculateNextUpgradeCost ();
	}

	//Add N constructions to those already possessed
	public void AddNConstructions(int numberOfConstructionsAdded) {
		quantity += numberOfConstructionsAdded;
		//Not all required calculations are performed here, but rather only those that effect this construction alone
		CalculateNumberOfConstructionsToBuild ();
		CalculateCostForNCopiesOfThisConstruction ();
		CalculateProduction ();
		UpdateButtonDisplayedQuantity ();
	}

	//Add N upgrades to those already possessed
	public void AddNUpgrades(int numberOfUpgradesToAdd) {
		upgradeLevel += numberOfUpgradesToAdd;
		//Not all required calculations are performed here, but rather only those that effect this construction alone
		CalculateNextUpgradeCost ();
		CalculateProduction ();
	}

	//Calculates the cost to build one copy of this construction
	//A * C ^ B  ... Where A = id, B = quantity, C = costModifier
	public double CalculateCostForOne() {
		return System.Math.Pow(id + 1, costModifier + 4) * System.Math.Pow(costModifier, quantity);
	}
		
	//Calculates the cost of the next upgrade
	public void CalculateNextUpgradeCost() {
		nextUpgradeCost = (double)((upgradeLevel + 1) * id);
	}

	//Calculates the cost to build N copies of this construction
	//((costForOne * ((C ^ N) - 1)) / (C - 1) ... Where C = costModifier, N = N
	public void CalculateCostForNCopiesOfThisConstruction() {
		cost = (CalculateCostForOne() * ((System.Math.Pow(costModifier, numberOfConstructionsToBuild)) - 1))/(costModifier - 1);
	}
		
	//Returns the maximum number of copies of this construction the player can afford at the moment with his current money
	//Floor(ln((availableMoney / costForOne) * (C - 1) + 1) / ln(c))
	public int CalculateMaxBuyable(double availableMoney) {
		return (int)System.Math.Floor (
			System.Math.Log (
				(
				    (
						availableMoney / CalculateCostForOne()
				    ) * (
						costModifier - 1
				    ) + 1
				)
			) / (
				System.Math.Log (
				    costModifier
			    )
			)
		);
	}

	//Calculates the amount of money produced by this construction per second
	public void CalculateProduction() {
		production = System.Math.Pow (id + 1, 2.0f) * quantity * System.Math.Pow(2, (double)(upgradeLevel));
	}

	//Calculates the contribution of this specific constructions among all constructions
	public void CalculateContribution() {
		if (PersistentData.farmingRewardFromConstructions != 0) {
			contribution = (float)(production / PersistentData.farmingRewardFromConstructions);
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

	//Updates the upgrade button image color
	public void UpdateUpgradeButtonColor() {
		upgradeButton.GetComponent<Image> ().color = WordsLists.upgradesColors [upgradeLevel];
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
						t.text = "(" + numberOfConstructionsToBuild.ToString() + "x) " + CommonTools.DoubleToString(cost) + " $";
					} else {
						t.text = CommonTools.DoubleToString(cost) + " $";
					}
					break;
				}
			}
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

	//Properties
	public string Name {
		get {
			return name;
		}
	}

	public int Quantity {
		get {
			return quantity;
		}
	}

	public int Id {
		get {
			return id;
		}
	}

	public int UpgradeLevel {
		get {
			return upgradeLevel;
		}
	}

	public int NumberOfConstructionsToBuild {
		get {
			return numberOfConstructionsToBuild;
		}
	}

	public double Cost {
		get {
			return cost;
		}
	}
		
	public double NextUpgradeCost {
		get {
			return nextUpgradeCost;
		}
	}

	public double Production {
		get {
			return production;
		}
	}

	public bool IsUnlocked {
		get {
			return unlocked;
		}
		set {
			unlocked = value;
			constructionButton.gameObject.SetActive(value);
			upgradeButton.gameObject.SetActive(value);
		}
	}

	public Button ConstructionButton {
		get {
			return constructionButton;
		}
		set {
			constructionButton = value;
		}
	}

	public bool ConstructionButtonIsInterractable {
		get {
			return constructionButton.interactable;
		}
		set {
			constructionButton.interactable = value;
		}
	}

	public Button UpgradeButton {
		get {
			return upgradeButton;
		}
		set {
			upgradeButton = value;
		}
	}

	public bool UpgradeButtonIsActive {
		get {
			return upgradeButton.gameObject.activeSelf;
		}
		set {
			if (value) {
				UpdateUpgradeButtonColor ();
			}
			upgradeButton.gameObject.SetActive(value);
		}
	}

	public bool UpgradeButtonIsInterractable {
		get {
			return upgradeButton.interactable;
		}
		set {
			upgradeButton.interactable = value;
		}
	}
}
