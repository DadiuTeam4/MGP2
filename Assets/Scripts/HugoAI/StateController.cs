// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HugoAI 
{
	[RequireComponent(typeof(Navigator))]
	public class StateController : MonoBehaviour 
	{
		public Transform[] idleWaypoints;
		[Header("Sequence of events will directly map to the sequence of the purpose waypoints below.")]
		public EventName[] numberEvents;
		public Transform[] purposeWaypoints;
		public State currentState;
		public bool active = true;

		[HideInInspector] public Navigator navigator;
		[HideInInspector] public Animator animator;
		[HideInInspector] public bool[] triggeredEvents;

		private State previousState;
		private float stateTimeElapsed;
		private int eventNumber;
		private UnityAction<int>[] eventOccurredCallbacks;

		private void Awake()
		{
			//animator = GetComponent<Animator>();
			navigator = GetComponent<Navigator>();
		}

		private void Start()
		{
			triggeredEvents = new bool[numberEvents.Length];
			eventOccurredCallbacks = new UnityAction<int>[numberEvents.Length];
			for (int i = 0; i < numberEvents.Length; i++) 
			{
				UnityAction<int> action = EventCallback;
				eventOccurredCallbacks[i] = action;
				EventManager.StartListening(numberEvents[i], action, i);
			}
		}

		private void EventCallback(int number)
		{
			triggeredEvents[number] = true;
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
