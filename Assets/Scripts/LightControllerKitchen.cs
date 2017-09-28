//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightControllerKitchen : MonoBehaviour
{
	public Light lt;
	void Start ()
	{
		lt = GetComponent<Light>();
		EventManager.StartListening(EventName.LightswitchClicked, SetLight);	
		SetLight();
	}

	private void SetLight()
	{
		if (ResourceManager.kitchenLightOn == true)
		{
			lt.intensity = 1;
		}
		else
		{
			lt.intensity = 0.3F;
		}
	}

}
