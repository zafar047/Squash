using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;

public class ContinueGame : MonoBehaviour
{
	private RewardedAd rewardedAd;
	public UnityEvent OnAdWatched;

	public void Start()
	{
		rewardedAd = new RewardedAd("ca-app-pub-7518368777151763/4692824178");
		rewardedAd.LoadAd(new AdRequest.Builder().Build());
		rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
	}

	public void UserChoseToWatchAd()
	{
		if (rewardedAd.IsLoaded())
			rewardedAd.Show();
	}

	public void HandleUserEarnedReward(object sender, Reward args)
	{
		OnAdWatched.Invoke();
	}
}