using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFoundInteractable : Interactable
{
    public EventName eventToFire;
    public float fireAfterSeconds;
    private bool fired;

    private void Start()
    {
    }

    public override void OnTouchHold()
    {

        if (!fired && timeHeld > fireAfterSeconds)
        {
            FireEvent();
            fired = true;
        }
    }

    void FireEvent()
    {
        EventManager.TriggerEvent(eventToFire);

    }

}
