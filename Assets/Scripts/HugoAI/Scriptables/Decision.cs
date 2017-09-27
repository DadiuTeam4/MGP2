// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	public abstract class Decision : ScriptableObject
	{
		public abstract bool Decide(StateController controller);
	}
}
