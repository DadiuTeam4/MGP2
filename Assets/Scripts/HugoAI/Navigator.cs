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

		private void Awake() 
		{
			navMeshAgent = GetComponent<NavMeshAgent>();	
		}

		public void SetDestination(Vector3 destination) 
		{
			navMeshAgent.SetDestination(destination);
		}

		public bool CheckDestinationReached() 
		{
			if (!navMeshAgent.pathPending)
			{
				if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
				{
					if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
