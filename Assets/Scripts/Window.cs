using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable {

	private bool isBeingPlayed = false;
	private bool windowsOpen = false; 


	void Start ()
	{
		EventManager.StartListening (EventName.KitchenSceneLoaded, KitchenSwitch); 
	}

	public override void OnTouchBegin()
	{	
		if (isBeingPlayed == false && windowsOpen == false)
		{
			//AkSoundEngine.SetRTPCValue ("HaveVolume", 100); 
			AkSoundEngine.PostEvent ("Play_MGP2_SD_WindowOpen", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Garden", gameObject); 
			isBeingPlayed = true;
			windowsOpen = true; 
		}

		if (isBeingPlayed == false && windowsOpen == true)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_WindowClose", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			AkSoundEngine.PostEvent ("Stop_MGP2_SD_Garden", gameObject); 
			isBeingPlayed = true;
			windowsOpen = false; 
		}
	}
	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}

	void KitchenSwitch()
	{
		AkSoundEngine.PostEvent ("Stop_MGP2_SD_Garden", gameObject); 
	}

}