using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseCameraGyroButton : MonoBehaviour {
	public void InverseX()
	{
		EventManager.TriggerEvent(EventName.InverseCameraGyroScopeX);
	}

	public void InverseY()
	{
		EventManager.TriggerEvent(EventName.InverseCameraGyroScopeY);
	}
}
