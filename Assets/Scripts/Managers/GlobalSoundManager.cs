using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {
	private bool isBeingPlayed = false;
	public bool hugoIsTalking = false; 
	private bool hasBeenIntroduced = false; 
	private bool hasBeenRestarted; 
	private bool grandmaHasCalled = false; 
	private bool grandmaIsResponding = false; 
	private bool areInKitchen = false; 
	private float timeLeft = 10f;
	private float curElapsedTime = 0f; 
	private float duration = 10f; 
	private float rockingChairFadeValue = 100f; 

	void Start () 
	{
		//Ambience
		AkSoundEngine.PostEvent ("Ambience_livingroom", gameObject);
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 0);

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
			StartCoroutine (IntroSpeak ()); 
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

	public void FortaelleBedstemor()
	{
		hugoIsTalking = true;
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_FortaelleBedstemor", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
		isBeingPlayed = true;
	}

	void GarnNoegleSpeak()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_1234Garnnoegler", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}

	void GarnNoegleTaelle()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_FemGarnnoegler", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
		if (grandmaIsResponding == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_SpaendeHistorie", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
		}

	void Hjemmesko ()
	{
		if (isBeingPlayed == false)
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_TreHjemmesko", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
		if (grandmaIsResponding == false) {
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
	}

	void HjemmeskoTaelle()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_EnToTreHjemmesko", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}

	void CookieJar()
	{
		if (isBeingPlayed == false)
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_SeksSmaakagerKrukken", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
	}
		if (grandmaIsResponding) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
	}

	void CookieJarTaelle()
	{
		if (isBeingPlayed == false)
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Cookie", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_Smaakager",gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
			hugoIsTalking = true;
		}
	}

	void Spoegelse()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_SpoegelseiKokkenet", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
		if (grandmaIsResponding) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
	}

	void SpoegelseTaelle()
	{
		if (isBeingPlayed == false) 
		{	
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtSpoegelse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}

	void Badeaender()
	{
		if (isBeingPlayed == false) 
		{	
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_FireBadeaender", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
		if (grandmaIsResponding)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
	}

	void BadeaenderTaelle()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true;
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_Bade_nder", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}

	void EtBarnToBarn()
	{
		{
			hugoIsTalking = true;
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtBarnToBoern", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
		if (grandmaIsResponding) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_BedstemorResponse", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			grandmaIsResponding = true; 
		}
	}

	void EtBarnToBarnTaelle()
	{
		if (isBeingPlayed == false)
		{
			hugoIsTalking = true;
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_EtBarnToBarn", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}

	public void HugoTryk()
	{
		if (isBeingPlayed == false) 
		{
			hugoIsTalking = true; 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_HugoTryk", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
			isBeingPlayed = true; 
		}
	}


	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
			hugoIsTalking = false; 
			if (grandmaIsResponding == true) 
			{
				grandmaIsResponding = false; 
			}
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

	IEnumerator IntroSpeak()
	{
		{
			isBeingPlayed = true; 
			hasBeenIntroduced = true; 
			hugoIsTalking = true;

			AkSoundEngine.PostEvent ("Play_MGP2_Speak_ErDuOksaa", gameObject); 
			yield return new WaitForSeconds (3.9f);
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_47Edderkopper", gameObject); 
			yield return new WaitForSeconds (4f); 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_Frikadeller", gameObject); 
			yield return new WaitForSeconds (2.9f); 
			AkSoundEngine.PostEvent ("Play_MGP2_Speak_Stokdoev", gameObject); 
		}
		yield return null; 
		isBeingPlayed = false;
		hugoIsTalking = false;

	}


}


