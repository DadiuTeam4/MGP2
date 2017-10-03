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
		[HideInInspector] public Dictionary<EventName, bool> triggeredEvents;
		[HideInInspector] public Transform currentNumberWaypoint;

		private Dictionary<int, EventName> eventIndexes;
		private State previousState;
		private float stateTimeElapsed;
		private int eventNumber;
		private UnityAction<int>[] eventOccurredCallbacks;

		#region DEBUG
		#if UNITY_EDITOR
		public bool aiDebugging = false;
		[HideInInspector] public string debugInfo;
		#endif
		#endregion

		private void Awake()
		{ 
			animator = GetComponent<Animator>();
			navigator = GetComponent<Navigator>();
		}

		private void Start()
		{
			triggeredEvents = new Dictionary<EventName, bool>();
			eventIndexes = new Dictionary<int, EventName>();
			eventOccurredCallbacks = new UnityAction<int>[numberEvents.Length];
			for (int i = 0; i < numberEvents.Length; i++) 
			{
				triggeredEvents.Add(numberEvents[i], false);
				eventIndexes.Add(i, numberEvents[i]);

				UnityAction<int> action = EventCallback;
				eventOccurredCallbacks[i] = action;
				EventManager.StartListening(numberEvents[i], action, i);
			}
			string breakPoint;
		}

		public bool CheckEventOccured(EventName eventName) 
		{
			bool eventOccured = triggeredEvents[eventName];
			triggeredEvents[eventName] = false; 
			return eventOccured;
		}

		private void EventCallback(int number)
		{
			EventName triggeredEvent;
			if (eventIndexes.TryGetValue(number, out triggeredEvent))
			{
				bool eventValue;
				if (triggeredEvents.TryGetValue(triggeredEvent, out eventValue)) 
				{
					triggeredEvents[eventIndexes[number]] = true;
				}
				else 
				{
					print("Event " + triggeredEvent + " does not exist");
				}
			}
			else 
			{
				print("Event number " + number + " does not exist");
			}
			if (triggeredEvent != EventName.InteractableClicked && triggeredEvent != EventName.NumberPickedUp)
			{
				currentNumberWaypoint = purposeWaypoints[number];
			}
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
			#region DEBUG
			#if UNITY_EDITOR
			debugInfo = "";
			UpdateDebugInfo();
			#endif
			#endregion
			animator.speed = navigator.GetSpeed();
			currentState.UpdateState(this);
		}

		public bool CheckIfCountDownElapsed(float duration)
		{
			stateTimeElapsed += Time.deltaTime;
			return stateTimeElapsed >= duration;
		}

		public void ResetStateTimer() 
		{
			stateTimeElapsed = 0;
		}

		private void OnExitState()
		{
			ResetStateTimer();
		}

		#region DEBUG
		#if UNITY_EDITOR
		private void UpdateDebugInfo()
		{
			debugInfo += ("State time elapsed:\t" + stateTimeElapsed + "\n");
			debugInfo += ("Current state:\t" + currentState.name + "\n");
			debugInfo += ("Current waypoint:\t" + navigator.GetDestination() + "\n");
			debugInfo += ("Current number waypoint:\t" + currentNumberWaypoint + "\n");
			debugInfo += ("\nTriggered events:\n");
			foreach (EventName eventName in numberEvents)
			{
				debugInfo += eventName + ": " + triggeredEvents[eventName] + "\n";
			}
		}

		void OnGUI()
		{
			if (aiDebugging)
			{
				GUI.Box(new Rect(0, 0, Screen.width, Screen.height), debugInfo, "");
			}
		}
		#endif
		#endregion
	}
}
