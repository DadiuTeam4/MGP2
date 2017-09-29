// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable 
{
	public override void OnTouchBegin() 
	{
		print("Touch begin");
	}

	public override void OnTouchHold()
	{
		print(timeHeld);	
	}

	public override void OnTouchReleased()
	{
		print("Touch released");
	}
}
