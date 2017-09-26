using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
	private UnityAction sceneTriggerListener;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start () 
	{
        EventManager.StartListening(EventName.KitchenDoorClicked, ChangeToKitchenScene);
		Debug.Log("Should change to KitchenScenenow!");
	}
	
	void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("KitchenScene");
    }
}
