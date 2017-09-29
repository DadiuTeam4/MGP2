// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/DebugPrint")]
	public class DebugPrint : Action
	{
		public override void Act(StateController controller)
		{
			Print(controller);
		}

		private void Print(StateController controller) 
		{
			Debug.Log("Q WAS PRESSED");
		}
	}
}