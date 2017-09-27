using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameMenuController : MonoBehaviour {
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
}
