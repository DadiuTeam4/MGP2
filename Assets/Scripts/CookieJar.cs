//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookieJar : Interactable
{
	private bool isBeingPlayed; 

    public override void OnTouchBegin()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
		EventManager.TriggerEvent(EventName.CookieJarTouched);
		if (isBeingPlayed == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Cookie", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
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
