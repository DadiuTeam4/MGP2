using UnityEngine;

using System.Collections;

using UnityEditor;

using System;

using System.Collections.Generic;



public class BuildScript : MonoBehaviour

{
    private static string[] scenesNames = new[] { "Assets/Scenes/GameScenes/IntroScene.unity",
                                                  "Assets/Scenes/GameScenes/HubScene.unity", 
                                                  "Assets/Scenes/GameScenes/KitchenScene.unity" };

    [MenuItem("MyTools/Jenkins build test")]
    public static void PerformBuild()

    {

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

        buildPlayerOptions.scenes = scenesNames;

        buildPlayerOptions.locationPathName = "Builds/gameTest.apk";

        buildPlayerOptions.target = BuildTarget.Android;

        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);

    }
}