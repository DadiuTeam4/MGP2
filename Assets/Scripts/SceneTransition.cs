using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        EventManager.StartListening("OpenDoorClicked", ChangeToKitchenScene);
	}

    void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("KitchenScene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
