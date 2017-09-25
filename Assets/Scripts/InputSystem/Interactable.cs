// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public virtual void Tap() {}
	public virtual void Hold(float timeHeld) {}
	public virtual void Released() {}
}
