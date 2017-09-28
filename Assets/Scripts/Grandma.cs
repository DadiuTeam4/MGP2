using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : Interactable {
	private float fadeValue = 100f; 
	private float fadeRate = 4.5f; 

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
		AkSoundEngine.PostEvent ("Stop_MGP2_SD_Tinnitus", gameObject); 

	}

	void FadeIn()	
	{
		if (fadeValue > 0) 
		{
		 fadeValue -= fadeRate;
			AkSoundEngine.PostEvent ("Play_MGP2_SD_Tinnitus", gameObject); 
		}
	}
}
