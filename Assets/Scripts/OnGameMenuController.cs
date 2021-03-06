﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnGameMenuController : MonoBehaviour
{
    private bool isOptionPanelActive;
    public GameObject optionPanel;
	public GlobalSoundManager GSM;

    void Start()
    {
		GSM = GameObject.Find ("GlobalSoundManager").GetComponent<GlobalSoundManager>();

        EventManager.StartListening(EventName.EnableOrDisableOptionMenu, EnableOrDisableOptions);
        EventManager.StartListening(EventName.EndGame, ExitGame);
        isOptionPanelActive = false;
    }

    public void TriggerCredits()
    {
        EventManager.TriggerEvent(EventName.ShowCredits);
    }

    public void ExitGame()
    {
        Application.Quit();
		AkSoundEngine.PostEvent ("Stop_all", gameObject); 
    }

    public void RestartGame()
    {
        optionPanel.SetActive(false);
        ResourceManager.ResetState();
        SceneTransitionManager.ChangeToHubScene();
		RestartMusic (); 

    }

    public void EnableOrDisableOptions()
    {
        if (isOptionPanelActive == false)
        {
            optionPanel.SetActive(true);
            isOptionPanelActive = true;
        }
        else
        {
            optionPanel.SetActive(false);
            isOptionPanelActive = false;
        }

    }

    public void ChangeLanguage()
    {
        Debug.Log("Change language here");
    }

	private void RestartMusic()
	{
		GSM.RestartMusicHub (); 
	}



}
