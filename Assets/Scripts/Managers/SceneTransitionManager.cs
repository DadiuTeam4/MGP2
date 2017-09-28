using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    private UnityAction sceneTriggerListener;

 
    void Start()
    {
        EventManager.StartListening(EventName.HubDoorClicked, ChangeToKitchenScene);

		EventManager.StartListening(EventName.KitchenDoorClicked, ChangeToHubScene);

        EventManager.StartListening(EventName.LanguageSelected, ChangeToHubScene);
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
