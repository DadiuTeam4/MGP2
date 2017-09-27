﻿// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HugoAI 
{
	[CreateAssetMenu(menuName = "HugoAI/Decisions/EventOccured")]
	public class EventOccured : Decision 
	{
		public EventName eventName;
		[Range(0.0f, 1.0f)] public float chanceOfReacting;

		private bool eventOccured;
		private UnityAction eventOccuredCallback;

		private void Start() 
		{
			eventOccuredCallback = new UnityAction(EventCallback);
			EventManager.StartListening(eventName, eventOccuredCallback);
		}

		private void EventCallback()
		{
			eventOccured = true;
		}

		public override bool Decide(StateController controller)
		{
			if (!eventOccured) 
			{
				return false;
			}

			if (chanceOfReacting == 1.0f)
			{
				return true;
			}

			float chance = 1 - chanceOfReacting;
			float reactionRoll = Random.Range(0f, 1f);
			if (reactionRoll > chance) 
			{
				return true;
			}
			else 
			{
				eventOccured = false;
				return false;
			}
		}
	}
}