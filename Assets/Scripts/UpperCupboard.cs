using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperCupboard : Interactable {

	private bool isBeingPlayed = false;
	private bool cupboardOpen = false; 

	public override void OnTouchBegin(Vector2 position)
	{	
		if (isBeingPlayed == false && cupboardOpen == false)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Cabinet_Open", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			cupboardOpen = true; 
		}

		if (isBeingPlayed == false && cupboardOpen == true)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Cabinet_Close", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			cupboardOpen = false; 
		}
	}
	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}
}