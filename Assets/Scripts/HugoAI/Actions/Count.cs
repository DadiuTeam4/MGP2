﻿// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/Count")]
	public class Count : Action
	{
		public Animation countingAnimation;

		public override void Act(StateController controller)
		{
			CountItem(controller);
		}

		private void CountItem(StateController controller) 
		{
			// Set and start animation
		}
	}
}