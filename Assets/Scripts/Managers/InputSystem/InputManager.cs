// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	private readonly List<Interactable> heldLastFrame = new List<Interactable>();
	private readonly List<Interactable> heldThisFrame = new List<Interactable>();

	#region DEBUG
	#if UNITY_EDITOR
	// MOUSE DEBUGGING
	// NOT COMPILED IN BUILDS
	bool mouseDownLastFrame;
	#endif
	#endregion


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
					TouchEnded();
					break;
				}

				case (TouchPhase.Canceled):
				{
					TouchCanceled();
					break;
				}
			}
		}
		
		#region DEBUG
		#if UNITY_EDITOR
		// MOUSE DEBUGGING
		// NOT COMPILED IN BUILDS
		if (Input.GetMouseButton(0)) 
		{
			Vector2 mousePos = Input.mousePosition;
			Interactable interactable = CastRayFromMousePos(mousePos);
			if (interactable)
			{
				heldThisFrame.Add(interactable);
				if (Input.GetMouseButtonDown(0)) 
				{
					if (!mouseDownLastFrame)
					{
						interactable.OnTouchBegin(mousePos);
						interactable.GiveTouchFeedback(mousePos);
					}
				}
			}
			mouseDownLastFrame = true;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Vector2 mousePos = Input.mousePosition;
			Interactable interactable = CastRayFromMousePos(mousePos);
			if (interactable)
			{
				interactable.OnTouchReleased();
				mouseDownLastFrame = false;
			}
		}
		#endif
		#endregion

        CallHeldObjects();
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
			interactable.OnTouchBegin(touch.position);
			interactable.GiveTouchFeedback(touch.position);
		}
	}

	private void TouchStationary(Touch touch)
	{
        Interactable interactable = CastRayFromTouch(touch);
        if (interactable)
        {
            heldThisFrame.Add(interactable);
        }
    }

	private void TouchMoved(Touch touch) 
	{
		Interactable interactable = CastRayFromTouch(touch);
		if (interactable) 
		{
			heldThisFrame.Add(interactable);
		}
	}

	private void TouchEnded() 
	{
		foreach (Interactable interactable in heldLastFrame) 
		{
			interactable.OnTouchReleased();
		}
	}

	private void TouchCanceled() 
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
		// Check if interactables are held
		foreach (Interactable interactable in heldThisFrame)
		{
			if (heldLastFrame.Contains(interactable))
			{
				interactable.timeHeld += Time.deltaTime;
				interactable.OnTouchHold();
			}
			else
			{
				interactable.timeHeld = 0;
			}
		}

		// Reset held interactables
		heldLastFrame.Clear();
		foreach (Interactable interactable in heldThisFrame) 
		{
			heldLastFrame.Add(interactable);
		}

		heldThisFrame.Clear();
	}

	#region DEBUG
	#if UNITY_EDITOR
	// MOUSE DEBUGGING
	// NOT COMPILED IN BUILDS
	private Interactable CastRayFromMousePos(Vector2 pos) 
	{
		Interactable interactableHit = null;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(pos);
		if (Physics.Raycast(ray, out hit))
		{
			interactableHit = hit.collider.GetComponent<Interactable>();
		}
		return interactableHit;
	}
	#endif
	#endregion
}
