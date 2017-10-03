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

	private Image fadeImage;
	
	private EventName onFadeEndTrigger = EventName.StartGame;
	private EventName onListenerStartOptionOne = EventName.LangDanish;
	private EventName onListenerStartOptionTwo = EventName.LangEnglish;

	void Start () 
	{
		EventManager.StartListening(onListenerStartOptionOne, StartColorLerp);
		EventManager.StartListening(onListenerStartOptionTwo, StartColorLerp);
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
		
		EventManager.TriggerEvent(onFadeEndTrigger);
	}
}
