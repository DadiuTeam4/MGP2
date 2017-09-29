// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HintSystem
{
	public abstract class Decision : ScriptableObject
	{
		public abstract bool Decide();
	}
}
