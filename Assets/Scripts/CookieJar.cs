//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookieJar : NumberFoundInteractable
{
    public override void OnTouchBegin()
    {

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
		EventManager.TriggerEvent(EventName.CookieJarTouched);
    }
}
