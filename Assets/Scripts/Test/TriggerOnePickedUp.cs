// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnePickedUp : MonoBehaviour 
{
	void Update() 
	{
		if (Input.GetKeyDown("q")) 
		{
			EventManager.TriggerEvent(EventName.NumberOnePickedUp);
		}		
	}
}