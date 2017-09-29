// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HintSystem 
{
	[CreateAssetMenu(menuName = "HintSystem/Decisions/TimeElapsed")]
	public class TimeElapsed : Decision 
	{
		public float time;

		public override bool Decide()
		{
			return HintManager.CheckIfCountdownElapsed(this, time);
		}
	}
}