using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : Interactable {

	// Use this for initialization

	private float fadeValue = 100f; 
	private float fadeMax = 100f;
	private float fadeMin = 0f; 
	public bool isFaded = false; 
	public float elapsedTime = 0f; 
	public float duration = 5f; 

	public override void OnTouchBegin()
	{	
		if (isFaded == false)
		{
			StartCoroutine (FadeIn ());
		}
		if (isFaded == true)
		{

			StartCoroutine (FadeOut ());
		}
	}

	public void Update()
	{
		AkSoundEngine.SetRTPCValue ("Vinyl_pitch", fadeValue);

		if (fadeValue <= 0.7f) {
			isFaded = true; 
			//elapsedTime = 0f; 
		}
		if (fadeValue >= 99.3f) {
			isFaded = false;
			//elapsedTime = 0f; 
		}
		Debug.Log (fadeValue); 
	}

	IEnumerator FadeIn()
	{
		//while (elapsedTime < duration)
		//{
			//fadeValue = Mathf.Lerp(fadeValue, fadeMin, (elapsedTime/ duration));
			//elapsedTime += Time.deltaTime;

			fadeValue = Mathf.Lerp (100f, 0f, Time.time/5);
			yield return new WaitForEndOfFrame ();


		//}
	}

	IEnumerator FadeOut()
	{
		//while (elapsedTime < duration)
		//{
			//fadeValue = Mathf.Lerp(fadeValue, fadeMax, (elapsedTime/ duration));
			//elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();

			fadeValue = Mathf.Lerp (0f, 100f, Time.time/5);
			yield return new WaitForEndOfFrame();


		//}
	}





	IEnumerator FadeLightColor(Color endColor, float timeForEffect, Action callback)
	{
		Color startColor = light.color;        
		float elapsed = 0f;

		while (elapsed < timeForEffect)
		{
			light.color = Color.Lerp(startColor, endColor, elapsed / timeForEffect);
			elapsed += Time.deltaTime;
			yield return null;
		}

		light.color = endColor;

		//Check callback wasn't set to null
		//Unity/Mono doesn't support later versions of c# yet which make this easier
		if (callback != null) 
		{
			callback();
		}
	}
}
