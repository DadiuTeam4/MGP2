using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour {
	[HideInInspector]
	public EventName eventName;
	[HideInInspector]
	public RectTransform canvasRect;
	[HideInInspector]
	public GraphicRaycaster graphicRayCaster;
	
	private PointerEventData pointerEventData = new PointerEventData(null);
	private List<RaycastResult> raycastResults = new List<RaycastResult>();
	private RectTransform buttonRect;
	private bool buttonHeld = false;


	void Awake()
	{
		buttonRect = GetComponent<RectTransform>();

	}

	void Update()
	{
		if (buttonHeld)
		{
			pointerEventData.position = Input.mousePosition;
			graphicRayCaster.Raycast(pointerEventData, raycastResults);
			for (int i = 0; i < raycastResults.Count; i++)
			{
				buttonRect.anchoredPosition = new Vector2(raycastResults[i].screenPosition.x, raycastResults[i].screenPosition.y - canvasRect.rect.height);
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
