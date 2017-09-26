// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HugoAI 
{
	[CreateAssetMenu(menuName = "HugoAI/Decisions/React")]
	public class ReactDecision : Decision 
	{
		[Range(0.0f, 1.0f)] public float chanceOfReacting; 

		private bool interactableWasTapped;
		private UnityAction interactableWasTappedCallback;

		private void Start() 
		{
			interactableWasTappedCallback = new UnityAction(InteractableWasTapped);
			EventManager.StartListening(EventName.InteractableWasClicked, interactableWasTappedCallback);
		}

		private void InteractableWasTapped() 
		{
			interactableWasTapped = true;
		}

		public override bool Decide(StateController controller)
		{
			if (!interactableWasTapped) 
			{
				return false;
			}

			float chance = 1 - chanceOfReacting;
			float reactionRoll = Random.Range(0f, 1f);
			if (reactionRoll > chance) 
			{
				return true;
			}
			else 
			{
				interactableWasTapped = false;
				return false;
			}
		}
	}
}