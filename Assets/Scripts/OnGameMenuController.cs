using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnGameMenuController : MonoBehaviour
{
    private bool isOptionPanelActive;
    public GameObject optionPanel;

    void Start()
    {
        isOptionPanelActive = false;
    }
    public void ExitGame()
    {
        Debug.Log("Exit the game");
        Application.Quit();
		AkSoundEngine.PostEvent ("Stop_all", gameObject); 
    }

    public void RestartGame()
    {
        optionPanel.SetActive(false);
        SceneManager.LoadScene(0);
		AkSoundEngine.PostEvent ("Stop_all", gameObject); 
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

}
