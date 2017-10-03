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

    public ParticleSystem onHoldParticleSystem;
    public ParticleSystem indicatorParticleSystem;
    private bool fired;
    private Vector3 originalPosition;
    private Vector2 mousePositionOnTouchBegin;
    public float timeInterval = 3.0f;
    public float period = 0.0f;
    public float stopParticlesTime = 1.0f;
    public float offsetOnYParticleSystem = 0.52f;
    public bool hasAnimation;
	public bool hasAnimator;

    protected void Start()
    {
        fired = ResourceManager.NumberFound(EventManager.NumberEventToInt(eventToFire))
               || ResourceManager.NumberCountedToGrandma(EventManager.NumberEventToInt(eventToFire));
        originalPosition = transform.position;
    }

    void Update()
    {
        if (!fired)
        {
            if (period > timeInterval)
            {
                period = 0;
                if (indicatorParticleSystem != null)
                {
                    indicatorParticleSystem.Play();
                    indicatorParticleSystem.transform.position = new Vector3(transform.position.x, transform.position.y + offsetOnYParticleSystem, transform.position.z);
                }
            }
            if (period > stopParticlesTime)
            {

                if (indicatorParticleSystem != null)
                {

                    indicatorParticleSystem.Stop();
                    indicatorParticleSystem.Clear();
                }
            }
            period += UnityEngine.Time.deltaTime;
        }

    }



    public override void OnTouchBegin()
    {
        mousePositionOnTouchBegin = InputManager.GetLastRayHit();
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

            if (onHoldParticleSystem != null && !onHoldParticleSystem.isPlaying)
            {
                onHoldParticleSystem.transform.position = InputManager.GetLastRayHit();
                onHoldParticleSystem.Play();
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

    public override void OnTouchReleased()
    {
        if (onHoldParticleSystem != null && onHoldParticleSystem.isPlaying)
        {
            onHoldParticleSystem.Stop();
            onHoldParticleSystem.Clear();
        }
        period = 0;
    }

    void FireEvent()
    {
        if (onHoldParticleSystem != null)
        {
            onHoldParticleSystem.Stop();
            onHoldParticleSystem.Clear();
        }
        EventManager.TriggerEvent(eventToFire);
        EventManager.TriggerEvent(EventName.NumberPickedUp);
        if (hasAnimation)
        {
            PlayAnimation();
        }
		if (hasAnimator) 
		{
			StartAnimator();
		}

    }

    private Vector3 ShakeSimple(float time, float speed, float magnitude)
    {
        float newZ = originalPosition.z + Mathf.Sin(time * speed) * magnitude;
        return new Vector3(originalPosition.x, originalPosition.y, newZ);
    }

    private void PlayAnimation()
    {
        Animation ani = GetComponent<Animation>();
		ani.Play(ani.clip.name);
    }
	private void StartAnimator()
	{
		Animator animator = GetComponent<Animator>();
		animator.SetBool ("HereWeGo", true);
	}

}
