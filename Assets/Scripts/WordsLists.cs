﻿using UnityEngine;
using System.Collections.Generic;

public static class WordsLists {

	#region NumberNotation

	public static string[] numbersNames = new string[] {"",
		" Thousand",
		" Million",
		" Billion",
		" Trillion",
		" Quadrillion",
		" Quintillion",
		" Sextillion",
		" Septillion",
		" Octillion",
		" Nonillion",
		" Decillion",
		" Undecillion",
		" Duodecillion",
		" Tredecillion",
		" Quattuordecillion",
		" Quindecillion",
		" Sexdecillion",
		" Septemdecillion",
		" Octodecillion",
		" Novemdecillion",
		" Vigintillion",
		" Unvigintillion",
		" Duovigintillion",
		" Tresvigintillion",
		" Quattuorvigintillion",
		" Quinvigintillion",
		" Sexvigintillion",
		" Septemvigintillion",
		" Octovigintillion",
		" Novemvigintillion",
		" Trigintillion",
		" Untrigintillion",
		" Duotrigintillion",
		" Trestrigintillion",
		" Quattuortrigintillion",
		" Quintrigintillion",
		" Sextrigintillion",
		" Septemtrigintillion",
		" Octotrigintillion",
		" Novemtrigintillion",
		" Quadragintillion",
		" Unquadragintillion",
		" Duoquadragintillion",
		" Tresquadragintillion",
		" Quattuorquadragintillion",
		" Quinquadragintillion",
		" Sexquadragintillion",
		" Septemquadragintillion",
		" Octoquadragintillion",
		" Novemquadragintillion",
		" Centillion",
		" Uncentillion",
		" Duocentillion",
		" Trescentillion",
		" Quattuorcentillion",
		" Quincentillion",
		" Sexcentillion",
		" Septemcentillion",
		" Octocentillion",
		" Novemcentillion",
		" Decicentillion",
		" Undecicentillion",
		" Duodecicentillion",
		" Tresdecicentillion",
		" Quattuordecicentillion",
		" Quindecicentillion",
		" Sexdecicentillion",
		" Septemdecicentillion",
		" Octodecicentillion",
		" Novemdecicentillion",
		" Viginticentillion",
		" Unviginticentillion",
		" Duoviginticentillion",
		" Tresviginticentillion",
		" Quattuorviginticentillion",
		" Quinviginticentillion",
		" Sexviginticentillion",
		" Septemviginticentillion",
		" Octviginticentillion",
		" Novemviginticentillion",
		" Trigintacentillion",
		" Untrigintacentillion",
		" Duotrigintacentillion",
		" Trestrigintacentillion",
		" Quattuortrigintacentillion",
		" Quintrigintacentillion",
		" Sextrigintacentillion",
		" Septemtrigintacentillion",
		" Octotrigintacentillion",
		" Novemtrigintacentillion",
		" Quadragintacentillion",
		" Unquadragintacentillion",
		" Duoquadragintacentillion",
		" Tresquadragintacentillion",
		" Quattuorquadragintacentillion",
		" Quinquadragintacentillion",
		" Sexquadragintacentillion",
		" Septemquadragintacentillion",
		" Octoquadragintacentillion",
		" Novemquadragintacentillion",
		" Quinquagintacentillion",
		" Unquinquagintacentillion",
		" Duoquinquagintacentillion",
		" Tresquinquagintacentillion",
		" Quattuorquinquagintacentillion",
		" Quinquinquagintacentillion",
		" Sexquinquagintacentillion",
		" Septemquinquagintacentillion",
		" Octoquinquagintacentillion",
		" Novemquinquagintacentillion",
		" Sexagintacentillion",
		" Unsexagintacentillion",
		" Duosexagintacentillion",
		" Tressexagintacentillion",
		" Quattuorsexagintacentillion",
		" Quinsexagintacentillion",
		" Sexsexagintacentillion",
		" Septemsexagintacentillion",
		" Octosexagintacentillion",
		" Novemsexagintacentillion",
		" Septuagintacentillion",
		" Unseptuagintacentillion",
		" Duoseptuagintacentillion",
		" Tresseptuagintacentillion",
		" Quattuorseptuagintacentillion",
		" Quinseptuagintacentillion",
		" Sexseptuagintacentillion",
		" Septemseptuagintacentillion",
		" Octoseptuagintacentillion",
		" Novemseptuagintacentillion",
		" Octogintacentillion",
		" Unoctogintacentillion",
		" Duooctogintacentillion",
		" Tresoctogintacentillion",
		" Quattuoroctogintacentillion",
		" Quinoctogintacentillion",
		" Sexoctogintacentillion",
		" Septemoctogintacentillion",
		" Octoctogintacentillion",
		" Novemoctogintacentillion",
		" Nonagintacentillion",
		" Unnonagintacentillion",
		" Duononagintacentillion",
		" Tresnonagintacentillion",
		" Quattuornonagintacentillion",
		" Quinnonagintacentillion",
		" Sexnonagintacentillion",
		" Septemnonagintacentillion",
		" Octononagintacentillion",
		" Novemnonagintacentillion",
		" Gentillion",
		" Ungentillion",
		" Duogentillion",
		" Tregentillion",
		" Quadringentillion",
		" Quingentillion",
		" Sexgentillion",
		" Septemgentillion",
		" Octogentillion",
		" Novemgentillion",
		" Millinillion"
	};

