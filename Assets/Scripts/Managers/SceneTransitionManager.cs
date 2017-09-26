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
        EventManager.StartListening(EventName.HubDoorClicked, ChangeToKitchenScene);
		Debug.Log("Should change to KitchenScene now!");

		EventManager.StartListening(EventName.KitchenDoorClicked, ChangeToHubScene);
	}
	
	void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("KitchenScene");
        EventManager.TriggerEvent(EventName.KitchenSceneLoaded);
    }

	void ChangeToHubScene()
    {
        SceneManager.LoadScene("HubScene");
        EventManager.TriggerEvent(EventName.HubSceneLoaded);
    }
}
