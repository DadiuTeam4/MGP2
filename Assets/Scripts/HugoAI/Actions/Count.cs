// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HugoAI
{
	[CreateAssetMenu (menuName = "HugoAI/Actions/Count")]
	public class Count : Action
	{
		public float maxHeight = 2.0f;
		public override void Act(StateController controller)
		{
			CountItem(controller);
		}

		private void CountItem(StateController controller) 
		{
			controller.animator.SetBool("counting", true);
			float worldHeight = controller.GetDestination().position.y;
			float normalizedHeight = ((worldHeight / maxHeight) * 2.0f) - 1.0f;
			Debug.Log(normalizedHeight);
			controller.animator.SetFloat("height", normalizedHeight);
		}
	}
}