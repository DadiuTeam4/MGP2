using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UIRaycaster))]
public class MenuHoldingController : MonoBehaviour
{
	private UIRaycaster uIRaycaster;
    private bool buttonHeld;
    private Vector2 mouseOffSet;

    private float holdTime;

    void Start()
    {
        uIRaycaster = gameObject.GetComponent<UIRaycaster>();
        Rect buttonRect = gameObject.GetComponent<RectTransform>().rect;
        buttonHeld = false;
        mouseOffSet = new Vector2(buttonRect.width / 2, buttonRect.height / 2);
    }

    void Update()
    {
        if (buttonHeld)
        {
            transform.position = uIRaycaster.GetRaycastedPositionOnCanvas();
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
