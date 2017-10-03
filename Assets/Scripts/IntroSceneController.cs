//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneController : MonoBehaviour
{
    void Start()
    {
        EventManager.StartListening(EventName.StartGame, StartGame);
    }

    private void StartGame()
    {
		Debug.Log("Game Should Start Now");
		EventManager.TriggerEvent(EventName.LanguageSelected);
    }
}
