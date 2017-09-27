//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{

    public void setEnglish()
    {
		Debug.Log("English");
		EventManager.TriggerEvent(EventName.LangEnglish);
    }

    public void setDanish()
    {
		Debug.Log("Danish");
		EventManager.TriggerEvent(EventName.LangDanish);
    }
}
