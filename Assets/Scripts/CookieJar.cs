//Author: UUUUU
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieJar : Interactable
{
    public override void OnTouchBegin()
    {
		Debug.Log("CookieJar Cliked");
		EventManager.TriggerEvent((int)EventName.CookieJarTouched);
    }
}
