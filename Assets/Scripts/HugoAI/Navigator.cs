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
		public GameObject destinationCheckerPrefab;

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
			if (!checkerSpawned) 
			{
				checker = Instantiate(destinationCheckerPrefab, destination, Quaternion.identity);
				checkerSpawned = true;
			}
			else if (checker != null)
			{
				checker.transform.position = destination;
			}
			navMeshAgent.SetDestination(destination);
		}

		public bool CheckDestinationReached()
		{
			if (destinationReached)
			{
				destinationReached = false;
				checkerSpawned = false;
				randomSet = false;
				return true;
			}
			else 
			{
				return false;
			}
		}

		private void OnTriggerEnter(Collider other) 
		{
			print(other.gameObject.tag);
			if (other.gameObject.tag == "DestinationChecker") 
			{
				Destroy(other.gameObject);
				destinationReached = true;	
			}
		}
	}
}
