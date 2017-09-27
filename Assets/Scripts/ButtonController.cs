using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	[HideInInspector]
	public EventName eventName;
	
	private RectTransform canvasRect;
	private RectTransform buttonRect;
	private bool buttonHeld = false;
	private Vector2 newPos = Vector2.zero;


	void Awake()
	{
		buttonRect = GetComponent<RectTransform>();
		canvasRect = transform.GetComponentInParent<RectTransform>();
	}

	void Update()
	{
		if (buttonHeld)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, null, out newPos))
			{
				buttonRect.anchoredPosition =  newPos;
			}
		}
	}
	
	public void OnPointerDown()
	{
        //EventManager.TriggerEvent(eventName);
		buttonHeld = true;
	}

	public void OnPointerUp()
	{
		buttonHeld = false;
	}
}
