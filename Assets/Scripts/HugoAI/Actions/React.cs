// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/React")]
	public class React : Action
	{
		public Animation reactionAnimation;

		private Vector3 pointToLookAt;

		public override void Act(StateController controller)
		{
			ReactToEvent(controller);
		}

		private void ReactToEvent(StateController controller) 
		{
			Vector3 pointToLookAt = InputManager.GetLastRayHit();
		}
	}
}