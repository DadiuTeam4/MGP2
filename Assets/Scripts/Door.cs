using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable 
{
    public EventName triggeredEvent = EventName.HubDoorClicked;
    private bool isOpen = false;

	void Start()
    {
        EventManager.StartListening(((int)EventName.NumberThreePickedUp), OpenDoor);
	}

    public override void OnTouchBegin()
    {
        if (this.isOpen)
        {
            EventManager.TriggerEvent((int)triggeredEvent);
            Debug.Log("Door open");
        } 
        else
        {
            Debug.Log("Door closed");
        }
    }
    void OnMouseDown()
	{
        Debug.Log("Door clicked");
        OnTouchBegin();
	}

    void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door is Opened!");
    }
}
