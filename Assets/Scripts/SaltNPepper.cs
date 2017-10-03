using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltNPepper : Interactable {
	private bool isBeingPlayed = false; 


	public override void OnTouchBegin()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Herbs", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
		isBeingPlayed = true; 
	}

	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}
}
