//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public void SetEnglish()
    {
      Debug.Log("English");
      EventManager.TriggerEvent(EventName.LangEnglish);
      AkSoundEngine.SetState ("Language", "English"); 
    }

    public void SetDanish()
    {
      Debug.Log("Danish");
      EventManager.TriggerEvent(EventName.LangDanish);
      AkSoundEngine.SetState ("Language", "Dansk"); 
    }
}
