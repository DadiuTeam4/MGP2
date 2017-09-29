// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HintSystem
{
	[System.Serializable]
	public class Trigger 
	{
		public Decision[] decisions;
		public Hint hint;
	}
}