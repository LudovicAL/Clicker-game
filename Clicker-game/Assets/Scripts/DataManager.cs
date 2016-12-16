﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {

	public int constructionUpgradesInterval;
	public float pointerUpgradesCostModifier;

	// Use this for initialization
	void Start () {
		this.GetComponent<CanvasManager> ().OnLoadButtonClic ();
		InvokeRepeating("TimedUpdate", 1.0f, 1.0f);
		if (PersistentData.planetName.Length == 0) {
			this.GetComponent<MainPanel> ().RandomizePlanet ();
		}
		this.GetComponent<MainPanel> ().UpdatePlanet ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TimedUpdate() {
		PersistentData.currentMoney += PersistentData.totalFarmingReward;
	}

	public void AddClick() {
		PersistentData.currentNumberOfClicks += 1;
		PersistentData.totalNumberOfClicks += 1;
		PersistentData.currentMoney += PersistentData.totalClickingReward;
	}

	public void AddClicks(int numberOfClicks) {
		PersistentData.currentNumberOfClicks += numberOfClicks;
		PersistentData.totalNumberOfClicks += numberOfClicks;
		PersistentData.currentMoney += (PersistentData.totalClickingReward * numberOfClicks);
	}

	//Returns true if the player can afford the construction
	public bool CanAffordConstruction(Construction c) {
		if (c.Cost == 0) {
			return false;
		} else {
			return (PersistentData.currentMoney >= c.Cost);
		}
	}

	//Returns true if the construction upgrade is available
	public bool IsUpgradeAvailable(Construction c) {
		return (c.Quantity >= ((c.UpgradeLevel + 1) * constructionUpgradesInterval));
	}

	//Returns true if the player can afford the construction upgrade
	public bool CanAffordConstructionUpgrade(Construction c) {
		return (PersistentData.currentMoney >= c.NextUpgradeCost);
	}

	//Buys a construction
	public void BuyConstruction(Construction c) {
		if (CanAffordConstruction(c)) {
			PersistentData.currentMoney -= c.Cost;
			c.AddNConstructions(c.NumberOfConstructionsToBuild);
			//Not all calculations are performed here, but rather only those that effect every button due to the change
			CalculateTotalFarmingReward ();
			CalculateCurrentTotalNumberOfConstruction ();
			foreach (Construction cons in PersistentData.listOfConstructions) {
				cons.CalculateContribution ();
				cons.UpdateButtonDisplayedContribution ();
				cons.UpdateButtonDisplayedCost ();
			}
		}
	}

	//Buys an upgrade
	public void BuyConstructionUpgrade(Construction c) {
		if (CanAffordConstructionUpgrade(c)) {
			PersistentData.currentMoney -= c.NextUpgradeCost;
			c.AddNUpgrades(1);
			//Not all calculations are performed here, but rather only those that effect every button due to the change
			CalculateTotalFarmingReward ();
			foreach (Construction cons in PersistentData.listOfConstructions) {
				cons.CalculateContribution ();
				cons.UpdateButtonDisplayedContribution ();
				cons.UpdateButtonDisplayedCost ();
			}
		}
	}

	public void CalculateTotalFarmingReward() {
		PersistentData.farmingRewardFromConstructions = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			PersistentData.farmingRewardFromConstructions += c.Production; 
		}
		PersistentData.totalFarmingReward = PersistentData.farmingRewardFromConstructions;
	}

	//Return the reward the player is entitled to after
	public int CalculateRewardAfterAbsence() {
		return (int)(PersistentData.timeSinceLastSave.TotalSeconds * PersistentData.totalFarmingReward);
	}

	//Calculates the current total number of construction
	public void CalculateCurrentTotalNumberOfConstruction() {
		int total = 0;
		foreach (Construction c in PersistentData.listOfConstructions) {
			total += c.Quantity;
		}
		PersistentData.currentTotalNumberOfConstruction = total;
		if (PersistentData.highestTotalNumberOfConstructionAchieved < PersistentData.currentTotalNumberOfConstruction) {
			PersistentData.highestTotalNumberOfConstructionAchieved = PersistentData.currentTotalNumberOfConstruction;
		}
	}

	//Calculates the total clicking reward (and the base clicking reward and clicking multiplier in the process)
	public void CalculateTotalClickingReward() {
		PersistentData.baseClickingReward = Mathf.Exp(PersistentData.baseClickingRewardUpgradeLevel);
		PersistentData.clickingMultiplier = (PersistentData.clickingMultiplierUpgradeLevel + 1);
		PersistentData.totalClickingReward = PersistentData.baseClickingReward * PersistentData.clickingMultiplier;
	}
}
