//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        EventManager.StartListening(EventName.LangEnglish, StartGame);
        EventManager.StartListening(EventName.LangDanish, StartGame);
    }
    private void StartGame()
    {
		Debug.Log("Game Should Start Now");
		EventManager.TriggerEvent(EventName.LanguageSelected);
    }

}
