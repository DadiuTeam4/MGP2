using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuHoldingController : MonoBehaviour
{
    private bool buttonHeld;
    private Vector2 mouseOffSet;
    private RectTransform buttonRect;
    private Vector2 mouseInCanvasPosition;
    private RectTransform canvasRect;

    private float holdTime;

    void Start()
    {
        buttonHeld = false;
        canvasRect = transform.parent.GetComponent<RectTransform>();
        buttonRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (buttonHeld)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, Camera.main, out mouseInCanvasPosition);
			buttonRect.localPosition = mouseInCanvasPosition;
        }
    }

    public void ButonClicked()
    {
        holdTime = Time.time;
        buttonHeld = true;
    }

    public void ButonReleased()
    {
        buttonHeld = false;
        if (Time.time > holdTime + 0.5f)
        {
            EventManager.TriggerEvent(EventName.EnableOrDisableOptionMenu);
        }
    }

}
