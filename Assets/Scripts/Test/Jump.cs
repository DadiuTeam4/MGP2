// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/Jump")]
	public class Jump : Action
	{
		public override void Act(StateController controller)
		{
			PerformJump(controller);
		}

		private void PerformJump(StateController controller) 
		{
			Vector3 newPos = new Vector3(controller.gameObject.transform.position.x, controller.gameObject.transform.position.y+5, controller.gameObject.transform.position.z);
			controller.gameObject.transform.position = newPos; 
		}
	}
}