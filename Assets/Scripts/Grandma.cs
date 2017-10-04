using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : Interactable {
	private float fadeValue = 100f; 
	private float fadeDeafValue = 100f;
	private float fadeMax = 100f;
	private float fadeMin = 0f; 
	private float duration;  
	private bool hasBeenPressed = false; 
	[HideInInspector] public static Animator animator; 

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public override void OnTouchBegin()
	{	
		if (hasBeenPressed == false)
		{
			StartCoroutine (FadeInGranny()); 
		}
	}

	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("Deaf_parameter", fadeDeafValue); 
	}
		
	IEnumerator FadeInGranny()
	{
		hasBeenPressed = true;
		duration = 50f * Time.deltaTime; 
		while (fadeDeafValue > fadeMin) 
		{
			fadeDeafValue -= duration; 
			yield return null; 
		}
		hasBeenPressed = false;
		//yield return new WaitForSeconds (1f); 
		StartCoroutine (FadeOutGranny ()); 
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
		hasBeenPressed = false;
	}
}
