using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public EventName triggeredEvent = EventName.HubDoorClicked;

    private Transform doorHinge;
    private bool isOpeningTheDoor;
    public float rotatingYAngle = 80;
    private float currentRotatingYAngle;
    public float rotaingSpeed = 10;

    void Start()
    {
        doorHinge = GetComponentInParent<Transform>();
        isOpeningTheDoor = false;
        currentRotatingYAngle = rotatingYAngle;
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
        if (isOpeningTheDoor)
        {
            doorHinge.Rotate(0f, -Time.deltaTime * rotaingSpeed, 0);
            currentRotatingYAngle -= Time.deltaTime * rotaingSpeed;
            if (currentRotatingYAngle <= 0)
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

    private void OpenDoor()
    {
        ResourceManager.doorToKitchenOpen = true;
        isOpeningTheDoor = true;
        AkSoundEngine.PostEvent("Play_MGP2_SD_DoorUnlock", gameObject);
    }

    private void KeepDoorOpenAtStart()
    {
        doorHinge.Rotate(0f, rotatingYAngle, 0f);
    }
}
