// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HintSystem
{
	public class HintManager : MonoBehaviour 
	{
		public Trigger[] triggers;

		private static Dictionary<Decision, float> timers;
		private static Dictionary<Decision, float> tempTimers;

		void Start()
		{
			timers = new Dictionary<Decision, float>();
			tempTimers = new Dictionary<Decision, float>();
		}

		void Update()
		{
			UpdateTimers();
			DetermineTriggers();
		}

		private void UpdateTimers()
		{
			tempTimers = timers;
			foreach (Decision decision in timers.Keys)
			{
				tempTimers[decision] += Time.deltaTime;
			}
			timers = tempTimers;
		}

		private void DetermineTriggers()
		{
			foreach (Trigger trigger in triggers)
			{
				bool triggers = true;
				foreach (Decision decision in trigger.decisions)
				{
					if (!decision.Decide())
					{
						triggers = false;
					}
				}
				if (triggers)
				{
					trigger.hint.CreateHint();
				}
			}
		}

		public static bool CheckIfCountdownElapsed(Decision decision, float time)
		{
			float timer;
			if (timers.TryGetValue(decision, out timer))
			{
				return time >= timer;
			}
			else
			{
				timers.Add(decision, 0.0f);
				return false;
			}
		}
	}
}
