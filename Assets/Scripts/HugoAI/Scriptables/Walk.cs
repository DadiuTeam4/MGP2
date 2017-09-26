// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/Walk")]
	public class Walk : Action
	{
		public float walkCooldown;
		public override void Act(StateController controller)
		{
			SetRandomWaypoint(controller);
		}

		private void SetRandomWaypoint(StateController controller) 
		{
			if (controller.CheckIfCountDownElapsed(walkCooldown)) 
			{
				int randomWayPoint = Random.Range(0, controller.waypoints.Count);
				Vector3 destination = controller.waypoints[randomWayPoint].position;
				controller.navigator.SetDestination(destination);
				controller.ResetStateTimeElapsed();
			}
		}
	}
}
