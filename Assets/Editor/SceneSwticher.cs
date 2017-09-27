using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwticher : MonoBehaviour
{
    [MenuItem("MyTools/SceneSwticher/IntroScene")]
    static void IntroScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/IntroScene.unity");
    }

	[MenuItem("MyTools/SceneSwticher/HubScene")]
    static void HubScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/HubScene.unity");
    }

	[MenuItem("MyTools/SceneSwticher/KitchenScene")]
    static void KitchenScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/KitchenScene.unity");
    }

}