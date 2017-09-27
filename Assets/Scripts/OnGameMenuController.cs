using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnGameMenuController : MonoBehaviour
{

    public GameObject optionPanel;
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

    public void ShowOptions()
    {
		if(optionPanel == null)
		{
			Debug.Log("The option panel is null");
		}
        optionPanel.SetActive(true);
    }
}
