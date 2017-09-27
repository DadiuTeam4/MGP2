using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	[HideInInspector]
	public EventName eventName;
	
	private RectTransform buttonRect;
	private bool buttonHeld = false;
	private Vector3 newPos = Vector3.zero;


	void Awake()
	{
		buttonRect = GetComponent<RectTransform>();
	}

	void Update()
	{
		if (buttonHeld)
		{
			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(buttonRect, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Camera.main, out newPos))
			{
				buttonRect.localPosition =  newPos;
			}
		}
	}
	
	public void OnPointerDown()
	{
		Debug.Log("Down");
		buttonHeld = true;
	}

	public void OnPointerUp()
	{
		Debug.Log("Up");
		buttonHeld = false;
	}
}
