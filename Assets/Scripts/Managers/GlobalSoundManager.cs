using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {
	private bool isBeingPlayed = false;
	private bool hasBeenIntroduced = false; 
	private bool hasBeenRestarted; 
	private bool grandmaHasCalled = false; 
	private bool areInKitchen = false; 
	private float timeLeft = 10f;
	private float curElapsedTime = 0f; 
	private float duration = 10f; 
	private float rockingChairFadeValue = 100f; 

	void Start () 
	{
		//SceneManagement
		EventManager.StartListening (EventName.KitchenSceneLoaded, SwitchToKitchen); 
		EventManager.StartListening (EventName.HubSceneLoaded, SwitchToHub); 
	
		//SPEAK-MANAGEMENT:
		//Garnnøgle
		EventManager.StartListening (EventName.NumberFiveClicked, GarnNoegleTaelle); 
		EventManager.StartListening (EventName.NumberFivePickedUp, GarnNoegleSpeak);
		//Hjemmesko
		EventManager.StartListening (EventName.NumberThreeClicked, Hjemmesko); 
		EventManager.StartListening (EventName.NumberThreePickedUp, HjemmeskoTaelle); 
		//Kagekrukke
		EventManager.StartListening (EventName.NumberSixClicked, CookieJar); 
		EventManager.StartListening (EventName.NumberSixPickedUp, CookieJarTaelle); 
		//Badeaender
		EventManager.StartListening (EventName.NumberFourClicked, Badeaender); 
		EventManager.StartListening (EventName.NumberFourPickedUp, BadeaenderTaelle); 
		//Spoegelse
		EventManager.StartListening (EventName.NumberOneClicked, Spoegelse); 
		EventManager.StartListening (EventName.NumberOnePickedUp, SpoegelseTaelle); 
		//Barn
		EventManager.StartListening (EventName.NumberTwoClicked, EtBarnToBarn); 
		EventManager.StartListening (EventName.NumberTwoPickedUp, EtBarnToBarnTaelle); 
		//Musik
		AkSoundEngine.PostEvent ("Play_MGP2_Music_throwout2piano_P__dirty", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Music_throwout2piano_P_", gameObject); 
		AkSoundEngine.SetRTPCValue ("Vinyl_dirty", 0); 
	}
	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("RockingChair", rockingChairFadeValue);  
	}

		
	void SwitchToKitchen()
	{
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 100); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 0);
		AkSoundEngine.PostEvent ("Break_MGP2_SD_Fireplace", gameObject);
		AkSoundEngine.PostEvent ("Break_MGP2_SD_RockingChair", gameObject);
		AkSoundEngine.SetRTPCValue ("Vinyl_kitchen", 100); 
		StartCoroutine (GrandmaCallTimer ()); 
		areInKitchen = true; 
	}

	void SwitchToHub()
	{
		StartCoroutine (RockingChairFade ()); 
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100);
		AkSoundEngine.PostEvent ("Ambience_kitchen", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_SD_RockingChair", gameObject); 
		AkSoundEngine.SetRTPCValue ("Vinyl_dirty", 100); 
		AkSoundEngine.SetRTPCValue ("Vinyl_kitchen", 0);  
		areInKitchen = false; 
		if (hasBeenIntroduced == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_ErDuOksaa", gameObject); 
			hasBeenIntroduced = true; 
		}
		if (hasBeenRestarted == true) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Music_throwout2piano_P__dirty", gameObject); 
			hasBeenRestarted = false; 
		}
	}

	public void OnClickSound()
	{
		AkSoundEngine.PostEvent ("OnScreenClick", gameObject); 
	}

	public void RestartMusicHub()
	{
			hasBeenRestarted = true; 
	}

	void GarnNoegleSpeak()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_1234Garnnoegler", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
		isBeingPlayed = true; 
	}

	void GarnNoegleTaelle()
	{
		if (isBeingPlayed == false)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_FemGarnnoegler", gameObject); 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_SpaendeHistorie", gameObject); 
		}
	}

	void Hjemmesko()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_TreHjemmesko", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject); 
	}

	void HjemmeskoTaelle()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_EnToTreHjemmesko", gameObject); 
	}

	void CookieJar()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_SeksSmaakagerKrukken", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject); 
	}

	void CookieJarTaelle()
	{
		AkSoundEngine.PostEvent("Play_MGP2_SD_Cookie", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_Smaakager", gameObject); 
	}

	void Spoegelse()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_SpoegelseiKokkenet", gameObject);
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject); 
	}

	void SpoegelseTaelle()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtSpoegelse", gameObject); 
	}

	void Badeaender()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_FireBadeaender", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject); 
	}

	void BadeaenderTaelle()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_Bade_nder", gameObject); 
	}

	void EtBarnToBarn()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtBarnToBoern", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject); 
	}

	void EtBarnToBarnTaelle()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtBarnToBarn", gameObject); 
	}

	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}

	IEnumerator GrandmaCallTimer()
	{
		timeLeft = 10f; 
		while (timeLeft > 0) 
		{
			curElapsedTime = 1f * Time.deltaTime; 
			timeLeft -= curElapsedTime;
			yield return null; 
		}
		if (timeLeft <0f && areInKitchen == true && grandmaHasCalled == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_Hugooo", gameObject);
			grandmaHasCalled = true; 
		}
	}

	IEnumerator RockingChairFade()
	{
		duration = 3f * Time.deltaTime; 
				while (rockingChairFadeValue > 30f) {
					rockingChairFadeValue -= duration; 
			yield return null; 
		}
	}
}
