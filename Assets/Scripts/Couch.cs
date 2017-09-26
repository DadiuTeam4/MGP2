using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactable {

	// Use this for initialization
	void Start () {
		
	}

    public override void OnTouchBegin()
    {
        Debug.Log("Couch clicked");
        EventManager.TriggerEvent((int)EventName.NumberThreePickedUp);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
