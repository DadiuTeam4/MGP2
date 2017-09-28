﻿// Author: Mathias Dam Hedelund
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

		public override void Act(StateController controller)
		{
			SetWaypoint(controller);
		}

		private void SetWaypoint(StateController controller) 
		{
			if (random)
			{
				controller.navigator.SetRandomDestination(controller);
			}
			else
			{
				controller.navigator.SetDestination(controller.purposeWaypoints[waypointIndex].position);
			}
		}
	}
}