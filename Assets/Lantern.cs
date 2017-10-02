using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : Interactable {

	public string eventName; 

	public void Start()
	{
		eventName = string.Concat ("", eventName, ""); 
	}

	public override void OnTouchBegin()
	{
		AkSoundEngine.PostEvent (eventName, gameObject);
	}
}

