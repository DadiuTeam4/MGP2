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
    
    public ParticleSystem onHoldParticleSystem;

    private bool fired;
    private Vector3 originalPosition;
    private Vector2 mousePositionOnTouchBegin;

    protected void Start()
    {
        originalPosition = transform.position;
    }

    public override void OnTouchBegin(Vector2 position)
    {
        mousePositionOnTouchBegin = position;
    }

    public override void OnTouchHold()
    {
        if (!fired) 
        {
            float progress = timeHeld / fireAfterSeconds;
            Vector3 newPos = ShakeSimple(timeHeld, speed, shakeMagnitude);
            transform.position = newPos;

            if (onHoldParticleSystem != null && !onHoldParticleSystem.isPlaying)
            {
                onHoldParticleSystem.transform.position = ScreenSpaceToWorldSpace(mousePositionOnTouchBegin);
                onHoldParticleSystem.Play();
            }

            if (timeHeld > fireAfterSeconds)
            {
                FireEvent();
                fired = true;
                transform.position = originalPosition;
            }
        }
    }

    public override void OnTouchReleased()
    {
        if (onHoldParticleSystem != null && onHoldParticleSystem.isPlaying)
        {
            onHoldParticleSystem.Stop();
            onHoldParticleSystem.Clear();
        }
    }

    void FireEvent()
    {
        if (onHoldParticleSystem != null)
        {
            onHoldParticleSystem.Stop();
            onHoldParticleSystem.Clear();
        }
        EventManager.TriggerEvent(eventToFire);
    }

    private Vector3 ShakeSimple(float time, float speed, float magnitude)
    {
        float newZ = originalPosition.z + Mathf.Sin(time * speed) * magnitude;
        return new Vector3(originalPosition.x, originalPosition.y, newZ);
    }
}
