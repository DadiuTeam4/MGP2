using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFoundInteractable : Interactable
{
    public EventName eventToFire;
    public float fireAfterSeconds;

    [Header("Shake values")]
    public bool shake = true;
    [Range(0, 100)]
    public float speed = 60;
    [Range(0.0f, 0.1f)]
    public float shakeMagnitude = 0.01f;
    
    private bool fired;
    private Vector3 originalPosition;

    protected void Start()
    {
        originalPosition = transform.position;
    }

    public override void OnTouchHold()
    {
        if (!fired) 
        {
            if (shake)
            {
                float progress = timeHeld / fireAfterSeconds;
                Vector3 newPos = ShakeSimple(timeHeld, speed, shakeMagnitude);
                transform.position = newPos;
            }

            if (timeHeld > fireAfterSeconds)
            {
                FireEvent();
                fired = true;
                if (shake)
                {
                    transform.position = originalPosition;
                }
            }
        }
    }

    void FireEvent()
    {
        EventManager.TriggerEvent(eventToFire);
    }

    private Vector3 ShakeSimple(float time, float speed, float magnitude)
    {
        float newZ = originalPosition.z + Mathf.Sin(time * speed) * magnitude;
        return new Vector3(originalPosition.x, originalPosition.y, newZ);
    }
}
