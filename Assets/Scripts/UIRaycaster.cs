using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIRaycaster : MonoBehaviour {
	[HideInInspector]
	public GraphicRaycaster graphicRaycaster;
	private PointerEventData pointerEventData = new PointerEventData(null);

	void Start()
	{
		graphicRaycaster = transform.parent.GetComponent<GraphicRaycaster>();
	}

	public Vector2 GetRaycastedPositionOnCanvas()
	{
		Vector2 result = Vector2.zero;
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		pointerEventData.position = Input.mousePosition;
		graphicRaycaster.Raycast(pointerEventData, raycastResults);

		for (int i = 0; i < raycastResults.Count; i++)
		{
			if (raycastResults[i].gameObject.tag == "UIPanel")
			{
				result = raycastResults[i].screenPosition * 2;
			}
		}
		return result;
	}
}
