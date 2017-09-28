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
	private bool buttonHeld;
	private bool active;
	private Vector3 originalPosition;
	public Collider targetCollider;
	private string currentScene;
	private string nameOfSceneThatHugoCanCount = "HubScene";

	void Start()
	{
		buttonRect = GetComponent<RectTransform>();
		GameObject targetGameObject;
		targetGameObject = GameObject.Find("Hugo");
		targetCollider = targetGameObject.GetComponent<Collider>();
		//getcomponent<collider>();

		currentScene = ResourceManager.GetCurrentSceneName();

	}



	void Update()
	{
		if (buttonHeld && active)
		{
			pointerEventData.position = Input.mousePosition;
			graphicRayCaster.Raycast(pointerEventData, raycastResults);
			for (int i = 0; i < raycastResults.Count; i++)
			{
				buttonRect.anchoredPosition = new Vector2(raycastResults[i].screenPosition.x, raycastResults[i].screenPosition.y - canvasRect.rect.height);
			}

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (targetCollider.Raycast(ray, out hit, 100.0F))
			{
				if (currentScene == nameOfSceneThatHugoCanCount)
				{
					active = false;
					buttonRect.localPosition = originalPosition;
					var color = GetComponent<Image> ().color;
					color = Color.red;
					GetComponent<Image> ().color = color;
					EventManager.TriggerEvent(eventName);
				}
				else
				{
					print(" Hey! Let me count it for grandma");
				}


			}

		}
	}
	
	public void OnPointerDown()
	{
		if (active)
		{
			buttonHeld = true;
		}
        
	}

	public void SetOriginalPosition(Vector3 localOriginalPosition)
	{
		originalPosition = localOriginalPosition;
	}
	public void SetActiveBool(bool myState)
	{
		active = myState;
		if (!active)
		{
			var color = GetComponent<Image> ().color;
			color = Color.red;
			GetComponent<Image> ().color = color;
		}
	}
	public void OnPointerUp()
	{
		buttonHeld = false;
		buttonRect.localPosition = originalPosition;
	}
}
