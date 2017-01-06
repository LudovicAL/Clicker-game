using System.Collections.Generic;

public class Race : Upgrade {
	public List<Construction> constructions { get; protected set; }
	public List<Ability> abilities { get; protected set; }

	public Race(string name, string description, List<Construction> constructions, List<Ability> abilities) : base (name, description) {
		this.constructions = constructions;
		this.abilities = abilities;
	}

	//Applies the upgrade effect
	public override void ApplyUpgradeEffect() {
		
	}

	//Calculates the cost of the next level for this upgrade
	public override void CalculateCostOfNextLevel() {

	}

	//Is the upgrade available
	public override bool IsUpgradeAvailable() {
		return true;
	}
}