using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdMobInit : MonoBehaviour
{
	public void Start()
	{
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(initStatus => { });

		SceneManager.LoadScene("MainMenu");
	}
}