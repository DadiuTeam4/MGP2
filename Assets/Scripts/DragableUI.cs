using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class DragableUI : MonoBehaviour {

	private bool buttonHeld;
	private Vector2 mouseInCanvasPosition;
	private RectTransform canvasRect;
	private RectTransform uiRect;

	void Start()
	{
		canvasRect = transform.parent.GetComponent<RectTransform>();
		uiRect = transform.GetComponent<RectTransform>();
	}

	void Update () 
	{
		if(buttonHeld)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, Camera.main, out mouseInCanvasPosition);
			uiRect.localPosition = mouseInCanvasPosition;
		}
	}

	public void OnPointerDown()
	{
		buttonHeld = true;
	}

	public void OnPointerUp()
	{
		buttonHeld = false;
	}
}
