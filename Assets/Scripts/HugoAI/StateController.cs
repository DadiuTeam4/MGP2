// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI 
{
	public class StateController : MonoBehaviour 
	{
		public List<Transform> idleWaypoints;
		public List<Transform> purposeWaypoints;
		public State currentState;
		public bool active = true;

		private State previousState;

		[HideInInspector] public Navigator navigator;
		[HideInInspector] public Animator animator;
		private float stateTimeElapsed;

		void Awake()
		{
			//animator = GetComponent<Animator>();
			navigator = GetComponent<Navigator>();
		}

		public void TransitionToState(State nextState)
		{
			if (nextState != currentState) 
			{
				previousState = currentState;
				currentState = nextState;
				OnExitState();
			}
		}

		public void ReturnToPreviousState() 
		{
			TransitionToState(previousState);
		}

		private void Update()
		{
			if (!active) 
			{
				return;
			}
			currentState.UpdateState(this);
		}

		public bool CheckIfCountDownElapsed(float duration)
		{
			stateTimeElapsed += Time.deltaTime;
			return (stateTimeElapsed >= duration);
		}

		public void ResetStateTimer() 
		{
			stateTimeElapsed = 0;
		}

		private void OnExitState()
		{
			ResetStateTimer();
		}
	}
}
