// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNumbers : MonoBehaviour 
{
	void Update() 
	{
		if (Input.GetKeyDown("q")) 
		{
			EventManager.TriggerEvent(EventName.NumberOnePickedUp);
			EventManager.TriggerEvent(EventName.NumberPickedUp);
		}
		if (Input.GetKeyDown("w")) 
		{
			EventManager.TriggerEvent(EventName.NumberTwoPickedUp);
			EventManager.TriggerEvent(EventName.NumberPickedUp);
		}
		if (Input.GetKeyDown("e")) 
		{
			EventManager.TriggerEvent(EventName.NumberThreePickedUp);
			EventManager.TriggerEvent(EventName.NumberPickedUp);
		}
	}
}