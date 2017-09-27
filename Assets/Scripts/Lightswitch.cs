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
		
	}
    public override void OnTouchBegin()
    {
		Debug.Log("Lightswitch touched");
        render.material.color = Color.green;
		EventManager.TriggerEvent(EventName.LightswitchClicked);
    }	

		

}
