using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable 
{
    public EventName triggeredEvent = EventName.HubDoorClicked;
    private bool isOpen = false;

 	void Start()
    {
        EventManager.StartListening((EventName.NumberThreePickedUp), OpenDoor);
	}

    public override void OnTouchBegin()
    {

        if (triggeredEvent == EventName.KitchenDoorClicked)
        {
            EventManager.TriggerEvent(EventName.KitchenDoorClicked);
        }

        Debug.Log(triggeredEvent);
        if (this.isOpen)
        {
            EventManager.TriggerEvent(triggeredEvent);
            Debug.Log("Door open");
        } 
        else
        {
            Debug.Log("Door closed");
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door is Opened!");
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DoorUnlock", gameObject); 

    }
}