	public static string[] numbersAbreviations = new string[] {"",
		"K",
		"M",
		"G",
		"T",
		"P",
		"E",
		"Z",
		"Y",
		"Oct",
		"Non",
		"Dec",
		"Udec",
		"Ddec",
		"Tdec",
		"Qdec",
		"Qqdec",
		"Sdec",
		"Stdec",
		"Odec",
		"Ndec",
		"Vig",
		"Uvig",
		"Dvig",
		"Tvig",
		"Qvig",
		"Qqvig",
		"Svig",
		"Stvig",
		"Ovig",
		"Nvig",
		"Trig",
		"Utrig",
		"Dtrig",
		"Ttrig",
		"Qtrig",
		"Qqtrig",
		"Strig",
		"Sttrig",
		"Otrig",
		"Ntrig",
		"Qag",
		"Uqag",
		"Dqag",
		"Tqag",
		"Qqag",
		"Qqqag",
		"Sqag",
		"Stqag",
		"Oqag",
		"Nqag",
		"Cent",
		"Ucent",
		"Dcent",
		"Tcent",
		"Qcent",
		"Qqcent",
		"Scent",
		"Stcent",
		"Ocent",
		"Ncent",
		"Dcent",
		"Udcent",
		"Ddcent",
		"Tdcent",
		"Qdcent",
		"Qqdcent",
		"Sdcent",
		"Stdcent",
		"Odcent",
		"Ndcent",
		"Vcent",
		"Uvcent",
		"Dvcent",
		"Tvcent",
		"Qvcent",
		"Qqvcent",
		"Svcent",
		"Stvcent",
		"Ovcent",
		"Nvcent",
		"Tcent",
		"Utcent",
		"Dtcent",
		"Ttcent",
		"Qtcent",
		"Qqtcent",
		"Stcent",
		"Sttcent",
		"Otcent",
		"Ntcent",
		"Qcent",
		"Uqcent",
		"Dqcent",
		"Tqcent",
		"Qqcent",
		"Qqqcent",
		"Sqcent",
		"Stqcent",
		"Oqcent",
		"Nqcent",
		"Qqcent",
		"Uqqcent",
		"Dqqcent",
		"Tqqcent",
		"Qqqcent",
		"Qqqqcent",
		"Sqqcent",
		"Stqqcent",
		"Oqqcent",
		"Nqqcent",
		"Scent",
		"Uscent",
		"Dscent",
		"Tscent",
		"Qcent",
		"Qqscent",
		"Sscent",
		"Stscent",
		"Oscent",
		"Nscent",
		"Stcent",
		"Ustcent",
		"Dstcent",
		"Tstcent",
		"Qstcent",
		"Qqstcent",
		"Sstcent",
		"Ststcent",
		"Ostcent",
		"Nstcent",
		"Ocent",
		"Uocent",
		"Docent",
		"Tocent",
		"Qocent",
		"Qqocent",
		"Socent",
		"Stocent",
		"Oocent",
		"Nocent",
		"Ncent",
		"Uncent",
		"Dncent",
		"Tncent",
		"Qncent",
		"Qqncent",
		"Sncent",
		"Stncent",
		"Oncent",
		"Nncent",
		"Gen",
		"Ugen",
		"Dgen",
		"Tgen",
		"Qgen",
		"Qqgen",
		"Sgen",
		"Stgen",
		"Ogen",
		"Ngen",
		"Mil"
	};

	#endregion

	#region Races

