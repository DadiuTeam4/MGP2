// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	public abstract class Action : ScriptableObject 
	{
		public abstract void Act (StateController controller);
	}
}
