﻿using UnityEngine;

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
		" Quinquadecillion",
		" Sedecillion",
		" Septendecillion",
		" Octodecillion",
		" Novendecillion",
		" Vigintillion",
		" Unvigintillion",
		" Duovigintillion",
		" Tresvigintillion",
		" Quattuorvigintillion",
		" Quinquavigintillion",
		" Sesvigintillion",
		" Septemvigintillion",
		" Octovigintillion",
		" Novemvigintillion",
		" Trigintillion",
		" Untrigintillion",
		" Duotrigintillion",
		" Trestrigintillion",
		" Quattuortrigintillion",
		" Quinquatrigintillion",
		" Sestrigintillion",
		" Septentrigintillion",
		" Octotrigintillion",
		" Noventrigintillion",
		" Quadragintillion",
		" Quinquagintillion",
		" Sexagintillion",
		" Septuagintillion",
		" Octogintillion",
		" Nonagintillion",
		" Centillion",
		" Uncentillion",
		" Duocentillion",
		" Trescentillion",
		" Decicentillion",
		" Undecicentillion",
		" Viginticentillion",
		" Unviginticentillion",
		" Trigintacentillion",
		" Quadragintacentillion",
		" Quinquagintacentillion",
		" Sexagintacentillion",
		" Septuagintacentillion",
		" Octogintacentillion",
		" Nonagintacentillion",
		" Ducentillion",
		" Trecentillion",
		" Quadringentillion",
		" Quingentillion",
		" Sescentillion",
		" Septingentillion",
		" Octingentillion",
		" Nongentillion",
		" Millinillion"
	};

	public static string[] numbersAbreviations = new string[] {"",
		" K",
		" M",
		" G",
		" T",
		" P",
		" E",
		" Z",
		" Y",
		" Oct",
		" Non",
		" Dec",
		" Udec",
		" Ddec",
		" Tdec",
		" Qdec",
		" Qqdec",
		" Sdec",
		" Stdec",
		" Odec",
		" Ndec",
		" Vig",
		" Uvig",
		" Dvig",
		" Tvig",
		" Qvig",
		" Qqvig",
		" Svig",
		" Stvig",
		" Ovig",
		" Nvig",
		" Trig",
		" Utrig",
		" Dtrig",
		" Ttrig",
		" Qtrig",
		" Qqtrig",
		" Strig",
		" Sttrig",
		" Otrig",
		" Ntrig",
		" Qag",
		" Qqag",
		" Sag",
		" Stag",
		" Oag",
		" Nag",
		" Cent",
		" Ucent",
		" Dcent",
		" Tcent",
		" Dcent",
		" Udecent",
		" Vigcent",
		" Uvigcent",
		" Trigcent",
		" Qagcent",
		" Qqagcent",
		" Sagcent",
		" Stagcent",
		" Oagcent",
		" Nagcent",
		" Dcent",
		" Tcent",
		" Quagen",
		" Quigent",
		" Sgent",
		" Stgent",
		" Ogent",
		" Ngent",
		" Mil"
	};

	#endregion

	#region Construction

	public static string[,] constructionsNames = new string[6, 10] {
		{ "Shovels", "Pickaxes", "Jackhammers", "Metal detectors", "Excavators", "Dump trucks", "Conveyors", "Refineries", "Explosives", "Tunnel borers" },
		{ "Shovels", "Pickaxes", "Jackhammers", "Cave dwellers", "Solar panels", "Air filters", "Incinerators", "Motherships", "Alpha canons", "Cyborgs" },
		{ "Shovels", "Pickaxes", "Jackhammers", "Troglodytes", "Water turbines", "Dust collectors", "Compressors", "Cargo vessels", "Gamma canons", "Space escalators" },
		{ "Shovels", "Pickaxes", "Jackhammers", "Fusion reactors", "", "", "", "Quantic excavators", "Pulse canons", "Tractor beams" },
		{ "Shovels", "Pickaxes", "Jackhammers", "Hydrolic arms", "Laser eyes", "Space conveyors", "Nuclear reactors", "Microwave canons", "Planet schedders", "Artificial intelligence" },
		{ "Shovels", "Pickaxes", "Jackhammers", "Soil obliterators", "Black matter collectors", "Teleporters", "Gravitational controlers", "Physic alterators", "", "" }
	};

	#endregion

	#region Abilities

	public static string[,] paidWorkersAbilitiesNames = new string[6, 3] {
		{ "Enhanced working effort", "Hydrolic excavation", "Additional salary incentives" },
		{ "Enhanced working effort", "", "" },
		{ "Enhanced working effort", "", "" },
		{ "Enhanced working effort", "", "" },
		{ "Enhanced working effort", "Oil refill", "Nuclear prospection" },
		{ "Enhanced working effort", "Apocalypse", "" }
	};

	public static string[,] enslavedWorkersAbilitiesNames = new string[6, 3] {
		{ "Enhanced working effort", "Whipping frenzy", "Night shifts" },
		{ "Enhanced working effort", "", "" },
		{ "Enhanced working effort", "", "" },
		{ "Enhanced working effort", "", "" },
		{ "", "", "" },
		{ "", "", "" }
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

	#region PointerStuff

	public static string[] pointerUpgradesNames = new string[] {
		"Pointer base reward",
		"Pointer reward multiplier"
	};

	public static string[] pointerUpgradesDescriptions = new string[] {
		"Doubles each click base reward.",
		"Double the click reward multiplier."
	};

	#endregion

	#region Achievements

	public static string[] wealthAchievementsNames = new string[] {
		"Money per second",
		"Total wealth"
	};

	public static string[] wealthAchievementsDescriptions = new string[] {
		"Your highest achieved income.",
		"Your highest achieved wealth."
	};

	public static double[,] wealthAchievementsValuesTable = new double[2, 5] {
		{ 5, 30, 100, 200, 1000 },
		{ 10, 50, 500, 5000, 50000 }
	};

	public static string[] timeAchievementsNames = new string[] {
		"Longest playing session",
		"Total time"
	};

	public static string[] timeAchievementsDescriptions = new string[] {
		"Your longest achieved playing session.",
		"Your total time spent playing the game."
	};

	public static double[,] timeAchievementsValuesTable = new double[2, 5] {
		{ 10, 30, 100, 200, 1000 },
		{ 10, 50, 500, 5000, 50000 }
	};

	#endregion
}