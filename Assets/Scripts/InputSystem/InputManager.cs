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
				print("Interactable \" + " + interactable.gameObject.name + " + \" not referenced in editor");
			}
		}
	}
	#endif
	#endregion
}
