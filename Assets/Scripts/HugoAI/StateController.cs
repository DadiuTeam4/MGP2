// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI 
{
	public class StateController : MonoBehaviour 
	{
		[Header("Customizable fields for Hugo's AI")]
		public List<Transform> waypoints;
		public State currentState;
		public State remainState;
		public bool active = true;

		[HideInInspector] public Navigator navigator;
		private float stateTimeElapsed;
		private Animator animator;

		void Awake()
		{
			//animator = GetComponent<Animator>();
			navigator = GetComponent<Navigator>();
		}

		public void TransitionToState(State nextState)
		{
			if (nextState != remainState) 
			{
				currentState = nextState;
				OnExitState ();
			}
		}

		private void Update()
		{
			if (!active) 
			{
				return;
			}
			stateTimeElapsed += Time.deltaTime;
			currentState.UpdateState(this);
		}

		public bool CheckIfCountDownElapsed(float duration)
		{
			stateTimeElapsed += Time.deltaTime;
			return (stateTimeElapsed >= duration);
		}

		public void ResetStateTimeElapsed() 
		{
			stateTimeElapsed = 0;
		}

		private void OnExitState()
		{
			ResetStateTimeElapsed();
		}
	}
}
