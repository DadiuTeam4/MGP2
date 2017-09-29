// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HintSystem
{
	[CreateAssetMenu(menuName = "HintSystem/Hints/DebugHint")]
	public class DebugHint : Hint 
	{
		public string message;

		public override void CreateHint()
		{
			Debug.Log(message);
		}
	}
}
