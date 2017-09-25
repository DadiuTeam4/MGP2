// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	[SerializeField]
	private List<Interactable> interactables;
	private void Update() 
	{
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
	}

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
		EventManager.Instance.AddListener();
	}

	private void TouchStationary(Touch touch)
	{

	}

	private void TouchMoved(Touch touch) 
	{

	}

	private void TouchEnded(Touch touch) 
	{
		
	}

	private void TouchCanceled(Touch touch) 
	{

	}

	private Interactable CastRayFromTouch(Touch touch)
	{
		Interactable interactableHit = null;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(touch.position);
		if (Physics.Raycast(ray, out hit)) 
		{
			interactableHit = GetComponent<Interactable>();
		}
		return interactableHit;
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
			if (!interactables.Contains(interactable)) 
			{
				print("Interactable \"" + interactable.name + "\" not referenced in editor");
			}
		}
	}
	#endif
	#endregion
}
