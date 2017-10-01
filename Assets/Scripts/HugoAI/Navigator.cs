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
		private GameObject checker;
		private bool checkerSpawned;
		private bool destinationReached;
		private bool randomSet;
		private int randomWayPoint;

		private void Awake() 
		{
			navMeshAgent = GetComponent<NavMeshAgent>();	
		}

		public void SetRandomDestination(StateController controller)
		{
			if (!randomSet) 
			{
				randomWayPoint = Random.Range(0, controller.idleWaypoints.Length);
				Vector3 destination = controller.idleWaypoints[randomWayPoint].position;
				SetDestination(destination);
				randomSet = true;
			}
		}

		public void SetDestination(Vector3 destination) 
		{
			navMeshAgent.SetDestination(destination);
		}

		public Vector3 GetDestination()
		{
			return navMeshAgent.destination;
		}

		public bool CheckDestinationReached() 
		{
			if (!navMeshAgent.pathPending)
			{
				if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
				{
					if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
					{
						randomSet = false;
						return true;
					}
				}
			}
			return false;
		}
	}
}
