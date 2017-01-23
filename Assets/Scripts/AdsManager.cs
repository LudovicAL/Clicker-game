using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	const string adName = "rewardedVideo";

	//Returns whether the advertisement system is initialized successfully.
	public bool IsInitialized() {
		return Advertisement.isInitialized;
	}

	//Returns if the current platform is supported by the advertisement system.
	public bool IsSupported() {
		return Advertisement.isSupported;
	}

	//Returns whether an advertisement is ready to be shown. Zones are configured per game in the UnityAds admin site, where you can also set your default zone.
	public bool IsReady() {
		return Advertisement.IsReady(adName);
	}

	//Returns whether an advertisement is currently being shown.
	public bool IsShowing() {
		return Advertisement.isShowing;
	}

	//Show an ad
	public void ShowRewardedAd() {
		if (Advertisement.IsReady(adName)) {
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show(adName, options);
		}
	}

	private void HandleShowResult(ShowResult result) {
		switch (result) {
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
}