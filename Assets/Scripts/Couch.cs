using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactable {

    public override void OnTouchBegin()
    {
        EventManager.TriggerEvent(EventName.NumberThreePickedUp);
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Bed", gameObject); 
    }

    /*void OnMouseDown()
	{
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent("NumberThreePickedUp");
	}*/
}
