using UnityEngine;

public static class CommonTools {

	public static string[] numbersNotations = WordsLists.numbersAbreviations;

	//Updates the current number notation
	public static void updateNumbersNotations() {
		if (PersistentData.shortNumbers) {
			numbersNotations = WordsLists.numbersAbreviations;
		} else {
			numbersNotations = WordsLists.numbersNames;
		}
	}

	//Convert a double to its shortened string representation using the user selected notation
	public static string DoubleToString(double d) {
		if (d < 1000) {
			return System.Math.Floor (d).ToString ();
		}
		int magnitude = 0;
		double dPrecedent = d;
		while (d >= 1000) {
			dPrecedent = d;
			d /= 1000;
			magnitude++;
		}
		string str = System.Math.Floor(d).ToString();
		if (d > 10) {
			if (d > 100) {
				//Do nothing
			} else {
				str += ",";
				str += (((int)System.Math.Floor(dPrecedent) / 100) % 10).ToString ();
			}
		} else {
			str += ",";
			str += (((int)System.Math.Floor(dPrecedent) / 10) % 100).ToString ();
		}
		return str + numbersNotations[magnitude];
	}

	 /*
	//WARNING: THIS VERSION OF THE SCRIPT IS REGIONAL DEPENDANT AS IT USE THE LOCAL TOSTRING RULES FOR BUILDING NUMERICS
	public static string DoubleToString(double d) {
		if (d <= 999) {
			return d.ToString("0");
		} else {
			string str = d.ToString ("N0");
			if (str.IndexOf(',') == 3) {
				return str.Substring (0, 3) + numbersNotations[str.Length / 4];
			} else {
				return str.Substring (0, 4) + numbersNotations[str.Length / 4];
			}
		}
	}
	*/

	//Generates a random planet name
	public static string GeneratePlanetName(){
		if (WordsLists.planetNames.Length > 0 && WordsLists.planetAdjectives.Length > 0) {
			int nameId = Random.Range (0, WordsLists.planetNames.Length - 1);
			int adjectiveId = Random.Range (0, WordsLists.planetAdjectives.Length - 1);
			return WordsLists.planetNames [nameId] + " the " + WordsLists.planetAdjectives [adjectiveId];
		} else {
			return "Planet name";
		}
	}
}