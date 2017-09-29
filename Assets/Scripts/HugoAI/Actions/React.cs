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

		public override void Act(StateController controller)
		{
			ReactToEvent(controller);
		}

		private void ReactToEvent(StateController controller) 
		{
			//Debug.Log("Reacting");
		}
	}
}