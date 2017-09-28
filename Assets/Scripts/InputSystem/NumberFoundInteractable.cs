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
    // [Range(0,100)]
    // public float amplitude = 1;
    // [Range(0.00001f, 0.99999f)]
    // public float frequency = 0.98f;
 
    // [Range(1,4)]
    // public int octaves = 2;
 
    // [Range(0.00001f,5)]
    // public float persistance = 0.2f;
    // [Range(0.00001f,100)]
    // public float lacunarity = 20;
 
    // [Range(0.00001f, 0.99999f)]
    // public float burstFrequency = 0.5f;
 
    // [Range(0,5)]
    // public int  burstContrast = 2;
    
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
            }
        }
    }

    void FireEvent()
    {
        EventManager.TriggerEvent(eventToFire);
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Yarn", gameObject); 
    }

    private Vector3 ShakeSimple(float time, float speed, float magnitude)
    {
        float newZ = originalPosition.z + Mathf.Sin(time * speed) * magnitude;
        return new Vector3(originalPosition.x, originalPosition.y, newZ);
    }

    private Vector3 Shake(float amplitude, float frequency, int octaves, float persistance, float lacunarity, float burstFrequency, int burstContrast, float time)
    {
        float valY = originalPosition.y;
        float valZ = originalPosition.z;
 
        float iAmplitude = 1;
        float iFrequency = frequency;
        float maxAmplitude = 0;
 
        // Burst frequency
        float burstCoord  = time / (1 - burstFrequency);
 
        // Sample diagonally trough perlin noise
        float burstMultiplier = Mathf.PerlinNoise(burstCoord, burstCoord);
 
        // Apply contrast to the burst multiplier using power, it will make values stay close to zero and less often peak closer to 1
        burstMultiplier =  Mathf.Pow(burstMultiplier, burstContrast);
 
        for (int i=0; i < octaves; i++)
        {
            float noiseFrequency = time / (1 - iFrequency) / 10;
 
            float perlinValueX = Mathf.PerlinNoise(noiseFrequency, 0.5f) ;
            float perlinValueY = Mathf.PerlinNoise(0.5f, noiseFrequency);
 
            // Adding small value To keep the average at 0 and   *2 - 1 to keep values between -1 and 1.
            perlinValueX = (perlinValueX + 0.0352f) * 2 - 1;
            perlinValueY = (perlinValueY + 0.0345f) * 2 - 1;
                   
            valY += perlinValueX * iAmplitude;
            valZ += perlinValueY * iAmplitude;
 
            // Keeping track of maximum amplitude for normalizing later
            maxAmplitude += iAmplitude;
 
            iAmplitude     *= persistance;
            iFrequency     *= lacunarity;
        }
 
        valY *= burstMultiplier;
        valZ *= burstMultiplier;
 
        // normalize
        valY /= maxAmplitude;
        valZ /= maxAmplitude;
 
        valY *= amplitude;
        valZ *= amplitude;
 
        return new Vector3(originalPosition.x, valY, valZ);
    }

}
