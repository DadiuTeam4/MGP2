//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable
{
	[Header("Growth values")]
	[Range(1.01f, 2.0f)] public float growth = 1.2f;
	[Range(0.00f, 3.0f)] public float growTime = 1f;
	[Range(0.00f, 5.0f)] public float timeBeforeReturning = 3f;

	private Vector3 originalScale;
	private Vector3 grownScale;
	private bool growing;

	public override void GiveTouchFeedback()
	{
		if (!growing)
		{
			originalScale = transform.localScale;
			grownScale = originalScale * growth;
			StartCoroutine(Grow());
			growing = true;
		}
	}

	private IEnumerator Grow()
	{
		float timeElapsed = 0.0f;
		float progress = 0.0f;
		while (timeElapsed < growTime)
		{
			timeElapsed += Time.deltaTime;
			progress = timeElapsed / growTime;
			transform.localScale = Vector3.Lerp(originalScale, grownScale, progress);
			yield return null;
		}
		yield return new WaitForSeconds(timeBeforeReturning);
		StartCoroutine(Shrink());
	}

	private IEnumerator Shrink()
	{
		float timeElapsed = 0.0f;
		float progress = 0.0f;
		while (timeElapsed < growTime)
		{
			timeElapsed += Time.deltaTime;
			progress = timeElapsed / growTime;
			transform.localScale = Vector3.Lerp(grownScale, originalScale, progress);
			yield return null;
		}
		growing = false;
	}
}
