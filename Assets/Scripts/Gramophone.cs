using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : Interactable {

	// Use this for initialization

	private bool isBeingPlayed = false;

	//public uint Play_MGP2_SD_VinylID; 

	public override void OnTouchBegin()
	{	
		if (isBeingPlayed == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Vinyl", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
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

	