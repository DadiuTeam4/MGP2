// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	private List<Interactable> heldLastFrame = new List<Interactable>();
	private List<Interactable> heldThisFrame = new List<Interactable>();

	#region UPDATE_LOOP
	private void Update() 
	{
		// Resolve all touches
		Touch[] touches = GetTouches();
		foreach (Touch touch in touches) 
		{
			switch (touch.phase) 
			{
				case (TouchPhase.Began):
				{
					TouchBegan(touch);
					break;
				}

				case (TouchPhase.Stationary):
				{
					TouchStationary(touch);
					break;
				}

				case (TouchPhase.Moved):
				{
					TouchMoved(touch);
					break;
				}

				case (TouchPhase.Ended):
				{
					TouchEnded(touch);
					break;
				}

				case (TouchPhase.Canceled):
				{
					TouchCanceled(touch);
					break;
				}
			}
		}
		heldLastFrame = heldThisFrame;
		heldThisFrame.Clear();
	}
	#endregion

	private Touch[] GetTouches() 
	{
		Touch[] touches = new Touch[Input.touchCount];
		for (int i = 0; i < Input.touchCount; i++) 
		{
			touches[i] = Input.GetTouch(i);
		}
		return touches;
	}

	private void TouchBegan(Touch touch) 
	{
		Interactable interactable = CastRayFromTouch(touch);
		if (interactable) 
		{
			interactable.OnTouchBegin();
		}
	}

	private void TouchStationary(Touch touch)
	{
		heldThisFrame = heldLastFrame;
	}

	private void TouchMoved(Touch touch) 
	{
		Interactable interactable = CastRayFromTouch(touch);
		if (interactable) 
		{
			heldThisFrame.Add(interactable);
		}
	}

	private void TouchEnded(Touch touch) 
	{
		foreach (Interactable interactable in heldLastFrame) 
		{
			interactable.OnTouchReleased();
		}
	}

	private void TouchCanceled(Touch touch) 
	{
		foreach (Interactable interactable in heldLastFrame) 
		{
			interactable.OnTouchReleased();
		}
	}

	private Interactable CastRayFromTouch(Touch touch)
	{
		Interactable interactableHit = null;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(touch.position);
		if (Physics.Raycast(ray, out hit)) 
		{
			interactableHit = hit.collider.GetComponent<Interactable>();
		}
		return interactableHit;
	}

	private void CallHeldObjects()
	{
		foreach (Interactable interactable in heldLastFrame) 
		{
			if (heldThisFrame.Contains(interactable)) 
			{
				interactable.timeHeld += Time.deltaTime;
				interactable.OnTouchHold();
			}
		}
	}

	#region DEBUG
	#if UNITY_EDITOR
	private void Awake() 
	{
		// Check that all interactables have been referenced
		CheckForMissingInteractables();
	}
	private void CheckForMissingInteractables()
	{
		Interactable[] missingInteractables = FindObjectsOfType(typeof(Interactable)) as Interactable[];
		foreach (Interactable interactable in missingInteractables) 
		{
			// if (!interactables.Contains(interactable)) 
			// {
			// 	print("Interactable \"" + interactable.name + "\" not referenced in editor");
			// }
		}
	}
	#endif
	#endregion
}
