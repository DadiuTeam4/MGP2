using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable {

	private bool isBeingPlayed = false;
	private bool drawerOpen = false; 

	public override void OnTouchBegin()
	{	
		if (isBeingPlayed == false && drawerOpen == false)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrawerOpen", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			drawerOpen = true; 
		}

		if (isBeingPlayed == false && drawerOpen == true)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrawerClose", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			drawerOpen = false; 
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