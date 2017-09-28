//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
	private Renderer render;

	void Start ()
	{
		render = GetComponent<Renderer>();
		renderLightswitch();
		
	}
    public override void OnTouchBegin()
    {
		Debug.Log("Lightswitch touched");
		ResourceManager.kitchenLightOn = !ResourceManager.kitchenLightOn;
		renderLightswitch();
		EventManager.TriggerEvent(EventName.LightswitchClicked);
		AkSoundEngine.PostEvent ("Play_MGP2_SD_LightSwitch", gameObject); 
    }

	private void renderLightswitch()
	{
		if (ResourceManager.kitchenLightOn == true) {
			render.material.color = Color.green;
		} else {
			render.material.color = Color.red;
		}
	}
}