	public static List<URace> listOfRacesUpgrades = new List<URace> {
		new URace (
	        "No race",
	        "No description",
			new List<Construction> {
				new Construction ("Shovels", 1, 1.15f),
				new Construction ("Pickaxes", 2, 1.15f),
				new Construction ("Jack Hammers", 3, 1.15f)
			},
			new List<Upgrade> {
				new UConstruction("Shovels", "Doubles your shovels productivity.", 1, 2),
				new UConstruction("Pickaxes", "Doubles your pickaxes productivity.", 2, 2),
				new UConstruction("Jack Hammers", "Doubles your jack hammers productivity.", 3, 2)
			},
			new List<Ability>()  {
				new DefaultAbility("Enhanced working effort", "Provide your workers with incentives to produce more.", 10.0f),
			},
			0,
			0
	    ),
		new URace (
	        "Humans",
	        "Beings like you and me.",
			new List<Construction> {
				new Construction ("Metal Detectors", 4, 1.15f),
				new Construction ("Excavators", 5, 1.15f),
				new Construction ("Dump Trucks", 6, 1.15f),
				new Construction ("Conveyor Belts", 7, 1.15f),
				new Construction ("Refineries", 8, 1.15f),
				new Construction ("Explosives", 9, 1.15f),
				new Construction ("Tunnel Borers", 10, 1.15f)
			},
			new List<Upgrade> {
				new UConstruction("Metal Detectors", "Doubles your metal detectors productivity.", 4, 25),
				new UConstruction("Excavators", "Doubles your excavators productivity.", 5, 25),
				new UConstruction("Dump Trucks", "Doubles your dump trucks productivity.", 6, 25),
				new UConstruction("Conveyor Belts", "Doubles your conveyors productivity.", 7, 25),
				new UConstruction("Refineries", "Doubles your refineries productivity.", 8, 25),
				new UConstruction("Explosives", "Doubles your explosives productivity.", 9, 25),
				new UConstruction("Tunnel Borers", "Doubles your tunnel borers productivity.", 10, 25),
			},
			new List<Ability>() {
				//Insert abilities here
			},
			50,
			0
	    ),
		new URace (
			"Martians",
			"Traders from planet Mars.",
			new List<Construction> {
				new Construction ("Cave Dwellers", 4, 1.15f),
				new Construction ("Solar Panels", 5, 1.15f),
				new Construction ("Air Filters", 6, 1.15f),
				new Construction ("Incinerators", 7, 1.15f),
				new Construction ("Motherships", 8, 1.15f),
				new Construction ("Alpha Canons", 9, 1.15f),
				new Construction ("Cyborgs", 10, 1.15f)
			},
			new List<Upgrade> {

			},
			new List<Ability>() {
				//Insert abilities here
			},
			100,
			0
		),
		new URace (
			"Venusians",
			"Contractors from planet Venus.",
			new List<Construction> {
				new Construction ("Troglodytes", 4, 1.15f),
				new Construction ("Water Turbines", 5, 1.15f),
				new Construction ("Dust Collectors", 6, 1.15f),
				new Construction ("Compressors", 7, 1.15f),
				new Construction ("Cargo Vessels", 8, 1.15f),
				new Construction ("Gamma Canons", 9, 1.15f),
				new Construction ("Space Elevators", 10, 1.15f)
			},
			new List<Upgrade> {

			},
			new List<Ability>() {
				//Insert abilities here
			},
			100,
			0
		),
		new URace (
			"Outer Space Civilization",
			"Entrepreneurs from outer space.",
			new List<Construction> {
				new Construction ("Empty", 4, 1.15f),
				new Construction ("Fusion Reactors", 5, 1.15f),
				new Construction ("Empty", 6, 1.15f),
				new Construction ("Empty", 7, 1.15f),
				new Construction ("Quantic Excavators", 8, 1.15f),
				new Construction ("Pulse Canons", 9, 1.15f),
				new Construction ("Tractor Beams", 10, 1.15f)
			},
			new List<Upgrade> {

			},
			new List<Ability>() {
				//Insert abilities here
			},
			200,
			0
		),
		new URace (
			"Robots",
			"Unremitting robots working around the clock.",
			new List<Construction> {
				new Construction ("Hydrolic Arms", 4, 1.15f),
				new Construction ("Laser Eyes", 5, 1.15f),
				new Construction ("Space Conveyors", 6, 1.15f),
				new Construction ("Nuclear Reactors", 7, 1.15f),
				new Construction ("Microwaves Canons", 8, 1.15f),
				new Construction ("Planet Shredders", 9, 1.15f),
				new Construction ("Artificial Intelligences", 10, 1.15f)
			},
			new List<Upgrade> {

			},
			new List<Ability>() {
				//Insert abilities here
			},
			300,
			0
		),
		new URace (
			"Etheral Beings",
			"Intagible beings with underfined objectives.",
			new List<Construction> {
				new Construction ("Soil Obliterators", 4, 1.15f),
				new Construction ("Black Matter Collectors", 5, 1.15f),
				new Construction ("Teleporters", 6, 1.15f),
				new Construction ("Gravitational Controlers", 7, 1.15f),
				new Construction ("Physic Alterators", 8, 1.15f),
				new Construction ("Empty", 9, 1.15f),
				new Construction ("Empty", 10, 1.15f)
			},
			new List<Upgrade> {

			},
			new List<Ability>() {
				//Insert abilities here
			},
			400,
			0
		)
	};

