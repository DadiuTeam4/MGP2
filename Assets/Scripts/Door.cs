﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable 
{
    public EventName triggeredEvent = EventName.HubDoorClicked;
    private bool isOpen = false;

 	void Start()
    {
        EventManager.StartListening((EventName.NumberOneClicked), OpenDoor);
	}

    public override void OnTouchBegin()
    {

        if (triggeredEvent == EventName.KitchenDoorClicked)
        {
            EventManager.TriggerEvent(EventName.KitchenDoorClicked);
        }


        if (this.isOpen)
        {
            EventManager.TriggerEvent(triggeredEvent);
        } 
        else
        {
        }
    }

    void OpenDoor()
    {
        isOpen = true;
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DoorUnlock", gameObject); 

    }
}
