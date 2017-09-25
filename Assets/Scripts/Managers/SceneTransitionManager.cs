using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
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

	public void ActivateAsyncronousScene(int id)
	{
		Debug.Assert(asyncOperationArray[id] != null, "SceneTransitionManager: asyncOperation is null");
		asyncOperationArray[id].allowSceneActivation = true;
	}

	public void ChangeScene(int id)
	{
		SceneManager.LoadScene(id);
	}
}
