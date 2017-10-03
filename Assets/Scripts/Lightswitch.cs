//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightswitch : NumberFoundInteractable
{
	public GameObject lightCanvas;

	public override void OnTouchBegin()
	{
		lightCanvas.SetActive(!lightCanvas.activeSelf);
		ResourceManager.kitchenLightOn = !ResourceManager.kitchenLightOn;
		EventManager.TriggerEvent(EventName.LightswitchClicked); 
		AkSoundEngine.PostEvent ("Play_MGP2_SD_LightSwitch", gameObject);
	}
}

