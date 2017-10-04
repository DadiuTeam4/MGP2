using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public enum Scene
{
    Hub = 0,
    Kitchen = 1
}

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    private UnityAction sceneTriggerListener;
    public static Scene currentScene = Scene.Hub;
 
    void Start()
    {
        EventManager.StartListening(EventName.HubDoorClicked, ChangeToKitchenScene);

		EventManager.StartListening(EventName.KitchenDoorClicked, ChangeToHubScene);

        EventManager.StartListening(EventName.LanguageSelected, ChangeToHubScene);

        
	}

    public static void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("KitchenScene");
        EventManager.TriggerEvent(EventName.KitchenSceneLoaded);
        currentScene = Scene.Kitchen;
    }

	public static void ChangeToHubScene()
    {
        SceneManager.LoadScene("HubScene");
        EventManager.TriggerEvent(EventName.HubSceneLoaded);
        currentScene = Scene.Hub;
    }
}
