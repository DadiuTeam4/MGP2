using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFoundInteractable : Interactable
{
    public EventName eventToFire;
    public float fireAfterSeconds;

    [Header("Shake values")]
    [Range(0, 100)]
    public float speed = 60;
    [Range(0.0f, 0.1f)]
    public float shakeMagnitude = 0.01f;

    public ParticleSystem particleOnHold;

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
            float progress = timeHeld / fireAfterSeconds;
            Vector3 newPos = ShakeSimple(timeHeld, speed, shakeMagnitude);
            transform.position = newPos;

            if (timeHeld > fireAfterSeconds)
            {
                FireEvent();
                fired = true;
                transform.position = originalPosition;
                if (particleOnHold.isEmitting)
                {
                    particleOnHold.Stop();
                }
            }
        }

        if (!particleOnHold.isEmitting && !fired)
        {
            particleOnHold.Play();
        }
    }

    public override void OnTouchReleased()
    {
        if (particleOnHold.isEmitting)
        {
            particleOnHold.Stop();
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
