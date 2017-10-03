using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoSpeak : NumberFoundInteractable {

	public bool isBeingPlayed = false; 
	public GlobalSoundManager GSM;

	public void Start ()
	{
		GSM = GameObject.Find ("GlobalSoundManager").GetComponent<GlobalSoundManager>();
	}



	public override void OnTouchBegin()
	{
		//EventManager.TriggerEvent(EventName.NumberOnePickedUp);
		if (GSM.hugoIsTalking == false) 
		{
			GSM.HugoTryk (); 
		}
	}

	/*void OnMouseDown()
	{
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent("NumberThreePickedUp");
	}*/
}
