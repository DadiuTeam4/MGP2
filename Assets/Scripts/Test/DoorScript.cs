using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        EventManager.StartListening("OpenDoorClicked", ChangeToKitchenScene);
	}

    void ChangeToKitchenScene()
    {
        SceneManager.LoadScene("KitchenScene");
    }

    // Update is called once per frame
    void Update () {
		
	}

	void OnMouseDown()
	{
		EventManager.TriggerEvent("doorClicked");
	}
}
