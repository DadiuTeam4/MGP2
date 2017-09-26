using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    private bool isOpen = false;

	// Use this for initialization
	void Start ()
    {
        EventManager.StartListening(((int)EventName.NumberThreePickedUp), OpenDoor);
	}

    public override void OnTouchBegin()
    {
        if (this.isOpen)
        {
            EventManager.TriggerEvent((int)EventName.OpenDoorClicked);
            Debug.Log("Door open");
        } else
        {
            Debug.Log("Door closed");
        }
    }

    public override void OnTouchHold()
    {
    }

    public override void OnTouchReleased()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door is Opened!");
    }
}
