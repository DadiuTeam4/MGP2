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

    void Start()
    {
        ovenHingeTransform = gameObject.GetComponentInChildren<Transform>();
		currentDoorOpenXAngle = doorOpenXAngle;
    }

    void Update()
    {
        if (isOpeningOvenDoor && !isOvenDoorOpen)
        {
            ovenHingeTransform.Rotate(Time.deltaTime * doorOpenSpeed, 0f, 0f);
            currentDoorOpenXAngle = currentDoorOpenXAngle - Time.deltaTime * doorOpenSpeed;
            if (currentDoorOpenXAngle <= 0)
            {
                isOvenDoorOpen = true;
                isOpeningOvenDoor = false;
                currentDoorOpenXAngle = doorOpenXAngle;
            }
        }

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
    }

}
