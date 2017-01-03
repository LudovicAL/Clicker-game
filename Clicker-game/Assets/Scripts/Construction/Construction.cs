using UnityEngine;
using UnityEngine.UI;

public abstract class Construction {
	public int id { get; protected set; } //The smallest id must start at 1.
	public string name { get; protected set; }
	public int quantity { get; protected set; }
	public double constructionCost { get; protected set; }
	public bool constructionAvailability { get; set; }
	public double production { get; protected set; }
	public float contribution { get; protected set; }
	protected int numberOfConstructionsToBuild;
	protected float constructionCostModifier;
	public Sprite icon { get; set; }
	public Button constructionButton { get; set; }

	public Button upgradeButton { get; set; }
	public int upgradeLevel { get; protected set; }
	public double upgradeCost { get; protected set; }
	protected int upgradesInterval;

	#region Constructor

	public Construction(string name, int quantity, int id, float constructionCostModifier, bool constructionAvailability, int upgradesInterval) {
		this.name = name;
		this.quantity = quantity;
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
		//Icons are managed in the child class
	}

	#endregion
		
	#region Construction

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
	protected double CalculateCostForOne() {
		return System.Math.Pow(id + 1, constructionCostModifier + 4) * System.Math.Pow(constructionCostModifier, quantity);
	}

	//Calculates the cost to build N copies of this construction
	//((costForOne * ((C ^ N) - 1)) / (C - 1) ... Where C = costModifier, N = N
	public void CalculateCostForNCopiesOfThisConstruction() {
		constructionCost = (CalculateCostForOne() * ((System.Math.Pow(constructionCostModifier, numberOfConstructionsToBuild)) - 1))/(constructionCostModifier - 1);
	}

	//Returns the maximum number of copies of this construction the player can afford at the moment with his current money
	//Floor(ln((availableMoney / costForOne) * (C - 1) + 1) / ln(c))
	protected int CalculateMaxBuyable(double availableMoney) {
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

	#region Upgrade

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
	public void CalculateNextUpgradeCost() {
		upgradeCost = (double)((upgradeLevel + 1) * id);
	}

	//Returns true if the player can afford the construction upgrade
	public bool CanAffordUpgrade() {
		return (PersistentData.currentMoney >= upgradeCost);
	}

	#endregion

	#region Construction Button

	public abstract void UpdateConstructionButtonAvailability();

	//Updates the button displaying the cost of the next copies of this construction
	public abstract void UpdateButtonDisplayedCost();

	//Updates the displayed name for this construction
	public abstract void UpdateButtonDisplayedName();

	//Updates the displayed contribution for this construction
	public abstract void UpdateButtonDisplayedContribution();

	//Updates the button displaying the number of copies of this construction currently possessed
	public abstract void UpdateButtonDisplayedQuantity();

	//Updates the construction button's image
	public abstract void UpdateConstructionButtonsImage();

	#endregion

	#region Upgrade Button

	//Updates the upgrade button availability
	public abstract void UpdateUpgradeButtonAvailability();

	//Updates the upgrade button image color
	protected abstract void UpdateUpgradeButtonColor();

	//Updates the upgrade button's image
	protected abstract void UpdateUpgradeButtonsImage();

	//When the mouse hover over the upgrade button
	public abstract void OnMouseOverUpgradeButton(ToolTip tt);

	#endregion

	#region OtherCalulations

	//Calculates the amount of money produced by this construction per second
	public abstract void CalculateProduction();

	//Calculates the contribution of this specific constructions among all constructions
	protected abstract void CalculateContribution();

	//Calculates the number of constructions to build according to the bulk buying roulette button
	public abstract void CalculateNumberOfConstructionsToBuild();

	#endregion
}