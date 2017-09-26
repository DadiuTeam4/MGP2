using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Ambience
		AkSoundEngine.PostEvent ("Ambience_kitchen", gameObject); 
		AkSoundEngine.PostEvent ("Ambience_livingroom", gameObject); 
		//Ambience volume
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100);
		//Music
		AkSoundEngine.PostEvent ("Music", gameObject); 
		EventManager.StartListening (EventName.KitchenSceneLoaded, SwitchToKitchen); 
		EventManager.StartListening (EventName.KitchenDoorClicked, KitchenDoorOpen);   


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			AkSoundEngine.SetRTPCValue ("Deaf_parameter", 0); 
		} 
		else 
		{
			AkSoundEngine.SetRTPCValue ("Deaf_parameter", 100); 
		}
	}
			void SwitchToKitchen()
	{
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 100); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 0);
	}

	void KitchenDoorOpen()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DoorUnlock", gameObject); 
		print ("DOORSOUND"); 
	}

			
		
}
