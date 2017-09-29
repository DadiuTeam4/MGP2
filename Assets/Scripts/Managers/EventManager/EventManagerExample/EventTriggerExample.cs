//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A example of triggering the event
public class EventTriggerExample : MonoBehaviour
{

    // When some events happens, trigger the event by the name of event
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
			EventManager.TriggerEvent((int)EventName.Test);
        }
    }
}
