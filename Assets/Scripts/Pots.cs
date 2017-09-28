using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pots : Interactable {
 
	public string eventName; 

	public void Start()
	{
		eventName = string.Concat ("", eventName, ""); 
	}

	public override void OnTouchBegin(Vector2 position)
	{
		AkSoundEngine.PostEvent (eventName, gameObject);
	}
}
