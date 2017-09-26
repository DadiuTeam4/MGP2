// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[HideInInspector]
	public float timeHeld;
	public virtual void OnTouchBegin() {}
	public virtual void OnTouchHold() {}
	public virtual void OnTouchReleased() {}
}
