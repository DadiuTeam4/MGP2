using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [MenuItem("MyTools/SceneSwitcher/IntroScene")]
    static void IntroScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/IntroScene.unity");
    }

	[MenuItem("MyTools/SceneSwitcher/HubScene")]
    static void HubScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/HubScene.unity");
    }

	[MenuItem("MyTools/SceneSwitcher/KitchenScene")]
    static void KitchenScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/KitchenScene.unity");
    }

}