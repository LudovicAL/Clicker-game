using UnityEngine;

public static class CommonTools {

	public static string[] numbersNotations = WordsLists.numbersAbreviations;

	//Updates the current number notation
	public static void UpdateNumbersNotations() {
		if (PersistentData.shortNumbers) {
			numbersNotations = WordsLists.numbersAbreviations;
		} else {
			numbersNotations = WordsLists.numbersNames;
		}
	}

	//Converts a double to its shortened string representation using the user selected notation
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

	//Generates a random planet name
	public static string GeneratePlanetName(){
		int nameId = Random.Range (0, WordsLists.planetNames.Length - 1);
		int adjectiveId = Random.Range (0, WordsLists.planetAdjectives.Length - 1);
		return WordsLists.planetNames [nameId] + " the " + WordsLists.planetAdjectives [adjectiveId];
	}
}