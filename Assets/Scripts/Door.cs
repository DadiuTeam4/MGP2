﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public EventName triggeredEvent = EventName.HubDoorClicked;

    public GameObject doorHinge;
    public Vector3 rotationVector;

    void Start()
    {
        getDoorState();
        rotationVector = new Vector3(0f, -60f, 0f);
        EventManager.StartListening(EventName.NumberFiveClicked, OpenDoor);

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
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Debug.Log("Kitchen door state is: Closed");
        }
    }

    void OpenDoor()
    {
        ResourceManager.doorToKitchenOpen = true;
        getDoorState();
        if (doorHinge != null)
        {
            doorHinge.transform.Rotate(rotationVector);
        }

        AkSoundEngine.PostEvent("Play_MGP2_SD_DoorUnlock", gameObject);

    }
}
