using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public EventName triggeredEvent = EventName.HubDoorClicked;

    public GameObject doorHinge;
    private bool isOpeningTheDoor;
    public float rotatingYAngle = 60;
    public float rotaingSpeed = 5;

    void Start()
    {
        getDoorState();
        isOpeningTheDoor = false;
        if (ResourceManager.doorToKitchenOpen)
        {
            KeepDoorOpenAtStart();
        }
        else
        {
            EventManager.StartListening(EventName.NumberFiveClicked, OpenDoor);
        }
    }

    void Update()
    {
        if (isOpeningTheDoor && doorHinge != null && rotatingYAngle > 0)
        {
            doorHinge.transform.Rotate(0f, -Time.deltaTime * rotaingSpeed, 0);
            rotatingYAngle = rotatingYAngle - Time.deltaTime * rotaingSpeed;
            if (rotatingYAngle <= 0)
            {
                isOpeningTheDoor = false;
            }
        }
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
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OpenDoor()
    {
        ResourceManager.doorToKitchenOpen = true;
        getDoorState();
        isOpeningTheDoor = true;
        AkSoundEngine.PostEvent("Play_MGP2_SD_DoorUnlock", gameObject);
    }

    void KeepDoorOpenAtStart()
    {
        doorHinge.transform.Rotate(0f, -rotatingYAngle, 0f);
    }
}
