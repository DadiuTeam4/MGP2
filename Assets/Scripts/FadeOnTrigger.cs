using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOnTrigger : MonoBehaviour 
{
	[Tooltip("Starting color")]
	public Color FromColor;
	[Tooltip("Ending color")]
	public Color ToColor;

	[Tooltip("Amount faded per interval")]
	[Range(0.01f, 1.0f)]
	public float fadeSpeed;

	[Tooltip("Time in between fade intervals, in seconds")]
	[Range(0.01f, 1.0f)]
	public float fadeInterval;

	[Tooltip("The amount of seconds waited till end trigger, in seconds")]
	[Range(0.0f, 10.0f)]
	public float waitTillTrigger;

	private Image fadeImage;
	
	public EventName onFadeEndTrigger;
	public EventName[] listeners;

	void Start () 
	{
		for(int i = 0; i < listeners.Length; i ++)
		{
			EventManager.StartListening(listeners[i], StartColorLerp);
		}
		fadeImage = transform.GetComponent<Image>();
	}

	private void StartColorLerp()
	{
		fadeImage.raycastTarget = true;
		StartCoroutine("ColorLerp");
	}

	private IEnumerator ColorLerp()
	{
		float t = 0;
		while(t < 1.0f)
		{
			t += fadeSpeed;
			fadeImage.color = Color.Lerp(FromColor, ToColor, t);
			yield return new WaitForSeconds(fadeInterval);
		}
		
		yield return new WaitForSeconds(waitTillTrigger);
		EventManager.TriggerEvent(onFadeEndTrigger);
	}
}
