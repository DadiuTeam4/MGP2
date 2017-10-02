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
    private RectTransform buttonRect;

    private float holdTime;

    void Start()
    {
        buttonHeld = false;
        uIRaycaster = gameObject.GetComponent<UIRaycaster>();
        buttonRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (buttonHeld)
        {
            buttonRect.anchoredPosition = uIRaycaster.GetRaycastedPositionOnCanvas();
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
