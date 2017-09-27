// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI 
{
	[CreateAssetMenu(menuName = "HugoAI/Decisions/EventOccured")]
	public class EventOccured : Decision 
	{
		[Header("This is the index of the event in the State Controller on Hugo")]
		public int eventIndex;
		[Range(0.0f, 1.0f)] public float chanceOfReacting = 1.0f;

		private bool initialized;
		private bool eventOccured;

		public override bool Decide(StateController controller)
		{
			if (!controller.triggeredEvents[eventIndex]) 
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