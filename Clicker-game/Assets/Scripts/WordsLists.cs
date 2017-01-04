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

	#region Construction

	public static Construction[] constructionsDefault = new Construction[10] {
		new ConstructionFull ("Shovels", 0, 1, 1.15f, true, 1),
		new ConstructionFull ("Pickaxes", 0, 2, 1.15f, true, 1),
		new ConstructionFull ("Jack Hammers", 0, 3, 1.15f, true, 1),
		new ConstructionEmpty(4),
		new ConstructionEmpty(5),
		new ConstructionEmpty(6),
		new ConstructionEmpty(7),
		new ConstructionEmpty(8),
		new ConstructionEmpty(9),
		new ConstructionEmpty(10)
	};

	public static Construction[] constructionsHuman = new Construction[7] {
		new ConstructionFull ("Metal detectors", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Excavators", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Dump trucks", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Conveyors", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Refineries", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Explosives", 0, 1, 1.15f, false, 1),
		new ConstructionFull ("Tunnel Borers", 0, 1, 1.15f, false, 1),
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

	#region PointerUpgrades

	public static string[] pointerUpgradesNames = new string[] {
		"Pointer base reward",
		"Pointer reward multiplier"
	};

	public static string[] pointerUpgradesDescriptions = new string[] {
		"Doubles each click base reward.",
		"Double the click reward multiplier."
	};

	#endregion

	#region ManaUpgrades

	public static string[] manaUpgradesNames = new string[] {
		"Maximum mana upgrade",
		"Mana regenaration upgrade"
	};

	public static string[] manaUpgradesDescriptions = new string[] {
		"Adds 50 to your maximum mana.",
		"Adds 0.5 to you mana regeneration rate per second."
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

	public static double[,] wealthAchievementsValuesTable = new double[,] {
		{ 0, 5, 30, 100, 200, 1000 },
		{ 0, 10, 50, 500, 5000, 50000 }
	};

	public static string[] timeAchievementsNames = new string[] {
		"Longest playing session",
		"Total time"
	};

	public static string[] timeAchievementsDescriptions = new string[] {
		"Your longest achieved playing session.",
		"Your total time spent playing the game."
	};

	public static double[,] timeAchievementsValuesTable = new double[,] {
		{ 0, 10, 30, 100, 200, 1000 },
		{ 0, 10, 50, 500, 5000, 50000 }
	};

	#endregion
}