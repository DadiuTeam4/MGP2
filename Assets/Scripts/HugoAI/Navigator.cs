// Author: Mathias Dam Hedelund
// Contributors: 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HugoAI 
{
	public class Navigator : MonoBehaviour 
	{
		private NavMeshAgent navMeshAgent;
		private bool waypointSet;

		private void Awake() 
		{
			navMeshAgent = GetComponent<NavMeshAgent>();	
		}

		public void SetDestination(Vector3 destination) 
		{
			if (!waypointSet) 
			{
				navMeshAgent.SetDestination(destination);
				waypointSet = true;
			}
		}

		public bool CheckDestinationReached() 
		{
			if (!navMeshAgent.pathPending)
			{
				if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
				{
					if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
					{
						waypointSet = false;
						return true;
					}
				}
			}
			return false;
		}
	}
}
