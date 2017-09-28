// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[Header("Visual feedback on touch")]
	[Range(1.01f, 1.2f)]
	public float boomMagnitude = 1.08f;
	[Range(0.0f, 0.5f)]
	public float boomTime = 0.1f;

	[HideInInspector]
	public float timeHeld;

	private bool booming;

	public virtual void GiveTouchFeedback() 
	{
		if (!booming)
		{
			StartCoroutine(Boom());
			booming = true;
		}
	}

	public virtual void OnTouchBegin() {}
	public virtual void OnTouchHold() {}
	public virtual void OnTouchReleased() {}

	private IEnumerator Boom() 
	{
		Vector3 originalScale = transform.localScale;
		Vector3 boomedScale = originalScale * boomMagnitude;
		float timeElapsed = 0.0f;
		float progress = 0.0f;
		while (timeElapsed < boomTime) 
		{
			timeElapsed += Time.deltaTime;
			progress = timeElapsed / boomTime;
			if (progress < 0.5f) 
			{
				transform.localScale = Vector3.Lerp(originalScale, boomedScale, progress * 2);
			}
			else
			{
				transform.localScale = Vector3.Lerp(boomedScale, originalScale, progress * 2 - 1);
			}
			yield return null;
		}
		booming = false;
	}
}
