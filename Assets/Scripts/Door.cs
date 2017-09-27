using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable 
{
    public EventName triggeredEvent = EventName.HubDoorClicked;

 	void Start()
    {
        getDoorState();
        EventManager.StartListening((EventName.NumberOneClicked), OpenDoor);

	}

    public override void OnTouchBegin()
    {

        if (triggeredEvent == EventName.KitchenDoorClicked)
        {
            EventManager.TriggerEvent(EventName.KitchenDoorClicked);
        }


        if (ResourceManager.doorToKitchenOpen == true)
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
        ResourceManager.doorToKitchenOpen = true;
		AkSoundEngine.PostEvent ("Play_MGP2_SD_DoorUnlock", gameObject); 

    }
}
