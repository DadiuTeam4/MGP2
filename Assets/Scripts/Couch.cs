using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactable {

    public override void OnTouchBegin()
    {
        EventManager.TriggerEvent(EventName.NumberOnePickedUp);
    }

    /*void OnMouseDown()
	{
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent("NumberThreePickedUp");
	}*/
}
