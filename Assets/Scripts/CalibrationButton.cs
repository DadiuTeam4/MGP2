using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationButton : MonoBehaviour {
	public void OnClick()
	{
		EventManager.TriggerEvent(EventName.CalibrateCameraGyroscope);
	}
}
