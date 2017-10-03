//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoor : Interactable
{

    // Use this for initialization
    private bool isOvenDoorOpen = false;
    private bool isOpeningOvenDoor = false;
    private bool isClosingOvenDoor = false;
    private Transform ovenHingeTransform;
    public float doorOpenXAngle = 70f;
    private float currentDoorOpenXAngle;
    public float doorOpenSpeed = 10;
    public float timeToCloseOvenDoor = 5;
    private float timeLeftToCloseOvenDoor;
    private bool isCloseDoorTimerStarted = false;

    void Start()
    {
        ovenHingeTransform = gameObject.GetComponentInChildren<Transform>();
        currentDoorOpenXAngle = doorOpenXAngle;
        timeLeftToCloseOvenDoor = timeToCloseOvenDoor;
    }

    void Update()
    {
        //Open Door
        if (isOpeningOvenDoor && !isOvenDoorOpen)
        {
            ovenHingeTransform.Rotate(Time.deltaTime * doorOpenSpeed, 0f, 0f);
            currentDoorOpenXAngle = currentDoorOpenXAngle - Time.deltaTime * doorOpenSpeed;
            if (currentDoorOpenXAngle <= 0)
            {
                isOvenDoorOpen = true;
                isOpeningOvenDoor = false;
                currentDoorOpenXAngle = doorOpenXAngle;
                StartTimerForAutoCloseTheDoor();
            }
        }

        //Close Door
        if (isClosingOvenDoor && isOvenDoorOpen)
        {
            ovenHingeTransform.Rotate(-Time.deltaTime * doorOpenSpeed, 0f, 0f);
            currentDoorOpenXAngle = currentDoorOpenXAngle - Time.deltaTime * doorOpenSpeed;
            if (currentDoorOpenXAngle <= 0)
            {
                isOvenDoorOpen = false;
                isClosingOvenDoor = false;
                currentDoorOpenXAngle = doorOpenXAngle;
            }
        }

        //Timer for close the door
        if (isCloseDoorTimerStarted)
        {
            timeLeftToCloseOvenDoor -= Time.deltaTime;
            if (timeLeftToCloseOvenDoor <= 0)
            {
                CloseOven();
            }
        }
    }

    public override void OnTouchBegin()
    {
        if (!isOvenDoorOpen && !isOpeningOvenDoor)
        {
            OpenOven();
        }

        if (isOvenDoorOpen && !isClosingOvenDoor)
        {
            CloseOven();
        }
    }

    private void OpenOven()
    {
        isOpeningOvenDoor = true;
    }

    private void CloseOven()
    {
        isClosingOvenDoor = true;
        isCloseDoorTimerStarted = false;
        timeLeftToCloseOvenDoor = timeToCloseOvenDoor;
    }

    private void StartTimerForAutoCloseTheDoor()
    {
        isCloseDoorTimerStarted = true;
    }
}
