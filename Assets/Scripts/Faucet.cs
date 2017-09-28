//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Faucet : NumberFoundInteractable
{

    void Start()
    {
        base.Start();
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DrippingWater", gameObject); 
    }

    void Update()
    {
        if(timeHeld > 2)
        {
            changeColor();
            EventManager.TriggerEvent(EventName.FaucetRunning);
            //Fire a event here
			AkSoundEngine.PostEvent ("Stop_MGP2_SD_DrippingWater", gameObject); 
			AkSoundEngine.PostEvent ("Play_MGP2_SD_SinkFill", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
        }

    }
    
    private void changeColor()
    {
        enabled = false;
    }

	private void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrippingWater", gameObject); 
		}
	}
}
