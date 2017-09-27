using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : Interactable {
	private float fadeValue = 100f; 
	private float fadeRate = 2.5f; 

	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("Deaf_parameter", fadeValue); 
	}

	public override void OnTouchHold()
	{
		FadeIn (); 
	}

	public override void OnTouchReleased()
	{
		fadeValue = 100f; 
	}

	void FadeIn()	
	{
		if (fadeValue > 0) 
		{
		 fadeValue -= fadeRate; 
		}
	}
}
