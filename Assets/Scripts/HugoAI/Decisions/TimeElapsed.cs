﻿// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HugoAI 
{
	[CreateAssetMenu(menuName = "HugoAI/Decisions/TimeElapsed")]
	public class TimeElapsed : Decision 
	{
		public float time;
		[Range(0.0f, 1.0f)] public float chanceOfReacting;

		private bool timerStarted;
		private bool timeElapsed;

		public override bool Decide(StateController controller)
		{
			if (!controller.CheckIfCountDownElapsed(time)) 
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
				time += time;
				return false;
			}
		}
	}
}