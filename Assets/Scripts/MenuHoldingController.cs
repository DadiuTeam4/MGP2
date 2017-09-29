using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuHoldingController : MonoBehaviour
{
    private bool buttonHeld;
    private Vector2 mouseOffSet;

    void Start()
    {
        Rect buttonRect = gameObject.GetComponent<RectTransform>().rect;
        buttonHeld = false;
        mouseOffSet = new Vector2(buttonRect.width / 2, buttonRect.height / 2);
    }

    void Update()
    {
        if (buttonHeld)
        {
            transform.position = new Vector2(Input.mousePosition.x + mouseOffSet.x, Input.mousePosition.y + mouseOffSet.y);
        }   
    }

    public void ButonClicked()
    {
        buttonHeld = true;
    }

    public void ButonReleased()
    {
        buttonHeld = false;
    }

}
