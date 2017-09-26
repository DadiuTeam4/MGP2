// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[System.Serializable]
	public class Transition 
	{
		public Decision decision;
		public State trueState;
		public State falseState;
	}
}
