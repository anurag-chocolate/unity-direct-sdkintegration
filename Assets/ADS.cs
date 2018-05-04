using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vdopia;

public class ADS : MonoBehaviour {

	// Use this for initialization
	VdopiaPlugin plugin;
	void Start () {

		if (Application.platform == RuntimePlatform.Android)
		{
			plugin = VdopiaPlugin.GetInstance();       //Initialize Plugin Instance

			if (plugin != null)
			{
				Debug.Log("Vdopia Plugin Initialized.");
				//Set Delegate Receiver For Vdopia SDK Ad Event (Not compulsory)
				VdopiaListener.GetInstance().VdopiaAdDelegateEventHandler += onVdopiaEventReceiver;

				//plugin.SetAdRequestUserData("23", "23/11/1990", "m", "single", "Asian", "999", "123123", "321321", “”, “”);

				plugin.SetAdRequestAppData("UnityDemo", "Chocolate", "unity-demo.com", "chocolateplatform.com", "", "IAB9");

				plugin.PrefetchInterstitialAd("EnP5f4");

			}
			else
			{
				Debug.Log("Vdopia Plugin Initialize Error.");
			}

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onVdopiaEventReceiver(string adType, string eventName)     //Ad Event Receiver
	{
		Debug.Log("Ad Event Received : " + eventName + " : For Ad Type : " + adType);

		if (adType.Equals(VdopiaPlugin.INTERSTITIAL_AD_TYPE))
		{
			if (eventName.Equals(VdopiaPlugin.INTERSTITIAL_AD_LOADED))
			{
				Debug.Log("INTERSTITIAL_AD_LOADED...");
			}

			if (eventName.Equals(VdopiaPlugin.INTERSTITIAL_AD_FAILED))
			{
				Debug.Log("INTERSTITIAL_AD_FAILED...");
			}

			if (eventName.Equals(VdopiaPlugin.INTERSTITIAL_AD_SHOWN))
			{
				Debug.Log("INTERSTITIAL_AD_SHOWN...");
				plugin.PrefetchInterstitialAd("EnP5f4");
			}

			if (eventName.Equals(VdopiaPlugin.INTERSTITIAL_AD_CLICKED))
			{
				Debug.Log("INTERSTITIAL_AD_CLICKED...");
			}

			if (eventName.Equals(VdopiaPlugin.INTERSTITIAL_AD_DISMISSED))
			{
				Debug.Log("INTERSTITIAL_AD_DISMISSED...");
			}

		}
	}


	public void loadInterstitial()     //called when btnLoadInterstitial Clicked
	{
		Debug.Log("Load Interstitial...");
		if (Application.platform == RuntimePlatform.Android && plugin != null)
		{
			//Param 1: AdUnit Id (This is your SSP App ID you received from your account manager or obtained from the portal)
			plugin.LoadInterstitialAd("EnP5f4");
		}
	}

	public void showInterstitial()     //called when btnShowInterstitial Clicked
	{
		Debug.Log("Show Interstitial...");
		if (Application.platform == RuntimePlatform.Android && plugin != null)
		{
			//Make sure Interstitial Ad is loaded before call this method
			plugin.ShowInterstitialAd();

			//New!  Optional.  Silently pre-fetch the next interstitial ad without making
			//any callbacks.  The pre-fetched ad will remain in cache until you call
			//the next LoadInterstitialAd.

		}
	}
}
