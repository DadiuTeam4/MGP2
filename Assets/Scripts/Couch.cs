using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactable {

    public override void OnTouchBegin()
    {
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent((int)EventName.NumberThreePickedUp);
    }

    void OnMouseDown()
	{
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent("NumberThreePickedUp");
	}
}