	#endregion

	#region Upgrades

	public static string[] upgradesAdjectives = new string[] {
		"Flashy ",
		"Big ",
		"Armored ",
		"Bronze plated ",
		"Ruby coated ",
		"Titanium covered ",
		"Indestructible ",
		"Submersible ",
		"Redesigned ",
		"Easy to use ",
		"Quiet ",
		"Ostentatious ",
		"Impressive ",
		"Reinforced ",
		"Platinium plated ",
		"Emerald coated ",
		"Stainless steel covered ",
		"Resistant ",
		"Brand new ",
		"Flamboyant ",
		"Massive ",
		"Strengthened ",
		"Silver plated ",
		"Strong ",
		"Restored ",
		"Immense ",
		"Durable ",
		"Gold plated ",
		"Mighty ",
		"Modern ",
		"Giant ",
		"Fortified ",
		"Potent ",
		"New-fashioned ",
		"Huge ",
		"Robust ",
		"Renovated ",
		"Gigantic ",
		"Powerful ",
		"Washed ",
		"Sturdy ",
		"Cleaned ",
		"Enormous "
	};

	public static Color[] upgradesColors = new Color[] {
		new Color(0.0F, 0.0F, 0.0F, 1.0F),
		new Color(0.2F, 1.0F, 0.4F, 1.0F),
		new Color(0.2F, 0.3F, 1.0F, 1.0F),
		new Color(0.2F, 0.3F, 0.4F, 1.0F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F),
		new Color(0.2F, 0.3F, 0.4F, 0.5F)
	};

	#endregion

	#region Planet

	public static string[] planetNames = new string[] {
		"Pluto",
		"Atlantis",
		"Aloria",
		"Andor",
		"Attilan",
		"Blefuscu",
		"Brobdingnag",
		"Laputa",
		"Lilliput",
		"Cardassia Prime",
		"Bajor",
		"Ferenginar",
		"Gallifrey",
		"Genosha",
		"Latveria",
		"Luggnagg",
		"Narnia",
		"Oz",
		"Qo'noS",
		"Remus",
		"Rohan",
		"Romulus",
		"Skaro",
		"Sontar",
		"Utopia",
		"Wakanda",
		"Vulcan"
	};

	public static string[] planetAdjectives = new string[] {
		"Beautiful",
		"Ancient",
		"Contemporary",
		"Unexplored",
		"Unknown",
		"Cosmopolitan",
		"Crowded",
		"Exciting",
		"Famous",
		"Fantastic",
		"Fascinating",
		"Huge",
		"Lively",
		"Picturesque",
		"Touristy"
	};

	#endregion

	#region PointerUpgrades

	public static List<Upgrade> listOfPointerUpgrades = new List<Upgrade>  {
		new UPointerBase ("Pointer Base Reward", "Doubles each click base reward."),
		new UPointerMultiplier ("Pointer Reward Multiplier", "Double the click reward multiplier.")
	};

	#endregion

	#region ManaUpgrades

	public static List<Upgrade> listOfManaUpgrades = new List<Upgrade>  {
		new UMaxMana ("Maximum Mana", "Adds 50 to your maximum mana."),
		new UManaRegen ("Mana Regeneration", "Adds 0.5 to you mana regeneration rate per second.")
	};

	#endregion

	#region InvestorsUpgrades

	public static List<Upgrade> listOfInvestorsUpgrades = new List<Upgrade>  {
		new UBonusPerInvestorUpgrade ("Bonus Per Investor", "Adds 1% to your bonus per investor."),
	};

	#endregion

	#region Achievements

	public static List<Achievement> listOfWealthAchievements = new List<Achievement>  {
		new AMoneyPerSecond("Money per second", "Your highest achieved income.", true, new double[] { 0, 10, 30, 100, 200, 1000 }),
		new ATotalMoney("Total wealth", "Your highest achieved wealth.", true, new double[] { 0, 5, 10, 15, 20, 25 })
	};

	public static List<Achievement> listOfTimeAchievements = new List<Achievement>  {
		new ALongestSession("Longest playing session", "Your longest achieved playing session.", true, new double[] { 0, 15, 30, 100, 200, 1000 }),
		new ATotalTime("Total time", "Your total time spent playing the game.", true, new double[] { 0, 25, 50, 500, 5000, 50000 })
	};

	public static List<Achievement> listOfConstructionsAchievements = new List<Achievement>  {
		new AConstructionsNumber("Number of constructions", "How many constructions you've built.", true, new double [] { 5, 10, 15 })
	};

	public static List<Achievement> listOfUpgradesAchievements = new List<Achievement>  {
		new AUpgradesNumber("Number of upgrades", "How many upgrades you've bought.", true, new double [] { 5, 10, 15 })
	};

	#endregion
}