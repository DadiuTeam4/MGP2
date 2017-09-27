using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable 
{
    public EventName triggeredEvent = EventName.HubDoorClicked;
    private bool isOpen = false;

 	void Start()
    {
        getDoorState();
        EventManager.StartListening((EventName.NumberThreePickedUp), OpenDoor);
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

    void getDoorState()
    {
        if (ResourceManager.doorToKitchenOpen == true)
        {
            Debug.Log("Kitchen door state is: Open");
        }
        else{
            Debug.Log("Kitchen door state is: Closed");
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        ResourceManager.doorToKitchenOpen = true;
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DoorUnlock", gameObject); 

    }
}
