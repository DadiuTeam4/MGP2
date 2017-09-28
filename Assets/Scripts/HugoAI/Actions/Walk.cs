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
		[Tooltip("If set to random, Hugo will go to a random idle waypoint set in the state controller.")]
		public bool random;
		[Tooltip("Ignored if set to random")]
		public int waypointIndex;

		private Vector3 destination;
		private int randomWayPoint;
		private bool waypointSet;

		public override void Act(StateController controller)
		{
			SetWaypoint(controller);
		}

		private void SetWaypoint(StateController controller) 
		{
			if (!waypointSet)
			{
				if (random)
				{
					randomWayPoint = Random.Range(0, controller.idleWaypoints.Length);
					destination = controller.idleWaypoints[randomWayPoint].position;
				}
				else
				{
					destination = controller.purposeWaypoints[waypointIndex].position;
				}
				waypointSet = true;
			}
			controller.navigator.SetDestination(destination);
		}
	}
}