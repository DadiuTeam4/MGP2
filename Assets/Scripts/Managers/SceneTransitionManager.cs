using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager> {
	AsyncOperation[] asyncOperationArray;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		asyncOperationArray = new AsyncOperation[SceneManager.sceneCount];
	}
	
	void Update ()
	{

	}

	public void LoadSceneAsynchroniously(int id)
	{
		asyncOperationArray[id] = SceneManager.LoadSceneAsync(id, LoadSceneMode.Single);
		asyncOperationArray[id].allowSceneActivation = false;
	} 

	public void ActivateAsyncronousScene(int id){
		asyncOperationArray[id].allowSceneActivation = true;
	}
}
