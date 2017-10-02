using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : Interactable {
	private float fadeValue = 100f; 
	private float fadeDeafValue = 100f;
	private float fadeMax = 100f;
	private float fadeMin = 0f; 
	private float duration;  
	private bool isFaded = false; 
	private bool hasBeenPressed = false; 

	public override void OnTouchBegin()
	{	
		if (isFaded == false && hasBeenPressed == false)
		{
			StartCoroutine (FadeInGranny()); 
		}
		if (isFaded == true && hasBeenPressed == false)
		{
			StartCoroutine (FadeOutGranny ()); 
		}
		if (isFaded == true && hasBeenPressed == true)
		{
			StartCoroutine (FadeOutGranny ()); 
		}
	}

	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("Deaf_parameter", fadeDeafValue); 
	}
		
	IEnumerator FadeInGranny()
	{
		print ("fader"); 
		hasBeenPressed = true;
		duration = 50f * Time.deltaTime; 
		while (fadeDeafValue > fadeMin) 
		{
			fadeDeafValue -= duration; 
			yield return null; 
		}
		isFaded = true; 
		hasBeenPressed = false;
	}

	IEnumerator FadeOutGranny()
	{
		hasBeenPressed = true;
		duration = 50f * Time.deltaTime; 
		while (fadeDeafValue < fadeMax) 
		{
			fadeDeafValue += duration; 
			yield return null; 
		}
		isFaded = false;
		hasBeenPressed = false;
	}
}
