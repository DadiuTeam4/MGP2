// Author: Kristian

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : Interactable {

	private float fadePitchValue = 100f;
	private float fadeMax = 100f;
	private float fadeMin = 0f; 
	private float duration;  
	private bool isFaded = false; 
	private bool hasBeenPressed = false; 

	public void Start()
	{
		EventManager.StartListening (EventName.KitchenSceneLoaded, KitchenSwitch); 
	}

	public override void OnTouchBegin()
	{	
		if (isFaded == false && hasBeenPressed == false)
		{
			StartCoroutine (FadeIn ()); 
		}
		if (isFaded == true && hasBeenPressed == false)
		{
			StartCoroutine (FadeOut ()); 
		}
		if (isFaded == true && hasBeenPressed == true)
		{
			StartCoroutine (FadeOut ()); 
		}
	}

	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("Vinyl_pitch", fadePitchValue);
	}

	IEnumerator FadeIn()
	{
		hasBeenPressed = true;
		duration = 20f * Time.deltaTime; 
		while (fadePitchValue > fadeMin) 
		{
			fadePitchValue -= duration; 
			yield return null; 
		}
		isFaded = true; 
		hasBeenPressed = false;
		AkSoundEngine.PostEvent("Pause_MGP2_Music_throwout2piano_P__dirty", gameObject); 
	}
		
	IEnumerator FadeOut()
	{
		AkSoundEngine.PostEvent("Resume_MGP2_Music_throwout2piano_P__dirty", gameObject); 
		hasBeenPressed = true;
		duration = 20f * Time.deltaTime; 
		while (fadePitchValue < fadeMax) 
		{
			fadePitchValue += duration; 
			yield return null; 
		}
		isFaded = false;
		hasBeenPressed = false;
	}

	void KitchenSwitch()
	{
		if (hasBeenPressed == true && isFaded == true)
		{
			isFaded = false;
			hasBeenPressed = true; 
		}
	}
}