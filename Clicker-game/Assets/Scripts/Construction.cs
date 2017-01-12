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
	public Sprite icon { get; set; }
	public Button constructionButton { get; set; }

	public Button upgradeButton { get; set; }
	public int upgradeLevel { get; private set; }
	public double upgradeCost { get; private set; }
	public int upgradesInterval { get; private set; }

	#region Constructor

	public Construction(string name, int id, float constructionCostModifier, bool constructionAvailability, int upgradesInterval) {
		this.name = name;
		this.quantity = 0;
		this.id = id;
		this.constructionButton = null;
		this.upgradeButton = null;
		this.constructionCostModifier = constructionCostModifier;
		this.contribution = 0;
		this.numberOfConstructionsToBuild = 0;
		this.constructionCost = 1;
		this.production = 0;
		this.upgradeLevel = 0;
		this.upgradeCost = 1;
		this.constructionAvailability = constructionAvailability;
		this.upgradesInterval = upgradesInterval;
		Sprite[] constructionIcons = Resources.LoadAll<Sprite> ("ConstructionsIcons");
		foreach (Sprite s in constructionIcons) {
			if (string.Compare(s.name.ToString(), name) == 0) {
				this.icon = s;
				break;
			}
		}
	}

	#endregion
		
	#region Construction

	//Add N constructions to those already possessed
	public void AddNConstructions(int numberOfConstructionsAdded) {
		quantity += numberOfConstructionsAdded;
		PersistentData.storedData.constructionsQuantities [id - 1] = quantity;
		//Not all required calculations are performed here, but rather only those that effect this construction alone
		CalculateNumberOfConstructionsToBuild ();
		CalculateCostForNCopiesOfThisConstruction ();
		CalculateProduction ();
		UpdateButtonDisplayedQuantity ();
	}

	//Buys a construction
	public void BuyConstruction(DataManager dm) {
		if (CanAffordConstruction()) {
			PersistentData.storedData.currentMoney -= constructionCost;
			AddNConstructions(numberOfConstructionsToBuild);
			//Not all calculations are performed here, but rather only those that effect every button due to the change
			dm.CalculateTotalFarmingReward ();
			dm.CalculateCurrentTotalNumberOfConstructions ();
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
			return (PersistentData.storedData.currentMoney >= constructionCost);
		}
	}

	//Calculates the cost to build one copy of this construction
	//A * C ^ B  ... Where A = id, B = quantity, C = costModifier
	private double CalculateCostForOne() {
		return System.Math.Pow(id + 1, constructionCostModifier + 4) * System.Math.Pow(constructionCostModifier, quantity);
	}

	//Calculates the cost to build N copies of this construction
	//((costForOne * ((C ^ N) - 1)) / (C - 1) ... Where C = costModifier, N = N
	public void CalculateCostForNCopiesOfThisConstruction() {
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

	#endregion

	#region Construction Button

	//Updates the construction button Active state
	public void UpdateConstructionButtonAvailability() {
		if (constructionButton != null) {
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
	public void UpdateConstructionButtonImage() {
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

	#region OtherCalulations

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

	//Calculates the number of constructions to build according to the bulk buying roulette button
	public void CalculateNumberOfConstructionsToBuild() {
		if (PersistentData.bulkBuyer.Quantity == 0) {
			numberOfConstructionsToBuild = CalculateMaxBuyable(PersistentData.storedData.currentMoney);
		} else {
			numberOfConstructionsToBuild = PersistentData.bulkBuyer.Quantity;
		}
	}

	#endregion
}