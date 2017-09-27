using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Interactable {
	private RectTransform buttonRect;
	void Awake()
	{
		buttonRect = GetComponent<RectTransform>();
	}
	
	override public void OnTouchBegin() 
	{
		Debug.Log("Hey");
	}
	override public void OnTouchHold() 
	{
		Vector2 temp = buttonRect.localPosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, Input.mousePosition, Camera.main, out temp);
		buttonRect.localPosition = temp;
	}
	override public void OnTouchReleased() 
	{

	}
}
