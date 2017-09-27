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
    }

    public void RestartGame()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene(0);
    }

    public void EnableOrDisableOptions()
    {
        if (isOptionPanelActive == false)
        {
            Debug.Log("Enable Option Panel");
            optionPanel.SetActive(true);
            isOptionPanelActive = true;
        }
        else
        {
            Debug.Log("Disable Option Panel");
            optionPanel.SetActive(false);
            isOptionPanelActive = false;
        }

    }

    public void ChangeLanguage()
    {
        Debug.Log("Change language here");
    }

}
