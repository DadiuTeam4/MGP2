using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFoundInteractable : Interactable
{
    public EventName eventToFire;
    public float fireAfterSeconds;
    private bool fired;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>(); 

    }

    public override void OnTouchHold()
    {
        if (!fired)
        {
            renderer.material.color = Random.ColorHSV();
        }
        else
        {
            renderer.material.color = Color.green;
        }
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
