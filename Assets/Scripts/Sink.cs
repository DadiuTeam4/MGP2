// Author: Jonathan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable 
{

	void Start ()
	{
        EventManager.StartListening(EventName.NumberFourPickedUp, FillSink);	
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DrippingWater", gameObject); 
	}
	
	void Update () {
		
	}

    void FillSink()
    {
        ResourceManager.kitchenSinkFull = true;
		AkSoundEngine.PostEvent ("Stop_MGP2_SD_DrippingWater", gameObject);
		AkSoundEngine.PostEvent ("Play_MGP2_SD_SinkFill", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);

    }

	private void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrippingWater", gameObject); 
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Rubberduck", gameObject); 
		}
	}
}
