using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactable {

	private bool isBeingPlayed = false; 

    public override void OnTouchBegin()
    {
        EventManager.TriggerEvent(EventName.NumberOnePickedUp);
		if (isBeingPlayed == false) 
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Bed", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
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

    /*void OnMouseDown()
	{
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent("NumberThreePickedUp");
	}*/
}
