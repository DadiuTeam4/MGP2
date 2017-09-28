using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject); 
	}

	void Start () 
	{

		//AkSoundEngine.PostEvent ("Ambience_livingroom", gameObject); 
		//Ambience volume
		//Music
		//SceneManagement
		EventManager.StartListening (EventName.KitchenSceneLoaded, SwitchToKitchen); 
		EventManager.StartListening (EventName.HubSceneLoaded, SwitchToHub); 
	}

	void Update () 
	{
	}
			void SwitchToKitchen()
	{
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 100); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 0);
		AkSoundEngine.PostEvent ("Break_MGP2_SD_Fireplace", gameObject);
		AkSoundEngine.PostEvent ("Break_MGP2_SD_RockingChair", gameObject);

	}

	void SwitchToHub()
	{
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100);
		AkSoundEngine.PostEvent ("Ambience_kitchen", gameObject); 
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Fireplace", gameObject);
		AkSoundEngine.PostEvent ("Play_MGP2_SD_RockingChair", gameObject); 
	}

}
